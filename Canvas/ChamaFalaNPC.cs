using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamaFalaNPC : MonoBehaviour
{
    //script para ativar o objeto com o texto e iniciar o script da text box

    public GameObject objetoComTexto;
    public bool ligarTexto;

    private void Update()
    {
        if (ligarTexto)
        {
            objetoComTexto.SetActive(true);
            ligarTexto = false;
        }
    }
}
