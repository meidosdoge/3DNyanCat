using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interagir : MonoBehaviour
{
    //itens com que o npc interage
    public GameObject controleTV;

    //itens que sofrem modificação
    public GameObject telaTV;

    public bool pegandoControle = false;


    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("NPC interage"))
        {
            //realiza ação
        }
    }


    void ControlaTV()
    {
        if(pegandoControle)
        {
            telaTV.SetActive(true);
            SoundManager.sound.SomTV(true);
        }
        else
        {
            telaTV.SetActive(false);
            SoundManager.sound.SomTV(false);
        }
    }

    /*
    movimenta npc de acordo com o navmesh pra não bater nas coisa
    fazer máquina pela btree
    escolhe pontos aleatórios dentro da mesh e vai

    se passa em um obj que interage, interrompe mov e usa obj
    depois de um intervalo no obj, volta mov

    colocar objs: controle, pia, cadeira por enquanto
    fazer isso de forma que dê pra adicionar outros objs depois
    então sem bools complicadas e específicas

    depois, fazer ranged view
    se ver o player, persegue
    se não vê mais o player, para
    se chega perto do player, reseta o nível
    */
}
