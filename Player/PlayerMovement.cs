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

            if(MudarCameras.camNoPlayer)
            {
                //camera 3a pessoa ligada
                //move mirando pra frente no mouse
                Vector3 move3aP = transform.right * inputX + transform.forward * inputZ;
                controller.Move(move3aP * speed * Time.deltaTime);
            }
            else
            {
                //em um dos aptos
                //move rodando de acordo com a direção do wasd
                Vector3 moveNoApto = new Vector3(-inputX, 0.0f, -inputZ);
                controller.Move(moveNoApto * speed * Time.deltaTime);

                if(inputX != 0 || inputZ != 0)
                {
                    //roda o player devagar pro lado que ele precisa ir
                    //transform.rotation = Quaternion.LookRotation(moveNoApto);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveNoApto), 0.2F);
                }
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            
            if(controller.isGrounded)
            {
                velocity.y = 0f;
            }


            if(inputX != 0 || inputZ != 0)
            {                
                EstadosPlayer.estadoMovimentacao = "andando";

                /*if(!somPasso1.activeInHierarchy && !SomPassos.colideTapete)
                {
                    somPasso1.SetActive(true);
                    somPasso2.SetActive(false);
                }
                if(!somPasso2.activeInHierarchy && SomPassos.colideTapete)
                {
                    somPasso1.SetActive(false);
                    somPasso2.SetActive(true);
                }*/
            }
            else
            {
                EstadosPlayer.estadoMovimentacao = "idle";
                //somPasso1.SetActive(false);
                //somPasso2.SetActive(false);
            }
        }
    }

    /*void OnDisable()
    {
        somPasso1.SetActive(false);
        somPasso2.SetActive(false);
    }*/
}