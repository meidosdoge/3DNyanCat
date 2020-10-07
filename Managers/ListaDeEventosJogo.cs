using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDeEventosJogo : MonoBehaviour
{
    //tava dando merda em algumas coisas, ai decidi fazer literalmente um metodo pra cada evento do jogo,
    //como dar tp entre um ap e outro (que é o que ta rolando)

    //todos os objetos necessarios são colocados ai
    public GameObject player, primeiroAndarSpawn, terreoSpawn;
    public GameObject objPrimeiroAndar, objTerreo;
    public GameObject cameraAp1;

    public GameObject elevadorApto, elevadorTerreo;
    public Animator animElevadorApto, animElevadorTerreo;


    public void PrimeiroAndar ()
    {
        //coroutine pra abrir o elevador e fazer a transição, leva como argumentos:
        //tempo, elevador atual, cenário que vai ligar, cenário que vai desligar, lugar de spawn
        StartCoroutine(Elevador(2f, elevadorTerreo, objPrimeiroAndar, objTerreo, primeiroAndarSpawn));
        
        cameraAp1.SetActive(true);
    }

    public void Terreo()
    {
        StartCoroutine(Elevador(2f, elevadorApto, objTerreo, objPrimeiroAndar, terreoSpawn));
    }


    public IEnumerator Elevador(float waitTime, GameObject elevadorEntrada,
    GameObject objAtivar, GameObject objDesativar, GameObject spawnPoint)
    {
        //abre os elevadores e liga o próximo ambiente
        objAtivar.SetActive(true);
        animElevadorTerreo.SetBool("AbreElevador", true);
        animElevadorApto.SetBool("AbreElevador", true);
        
        yield return new WaitForSeconds(waitTime);

        MoveToPoint(elevadorEntrada);

        yield return new WaitForSeconds(waitTime);

        //fecha os elevadores
        animElevadorApto.SetBool("AbreElevador", false);
        animElevadorTerreo.SetBool("AbreElevador", false);

        //move o player, desativa o ambiente anterior
        player.transform.position = spawnPoint.transform.position;
        objDesativar.SetActive(false);
        PegaEventoParaExecutar.desativaCheirar();
    }


    void MoveToPoint(GameObject finalPoint)
    {
        //setta o objetivo de movimentação usando a posição do objeto e a altura do player
        Vector3 objetivo = new Vector3 (finalPoint.transform.position.x, player.transform.position.y, finalPoint.transform.position.z);

        //tranca o jogador mas mantém a animação de walk
        DesativaMovPlayer.desMov.DesativaMov();
        EstadosPlayer.estadoMovimentacao = "andando";

        //move o player pra dentro do elevador
        player.transform.position = Vector3.MoveTowards(player.transform.position, objetivo, 0.25f);

        //se o jogador chegou no lugar, volta a movimentação
        if(Vector3.Distance(player.transform.position, objetivo) < 0.1f)
        {
            print("alo");
            EstadosPlayer.estadoMovimentacao = "idle";
            DesativaMovPlayer.desMov.AtivaMov();
        }
    }
}
