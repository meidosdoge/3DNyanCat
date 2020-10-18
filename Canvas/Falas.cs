using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Falas : MonoBehaviour
{
    //recebe o nome do arquivo pra pegar o arquivo dentro da pasta
    public string nomeArquivoComTexto;

    //string que recebe todos os caracteres do arquivo
    public string arquivoDeTexto;

    //letras Por Segundo 
    public float LPS, LPSOriginal;

    //timer para colocar a proxima letra
    float tempo;

    //quando ele identifica que o paragrafo acabou,
    //ele para de correr o texto até o mouse ser pressionado e pular pro proximo
    bool correTempo = true;

    //recebe o tempo até a proxima letra ser colocada
    int i;

    //recebe o objeto de texto que receberá a fala
    public Text balao;

    bool comecaTexto;


    void Start()
    {
        LPSOriginal = LPS;

        //NAO PODE MUDAR A PASTA QUE ESTÃO OS TEXTOS
        arquivoDeTexto = File.ReadAllText("Assets\\_Falas\\" + nomeArquivoComTexto + ".txt");

        balao.text = "";
    }

    private void OnEnable()
    {
        comecaTexto = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (comecaTexto)
            LeArquivoDeTexto();
    }

    void LeArquivoDeTexto()
    {
        SoundManager.sound.DogMove(false);

        tempo += Time.deltaTime;

        //aumenta a velocidade do texto quando clica com o mouse
        if (Input.GetMouseButtonDown(0))
        {
            LPS *= 3;
        }

        //adiciona a proxima letra quando der o tempo pra fazer isso
        //identifica quando o arquivo de texto acaba
        if(tempo > (1f/LPS) && i < arquivoDeTexto.Length)
        {
            DesativaMovPlayer.desMov.DesativaMov();

            //chama som de fala
            SoundManager.sound.VozNPC(true);

            //ação pra quando ele encontra um traço no arquivo de texto
            //que marca o inicio de outro paragrafo
            if (arquivoDeTexto[i] == '-')
            {
                correTempo = false;

                //reseta a velocidade do texto, apaga o texto pra receber o proximo paragrafo
                //e volta a correr o texto quando o jogador clicar
                if (Input.GetMouseButtonDown(0))
                {
                    LPS = LPSOriginal;
                    balao.text = "";
                    i++;
                    correTempo = true;

                    SoundManager.sound.VozNPC(false);
                }
            }

            //se estiver no texto normal, ele continua adicionando as letras
            //ate achar um traço e fazer o processo acima
            else
            {
                //adiciona as letras do arquivo de texto
                balao.text += arquivoDeTexto[i];
            }

            if (correTempo)
            {
                //zera o contador pra colocar a proxima letra
                tempo = 0;

                //passa pra proxima letra
                i++;
            }
                
        }


        //desliga o objeto de texto quando o texto acabar e o jogador fechar ele
        else if (i >= arquivoDeTexto.Length && Input.GetMouseButtonUp(0))
        {
            balao.text = "";
            i = 0;
            LPS = LPSOriginal;
            this.gameObject.SetActive(false);
            DesativaMovPlayer.desMov.AtivaMov();

            SoundManager.sound.VozNPC(false);
        }
    }
}
