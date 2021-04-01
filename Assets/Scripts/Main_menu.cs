using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public string escena;
    public void EscenaJoc()
    {
        SceneManager.LoadScene(escena);
    }
}
