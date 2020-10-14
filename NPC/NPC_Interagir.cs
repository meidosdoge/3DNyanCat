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
        ControlaTV();
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
}
