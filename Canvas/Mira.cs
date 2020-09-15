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
        //faz a imagem seguir o mouse na tela
        Vector2 posCursor = Input.mousePosition;
        transform.position = posCursor;

        //verifica em qual situação o jogador está e muda o cursor de acordo,
        //utilizando as variáveis que vem do raycast
        else if (DogRaycast.distDogObj == 1)
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
