using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPC_Interagir : MonoBehaviour
{
    public Animator animNpc;

    public GameObject player;
    public NavMeshAgent navMesh;

    //itens com que o npc interage
    public GameObject controleTV;

    //itens que sofrem modificação
    public GameObject telaTV;

    public bool perseguindo = false; //tá correndo atrás do personagem
    public bool pegandoControle = false; //pegou o controle da tv
    public Animator fade;

    GameObject direcionarNPC;

    void Update()
    {
        if(Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z),
        new Vector2 (player.transform.position.x, player.transform.position.z)) < 1)
        {

            animNpc.SetBool("Pegou", true);

            StartCoroutine(Reseta(1f));
        }
    }

    void Perseguir()
    {
        animNpc.SetBool("Sentado", false);
        animNpc.SetInteger("EstadosNpc", 2);
        perseguindo = true;
        navMesh.speed = 4;
        SoundManager.sound.CorreNPC(true);
    }

    void Andar()
    {
        animNpc.SetBool("Sentado", false);
        animNpc.SetInteger("EstadosNpc", 1);
        perseguindo = false;
        navMesh.speed = 2;
        SoundManager.sound.PassosNPC(true);
    }

    void Parar()
    {
        animNpc.SetInteger("EstadosNpc", 0);
        perseguindo = false;
        navMesh.speed = 0;
        SoundManager.sound.PassosNPC(false);
        SoundManager.sound.CorreNPC(false);
        transform.LookAt(direcionarNPC.transform.position);
        //se o NPC parar e estiver olhando para a televisao, ele passa para a animação de sentar e dps a de ficar sentado
        if (direcionarNPC.transform.name == "tellevisao")
            animNpc.SetBool("Sentado", true);
    }

    void ControlaTV(GameObject direcao)
    {
        if(!pegandoControle)
        {
            direcionarNPC = direcao;
            telaTV.SetActive(true);
            SoundManager.sound.SomTV(true);
            pegandoControle = true;
        }
        else if (pegandoControle)
        {
            direcionarNPC = direcao;
            telaTV.SetActive(false);
            SoundManager.sound.SomTV(false);
            pegandoControle = false;
        }
    }

    void UsaPia(GameObject direcao)
    {
        direcionarNPC = direcao; 
        SoundManager.sound.SomPia();
    }

    void Cadeira(GameObject direcao)
    {
        direcionarNPC = direcao;
    }

    void FazNada(GameObject direcao)
    {
        direcionarNPC = direcao;
    }

    public IEnumerator Reseta(float waitTime)
    {
        SoundManager.sound.DogLate();
        DesativaMovPlayer.desMov.DesativaMov();

        yield return new WaitForSeconds(waitTime);

        fade.SetBool("Fade", true);

        Farejar.efeitoNegativo = false;
        Farejar.efeitoPositivo = false;
        Time.timeScale = 1;
        
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
        animNpc.SetBool("Pegou", false);
    }
}
