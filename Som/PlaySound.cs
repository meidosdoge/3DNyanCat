using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public int waitTime = 2; //tempo antes de desligar

    public void PlayOneShot(string evento)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(evento, this.gameObject);
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            StartCoroutine(DesligaObj());
        }
    }

    public IEnumerator DesligaObj ()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}