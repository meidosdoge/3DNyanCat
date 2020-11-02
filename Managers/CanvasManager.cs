using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static bool jogoPausado = false;
    public GameObject pauseMenu, cheatsMenu, controlesMenu, menuSuspeitos;

    void Update()
    {
        //Ativa e desativa o menu de pausa
        if((Input.GetKeyDown(KeyCode.Escape) || ListaDeEventosJogo.pausar) && jogoPausado == false)
        {
            if (!ListaDeEventosJogo.pausar)
                pauseMenu.SetActive(true);
            jogoPausado = true;
            Time.timeScale = 0;

            //passei esse cara pra cá porque no outro script ele tava ativando a movimentação
            //sempre que não tava pausado, me impedindo de desativar a mov em outros lugares
            DesativaMovPlayer.desMov.AtivaCursor();
            DesativaMovPlayer.desMov.DesativaMov();

            SoundManager.sound.Pause();
            SoundManager.sound.DogMove(false);
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && jogoPausado)
        {
            //desativa ou o menu, ou a tela de suspeitos, dependendo de em qual o jogador está
            DisablePauseMenu();                
        }
    }

    public void DisablePauseMenu()
    {
        DesativaMovPlayer.desMov.AtivaMov();
        if (!ListaDeEventosJogo.pausar)
        {
            pauseMenu.SetActive(false);
            cheatsMenu.SetActive(false);
            controlesMenu.SetActive(false);
        }
        else if (ListaDeEventosJogo.pausar)
            menuSuspeitos.SetActive(false);

        jogoPausado = false;
        SoundManager.sound.Ambiente();

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
