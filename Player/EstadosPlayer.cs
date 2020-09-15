using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosPlayer : MonoBehaviour
{
    public static string estadoMovimentacao = "idle";
    public static string estadoHabilidade = "inativo";
    
    //possibilidades de estado
    //movimentação: idle, andando, correndo
    //ação da cara: inativo, cheirando, mordendo

    void Update()
    {
        //print("estadoMovimentacao " + estadoMovimentacao);
        //print("estadoHabilidade " + estadoHabilidade);
    }
}
