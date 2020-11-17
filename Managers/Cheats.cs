using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public GameObject player, mainCanvas;
    public GameObject apto1, terreo;
    public GameObject apto2, apto3, apto4;
    public GameObject tela, holder, ganhou;
    private CanvasManager cvm;

    void Awake()
    {
        cvm = mainCanvas.GetComponent<CanvasManager>();    
    }

    public void PulaTutorial()
    {
        ScriptTutorial.pularTutorial = true;
        //desativa o menu de pause
        cvm.DisablePauseMenu();
    }

    public void EscolheInimigo()
    {
        cvm.DisablePauseMenu();
        tela.SetActive(true);
        ganhou.SetActive(true);
        holder.SetActive(true);
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

    //tive que fazer um por um da forma burra, porque função pra botão só pode ter um objeto na chamada
    public void TeletransporteApto1(GameObject spawn)
    {
        if(EstadosPlayer.estadoCheirando)
            Farejar.fareja.VisaoOff();
        
        if(EstadosPlayer.estadoMordendo)
            Morder.morde.SoltaItem();

        //liga o outro ambiente pra garantir que não vai ter abismo
        apto1.SetActive(true);

        //move o player pro spawn point
        player.transform.position = spawn.transform.position;

        //desativa ambientes onde não tá
        terreo.SetActive(false);
        apto2.SetActive(false);
        apto3.SetActive(false);
        apto4.SetActive(false);

        //desativa o menu de pause
        cvm.DisablePauseMenu();
    }

    public void TeletransporteApto2(GameObject spawn)
    {
        if(EstadosPlayer.estadoCheirando)
            Farejar.fareja.VisaoOff();
        
        if(EstadosPlayer.estadoMordendo)
            Morder.morde.SoltaItem();

        //liga o outro ambiente pra garantir que não vai ter abismo
        apto2.SetActive(true);

        //move o player pro spawn point
        player.transform.position = spawn.transform.position;

        //desativa ambientes onde não tá
        terreo.SetActive(false);
        apto1.SetActive(false);
        apto3.SetActive(false);
        apto4.SetActive(false);

        //desativa o menu de pause
        cvm.DisablePauseMenu();
    }

    public void TeletransporteApto3(GameObject spawn)
    {
        if(EstadosPlayer.estadoCheirando)
            Farejar.fareja.VisaoOff();
        
        if(EstadosPlayer.estadoMordendo)
            Morder.morde.SoltaItem();

        //liga o outro ambiente pra garantir que não vai ter abismo
        apto3.SetActive(true);

        //move o player pro spawn point
        player.transform.position = spawn.transform.position;

        //desativa ambientes onde não tá
        terreo.SetActive(false);
        apto1.SetActive(false);
        apto2.SetActive(false);
        apto4.SetActive(false);

        //desativa o menu de pause
        cvm.DisablePauseMenu();
    }

    public void TeletransporteApto4(GameObject spawn)
    {
        if(EstadosPlayer.estadoCheirando)
            Farejar.fareja.VisaoOff();
        
        if(EstadosPlayer.estadoMordendo)
            Morder.morde.SoltaItem();

        //liga o outro ambiente pra garantir que não vai ter abismo
        apto4.SetActive(true);

        //move o player pro spawn point
        player.transform.position = spawn.transform.position;

        //desativa ambientes onde não tá
        terreo.SetActive(false);
        apto1.SetActive(false);
        apto2.SetActive(false);
        apto3.SetActive(false);

        //desativa o menu de pause
        cvm.DisablePauseMenu();
    }
}
