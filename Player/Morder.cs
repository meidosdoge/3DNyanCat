using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morder : MonoBehaviour
{
    //fala pro tutorial se o jogador aprendeu a morder
    public static bool morderTutorial;

    public static Morder morde; //referência a esse script

    bool carregandoItem = false; //o dog tá com um item

    //lugar em que o objeto vai ficar na boca
    public GameObject jointBoca;
    //pega as propriedades do objeto que está na boca do dog
    public GameObject objetoNaBoca;

    bool manterNaBoca;

    void Awake()
    {
        morde = this;
    }

    void Update()
    {
        //Debug.Log(DogRaycast.bocaDog);

        if(!CanvasManager.jogoPausado)
        {
            //solta o item
            if(carregandoItem && Input.GetMouseButtonDown(0)
            || EstadosPlayer.estadoMordendo && Input.GetMouseButtonDown(0))
            {
                SoltaItem();
            }
            else if(!carregandoItem 
                && Input.GetMouseButtonDown(0) 
                && DogRaycast.bocaDog 
                && (DogRaycast.objSendoObservado.transform.gameObject.CompareTag ("Morder") 
                ||DogRaycast.objSendoObservado.transform.gameObject.CompareTag ("FarejarEMorder")))
            {
                //morde o item. Tem que ser nessa ordem os ifs, primeiro o solta e depois o morde
                PegaItem();
            }


            ManterObjetoNaBoca();
        }
    }


    public void PegaItem()
    {
        //ativa a animação de morder
        EstadosPlayer.estadoMovimentacao = "mordendo";
        objetoNaBoca = DogRaycast.objSendoObservado;
        EstadosPlayer.estadoMordendo = true;
        carregandoItem = true;
        objetoNaBoca.layer = 9;
        objetoNaBoca.transform.position = jointBoca.transform.position;
        objetoNaBoca.GetComponent<Rigidbody>().isKinematic = true;
        objetoNaBoca.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        manterNaBoca = true;

        morderTutorial = true;
    }

    public void SoltaItem()
    {
        EstadosPlayer.estadoMordendo = false;
        carregandoItem = false;
        objetoNaBoca.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        objetoNaBoca.GetComponent<Rigidbody>().isKinematic = false;
        manterNaBoca = false;
        //objetoNaBoca.layer = 12;
        objetoNaBoca = null;
    }


    void ManterObjetoNaBoca()
    {
        if (manterNaBoca)
        {
            objetoNaBoca.transform.position = jointBoca.gameObject.transform.position;
            objetoNaBoca.transform.rotation = jointBoca.gameObject.transform.rotation;
        }
    }
}