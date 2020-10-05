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

    public void PrimeiroAndar ()
    {
        //objPrimeiroAndar.SetActive(true);
        //if (objPrimeiroAndar.activeSelf)
            player.transform.position = primeiroAndarSpawn.transform.position;
        cameraAp1.SetActive(true);
        //if (player.transform.position == primeiroAndarSpawn.transform.position)
            //objTerreo.SetActive(false);
    }

    public void Terreo()
    {
        //objTerreo.SetActive(true);
        //if (objTerreo.activeSelf)
            player.transform.position = terreoSpawn.transform.position;
        //cameraAp1.SetActive(false);
        //if (player.transform.position == terreoSpawn.transform.position)
           //objPrimeiroAndar.SetActive(false);
    }
}
