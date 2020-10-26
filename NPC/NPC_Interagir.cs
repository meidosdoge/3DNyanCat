using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPC_Interagir : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMesh;

    //itens com que o npc interage
    public GameObject controleTV;

    //itens que sofrem modificação
    public GameObject telaTV;

    public bool perseguindo = false; //tá correndo atrás do personagem
    public bool pegandoControle = false; //pegou o controle da tv
    public Animator fade;

    void Update()
    {
        if(Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
        new Vector2 (player.transform.position.x, player.transform.position.z)) < 1)
        {
            StartCoroutine(Reseta(1f));
        }
    }

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

    public IEnumerator Reseta(float waitTime)
    {
        SoundManager.sound.DogLate();
        DesativaMovPlayer.desMov.DesativaMov();

        yield return new WaitForSeconds(waitTime);

        fade.SetBool("Fade", true);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }
}
