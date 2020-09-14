using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform player;
    float xRotation = 0f;

    //modificar a gosto
    [SerializeField]
    string ModificarAGosto = "//";
    public float mouseSensitivity = 100f;
    public float anguloMinimoY = 90;
    public float anguloMaximoY = 90;

    void Start()
    {
        //Esconde a setinha do mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(CanvasManager.jogoPausado == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -anguloMinimoY, anguloMaximoY);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
            //eixoCam.Rotate(Vector3.up * mouseX);


            /*if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0){
                Quaternion pegaRotacaoEixo = Quaternion.Euler(eixoCam.rotation.x, player.rotation.y, player.rotation.z);
                player.rotation = pegaRotacaoEixo;
            }*/
        } 
    }
}
