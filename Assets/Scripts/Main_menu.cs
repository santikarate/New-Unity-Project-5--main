﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void EscenaJoc()
    {
        SceneManager.LoadScene("Pantalla de carga");
        //StartCoroutine(this.CargarEscena());
    }
    /*IEnumerator CargarEscena()
    {
        SceneManager.LoadScene("Pantalla de carga");
        AsyncOperation operation = SceneManager.LoadSceneAsync("Pantalla de carga");
        while (!operation.isDone)
        {
            yield return null;
        }
    }*/
}
