using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightRay : MonoBehaviour
{
    public int raycastDist;
    public Camera mainCamera;

    public GameObject litObj;

    public LayerMask ignoraPlayer;

    //pega o dog para castar o Ray nele
    public GameObject dog;


    void Update()
    {
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //armazena os objetos que estão proximos do dog na camera fixa
        RaycastHit[] hitCamFixa = new RaycastHit[0];

        if (MudarCameras.camNoPlayer)
        {
            if (Physics.Raycast(ray, out hit, raycastDist, ~ignoraPlayer))
            {
                //print(hit.collider.gameObject);
                if (litObj != null && litObj != hit.collider.gameObject)
                {
                    litObj.GetComponent<Highlight>().desliga();
                }

                if (hit.collider.gameObject.GetComponent<Highlight>() != null)
                {
                    litObj = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<Highlight>().liga();
                }
            }
            else
            {
                if (litObj != null)
                {
                    litObj.GetComponent<Highlight>().desliga();
                }
            }
        }

        else if (!MudarCameras.camNoPlayer)
        {
            //desliga o highlight dos objetos que estavam no array na frame anterior
            for (int i = 0; i < hitCamFixa.Length; i++)
            {
                hit = hitCamFixa[i];
                if (hit.collider.GetComponent<Highlight>() != null)
                    hit.collider.gameObject.GetComponent<Highlight>().desliga();
            }

            //detecta os objetos envolta do jogador 9ou devia ne)
            hitCamFixa = Physics.SphereCastAll(dog.transform.position, 30, dog.transform.position, 0.1f, ~ignoraPlayer);

            for (int i = 0; i < hitCamFixa.Length; i++)
            {
                hit = hitCamFixa[i];
                if (hit.collider.GetComponent<Highlight>() != null)
                    hit.collider.gameObject.GetComponent<Highlight>().liga();
            }
        }

    }
}
