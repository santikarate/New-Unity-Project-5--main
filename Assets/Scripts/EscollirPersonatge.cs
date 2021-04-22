using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EscollirPersonatge : MonoBehaviour
{
    public GameObject infoBardok, infoGoku, infoVegeta;
    public GameObject bardokVerd, bardokGroc, bardokBlau;
    public GameObject gokuVerd, gokuGroc, gokuBlau;
    public GameObject vegetaVerd, vegetaGroc, vegetaBlau;
    public GameObject skins, personatges;
    public Text skin_personatge;
    public GameObject gokuComprat, vegetaComprat;
    public GameObject bardokVerdComprat, bardokGrocComprat, bardokBlauComprat;
    public GameObject gokuVerdComprat, gokuGrocComprat, gokuBlauComprat;
    public GameObject vegetaVerdComprat, vegetaGrocComprat, vegetaBlauComprat;
    public Text estadistiquesBardok, estadistiquesGoku, estadistiquesVegeta;
    // Start is called before the first frame update
    void Start()
    {
        skins.SetActive(false);
        personatges.SetActive(true);
        tancar();
        tancarInfo();
    }
    private void Update()
    {
        comprovar();
    }
    private void comprovar()
    {
        if (PlayerPrefs.GetString("Goku_verd") == "no")
        {
            gokuVerdComprat.SetActive(false);
        }
        else
        {
            gokuVerdComprat.SetActive(true);
        }
        if(PlayerPrefs.GetString("Goku_blau") == "no"){
            gokuBlauComprat.SetActive(false);
        } else
        {
            gokuBlauComprat.SetActive(true);
        }
        if(PlayerPrefs.GetString("Goku_groc") == "no")
        {
            gokuGrocComprat.SetActive(false);
        } else
        {
            gokuGrocComprat.SetActive(true);
        }
        if(PlayerPrefs.GetString("Vegeta_verd") == "no")
        {
            vegetaVerdComprat.SetActive(false);
        }
        else
        {
            vegetaVerdComprat.SetActive(true);
        }
        if(PlayerPrefs.GetString("Vegeta_blau") == "no")
        {
            vegetaBlauComprat.SetActive(false);
        }
        else
        {
            vegetaBlauComprat.SetActive(true);
        }
        if(PlayerPrefs.GetString("Vegeta_groc") == "no")
        {
            vegetaGrocComprat.SetActive(false);
        } else
        {
            vegetaGrocComprat.SetActive(true);
        }
        if (PlayerPrefs.GetString("Bardok_verd") == "no")
        {
            bardokVerdComprat.SetActive(false);
        }
        else
        {
            bardokVerdComprat.SetActive(true);
        }
        if (PlayerPrefs.GetString("Bardok_blau") == "no")
        {
            bardokBlauComprat.SetActive(false);
        } else
        {
            bardokBlauComprat.SetActive(true);
        }
        if(PlayerPrefs.GetString("Bardok_groc") == "no")
        {
            bardokGrocComprat.SetActive(false);
        }
        else
        {
            bardokGrocComprat.SetActive(true);
        }
        if(PlayerPrefs.GetString("Vegeta") == "no")
        {
            vegetaComprat.SetActive(false);
            estadistiquesVegeta.text = "";
        } else
        {
            vegetaComprat.SetActive(true);
            estadistiquesVegeta.text = "Estadistiques:\n \n" +
                "Vida: " + PlayerPrefs.GetInt("Vida Vegeta") + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Vegeta") + "\n" +
                "Mal: " + PlayerPrefs.GetInt("Mal Vegeta") * 10 + "\n" + "\n" +
                "Nivell: " + PlayerPrefs.GetInt("Nivell Vegeta");
        }
        if (PlayerPrefs.GetString("Goku") == "no")
        {
            gokuComprat.SetActive(false);
            estadistiquesGoku.text = "";
        } else
        {
            estadistiquesGoku.text = "Estadistiques:\n \n" +
                "Vida: " + PlayerPrefs.GetInt("Vida Goku") + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Goku") + "\n" +
                "Mal: " + PlayerPrefs.GetInt("Mal Goku") * 10 + "\n" + "\n" +
                "Nivell: " + PlayerPrefs.GetInt("Nivell Goku");
            gokuComprat.SetActive(true);
        }
        estadistiquesBardok.text = "Estadistiques:\n \n" +
                "Vida: " + PlayerPrefs.GetInt("Vida Bardok") + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Bardok") + "\n" +
                "Mal: " + PlayerPrefs.GetInt("Mal Bardok") * 10 + "\n" + "\n" +
                "Nivell: " + PlayerPrefs.GetInt("Nivell Bardok");
    }
    public void bardokVerdPantalla()
    {
        bardokVerd.SetActive(true);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
    }
    public void bardokGrocPantalla()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(true);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
    }
    public void bardokBlauPantalla()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(true);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
    }
    public void gokuVerdPantalla()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(true);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
    }
    public void gokuGrocPantalla()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(true);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
    }
    public void gokuBlauPantalla()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(true);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
    }
    public void vegetaVerdPantalla()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(true);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
    }
    public void vegetaGrocPantalla()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(true);
        vegetaBlau.SetActive(false);
    }
    public void vegetaBlauPantalla()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(true);
    }

    public void tancar()
    {
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
    }
    public void informacioVegeta()
    {
        infoBardok.SetActive(false);
        infoGoku.SetActive(false);
        infoVegeta.SetActive(true);
    }
    public void informacioGoku()
    {
        infoBardok.SetActive(false);
        infoGoku.SetActive(true);
        infoVegeta.SetActive(false);
    }
    public void informacioBardok()
    {
        infoBardok.SetActive(true);
        infoGoku.SetActive(false);
        infoVegeta.SetActive(false);
    }
    public void tancarInfo()
    {
        infoBardok.SetActive(false);
        infoGoku.SetActive(false);
        infoVegeta.SetActive(false);
    }
    public void tornarEnrere()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void pantallaSkins()
    {
        if (skin_personatge.text == "Skins")
        {
            skin_personatge.text = "Personatges";
            tancarInfo();
            skins.SetActive(true);
            personatges.SetActive(false);
        }
        else
        {
            skin_personatge.text = "Skins";
            tancar();
            skins.SetActive(false);
            personatges.SetActive(true);
        }
    }
    public void seleccionarGoku()
    {
        PlayerPrefs.SetString("Player", "Goku");
        PlayerPrefs.SetString("Color", "Blanc");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarGokuVerd()
    {
        PlayerPrefs.SetString("Player", "Goku");
        PlayerPrefs.SetString("Color", "Verd");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarGokuBlau()
    {
        PlayerPrefs.SetString("Player", "Goku");
        PlayerPrefs.SetString("Color", "Blau");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarGokuGroc()
    {
        PlayerPrefs.SetString("Player", "Goku");
        PlayerPrefs.SetString("Color", "Groc");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarVegeta()
    {
        PlayerPrefs.SetString("Player", "Vegeta");
        PlayerPrefs.SetString("Color", "Blanc");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarVegetaVerd()
    {
        PlayerPrefs.SetString("Player", "Vegeta");
        PlayerPrefs.SetString("Color", "Verd");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarVegetaBlau()
    {
        PlayerPrefs.SetString("Player", "Vegeta");
        PlayerPrefs.SetString("Color", "Blau");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarVegetaGroc()
    {
        PlayerPrefs.SetString("Player", "Vegeta");
        PlayerPrefs.SetString("Color", "Groc");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarBardok()
    {
        PlayerPrefs.SetString("Player", "Bardok");
        PlayerPrefs.SetString("Color", "Blanc");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarBardokVerd()
    {
        PlayerPrefs.SetString("Player", "Bardok");
        PlayerPrefs.SetString("Color", "Verd");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarBardokBlau()
    {
        PlayerPrefs.SetString("Player", "Bardok");
        PlayerPrefs.SetString("Color", "Blau");
        SceneManager.LoadScene("Pantalla de carga");
    }
    public void seleccionarBardokGorc()
    {
        PlayerPrefs.SetString("Player", "Bardok");
        PlayerPrefs.SetString("Color", "Gorc");
        SceneManager.LoadScene("Pantalla de carga");
    }
}
