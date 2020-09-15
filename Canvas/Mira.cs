using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mira : MonoBehaviour
{
    public Image spriteMira;

    //modificar a gosto
    public Sprite cursorNormal, cursorMorder, cursorCheirar;

    private void Start()
    {
        spriteMira = GetComponent<Image>();
    }

    private void Update()
    {
        Vector2 posCursor = Input.mousePosition;
        transform.position = posCursor;

        if (DogRaycast.distDogObj == 2)
        {
            //imagem cursor longa distância
            spriteMira.sprite = cursorNormal;
        }
        else if (DogRaycast.distDogObj == 1)
        {
            //imagem cursor media distanica
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
