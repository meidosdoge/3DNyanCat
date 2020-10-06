using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosPlayer : MonoBehaviour
{
    public static string estadoMovimentacao = "idle";
    public static bool estadoMordendo = false, estadoCheirando = false;

    //possibilidades de estado
    //movimentação: idle, andando, correndo
    //ação da cara: inativo, cheirando, mordendo


    public static bool gerandoParticula = false;
    //ativa quando duas partículas estão colidindo

    void Update()
    {
        //print("estadoMovimentacao " + estadoMovimentacao);
        //print("estadoHabilidade " + estadoHabilidade);
        //print(gerandoParticula);
    }
}
