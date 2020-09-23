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
            || EstadosPlayer.estadoHabilidade == "mordendo" && Input.GetMouseButtonDown(0))
            {
                EstadosPlayer.estadoHabilidade = "inativo";
                carregandoItem = false;
                DogRaycast.bocaDog = false;
                SoltaItem();
            }


            else if(!carregandoItem 
                && Input.GetMouseButtonDown(0) 
                && DogRaycast.bocaDog 
                && DogRaycast.objSendoObservado.transform.gameObject.CompareTag ("Morder")) //morde o item. Tem que ser nessa ordem os ifs, primeiro o solta e depois o morde
            {
                EstadosPlayer.estadoHabilidade = "mordendo";
                carregandoItem = true;
                PegaItem();
            }
        }
    }


    void PegaItem()
    {
        objetoNaBoca = DogRaycast.objSendoObservado;
        objetoNaBoca.transform.parent = jointBoca.transform;
        objetoNaBoca.transform.position = jointBoca.transform.position;
        objetoNaBoca.GetComponent<Rigidbody>().isKinematic = true;
    }

    void SoltaItem()
    {
        objetoNaBoca.transform.parent = null;
        objetoNaBoca.GetComponent<Rigidbody>().isKinematic = false;
        objetoNaBoca.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * forcaDeSoltar);
    }
}
