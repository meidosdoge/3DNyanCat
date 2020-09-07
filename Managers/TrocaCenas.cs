using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCenas : MonoBehaviour
{
    public void ChangeScene(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("EndGame");
    }

    public void EnableObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    
    public void DisableObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
