using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public void PlayOneShot(string evento)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(evento, this.gameObject);
    }
}