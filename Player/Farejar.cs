using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farejar : MonoBehaviour
{
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
            }

            
            //diminui ou regenera a barra "de vida" do estado
            if(EstadosPlayer.estadoCheirando)
            {
                farejaDur -= Time.deltaTime * uso;
            }
            else if(farejaDur < 100)
            {
                farejaDur += Time.deltaTime * regenera;
            }
        }
    }

    void AtualizaBarra()
    {
        barrinha.value = farejaDur;
    }

    public void VisaoOn()
    {
        ppPretoBranco.SetActive(true);
        Time.timeScale = cameraLenta;
        EstadosPlayer.estadoCheirando = true;
        DogRaycast.objSendoObservado.GetComponent<ControlaParticula>().podeAtivarPart = true;

        SoundManager.sound.DogCheira(true);
    }

    public void VisaoOff()
    {
        ppPretoBranco.SetActive(false);
        Time.timeScale = 1;
        EstadosPlayer.estadoCheirando = false;

        SoundManager.sound.DogCheira(false);
    }
}
