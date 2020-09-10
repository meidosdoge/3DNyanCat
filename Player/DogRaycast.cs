using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRaycast : MonoBehaviour
{
    float distanceObjRay;

    //modificar a gosto
    [SerializeField]
    string ModificarAGosto = "//";
    public float raycastDistance; //tamanho do raycast que o jogador vai fazer
    public Camera mainCamera;
    public float diamRay, distMedio, distLonge;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y)); //pega as coordenadas do mouse na tela e converte para o world space,
        //saindo da câmera e chegando ao primeiro ponto de impacto
        RaycastHit whatIHit;


        //if (Physics.SphereCast(ray, diamRay, out whatIHit, raycastDistance)) {
        if (Physics.Raycast(ray, out whatIHit, raycastDistance))
            {

                distanceObjRay = Vector3.Distance(this.transform.position, whatIHit.point);

            if (distanceObjRay >= distLonge ) {
                Debug.Log("maior que 10");
                Debug.DrawRay(this.transform.position, this.transform.forward * raycastDistance, Color.green);
            }
            else if (distanceObjRay >= distMedio){
                Debug.Log("menor que 10 e maior que 4");
                Debug.DrawRay(this.transform.position, this.transform.forward * raycastDistance, Color.yellow);
            }
            else if (distanceObjRay < distMedio){
                Debug.Log("menor que 4");
                Debug.DrawRay(this.transform.position, this.transform.forward * raycastDistance, Color.red);
            }

        }
    }
}
