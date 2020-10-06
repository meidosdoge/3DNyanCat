using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaParticula : MonoBehaviour
{
    private GameObject particle; //objeto com o emitter
    private ParticleSystem parSys; //referência pro particle system
    
    public GameObject partPool; //partícula na cena que vai modificar
    private ParticleSystem partPoolSys; //referência pro particle system do pool
    
    private Vector3 collidePosition; //guarda a posição de onde colidiu

    private bool addedSprite = false; //checa se já trocou a partícula

    public Color color1, color2; //cores das partículas originais

    public bool podeAtivarPart; //checa se já cheirou o obj pra poder ligar partícula 

    void Start()
    {
        particle = transform.GetChild(0).gameObject; //pega a partícula dentro do obj
        parSys = particle.GetComponent<ParticleSystem>(); //referência do particlesystem

        partPool = GameObject.Find("PartMistura"); //mesmas referências mas pro pool
        partPoolSys = partPool.GetComponent<ParticleSystem>();

        particle.SetActive(false);        
    }
    void Update()
    {
        AtivaParticles();
    }


    void AtivaParticles()
    {
        //vê se tá cheirando e se já interagiu com a partícula
        //se sim, liga a partícula e faz o mix; se não, desliga

        if(podeAtivarPart && EstadosPlayer.estadoCheirando)
        {
            particle.SetActive(true);
            MixParticles();
        }
        else if (!podeAtivarPart)
        {
            particle.SetActive(false);
        }
        else if (EstadosPlayer.estadoCheirando == false)
        {
            //desliga as todas as partículas e desfaz o mix
            particle.SetActive(false);
            partPool.SetActive(false);

            EstadosPlayer.gerandoParticula = false;
            ParticleArray.settou1 = false;
        }
    }

    
    //cria partículas bonitas no lugar da colisão
    void MixParticles()
    {
        var texAnim = parSys.textureSheetAnimation; //referência da animação por sheet
        var mixTexAnim = partPoolSys.textureSheetAnimation; //referência da animação por sheet da mistura


        if(EstadosPlayer.gerandoParticula)
        {  
            partPool.SetActive(true); //ativa a partícula mistura

            //move a partícula pro lugar da col
            if(collidePosition.x != 0 || collidePosition.z != 0) 
                partPool.transform.position = new Vector3 (collidePosition.x, collidePosition.y + 1, collidePosition.z);

            //muda a sprite
            if(!addedSprite)
            {
                mixTexAnim.SetSprite(0, ParticleArray.partArray.chosenSprite); //usa a sprite escolhida no script particle array
                addedSprite = true;
            }
        }
        else
        {   
            color1 = Color.white;
            color2 = Color.white;

            collidePosition = Vector3.zero; //AMÉM ANDRÉ :goodjob:
            partPool.SetActive(false);  //desativa a partícula de mistura na cena
            addedSprite = false; //limpa a sprite 
            ParticleArray.partArray.settouSprite = false;
        }
    }

    void MixColor()
    {
        //pega as duas cores de partículas e soma os valores r g b 
        float newR = (color1.r + color2.r) / 2;
        float newG = (color1.g + color2.g) / 2;
        float newB = (color1.b + color2.b) / 2;

        //referência da partícula misturada
        var mainPool = partPoolSys.main;

        //se a cor escolhida não for branco, atribui pra partícula de mistura
        if(newR != 0 || newG != 0 || newB != 0)
            mainPool.startColor = new Color(newR, newG, newB, 1f);
    }


    //liga e desliga o gerador de partícula com a colisão
    void OnTriggerEnter(Collider other) 
    {
        var texAnim = parSys.textureSheetAnimation; //referência da animação por sheet
        var mainParticle = parSys.main; //referência de cores das partículas
        var mainParticle2 = other.gameObject.GetComponent<ParticleSystem>().main;

        //pega cor das duas partículas
        color1 = mainParticle.startColor.color;
        color2 = mainParticle2.startColor.color;
        MixColor();
        
        if(!EstadosPlayer.gerandoParticula)
        {
            if(!ParticleArray.settou1) 
            {
                //pega o número da primeira partícula
                ParticleArray.partArray.currentNum1 = texAnim.GetSprite(0).name;
                ParticleArray.settou1 = true;
            }
            else
            {
                //pega o número da segunda partícula
                ParticleArray.partArray.currentNum2 = texAnim.GetSprite(0).name;
                
                //liga o gerador de partícula e pega a posição da colisão
                EstadosPlayer.gerandoParticula = true;
                collidePosition = particle.transform.position;
            }  
        }
    }
    void OnTriggerExit(Collider other)
    {
        EstadosPlayer.gerandoParticula = false;
        ParticleArray.settou1 = false;
    }
}