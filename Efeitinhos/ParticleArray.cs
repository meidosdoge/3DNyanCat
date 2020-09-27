using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleArray : MonoBehaviour
{
    public static ParticleArray partArray; //referência pra esse script pra facilitar chamadas

    public Sprite [] mixSpriteArray; //seleção do array da partícula
    public Sprite chosenSprite; //sprite escolhida no array de números pra passar pro outro script
    public bool settouSprite; //verifica se já trocou a sprite pra não trocar mil vezes
    
    public string currentNum1; //pega o número da sprite da partícula original1
    public string currentNum2; //pega o número da sprite da partícula original2

    public static bool settou1 = false;

    void Awake()
    {
        partArray = this; //referência pra esse script pra facilitar chamadas
    }

    void Update()
    {
        if(!settouSprite && EstadosPlayer.gerandoParticula)
        {
            ChooseSprite(); //se não tem uma sprite escolhida, escolhe uma sprite
            settouSprite = true;
        }
    }

    void ChooseSprite()
    {
        //escolhe sprite baseado no nome das duas que colidiram
        for(int i = 0; i < mixSpriteArray.Length; i++)
        {
            if(mixSpriteArray[i].name.Contains(currentNum1 + "_" + currentNum2))
            {
                chosenSprite = mixSpriteArray[i];
            }
        }      
    }
}
