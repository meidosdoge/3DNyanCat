using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTutorial : MonoBehaviour
{
    //registra em qual parte do tutorial o gênio do jogador ta
    int parteTutorial;
    //lista de falas da vovózinha cuti cuti
    public GameObject[] listaFalas;
    //hitboxes do tutorial
    public GameObject limite1, limite2;
    //caixas de texto para lembrar o jogador do que se tem que fazer
    public GameObject auxilioMorder, auxilioCheirar, auxilioJuntar, setaBarraCheiro, indicaCesta;
    // ativa NPC que segue
    public GameObject NPC;



    // Start is called before the first frame update
    void Start()
    {
        parteTutorial = 1;
        limite1.SetActive(true);
        limite2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (parteTutorial == 1)
        {
            ChamaFala(0);
        }

        else if (parteTutorial == 2)
        {
            limite1.SetActive(true);
            auxilioMorder.SetActive(true);
            if (Morder.morderTutorial)
            {
                auxilioMorder.SetActive(false);
                ProximoTutorial();
            }
        }

        else if (parteTutorial == 3)
        {
            ChamaFala(1);
            //fiz isso pra que mesmo se o jogador ja tiver cheirado, ele deva cheirar novamente
            Farejar.cheirarTutorial = false;
        }

        else if (parteTutorial == 4)
        {
            auxilioCheirar.SetActive(true);
            if (Farejar.cheirarTutorial)
            {
                auxilioCheirar.SetActive(false);
                ProximoTutorial();
            }
        }

        else if (parteTutorial == 5)
        {
            setaBarraCheiro.SetActive(true);
            ChamaFala(2);
        }

        else if (parteTutorial == 6)
        {
            
            if (Farejar.desativarCheiroTutorial == true)
            {
                setaBarraCheiro.SetActive(false);
                ChamaFala(3);
                limite1.SetActive(false);
                limite2.SetActive(true);
            }
            
        }

        else if (parteTutorial == 7)
        {
            auxilioJuntar.SetActive(true);
            if (ControlaParticula.fusaoTutorial)
            {
                ProximoTutorial();
                auxilioJuntar.SetActive(false);
            }
        }

        else if (parteTutorial == 8)
        {
            ChamaFala(4);
            limite2.SetActive(false);
        }

        else if (parteTutorial >= 9)
        {
            indicaCesta.SetActive(true);
            NPC.GetComponent<NPC_Interagir>().enabled = true;
            NPC.GetComponent<BehaviorExecutor>().enabled = true;
            this.gameObject.SetActive(false);
        }
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
