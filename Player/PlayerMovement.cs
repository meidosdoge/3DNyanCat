using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    Vector3 velocity;
    public static float gravity = -10f;

    //modificar a gosto
    [SerializeField]
    string ModificarAGosto = "//";
    public float speed;
    public float runSpeed;

    //public GameObject somPasso1, somPasso2;

    void Update()
    {
        if(CanvasManager.jogoPausado == false)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * inputX + transform.forward * inputZ;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if(controller.isGrounded)
            {
                velocity.y = 0f;
            }

            if(Input.GetAxis("Run") > 0)
                controller.Move(move * runSpeed * Time.deltaTime);

            /*if(inputX != 0 || inputZ != 0)
            {
            if(!somPasso1.activeInHierarchy && !SomPassos.colideTapete)
            {
                somPasso1.SetActive(true);
                somPasso2.SetActive(false);
            }
            if(!somPasso2.activeInHierarchy && SomPassos.colideTapete)
            {
                somPasso1.SetActive(false);
                somPasso2.SetActive(true);
            }
        }
        else
        {
            somPasso1.SetActive(false);
            somPasso2.SetActive(false);
        }*/
        }
    }

    /*void OnDisable()
    {
        somPasso1.SetActive(false);
        somPasso2.SetActive(false);
    }*/
}