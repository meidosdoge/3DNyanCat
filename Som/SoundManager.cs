using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sound;

    //métodos e objetos pra ligar e desligar sons na cena

    [Header("Sons do Ambiente")]
    public GameObject ambiente;
    public GameObject pause;
    public GameObject elevador;

    public GameObject tvLiga;
    public GameObject tvDesliga;

    [Header("Sons do Dog")]
    public GameObject dogIdle;
    public GameObject dogMove;
    public GameObject dogCheira;
    public GameObject dogLate;

    public GameObject misturaCheiro;

    [Header("Sons do NPC")]
    public GameObject vozNPC;
    public GameObject npcPassos;
    public GameObject npcCorre;


    //////////sons do ambiente
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

    public void SomTV(bool ligando)
    {
        //se a tv tá ligando
        if(ligando)
        {
            tvLiga.SetActive(true);
        }
        else
        {
            tvDesliga.SetActive(true);
        }
    }

    //////////sons do dog
    public void DogCheira(bool cheirando)
    {
        //som do dog cheirando
        if(cheirando)
        {
            dogCheira.SetActive(true);
        }
        else
        {
            dogCheira.SetActive(false);
        }
    }

    public void DogLate()
    {
        //som do dog latindo
        //ainda não tem uso, mas o pedro fez o som bonitinho
        //então já deixei o método aqui
        dogLate.SetActive(true);
    }
    
    public void DogMove(bool movendo)
    {
        //se o dog tá andando
        if(movendo)
        {
            dogMove.SetActive(true);
            dogIdle.SetActive(false);
        }
        else
        {
            dogMove.SetActive(false);
            dogIdle.SetActive(true);
        }
    }

    public void MisturaCheiro(bool misturando)
    {
        //se as partículas colidem
        if(misturando)
        {
            misturaCheiro.SetActive(true);
        }
        else
        {
            misturaCheiro.SetActive(false);
        }
    }

    //////////sons do npc
    public void VozNPC(bool falando)
    {
        //se o balãozinho tá ativo
        if(falando)
        {
            vozNPC.SetActive(true);
        }
        else
        {
            vozNPC.SetActive(false);
        }
    }

    public void PassosNPC(bool correndo)
    {
        //se o npc tá perseguindo
        if(correndo)
        {
            npcCorre.SetActive(true);
            npcPassos.SetActive(false);
        }
        else
        {
            npcCorre.SetActive(false);
            npcPassos.SetActive(true);
        }
    }


    void Awake()
    {
        //só faz uma referência estática pra facilitar usar cross-scripts
        sound = this;
    }
}
