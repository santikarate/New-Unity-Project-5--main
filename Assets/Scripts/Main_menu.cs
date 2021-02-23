using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void EscenaJoc()
    {
        StartCoroutine(CargarEscena());
    }
    IEnumerator CargarEscena()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level1");
        while (!operation.isDone)
        {
            yield return null;

        }
    }
}
