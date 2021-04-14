using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public static bool gamePause;
    public static bool segurPause;
    public static bool mort;

    public GameObject menuPause, sortirPausa, mortMenu, winMenu; 
    public GameObject player, jefeFinal;
    // Start is called before the first frame update
    void Start()
    {
        menuPause.SetActive(false);
        sortirPausa.SetActive(false);
        mortMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (sortirPausa.activeSelf)
            {
                mostrarMenuPausa();
            }
        }
        if (player == null)
        {
            mortMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (jefeFinal == null)
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void mostrarMenuPausa()
    {
        if (gamePause)
        {
            btnSeguent();
        } else
        {
            btnPause();
        }
    }
    void btnSeguent()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;
        gamePause = false;
    }
    void btnPause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0;
        gamePause = true;
    }

    public void menuPrincipal (string name)
    {
        SceneManager.LoadScene(name);
    }
    public void panel2()
    {
        sortirPausa.SetActive(true);
    }
    public void sortir()
    {
        Debug.Log("Ha sortit del Joc");
        Application.Quit();
    }
    public void sortirNo()
    {
        sortirPausa.SetActive(false);
    }
}
