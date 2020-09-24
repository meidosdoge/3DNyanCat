using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaParticula : MonoBehaviour
{
    /*
    comentar esse script direito

    void MixParticles()
    {
        mudar a sprite atual? maybe nicer
        testar com o negócio feio que eu fiz
        se funcionar, fazer uma sheet bonita
        preta com a forma em branco
        pegar o número de um e outro e escolher a sheet pelo nome faseX_particula_i_j
        ou seja lá qual o padrão de renomear do unity
        fazer um material com essa bonita pra usar

        quando criar a partícula, mudar a cor dela
        cor é a mistura de a e b, ver aquele bagulho da soma
        a v1 pode não ter cor, tudo bem
    }

        else if sprite not work
        {
            pega o número da row atual
            usa dentro de um array com os quatro cheiros do ambiente
            de acordo com qual a forma inicial, gera partícula com material da sheet de combinação
            sheets de combinação de cada forma, lugar com 4 cheiros tem 4 materiais (inicial, comb linha1, ...)
        }
    
    void ativaParticle()
    {
        criar uma pode ligar
        pegar do raycast qual o objeto que eu cliquei
        mandar mensagem do próprio raycast talvez seja mais fácil
        chamar esse método lá, objQueEuCliquei.ControlaParticula.ativaParticle()
        if obj interagido = this/chegou aqui, pode ligar = true
        esse true NÃO FICA FALSE NUNCAAAA

        if(Estadosplayer bla cheirando && pode ligar)
            liga o filho meo parça
    }

    fazer o morder e cheirar as well pra ficar melhor, mas depois
    */

    private GameObject particle; //objeto com o emitter
    private ParticleSystem parSys; //referência pro particle system
    
    public GameObject partPool; //partícula na cena que vai modificar
    private ParticleSystem partPoolSys; //referência pro particle system do pool
    
    private int rowNumber; //onde vai pegar imagem na sprite sheet
    private Vector3 collidePosition; //guarda a posição de onde colidiu


    void Start()
    {
        particle = transform.GetChild(0).gameObject; //pega a partícula dentro do obj
        parSys = particle.GetComponent<ParticleSystem>(); //referência do particlesystem

        partPool = GameObject.Find("PartMistura"); //mesmas referências mas pro pool
        partPoolSys = partPool.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        var texAnim = parSys.textureSheetAnimation; //referência da animação por sheet
        //texAnim.rowIndex = rowNumber; //escolhe qual linha da animação vai usar

        MixParticles();
    }

    
    //cria partículas bonitas no lugar da colisão
    void MixParticles()
    {
        if(EstadosPlayer.gerandoParticula)
        {
            partPool.SetActive(true);

            if(collidePosition.x != 0 || collidePosition.z != 0) //move a partícula pro lugar da col
                partPool.transform.position = new Vector3 (collidePosition.x, collidePosition.y * 2, collidePosition.z);
        }
        else
        {
            partPool.SetActive(false);
        }
    }


    //liga e desliga o gerador de partícula com a colisão
    void OnTriggerEnter(Collider other) 
    {
        if(!EstadosPlayer.gerandoParticula)
        {
            EstadosPlayer.gerandoParticula = true;
            collidePosition = particle.transform.position;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(EstadosPlayer.gerandoParticula)
        {
            EstadosPlayer.gerandoParticula = false;
        }
    }
}
