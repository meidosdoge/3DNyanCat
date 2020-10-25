using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioDoGame : MonoBehaviour
{
    //script com coisas para setar o game antes dele começar
    public List<GameObject> objComecaInvisivel = new List<GameObject>();
    public GameObject dog, cameraPlayer;
    public Vector3 direcaoDogInicial;

    void Awake()
    {
        Application.targetFrameRate = 45;

        Time.timeScale = 1;
        CanvasManager.jogoPausado = false;

        foreach(GameObject obj in objComecaInvisivel)
        {
            obj.SetActive(false);
        }

        SoundManager.sound.Ambiente();
    }

    private void Start()
    {
        //dog começa apontando pra frente ou a direção que quiser, só mudar a variavel publica
        dog.transform.localRotation = Quaternion.Euler(direcaoDogInicial);
        cameraPlayer.transform.localRotation = Quaternion.Euler(0, 0f, 0f);
    }
}
