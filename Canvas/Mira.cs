using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mira : MonoBehaviour
{
    //pega as propriedades de imagem do objeto para poder modificar a sprite
    public Image spriteMira;

    //imagens dos cursores que serão usados. Por enquanto são só três
    public Sprite cursorNormal, cursorMorder, cursorCheirar;

    private void Start()
    {
        spriteMira = GetComponent<Image>();
    }

    private void Update()
    {
        //define os estados do cursor dependendo de qual camera está ativa
        if (MudarCameras.camNoPlayer)
        {
            //coloca a imagem do canvas de volta no centro da tela
            GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!MudarCameras.camNoPlayer)
        {
            //faz a imagem do cursor seguir o mouse
            Vector2 posCursor = Input.mousePosition;
            transform.position = posCursor;
            Cursor.lockState = CursorLockMode.None;
        }

        //caso pause o jogo, ele ja faz a verificação por aq pra n conflitar
        if (CanvasManager.jogoPausado)
        {
            Vector2 posCursor = Input.mousePosition;
            transform.position = posCursor;
            Cursor.lockState = CursorLockMode.None;
        }
        

        //verifica em qual situação o jogador está e muda o cursor de acordo,
        //utilizando as variáveis que vem do raycast
        if (DogRaycast.distDogObj == 1)
        {
            //imagem cursor longa distancia
            spriteMira.sprite = cursorNormal;
        }

        else if (DogRaycast.fucinhoDog)
        {
            //imagem de quando pode cheirar
            spriteMira.sprite = cursorCheirar;
        }

        else if (DogRaycast.bocaDog)
        {
            //imagem de quando pode morder
            spriteMira.sprite = cursorMorder;
        }

    }
}
