using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTutorial : MonoBehaviour
{
    //registra em qual parte do tutorial o gênio do jogador ta
    int parteTutorial;
    //lista de falas da vovózinha cuti cuti
    public GameObject[] listaFalas;
    //caixas de texto para lembrar o jogador do que se tem que fazer
    public GameObject auxilioMorder, auxilioCheirar, auxilioJuntar, setaBarraCheiro, indicaCesta, caixaDeFundo;
    // ativa NPC que segue
    public GameObject NPC;

    public static bool terminouTutorial;

    public static bool pularTutorial;

    bool completouPasso = false; //tocar som quando completa uma parte do tutorial



    // Start is called before the first frame update
    void Start()
    {
        parteTutorial = 1;

        if (terminouTutorial)
        {
            FechaTutorial();
            parteTutorial = 9;
            caixaDeFundo.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P)) pularTutorial = true;

        if (parteTutorial == 1)
        {
            if (!pularTutorial)
            {
                ChamaFala(0);
            }
            else if (pularTutorial)
            {
                listaFalas[0].SetActive(false);
                ProximoTutorial();
            }
                
        }

        else if (parteTutorial == 2)
        {
            auxilioMorder.SetActive(true);
            if (Morder.morderTutorial || pularTutorial)
            {
                auxilioMorder.SetActive(false);
                ProximoTutorial();
                completouPasso = true;
            }
        }

        else if (parteTutorial == 3)
        {
            if(completouPasso)
            {
                SoundManager.sound.TutorialStep();
                completouPasso = false;
            }
            
            if (!pularTutorial)
                ChamaFala(1);

            else if (pularTutorial)
            {
                listaFalas[1].SetActive(false);
                ProximoTutorial();
            }
            //fiz isso pra que mesmo se o jogador ja tiver cheirado, ele deva cheirar novamente
            Farejar.cheirarTutorial = false;
        }

        else if (parteTutorial == 4)
        {
            auxilioCheirar.SetActive(true);
            if (Farejar.cheirarTutorial || pularTutorial)
            {
                auxilioCheirar.SetActive(false);
                ProximoTutorial();
                completouPasso = true;
            }
        }

        else if (parteTutorial == 5)
        {
            if(completouPasso)
            {
                SoundManager.sound.TutorialStep();
                completouPasso = false;
            }
            
            setaBarraCheiro.SetActive(true);
            caixaDeFundo.SetActive(false);
            if (!pularTutorial)
                ChamaFala(2);

            else if (pularTutorial)
            {
                listaFalas[2].SetActive(false);
                ProximoTutorial();
            }
        }

        else if (parteTutorial == 6)
        {
            
            if (Farejar.desativarCheiroTutorial == true || pularTutorial)
            {
                setaBarraCheiro.SetActive(false);
                caixaDeFundo.SetActive(true);
                if (!pularTutorial)
                    ChamaFala(3);

                else if (pularTutorial)
                {
                    listaFalas[3].SetActive(false);
                    ProximoTutorial();
                }
            }
            
        }

        else if (parteTutorial == 7)
        {
            auxilioJuntar.SetActive(true);
            if (ControlaParticula.fusaoTutorial || pularTutorial)
            {
                ProximoTutorial();
                auxilioJuntar.SetActive(false);
            }
        }

        else if (parteTutorial == 8)
        {
            if (!pularTutorial)
                ChamaFala(4);

            else if (pularTutorial)
            {
                ListaDeEventosJogo.executouCutscene = true;
                listaFalas[4].SetActive(false);
                ProximoTutorial();
            }
        }

        else if (parteTutorial >= 9)
        {
            caixaDeFundo.SetActive(false);
            FechaTutorial();
        }
    }

    public void FechaTutorial()
    {
        SoundManager.sound.TutorialComplete();
        indicaCesta.SetActive(true);
        NPC.GetComponent<BehaviorExecutor>().enabled = true;
        terminouTutorial = true;
        this.gameObject.SetActive(false);
        DesativaMovPlayer.desMov.AtivaMov();
    }

    public void ChamaFala(int numeroDaFala)
    {
        if (listaFalas[numeroDaFala].gameObject.GetComponent<Falas>().acabouTexto == false)
            listaFalas[numeroDaFala].SetActive(true);
        else if (listaFalas[numeroDaFala].gameObject.GetComponent<Falas>().acabouTexto == true)
        {
            listaFalas[numeroDaFala].SetActive(false);
            ProximoTutorial();
        }
            
    }

    public void ProximoTutorial()
    {
        parteTutorial += 1;
    }
}
