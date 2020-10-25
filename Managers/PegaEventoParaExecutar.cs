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
            if (!IsInvoking(nomeFuncao))
            {
                metodos.GetComponent<ListaDeEventosJogo>().Invoke(nomeFuncao, 0f);
                eventoSolicitado = false;
            }
        }
    }
}
