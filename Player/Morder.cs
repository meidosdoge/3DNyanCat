using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morder : MonoBehaviour
{
    bool podeMorder; //a boca tá livre pra fazer nhac
    //fazer: se raycast interage com um item da tag morder, então podeMorder=true;
    bool carregandoItem; //o dog tá com um item
    //fazer: dog pega o item se essa variável é true, solta o item se false

    void Update()
    {
        if(!CanvasManager.jogoPausado)
        {
            //solta o item
            if(carregandoItem && Input.GetMouseButtonDown(0)
            || !podeMorder && Input.GetMouseButtonDown(0)
            || EstadosPlayer.estadoHabilidade == "mordendo" && Input.GetMouseButtonDown(0))
            {
                EstadosPlayer.estadoHabilidade = "inativo";
                carregandoItem = false;
                podeMorder = true;
            }
            else if(podeMorder && Input.GetMouseButtonDown(0)) //morde o item. Tem que ser nessa ordem os ifs, primeiro o solta e depois o morde
            {
                EstadosPlayer.estadoHabilidade = "mordendo";
                carregandoItem = true;
            }

        }
    }
}
