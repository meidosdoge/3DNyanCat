using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCamera : MonoBehaviour
{
    public Transform camAp, destino;
    Vector3 velocity = Vector3.zero;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            camAp.position = Vector3.SmoothDamp(camAp.position, destino.transform.position, ref velocity, 0.3f, 20);
            //camAp.rotation = Quaternion.Slerp(camAp.rotation, destino.transform.rotation, 0.3f);
        }
    }
}
