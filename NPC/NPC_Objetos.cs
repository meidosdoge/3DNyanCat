using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Objetos : MonoBehaviour
{
    public string nomeDoMetodo;
    public GameObject posicaoDoObjeto;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("NPC"))
        {
            other.gameObject.SendMessage(nomeDoMetodo, posicaoDoObjeto);
        }
    }
}
