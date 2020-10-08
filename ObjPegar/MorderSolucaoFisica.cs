using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorderSolucaoFisica : MonoBehaviour
{
    //esse script é pra poder soltar o objeto e ele cair, mas só até chegar no chão
    //fazendo com que não se mova mais dps disso e n de mais problemas de colisão
    //o thiago vai ficar triste

    Rigidbody rb;
    bool caindo;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.y < -0.1f)
        {
            caindo = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }

        if (caindo && rb.velocity.y > -0.1f)
        {
            caindo = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
