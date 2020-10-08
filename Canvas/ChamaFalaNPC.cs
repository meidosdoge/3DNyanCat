using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamaFalaNPC : MonoBehaviour
{
    //script para ativar o objeto com o texto e iniciar o script da text box

    public GameObject objetoComTexto;
    public bool ligarTexto;

    public int reinteragir = 1;

    private void Update()
    {
        if (ligarTexto && reinteragir%2 == 0)
        {
            objetoComTexto.SetActive(true);
            ligarTexto = false;
        }
    }
}
