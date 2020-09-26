using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRaycast : MonoBehaviour
{
    //condição de distância para verificar se ele está perto o suficiente para interagir
    public static int distDogObj; 
    //variaveis para avisar os scripts de quando pode mmorder ou cheirar
    public static bool bocaDog, fucinhoDog; 
    public static GameObject objSendoObservado;
    //layer do player pro raycast ignorar
    public LayerMask ignoraRaycast;

    float distanceObjRay;

    //modificar a gosto
    [SerializeField]
    string ModificarAGosto = "//";
    public float raycastDistance; //tamanho do raycast
    public Camera mainCamera;
    public float diamRay, distLonge;


    void Update()
    {
        //pega as coordenadas do mouse na tela e converte para o world space,
        //saindo da câmera e chegando ao primeiro ponto de impacto
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); 

        RaycastHit whatIHit;

        if (Physics.Raycast(ray, out whatIHit, raycastDistance, ~ignoraRaycast)) { 

            distanceObjRay = Vector3.Distance(this.transform.position, whatIHit.point);

            //armazena o gameobject q está com o mouse em cima para passar essa informação
            //pros outros scripts de morder e cheirar
            objSendoObservado = whatIHit.transform.gameObject;

            //ifs para calcular a distãncia e 
            //fazer verificação do que o jogador pode fazer ou n
            if (distanceObjRay >= distLonge ) {
                distDogObj = 1;
            }

            //o farejar e morder só vão acontecer qnd
            //estiver abaixo da distância longe
            else if (distanceObjRay < distLonge){ 

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
                else if (whatIHit.transform.CompareTag("EventosJogador"))
                {
                    whatIHit.transform.GetComponent<PegaEventoParaExecutar>().eventoSolicitado = true;
                }
                else if (whatIHit.transform.CompareTag("Cenário") || whatIHit.transform.CompareTag ("Untagged"))
                {
                    bocaDog = false;
                    fucinhoDog = false;
                }

            }

        }
    }
}
