using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sound;

    //aqui eu chamo todos os sons que dá pra chamar sem influência de outros objetos
    //sons que não estão aqui: ações do player, npc

    public GameObject ambiente, pause;
    public GameObject elevador;

    public GameObject misturaCheiro;

    public GameObject vozNPC;

    public void Ambiente()
    {
        //sons no início do jogo
        ambiente.SetActive(true);
        pause.SetActive(false);
    }

    public void Elevador()
    {
        //excuta som do elevador
        elevador.SetActive(true);
    }

    public void Pause()
    {
        //excuta música de pause
        ambiente.SetActive(false);
        pause.SetActive(true);
    }

    public void VozNPC(bool falando)
    {
        if(falando)
        {
            vozNPC.SetActive(true);
        }
        else
        {
            vozNPC.SetActive(false);
        }
    }

    public void MisturaCheiro(bool misturando)
    {
        if(misturando)
        {
            misturaCheiro.SetActive(true);
        }
        else
        {
            misturaCheiro.SetActive(false);
        }
    }


    void Awake()
    {
        //só faz uma referência estática pra facilitar usar cross-scripts
        sound = this;
    }
}
