using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaEventoParaExecutar : MonoBehaviour
{
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
        if (eventoSolicitado && Input.GetMouseButton(0))
        {
            metodos.GetComponent<ListaDeEventosJogo>().Invoke(nomeFuncao, 0f);
            eventoSolicitado = false;
        }
    }
}
