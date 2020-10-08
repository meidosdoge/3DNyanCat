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

    public Animator animElevador;

    public void PrimeiroAndar ()
    {
        player.transform.position = primeiroAndarSpawn.transform.position;
        animElevador.SetBool("AbreElevador", true);
        
        cameraAp1.SetActive(true);
        objPrimeiroAndar.SetActive(true);
        objTerreo.SetActive(false);
        
        PegaEventoParaExecutar.desativaCheirar();
    }

    public void Terreo()
    {
        player.transform.position = terreoSpawn.transform.position;
        animElevador.SetBool("AbreElevador", false);

        objPrimeiroAndar.SetActive(false);
        objTerreo.SetActive(true);

        PegaEventoParaExecutar.desativaCheirar();
    }
}
