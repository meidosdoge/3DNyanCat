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
    public Animator fade;
    
    private GameObject objetivoMovimenta;
    public bool movimenta = false;

    //adicione eventos aqui

    public void PrimeiroAndar ()
    {
        //leva pro primeiroAndar

        //coroutine pra abrir o elevador e fazer a transição, leva como argumentos:
        //tempo, ponto central do elevador atual, ponto central do elevador destino, cenário ligando, cenário desligando, spawn
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

        //liga o próximo ambiente e abre os elevadores
        objAtivar.SetActive(true);
        animElevadorTerreo.SetBool("AbreElevador", true);
        animElevadorApto.SetBool("AbreElevador", true);
        yield return new WaitForSeconds(waitTime);

        //move o player pro próximo local
        objetivoMovimenta = elevadorEntrada;
        movimenta = true;
        yield return new WaitForSeconds(waitTime);

        //fade tapando câmera
        fade.SetBool("Fade", true);

        //fecha elevadores e espera pra transportar o player
        animElevadorApto.SetBool("AbreElevador", false);
        animElevadorTerreo.SetBool("AbreElevador", false);
        yield return new WaitForSeconds(waitTime);

        //move o player pro elevador, desativa o ambiente anterior
        player.transform.position = elevadorSaida.transform.position;
        player.transform.LookAt(spawnPoint.transform.position);
        objDesativar.SetActive(false);

        //abre o elevador
        animElevadorTerreo.SetBool("AbreElevador", true);
        animElevadorApto.SetBool("AbreElevador", true);
        yield return new WaitForSeconds(waitTime);

        //tira o fade tapando a câmera
        fade.SetBool("Fade", false);

        //move o player pra fora do elevador
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
        //player não tá andando, então faço isso pra manter a animação de walk
        EstadosPlayer.estadoMovimentacao = "andando";

        //setta o objetivo de movimentação usando a posição do objeto e a altura do player
        Vector3 objetivo = new Vector3 (finalPoint.transform.position.x, player.transform.position.y, finalPoint.transform.position.z);

        //move o player pro objeto
        player.transform.position = Vector3.MoveTowards(player.transform.position, objetivo, 0.1f);

        //se o jogador chegou no lugar, termina a movimentação
        if(Vector3.Distance(player.transform.position, objetivo) < 0.1f)
        {
            EstadosPlayer.estadoMovimentacao = "idle";
            movimenta = false;
        }
    }
}    
    
/*música dentro do elevador
som quando clica
som quando chega*/