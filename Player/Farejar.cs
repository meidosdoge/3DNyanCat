using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farejar : MonoBehaviour
{
    //fazer: interação da ação com o raycast
    //fazer: interação da ação com a hud

    public float farejaDur = 100f; //total de permissão pra cheirar
    public float uso = 5f; //gasto por cheiro
    public float regenera = 0.5f; //tempo de regeneração da barra

    //variáveis da barra de vida
    public Slider barrinha;


    void Update()
    {
        AtualizaBarra();

        if(!CanvasManager.jogoPausado)
        {
            //liga e desliga o cheirar
            if(farejaDur < uso || EstadosPlayer.estadoHabilidade == "cheirando" && Input.GetMouseButtonDown(1))
            {
                EstadosPlayer.estadoHabilidade = "inativo";
            }
            else if(farejaDur >= uso && Input.GetMouseButtonDown(1))
            {
                EstadosPlayer.estadoHabilidade = "cheirando";
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
}
