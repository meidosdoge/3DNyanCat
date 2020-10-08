using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public GameObject player, mainCanvas;
    public GameObject apto1, terreo;
    private CanvasManager cvm;

    void Awake()
    {
        cvm = mainCanvas.GetComponent<CanvasManager>();    
    }

    public void AtivaCheiros(GameObject obj)
    {
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            //pega todos os filhos do obj de partículas e manda ligar a partícula
            obj.transform.GetChild(i).gameObject.GetComponent<ControlaParticula>().podeAtivarPart = true;
            //desativa o menu de pause
            cvm.DisablePauseMenu();
        }
    }

    public void Teletransporte(GameObject spawn)
    {
        //liga o outro ambiente pra garantir que não vai ter abismo
        if(apto1.activeInHierarchy)
            terreo.SetActive(true);
        else if(terreo.activeInHierarchy)
            apto1.SetActive(true);

        //move o player pro spawn point
        player.transform.position = spawn.transform.position;
        //desativa o menu de pause
        cvm.DisablePauseMenu();
    }
}
