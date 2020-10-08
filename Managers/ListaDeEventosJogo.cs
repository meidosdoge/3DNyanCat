using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDeEventosJogo : MonoBehaviour
{
    //todos os objetos necessarios são colocados aqui
    public GameObject player, primeiroAndarSpawn, terreoSpawn;
    public GameObject objPrimeiroAndar, objTerreo;
    public GameObject cameraAp1;

    public GameObject elevadorApto, elevadorTerreo;
    public Animator animElevadorApto, animElevadorTerreo;
    public bool movimenta = false;
    private GameObject objetivoMovimenta;


    //adicione eventos aqui

    public void PrimeiroAndar ()
    {
        //leva pro primeiroAndar

        //coroutine pra abrir o elevador e fazer a transição, leva como argumentos:
        //tempo, elevador atual, elevador destino, cenário que vai ligar, cenário que vai desligar, lugar de spawn
        StartCoroutine(Elevador(1f, elevadorTerreo, elevadorApto, objPrimeiroAndar, objTerreo, primeiroAndarSpawn));
        
        cameraAp1.SetActive(true);
    }

    public void Terreo()
    {
        //leva pro terreo
        StartCoroutine(Elevador(1f, elevadorApto, elevadorTerreo, objTerreo, objPrimeiroAndar, terreoSpawn));
    }
    


    //grande "cutscene" do elevador feita de jeito burro com muitas tarefas e waits, im sorry
    void Update()
    {
        //checa se o player se movimentou pra onde deve
        if(movimenta)
            MoveToPoint(objetivoMovimenta);
    }
    
    //entra e sai do elevador
    public IEnumerator Elevador(float waitTime, GameObject elevadorEntrada, GameObject elevadorSaida,
    GameObject objAtivar, GameObject objDesativar, GameObject spawnPoint)
    {
        //desativa skills e movimento, vira o player pro elevador
        PegaEventoParaExecutar.desativaCheirar();
        DesativaMovPlayer.desMov.DesativaMov();
        player.transform.LookAt(elevadorEntrada.transform.position);

        //abre os elevadores e liga o próximo ambiente
        objAtivar.SetActive(true);
        animElevadorTerreo.SetBool("AbreElevador", true);
        animElevadorApto.SetBool("AbreElevador", true);
        yield return new WaitForSeconds(waitTime);

        //move o player pro próximo local
        objetivoMovimenta = elevadorEntrada;
        movimenta = true;
        yield return new WaitForSeconds(waitTime);

        //fade na câmra

        //fecha elevadores e espera pra transportar o player
        animElevadorApto.SetBool("AbreElevador", false);
        animElevadorTerreo.SetBool("AbreElevador", false);
        yield return new WaitForSeconds(waitTime);

        //move o player, desativa o ambiente anterior
        player.transform.position = elevadorSaida.transform.position;
        player.transform.LookAt(spawnPoint.transform.position);
        objDesativar.SetActive(false);

        //volta a câmera e abre o elevador
        animElevadorTerreo.SetBool("AbreElevador", true);
        animElevadorApto.SetBool("AbreElevador", true);
        yield return new WaitForSeconds(waitTime);

        //move o player pro próximo local
        objetivoMovimenta = spawnPoint;
        movimenta = true;
        yield return new WaitForSeconds(waitTime);

        //fecha o elevador
        animElevadorApto.SetBool("AbreElevador", false);
        animElevadorTerreo.SetBool("AbreElevador", false);
        yield return new WaitForSeconds(1.5f);

        //libera o player da "cutscene"
        DesativaMovPlayer.desMov.AtivaMov();
    }

    void MoveToPoint(GameObject finalPoint)
    {
        //player tá trancado mas isso mantém a animação de walk
        EstadosPlayer.estadoMovimentacao = "andando";

        //setta o objetivo de movimentação usando a posição do objeto e a altura do player
        Vector3 objetivo = new Vector3 (finalPoint.transform.position.x, player.transform.position.y, finalPoint.transform.position.z);

        //move o player pro objetivo
        player.transform.position = Vector3.MoveTowards(player.transform.position, objetivo, 0.1f);

        //se o jogador chegou no lugar, volta a movimentação
        if(Vector3.Distance(player.transform.position, objetivo) < 0.1f)
        {
            EstadosPlayer.estadoMovimentacao = "idle";
            movimenta = false;
        }
    }
}    
    /*quando o dog entra, rola um fade
    aparece de novo na câmera lá em cima com as portas abrindo

    música dentro do elevador
    som quando clica
    som quando chega*/