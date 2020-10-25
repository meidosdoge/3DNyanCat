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

    void ControlaTV(GameObject direcao)
    {
        if(!pegandoControle)
        {
            StartCoroutine(WaitFor(1.2f, direcao));  
            telaTV.SetActive(true);
            SoundManager.sound.SomTV(true);
            pegandoControle = true;
        }
        else if (pegandoControle)
        {
            StartCoroutine(WaitFor(1.2f, direcao));  
            telaTV.SetActive(false);
            SoundManager.sound.SomTV(false);
            pegandoControle = false;
        }
    }

    void UsaPia(GameObject direcao)
    {
        StartCoroutine(WaitFor(1.2f, direcao));  
        SoundManager.sound.SomPia();
    }

    void Cadeira(GameObject direcao)
    {
        StartCoroutine(WaitFor(1.2f, direcao));   
    }

    public IEnumerator WaitFor(float waitTime, GameObject direcionarNPC)
    {
        yield return new WaitForSeconds(waitTime);
        transform.LookAt(direcionarNPC.transform.position);
    }

    /*
    se chega perto do player, reseta o nível

    Ligar coisas do tutorial, desligar mov do hitchcock
    Fazer uma build
    */
}
