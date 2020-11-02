using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosPlayer : MonoBehaviour
{
    public static string estadoMovimentacao = "idle";
    public static bool estadoMordendo = false, estadoCheirando = false;

    public Animator estadosAnimacao;

    //possibilidades de estado
    //movimentação: idle, andando, mordendo, cheirando
    //ação da cara: inativo, cheirando, mordendo

    private void OnEnable()
    {
        DesativaMovPlayer.desMov.AtivaMov();
    }

    public static bool gerandoParticula = false;
    //ativa quando duas partículas estão colidindo

    void Update()
    {
        //altera o estado da animação dependendo da ação do player
        switch (estadoMovimentacao){
            case "idle":
                estadosAnimacao.SetInteger("EstadoPlayer", 0);
                break;
            case "andando":
                estadosAnimacao.SetInteger("EstadoPlayer", 1);
                break;
            case "mordendo":
                estadosAnimacao.SetInteger("EstadoPlayer", 2);
                break;
            case "cheirando":
                estadosAnimacao.SetInteger("EstadoPlayer", 3);
                break;
        }
    }
}
