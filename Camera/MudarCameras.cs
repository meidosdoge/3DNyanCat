using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarCameras : MonoBehaviour
{
    //pega camera atual para fazer a verificação se o player está na visão dela
    Camera camera;
    //referencias de objetos para realizar a transição das cameras e executar o que precisa
    public GameObject player, cameraPlayer;
    public GameObject cameraAp, cameraPartAp;  //não entendi a necessidade dessa aqui
    //variavel que indica se está na camera fixa ou movel, para a mira conseguir funcionar de acordo
    public static bool camNoPlayer = false;

    private void Start()
    {
        camera = cameraAp.GetComponent<Camera>();
    }

    void Update()
    {
        //verificação se o player entrou na camera ou saiu {
        Vector3 screenPoint = camera.WorldToViewportPoint(player.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        //}

        //ações de acordo com o estado da visualização do player na camera
        if (onScreen)
        {
            cameraPlayer.SetActive(false);
            camNoPlayer = false;
            cameraAp.SetActive(true);
            cameraPartAp.SetActive(true);
        }
        else if (!onScreen)
        {
            cameraPlayer.SetActive(true);
            camNoPlayer = true;
            cameraAp.SetActive(false);
            cameraPartAp.SetActive(false);
        }
    }

    /*abrir porta quando clica
    lock player, move dog forward
    quando o dog entra, rola um fade

    aparece de novo na câmera lá em cima com as portas abrindo
    direção do dog facing up pra ir pro lado certo 

    música dentro do elevador
    som quando clica
    som quando chega*/
}
