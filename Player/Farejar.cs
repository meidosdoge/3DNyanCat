﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farejar : MonoBehaviour
{
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
        PegaEventoParaExecutar.desativaCheirarEMorder += VisaoOff;
    }

    void Update()
    {
        AtualizaBarra();

        if(!CanvasManager.jogoPausado)
        {
            //liga e desliga o cheirar
            if(farejaDur < uso || EstadosPlayer.estadoHabilidade == "cheirando" && Input.GetMouseButtonDown(1))
            {
                PegaEventoParaExecutar.desativaCheirarEMorder();
            }
            else if(farejaDur >= uso && Input.GetMouseButtonDown(1) && DogRaycast.fucinhoDog)
            {
                VisaoOn();
            }

            
            //diminui ou regenera a barra "de vida" do estado
            if(EstadosPlayer.estadoHabilidade == "cheirando")
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

    void VisaoOn()
    {
        ppPretoBranco.SetActive(true);
        Time.timeScale = cameraLenta;
        EstadosPlayer.estadoHabilidade = "cheirando";
        DogRaycast.objSendoObservado.GetComponent<ControlaParticula>().podeAtivarPart = true;
    }

    public void VisaoOff()
    {
        ppPretoBranco.SetActive(false);
        Time.timeScale = 1;
        EstadosPlayer.estadoHabilidade = "inativo";
    }
}
