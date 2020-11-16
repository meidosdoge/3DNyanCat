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
    public GameObject pia;

    [Header("Sons do Dog")]
    public GameObject dogIdle;
    public GameObject dogMove;
    public GameObject dogCheira;
    public GameObject dogLate;

    public GameObject misturaCheiro;
    public GameObject cheiroRuim;
    public GameObject cheiroBom;

    [Header("Sons do NPC")]
    public GameObject vozNPC;
    public GameObject npcPassos;
    public GameObject npcCorre;

    [Header("Eventos")]
    public GameObject tutorialStep;
    public GameObject tutorialComplete;
    public GameObject culpadoErrado;
    public GameObject culpadoCerto;

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

    public void SomPia()
    {
        //som da pia
        pia.SetActive(true);
    }

    public void SomTV(bool ligando)
    {
        //se a tv tá ligando
        if(ligando)
        {
            tvLiga.SetActive(true);
            tvDesliga.SetActive(false);
        }
        else
        {
            tvLiga.SetActive(false);
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
        //se o dog tá andando e não tá cheirando
        if(movendo && !EstadosPlayer.estadoCheirando)
        {
            dogMove.SetActive(true);
            dogIdle.SetActive(false);
        }
        else
        {
            if (CanvasManager.jogoPausado || EstadosPlayer.estadoCheirando)
            {
                dogMove.SetActive(false);
                dogIdle.SetActive(false);
            }
            else
            {
                dogMove.SetActive(false);
                dogIdle.SetActive(true);
            }
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

    public void CheiroRuim()
    {
        cheiroRuim.SetActive(true);
    }

    public void CheiroBom()
    {
        cheiroBom.SetActive(true);
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

    public void PassosNPC(bool andando)
    {
        //se o npc tá andando
        if(andando)
        {
            npcCorre.SetActive(false);
            npcPassos.SetActive(true);
        }
        else
        {
            npcPassos.SetActive(false);
        }
    }
    public void CorreNPC(bool correndo)
    {
        //se o npc tá andando
        if(correndo)
        {
            npcCorre.SetActive(true);
            npcPassos.SetActive(false);
        }
        else
        {
            npcCorre.SetActive(false);
        }
    }

    ///////////////sons eventos
    public void TutorialStep()
    {
        tutorialStep.SetActive(true);
    }
    public void TutorialComplete()
    {
        tutorialComplete.SetActive(true);
    }
    public void EscolheInimigoErrado()
    {
        culpadoErrado.SetActive(true);
    }
    public void EscolheInimigoCerto()
    {
        culpadoCerto.SetActive(true);
    }


    void Awake()
    {
        //só faz uma referência estática pra facilitar usar cross-scripts
        sound = this;
    }
}
