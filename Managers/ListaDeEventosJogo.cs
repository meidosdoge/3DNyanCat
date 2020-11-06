using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDeEventosJogo : MonoBehaviour
{
    //todos os objetos necessarios são colocados aqui
    [Header("Posições na cena")]
    public GameObject cameraAp1;
    public GameObject player, apto2Spawn, apto3Spawn, apto4Spawn;
    public GameObject terreoSpawnDo2, terreoSpawnDo3, terreoSpawnDo4;
    public GameObject objPrimeiroAndar, objTerreo, apto2, apto3, apto4;
    
    [Header("Elevador evento")]
    public Animator fade;
    public GameObject elevadorApto2, elevadorApto3, elevadorApto4;
    public GameObject elevadorTerreoPro2, elevadorTerreoPro3, elevadorTerreoPro4;

    [Header("Animators")]
    public Animator animElevador2;
    public Animator animElevador3, animElevador4;
    public Animator animTerreoPro2, animTerreoPro3, animTerreoPro4;
    
    private GameObject objetivoMovimenta;
    public bool movimenta = false;


    //coisas da cesta
    [Header("Cesta")]    
    public GameObject sons;
    public GameObject cutVideo, cutUI;
    public GameObject cestaAp1, cestaCondo;
    public static bool executouCutscene;

    [Header("Suspeitos")]
    public GameObject menuSuspeitos;
    //var pra fazer o jogo pausar, igual quando se entra no menu normal
    public static bool pausar;
    
    //adicione eventos aqui

    public void Apto2()
    {
        //leva pro apto2

        //coroutine pra abrir o elevador e fazer a transição, leva como argumentos:
        //tempo, ponto central do elevador atual, ponto central do elevador destino, cenário ligando, cenário desligando, spawn, anim do elevador terreo e anim do elevador apto
        StartCoroutine(Elevador(1f, elevadorTerreoPro2, elevadorApto2, apto2, objTerreo, apto2Spawn, animTerreoPro2, animElevador2));
    }

    public void TerreoDo2()
    {
        //leva pro terreo
        StartCoroutine(Elevador(1f, elevadorApto2, elevadorTerreoPro2, objTerreo, apto2, terreoSpawnDo2, animTerreoPro2, animElevador2));
    }

    public void Apto3()
    {
        //leva pro apto3

        StartCoroutine(Elevador(1f, elevadorTerreoPro3, elevadorApto3, apto3, objTerreo, apto3Spawn, animTerreoPro3, animElevador3));
    }

    public void TerreoDo3()
    {
        //leva pro terreo
        StartCoroutine(Elevador(1f, elevadorApto3, elevadorTerreoPro3, objTerreo, apto3, terreoSpawnDo3, animTerreoPro3, animElevador3));
    }

    public void Apto4()
    {
        //leva pro apto3

        StartCoroutine(Elevador(1f, elevadorTerreoPro4, elevadorApto4, apto4, objTerreo, apto4Spawn, animTerreoPro4, animElevador4));
    }

    public void TerreoDo4()
    {
        //leva pro terreo
        StartCoroutine(Elevador(1f, elevadorApto4, elevadorTerreoPro4, objTerreo, apto4, terreoSpawnDo4, animTerreoPro4, animElevador4));
    }

    //chama funções da cesta
    public void CestaApto()
    {
        StartCoroutine(CestaCutscene(1f, cestaCondo, objTerreo, objPrimeiroAndar));
    }
    public void CestaTerreo()
    {
        StartCoroutine(CestaCutscene(1f, cestaAp1, objPrimeiroAndar, objTerreo));
    }


    //grande "cutscene" do elevador feita de jeito burro com muitas tarefas e waits, im sorry
    void Update()
    {
        //checa se o player se movimentou pra onde deve
        if(movimenta)
            MoveToPoint(objetivoMovimenta);
    }

    //cutscene do vídeo e uso da cesta
    public IEnumerator CestaCutscene(float waitTime, GameObject outPoint, 
    GameObject objAtivar, GameObject objDesativar)
    {
        EstadosPlayer.estadoMovimentacao = "idle";

        if(EstadosPlayer.estadoCheirando)
            Farejar.fareja.VisaoOff();
        
        if(EstadosPlayer.estadoMordendo)
            Morder.morde.SoltaItem();

        //fade tapando câmera
        fade.SetBool("Fade", true);
        DesativaMovPlayer.desMov.DesativaMov();
        objAtivar.SetActive(true);

        yield return new WaitForSeconds(waitTime);        

        if(!executouCutscene)
        {
            //executaCutscene
            sons.SetActive(false);
            cutVideo.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            cutUI.SetActive(true);
            fade.SetBool("Fade", false);

            yield return new WaitForSeconds(16f);
            fade.SetBool("Fade", true);
            executouCutscene = true;

            yield return new WaitForSeconds(waitTime);
            cutVideo.SetActive(false);
            cutUI.SetActive(false);
            sons.SetActive(true);
        }        

        player.transform.position = outPoint.transform.position;
        fade.SetBool("Fade", false);
        
        yield return new WaitForSeconds(waitTime);
        EstadosPlayer.estadoMovimentacao = "idle";
        DesativaMovPlayer.desMov.AtivaMov();
        objDesativar.SetActive(false);
    }
    
    //entra e sai do elevador
    public IEnumerator Elevador(float waitTime, GameObject elevadorEntrada, GameObject elevadorSaida,
    GameObject objAtivar, GameObject objDesativar, GameObject spawnPoint, 
    Animator animElevadorTerreo, Animator animElevadorApto)
    {
        //desativa skills e movimento, vira o player pro elevador
        if(EstadosPlayer.estadoCheirando)
            Farejar.fareja.VisaoOff();
        
        if(EstadosPlayer.estadoMordendo)
            Morder.morde.SoltaItem();

        DesativaMovPlayer.desMov.DesativaMov();
        EstadosPlayer.estadoMovimentacao = "idle";
        player.transform.LookAt(elevadorEntrada.transform.position);

        //liga o próximo ambiente e abre os elevadores
        objAtivar.SetActive(true);
        SoundManager.sound.Elevador();
        animElevadorTerreo.SetBool("AbreElevador", true);
        animElevadorApto.SetBool("AbreElevador", true);
        yield return new WaitForSeconds(waitTime);

        //move o player pro próximo local
        objetivoMovimenta = elevadorEntrada;
        movimenta = true;
        SoundManager.sound.Pause(); //toca a música de elevador
        yield return new WaitForSeconds(waitTime);

        //fade tapando câmera
        fade.SetBool("Fade", true);

        //fecha elevadores e espera pra transportar o player
        animElevadorApto.SetBool("AbreElevador", false);
        animElevadorTerreo.SetBool("AbreElevador", false);
        yield return new WaitForSeconds(waitTime);

        //move o player pro elevador
        movimenta = false;
        player.transform.position = elevadorSaida.transform.position;
        player.transform.LookAt(spawnPoint.transform.position);

        //abre o elevador
        animElevadorTerreo.SetBool("AbreElevador", true);
        animElevadorApto.SetBool("AbreElevador", true);
        yield return new WaitForSeconds(waitTime);

        //tira o fade tapando a câmera
        fade.SetBool("Fade", false);

        //move o player pra fora do elevador
        objetivoMovimenta = spawnPoint;
        movimenta = true;
        SoundManager.sound.Elevador();
        yield return new WaitForSeconds(waitTime);

        //fecha o elevador
        animElevadorApto.SetBool("AbreElevador", false);
        animElevadorTerreo.SetBool("AbreElevador", false);
        SoundManager.sound.Ambiente();
        yield return new WaitForSeconds(1.5f);        

        //libera o player da "cutscene", desativa o ambiente anterior
        EstadosPlayer.estadoMovimentacao = "idle";
        DesativaMovPlayer.desMov.AtivaMov();
        objDesativar.SetActive(false);
    }

    void MoveToPoint(GameObject finalPoint)
    {
        //player não tá andando, então faço isso pra manter a animação de walk
        EstadosPlayer.estadoMovimentacao = "andando";

        //setta o objetivo de movimentação usando a posição do objeto e a altura do player
        Vector3 objetivo = new Vector3 (finalPoint.transform.position.x, player.transform.position.y, finalPoint.transform.position.z);

        //move o player pro objeto
        player.transform.position = Vector3.MoveTowards(player.transform.position, objetivo, 0.1f);

        //se o jogador chegou no lugar, termina a movimentação
        if(Vector3.Distance(player.transform.position, objetivo) < 0.1f)
        {
            EstadosPlayer.estadoMovimentacao = "idle";
            movimenta = false;
        }
    }

    //tentativa de evento pra chamar o canvas que o player vai decidir o suspeito
    public void ChamaCanvasSuspeitos()
    {
        menuSuspeitos.SetActive(true);
        pausar = true;
    }
}