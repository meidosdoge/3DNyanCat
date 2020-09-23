using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaParticula : MonoBehaviour
{
    /*
    comentário da mei pra mei, releva e ignora

    tirar esse negócio do público, usar child gameobj
    trigger collider em volta da partícula
    
    void onParticleTrigger()
    {
        pegar ex da documentação
        variável global de gerando partícula 3a = true
        if ^ true, não gera outra partícula pra evitar de gerar nos dois scripts?

        MixParticles();
    }

    void MixParticles()
    {
        gera partícula a partir do prefab
        no meio das duas no lugar onde colidiu
        fica bonito isso aí?

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
    */

    public GameObject testParticle;
    public int rowNumber = 0;
    private ParticleSystem parSys;

    void Start()
    {
        parSys = testParticle.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var texAnim = parSys.textureSheetAnimation;
        texAnim.rowIndex = rowNumber;

        //var partColor = parSys.
    }
}
