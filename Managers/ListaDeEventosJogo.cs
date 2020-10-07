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

    public Animator animElevadorApto, animElevadorTerreo;

    public void PrimeiroAndar ()
    {
        //coroutine pra abrir o elevador e fazer a transição, leva como argumentos:
        //quanto tempo leva, cenário que vai ligar, cenário que vai desligar, lugar de spawn
        StartCoroutine(Elevador(2f, objPrimeiroAndar, objTerreo, primeiroAndarSpawn));
        
        cameraAp1.SetActive(true);
    }

    public void Terreo()
    {
        StartCoroutine(Elevador(2f, objTerreo, objPrimeiroAndar, terreoSpawn));
    }

    public IEnumerator Elevador(float waitTime,
    GameObject objAtivar, GameObject objDesativar, GameObject spawnPoint)
    {
        //abre os elevadores e liga o próximo ambiente
        objAtivar.SetActive(true);
        animElevadorTerreo.SetBool("AbreElevador", true);
        animElevadorApto.SetBool("AbreElevador", true);
        
        yield return new WaitForSeconds(waitTime);

        //fecha os elevadores
        animElevadorApto.SetBool("AbreElevador", false);
        animElevadorTerreo.SetBool("AbreElevador", false);

        //move o player, desativa o ambiente anterior
        player.transform.position = spawnPoint.transform.position;
        objDesativar.SetActive(false);
        PegaEventoParaExecutar.desativaCheirar();
    }
}
