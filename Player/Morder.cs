using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morder : MonoBehaviour
{
    bool carregandoItem = false; //o dog tá com um item

    //lugar em que o objeto vai ficar na boca
    public GameObject jointBoca;
    //pega as propriedades do objeto que está na boca do dog
    public GameObject objetoNaBoca;

    public float forcaDeSoltar = 10;


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
        }
    }


    public void PegaItem()
    {
        objetoNaBoca = DogRaycast.objSendoObservado;
        EstadosPlayer.estadoMordendo = true;
        carregandoItem = true;        
        objetoNaBoca.transform.parent = jointBoca.transform;
        objetoNaBoca.transform.position = jointBoca.transform.position;
        objetoNaBoca.GetComponent<Rigidbody>().isKinematic = true;
        objetoNaBoca.GetComponent<BoxCollider>().enabled = false;
        objetoNaBoca.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        PegaEventoParaExecutar.desativaCheirarEMorder += SoltaItem;
    }

    public void SoltaItem()
    {
        EstadosPlayer.estadoMordendo = false;
        carregandoItem = false;
        objetoNaBoca.transform.parent = null;
        objetoNaBoca.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        objetoNaBoca.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        objetoNaBoca.GetComponent<Rigidbody>().isKinematic = false;
        objetoNaBoca.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        objetoNaBoca.GetComponent<BoxCollider>().enabled = true;
        PegaEventoParaExecutar.desativaCheirarEMorder -= SoltaItem;
    }
}