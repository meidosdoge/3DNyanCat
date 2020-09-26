using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioDoGame : MonoBehaviour
{
    //script com coisas para setar o game antes dele começar
    public List<GameObject> objComecaInvisivel = new List<GameObject>();
    void Awake()
    {
        foreach(GameObject obj in objComecaInvisivel)
        {
            obj.SetActive(false);
        }
    }
}
