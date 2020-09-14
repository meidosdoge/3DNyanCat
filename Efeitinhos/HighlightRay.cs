using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightRay : MonoBehaviour
{
    public int raycastDist;
    public Camera mainCamera;

    public GameObject litObj;

    void Update()
    {
        int x = Screen.width/2;
        int y = Screen.height/2;

        Ray ray = mainCamera.ScreenPointToRay(new Vector3(x,y));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, raycastDist))
        {
            //print(hit.collider.gameObject);
            if(litObj != null && litObj != hit.collider.gameObject)
            {
                litObj.GetComponent<Highlight>().desliga();
            }

            if(hit.collider.gameObject.GetComponent<Highlight>() != null)
            {
                litObj = hit.collider.gameObject;
                hit.collider.gameObject.GetComponent<Highlight>().liga();
            }
        }
        else
        {
            if(litObj != null)
            {
                litObj.GetComponent<Highlight>().desliga();
            }
        }
    }
}
