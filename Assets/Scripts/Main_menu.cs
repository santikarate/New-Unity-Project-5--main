using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public string escena;
    public GameObject panelAjustes;
    public GameObject panelNovaPartida;
    public GameObject botoAdmin;
    public void Start()
    {
        panelAjustes.SetActive(false);
        panelNovaPartida.SetActive(false);
        botoAdmin.SetActive(false);
        Time.timeScale = 1;
    }
    public void Update()
    {
        PlayerPrefs.SetInt("Partida", PlayerPrefs.GetInt("Partida") + 1);
        if (PlayerPrefs.GetInt("Partida") == 1)
        {
            print("començament");
            declararValors();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            botoAdmin.SetActive(true);
        }
    }
    private void declararValors()
    {
        //atributs per comprovar si les skins estan comprades
        PlayerPrefs.SetInt("Moneda", 0);
        PlayerPrefs.SetString("Goku_verd", "no");
        PlayerPrefs.SetString("Goku_blau", "no");
        PlayerPrefs.SetString("Goku_groc", "no");
        PlayerPrefs.SetString("Vegeta_verd", "no");
        PlayerPrefs.SetString("Vegeta_blau", "no");
        PlayerPrefs.SetString("Vegeta_groc", "no");
        PlayerPrefs.SetString("Bardok_verd", "no");
        PlayerPrefs.SetString("Bardok_blau", "no");
        PlayerPrefs.SetString("Bardok_groc", "no");
        //atributs per comprovar si els personatges estan comprats
        PlayerPrefs.SetString("Vegeta", "no");
        PlayerPrefs.SetString("Goku", "no");
        //atributs per comprovar el nivell dels personatges
        PlayerPrefs.SetInt("Nivell Goku", 0);
        PlayerPrefs.SetInt("Nivell Bardok", 0);
        PlayerPrefs.SetInt("Nivell Vegeta", 0);
        //atributs per comprovar les estadistiques dels personatges
        //Bardok
        PlayerPrefs.SetInt("Vida Bardok", 50);
        PlayerPrefs.SetInt("Mal Bardok", 1);
        PlayerPrefs.SetInt("Mana Bardok", 70);
        //Goku
        PlayerPrefs.SetInt("Vida Goku", 80);
        PlayerPrefs.SetInt("Mal Goku", 1);
        PlayerPrefs.SetInt("Mana Goku", 80);
        //Vegeta
        PlayerPrefs.SetInt("Vida Vegeta", 70);
        PlayerPrefs.SetInt("Mal Vegeta", 2);
        PlayerPrefs.SetInt("Mana Vegeta", 80);
    }
    public void EscenaJoc()
    {
        SceneManager.LoadScene(escena);
    }
    public void sortir()
    {
        Debug.Log("Ha sortit del Joc");
        Application.Quit();
    }
    public void novaPartida()
    {
        declararValors();
        SceneManager.LoadScene("Main_Menu");
    }
    public void ajustes()
    {
        panelAjustes.SetActive(true);
        panelNovaPartida.SetActive(false);
    }
    public void obrirNovaPartida()
    {
        panelNovaPartida.SetActive(true);
    }
    public void sortiNovaPartida()
    {
        panelNovaPartida.SetActive(false);
    }
    public void sortirAjustes()
    {
        panelAjustes.SetActive(false);
    }
    public void sumarMonedes()
    {
        PlayerPrefs.SetInt("Moneda", PlayerPrefs.GetInt("Moneda") + 10000);
        SceneManager.LoadScene("Main_Menu");
    }
    
}
