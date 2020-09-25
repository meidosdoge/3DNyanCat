using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public static Highlight highlightScript;
    Renderer rend;
    public bool ligaHighlight = false;
    private float valorOriginal;

    void Awake()
    {
        highlightScript = this;
    }

    void Start()
    {
        rend = GetComponent<Renderer> ();
        rend.material.shader = Shader.Find("Outlined/UltimateOutline");

        valorOriginal = rend.material.GetFloat("_FirstOutlineWidth");
        ligaHighlight = false;
    }

    void Update()
    {
        //if(ExamineObjectNew.exObNew.isCarryingObj)
        //    ligaHighlight = false;

        if(!ligaHighlight)
        {
            rend.material.SetFloat("_FirstOutlineWidth", 0);
        }
        else
        {
            rend.material.SetFloat("_FirstOutlineWidth", valorOriginal);
        }
    }

    public void liga()
    {
        ligaHighlight = true;
    }

    public void desliga()
    {
        ligaHighlight = false;
    }
}
