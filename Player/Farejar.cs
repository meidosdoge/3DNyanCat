using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farejar : MonoBehaviour
{
    //fala pro tutorial se o jogador aprendeu a cheirar
    public static bool cheirarTutorial, desativarCheiroTutorial;
    public static Farejar fareja; //referência a esse script

    public float farejaDur = 100f; //total de permissão pra cheirar
    public float uso = 5f; //gasto por cheiro
    public float regenera = 0.5f; //tempo de regeneração da barra

    //variáveis da barra de vida
    public Slider barrinha;

    //pega o objeto que contem o efeito do post processing
    public GameObject ppPretoBranco;

    //tempo em camera lenta do TimeScale
    public float cameraLenta = 0.4f;

    //buff debuff
    public static bool efeitoPositivo = false;
    public static bool efeitoNegativo = false;

    public Sprite [] barraBackground;
    public Sprite [] barraStates;

    public GameObject barraBack, barraStat;

    private void Start()
    {
        PegaEventoParaExecutar.desativaCheirar += VisaoOff;
        fareja = this;
    }

    void Update()
    {
        AtualizaBarra();

        if(!CanvasManager.jogoPausado)
        {
            //liga e desliga o cheirar
            if(farejaDur < uso || EstadosPlayer.estadoCheirando && Input.GetMouseButtonDown(1))
            {
                VisaoOff();
            }
            else if(farejaDur >= uso && Input.GetMouseButtonDown(1) && DogRaycast.fucinhoDog)
            {
                VisaoOn();

                MudaBarra();
            }

            
            //diminui ou regenera a barra "de vida" do estado
            if(EstadosPlayer.estadoCheirando)
            {
                farejaDur -= Time.deltaTime * uso;
            }
            else if(farejaDur < 100 && !efeitoNegativo)
            {
                farejaDur += Time.deltaTime * regenera;
            }
        }
    }

    void MudaBarra()
    {
        if(efeitoPositivo)
        {
            //barrinha azul
            barraBack.GetComponent<Image>().sprite = barraBackground[1];
            barraStat.GetComponent<Image>().sprite = barraStates[1];
            farejaDur = 100;
            SoundManager.sound.CheiroBom();
        }
        else if(efeitoNegativo)
        {
            //barrinha vermelha
            barraBack.GetComponent<Image>().sprite = barraBackground[2];
            barraStat.GetComponent<Image>().sprite = barraStates[2];
            if(farejaDur > 25)
                farejaDur = 25;
            SoundManager.sound.CheiroRuim();
        }
        else
        {
            //barrinha padrão
            barraBack.GetComponent<Image>().sprite = barraBackground[0];
            barraStat.GetComponent<Image>().sprite = barraStates[0];
        }
    }

    void AtualizaBarra()
    {
        barrinha.value = farejaDur;
    }

    public void VisaoOn()
    {
        //ativa a animação de cheirar
        EstadosPlayer.estadoMovimentacao = "cheirando";
        ppPretoBranco.SetActive(true);
        Time.timeScale = cameraLenta;
        EstadosPlayer.estadoCheirando = true;
        DogRaycast.objSendoObservado.GetComponent<ControlaParticula>().podeAtivarPart = true;

        cheirarTutorial = true;
        SoundManager.sound.DogCheira(true);
    }

    public void VisaoOff()
    {
        ppPretoBranco.SetActive(false);
        Time.timeScale = 1;
        EstadosPlayer.estadoCheirando = false;

        desativarCheiroTutorial = true;
        SoundManager.sound.DogCheira(false);
    }
}
