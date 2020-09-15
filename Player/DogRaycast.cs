using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRaycast : MonoBehaviour
{
    public static int distDogObj; //condições de distãncia, se ele quer cheirar ou morder
    public static bool bocaDog, fucinhoDog;
    public static GameObject objSendoObservado;

    float distanceObjRay;

    //modificar a gosto
    [SerializeField]
    string ModificarAGosto = "//";
    public float raycastDistance; //tamanho do raycast
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

            objSendoObservado = whatIHit.transform.gameObject;//armazena o gameobject q está com o mouse em cima para passar essa informação
            //pros outros scripts de morder e cheirar

            if (distanceObjRay >= distLonge ) {
                distDogObj = 2;
            }

            else if (distanceObjRay >= distMedio){
                distDogObj = 1;
            }

            else if (distanceObjRay < distMedio){

                distDogObj = 0;

                if (whatIHit.transform.CompareTag("Farejar"))
                {
                    fucinhoDog = true;
                    bocaDog = false;
                }
                else if (whatIHit.transform.CompareTag("Morder"))
                {
                    bocaDog = true;
                    fucinhoDog = false;
                }
                else if (whatIHit.transform.CompareTag("Cenário") || whatIHit.transform.CompareTag (""))
                {
                    bocaDog = false;
                    fucinhoDog = false;
                }

            }

        }
    }
}
