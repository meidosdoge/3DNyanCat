using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioDoGame : MonoBehaviour
{
    //script com coisas para setar o game antes dele começar
    public List<GameObject> objComecaInvisivel = new List<GameObject>();
    void Awake()
    {
        Time.timeScale = 1;
        CanvasManager.jogoPausado = false;

        foreach(GameObject obj in objComecaInvisivel)
        {
            obj.SetActive(false);
        }
    }
}
