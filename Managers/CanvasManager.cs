using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static bool jogoPausado = false;
    public GameObject pauseMenu, cheatsMenu, controlesMenu;

    void Update()
    {
        //Ativa e desativa o menu de pausa
        if(Input.GetKeyDown(KeyCode.Escape) && jogoPausado == false)
        {
            pauseMenu.SetActive(true);
            jogoPausado = true;
            Time.timeScale = 0;
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && jogoPausado)
        {
            DisablePauseMenu();
        }
    }

    public void DisablePauseMenu()
    {
        pauseMenu.SetActive(false);
        cheatsMenu.SetActive(false);
        controlesMenu.SetActive(false);
        jogoPausado = false;

        if(EstadosPlayer.estadoCheirando)
        {
            Time.timeScale = 0.4f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
