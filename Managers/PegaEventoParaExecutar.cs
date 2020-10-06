using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaEventoParaExecutar : MonoBehaviour
{
    public delegate void MyDelegate();
    public static MyDelegate desativaCheirar;

    //script pra pegar uma função especifica do outro e executar

    public bool eventoSolicitado;
    public string nomeFuncao;
    GameObject metodos;

    private void Start()
    {
        metodos = GameObject.Find("EventosTriggers");
    }


    private void Update()
    {
        if (eventoSolicitado)
        {
            //aqui tem que desativar só o cheirar, ou ele dá erro porque não tem objeto na boca
            //e aí ele não sobe no elevador antes de morder algo
            //desativaCheirarEMorder();

            metodos.GetComponent<ListaDeEventosJogo>().Invoke(nomeFuncao, 0f);
            eventoSolicitado = false;
        }
    }
}
