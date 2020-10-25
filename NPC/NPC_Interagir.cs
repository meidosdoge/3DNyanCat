using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Interagir : MonoBehaviour
{
    public NavMeshAgent navMesh;

    //itens com que o npc interage
    public GameObject controleTV;

    //itens que sofrem modificação
    public GameObject telaTV;

    public bool perseguindo = false; //tá correndo atrás do personagem
    public bool pegandoControle = false; //pegou o controle da tv


    void Perseguir()
    {
        perseguindo = true;
        navMesh.speed = 4;
    }

    void Andar()
    {
        perseguindo = false;
        navMesh.speed = 2;
    }

    void ControlaTV(GameObject direcionarNPC)
    {
        if(!pegandoControle)
        {
            telaTV.SetActive(true);
            SoundManager.sound.SomTV(true);
            transform.LookAt(direcionarNPC.transform.position);
            pegandoControle = true;
        }
        else if (pegandoControle)
        {
            telaTV.SetActive(false);
            SoundManager.sound.SomTV(false);
            pegandoControle = false;
        }
    }

    void UsaPia(GameObject direcionarNPC)
    {
        SoundManager.sound.SomPia();
        transform.LookAt(direcionarNPC.transform.position);
    }

    void Cadeira(GameObject direcionarNPC)
    {
        transform.LookAt(direcionarNPC.transform.position);
    }

    /*
    Esperar um segundo e aí sim virar
    
    se chega perto do player, reseta o nível

    cutscene

    Ligar coisas do tutorial, desligar mov do hitchcock
    Fazer uma build
    */
}
