using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRaycast : MonoBehaviour
{
    public static int distDogObj;

    float distanceObjRay;

    //modificar a gosto
    [SerializeField]
    string ModificarAGosto = "//";
    public float raycastDistance; //tamanho do raycast que o jogador vai fazer
    public Camera mainCamera;
    public float diamRay, distMedio, distLonge;

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //pega as coordenadas do mouse na tela e converte para o world space,
        //saindo da câmera e chegando ao primeiro ponto de impacto

        RaycastHit whatIHit;

        if (Physics.Raycast(ray, out whatIHit, raycastDistance)) { 

            distanceObjRay = Vector3.Distance(this.transform.position, whatIHit.point);

            if (distanceObjRay >= distLonge ) {
                distDogObj = 2;
            }
            else if (distanceObjRay >= distMedio){
                distDogObj = 1;
            }
            else if (distanceObjRay < distMedio){
                distDogObj = 0;
            }

        }
    }
}
