using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mira : MonoBehaviour
{
    public Image spriteMira;

    //modificar a gosto
    public string orientacaoDasSprites = "/Quanto menor o valor dentro da lista, ";
    public string orientacaoDasSprites2 = " menor a distância até o objeto/";

    public List<Sprite> spritesMouse = new List<Sprite>();

    private void Start()
    {
        spriteMira = GetComponent<Image>();
    }

    private void Update()
    {
        Vector2 posCursor = Input.mousePosition;
        transform.position = posCursor;

        spriteMira.sprite = spritesMouse[DogRaycast.distDogObj];
    }
}
