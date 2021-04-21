using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TendaController : MonoBehaviour
{
    public GameObject infoBardok, infoGoku, infoVegeta;
    public GameObject bardokVerd, bardokGroc, bardokBlau;
    public GameObject gokuVerd, gokuGroc, gokuBlau;
    public GameObject vegetaVerd, vegetaGroc, vegetaBlau;
    public GameObject skins, personatges;
    public GameObject comprat_Goku, comprat_Vegeta, comprat_Bardok;
    public GameObject comprar_Goku, comprar_Vegeta, comprar_Bardok;
    public Text skin_personatge, monedes_txt;
    public Text millora_Goku, millora_Vegeta, millora_Bardok;
    public Text accio_Goku, accio_Vegeta, accio_Bardok;
    public GameObject comprarGokuVerd, comprarGokuBlau, comprarGokuGroc, comprarBardokVerd, comprarBardokBlau, comprarBardokGroc, comprarVegetaVerd, comprarVegetaBlau, comprarVegetaGroc;
    public GameObject compratGokuVerd, compratGokuBlau, compratGokuGroc, compratBardokVerd, compratBardokBlau, compratBardokGroc, compratVegetaVerd, compratVegetaBlau, compratVegetaGroc;
    public Text costGokuVerd, costGokuBlau, costGokuGroc, costBardokVerd, costBardokBlau, costBardokGroc, costVegetaVerd, costVegetaBlau, costVegetaGroc;
    private int monedes;
    public Text estadistiquesBardok, estadistiquesGoku, estadistiquesVegeta;
    public GameObject preuInsuficient;

    void Start()
    {
        //declararValors();
        tancar();
        tancarInfo();
        skins.SetActive(false);
        personatges.SetActive(true);
        preuInsuficient.SetActive(false);
        skin_personatge.text = "Skins";
        monedes = PlayerPrefs.GetInt("Moneda");
        monedes_txt.text = monedes.ToString();
    }
    private void declararValors()
    {
        //atributs per comprovar si les skins estan comprades
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
    private void Update()
    {
        monedes_txt.text = monedes.ToString();
        comprovarTenda();
        estadistiques();
    }
    private void comprovarTenda()
    {
        comprovarGoku();
        comprovarVegeta();
        comprovarBardok();
        comprovarSkins();
    }
    private void estadistiques()
    {
        if(PlayerPrefs.GetString("Goku") != "no")
        {
            estadistiquesGoku.text = "Estadistiques:\n \n" +
                "Vida: " + PlayerPrefs.GetInt("Vida Goku") + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Goku") + "\n" +
                "Mal: " + PlayerPrefs.GetInt("Mal Goku")*10 + "\n" + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Goku");
        }
        else 
        {
            
        }
        if (PlayerPrefs.GetString("Vegeta") != "no")
        {
            estadistiquesVegeta.text = "Estadistiques:\n \n" +
                "Vida: " + PlayerPrefs.GetInt("Vida Vegeta") + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Vegeta") + "\n" +
                "Mal: " + PlayerPrefs.GetInt("Mal Vegeta")*10 + "\n" + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Vegeta");
        }
        else
        {
        }
        estadistiquesBardok.text = "Estadistiques:\n \n" +
                "Vida: " + PlayerPrefs.GetInt("Vida Bardok") + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Bardok") + "\n" +
                "Mal: " + PlayerPrefs.GetInt("Mal Bardok")*10 + "\n" + "\n" +
                "Mana: " + PlayerPrefs.GetInt("Mana Bardok");
    }
    private void comprovarGoku()
    {
        if (PlayerPrefs.GetString("Goku") == "no")
        {
            millora_Goku.text = "Cost: 3500";
            accio_Goku.text = "Comprar";
            comprar_Goku.SetActive(true);
            comprat_Goku.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("Nivell Goku") == 0)
            {
                millora_Goku.text = "Millores: \n" +
                    "Mal + 10\n" +
                    "Mana + 10\n" +
                    "Cost: 4000";
                accio_Goku.text = "Millorar";
                comprar_Goku.SetActive(true);
                comprat_Goku.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 1)
            {
                millora_Goku.text = "Millores:\n" +
                    "Vida + 20\n" +
                    "Mal + 10\n" +
                    "Cost: 5000";
                accio_Goku.text = "Millorar";
                comprar_Goku.SetActive(true);
                comprat_Goku.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 2)
            {
                millora_Goku.text = "Millores:\n" +
                    "Mana + 20\n" +
                    "Mal + 10\n" +
                    "Cost: 6250";
                accio_Goku.text = "Millorar";
                comprar_Goku.SetActive(true);
                comprat_Goku.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 3)
            {
                millora_Goku.text = "Millores:\n" +
                    "Vida + 10\n" +
                    "Mal + 10\n" +
                    "Cost: 7500";
                accio_Goku.text = "Millorar";
                comprar_Goku.SetActive(true);
                comprat_Goku.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 4)
            {
                millora_Goku.text = "Millores:\n" +
                    "Vida + 10\n" +
                    "Mal + 10\n" +
                    "Cost: 8000";
                accio_Goku.text = "Millorar";
                comprar_Goku.SetActive(true);
                comprat_Goku.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 5)
            {
                millora_Goku.text = "Millorat al màxim";
                comprar_Goku.SetActive(false);
                comprat_Goku.SetActive(true);
            }
        }
    }
    private void comprovarVegeta()
    {
        if (PlayerPrefs.GetString("Vegeta") == "no")
        {
            millora_Vegeta.text = "Cost: 8500";
            accio_Vegeta.text = "Comprar";
            comprar_Vegeta.SetActive(true);
            comprat_Vegeta.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("Nivell Vegeta") == 0)
            {
                millora_Vegeta.text = "Milores: \n" +
                    "Vida + 20\n" +
                    "Mal + 10\n" +
                    "Cost: 10000";
                accio_Vegeta.text = "Millorar";
                comprar_Vegeta.SetActive(true);
                comprat_Vegeta.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 1)
            {
                millora_Vegeta.text = "Milores: \n" +
                    "Mana + 10\n" +
                    "Mal + 10\n" +
                    "Cost: 12000";
                accio_Vegeta.text = "Millorar";
                comprar_Vegeta.SetActive(true);
                comprat_Vegeta.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 2)
            {
                millora_Vegeta.text = "Milores: \n" +
                     "Mana + 20\n" +
                     "Mal + 10\n" +
                     "Cost: 14000";
                accio_Vegeta.text = "Millorar";
                comprar_Vegeta.SetActive(true);
                comprat_Vegeta.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 3)
            {
                millora_Vegeta.text = "Milores: \n" +
                    "Vida + 20\n" +
                    "Mal + 10\n" +
                    "Cost: 15500 ";
                accio_Vegeta.text = "Millorar";
                comprar_Vegeta.SetActive(true);
                comprat_Vegeta.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 4)
            {
                millora_Vegeta.text = "Milores: \n" +
                    "Vida + 20\n" +
                    "Mal + 20\n" +
                    "Cost: 17000 ";
                accio_Vegeta.text = "Millorar";
                comprar_Vegeta.SetActive(true);
                comprat_Vegeta.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 5)
            {
                millora_Vegeta.text = "Millorat al màxim";
                comprar_Vegeta.SetActive(false);
                comprat_Vegeta.SetActive(true);
            }
        }
    }
    private void comprovarBardok()
    {
        if (PlayerPrefs.GetInt("Nivell Bardok") == 0)
        {
            millora_Bardok.text = "Millores: \n" +
                "Vida + 10\n" +
                "Mana + 10\n" +
                "Cost: 750";
            accio_Bardok.text = "Millorar";
            comprar_Bardok.SetActive(true);
            comprat_Bardok.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 1)
        {
            millora_Bardok.text = "Millores: \n" +
                "Mana + 20\n" +
                "Mal + 10\n" +
                "Cost: 1500";
            accio_Bardok.text = "Millorar";
            comprar_Bardok.SetActive(true);
            comprat_Bardok.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 2)
        {
            millora_Bardok.text = "Millores: \n" +
                "Vida + 20\n" +
                "Mal + 10\n" +
                "Cost: 2200";
            accio_Bardok.text = "Millorar";
            comprar_Bardok.SetActive(true);
            comprat_Bardok.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 3)
        {
            millora_Bardok.text = "Millores: \n" +
                "Mana + 20\n" +
                "Vida + 10\n" +
                "Cost: 3000";
            accio_Bardok.text = "Millorar";
            comprar_Bardok.SetActive(true);
            comprat_Bardok.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 4)
        {
            millora_Bardok.text = "Millores: \n" +
                "Vida + 10\n" +
                "Mal + 10\n" +
                "Cost: 4500";
            accio_Bardok.text = "Millorar";
            comprar_Bardok.SetActive(true);
            comprat_Bardok.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 5)
        {
            millora_Bardok.text = "Millorat al maxim";
            comprar_Bardok.SetActive(false);
            comprat_Bardok.SetActive(true);
        }
    }
    private void comprovarSkins()
    {
        if (PlayerPrefs.GetString("Goku") == "no")
        {
            comprarGokuVerd.SetActive(false);
            compratGokuVerd.SetActive(false);
            costGokuVerd.text = "Comprar primer el personatge: Goku";
            comprarGokuBlau.SetActive(false);
            compratGokuBlau.SetActive(false);
            costGokuBlau.text = "Comprar primer el personatge: Goku";
            comprarGokuGroc.SetActive(false);
            compratGokuGroc.SetActive(false);
            costGokuGroc.text = "Comprar primer el personatge: Goku";
        }
        else
        {
            if (PlayerPrefs.GetString("Goku_verd") == "no")
            {
                comprarGokuVerd.SetActive(true);
                compratGokuVerd.SetActive(false);
                costGokuVerd.text = "Cost: 5000";
            }
            else
            {
                comprarGokuVerd.SetActive(false);
                compratGokuVerd.SetActive(true);
                costGokuVerd.text = "";
            }
            if (PlayerPrefs.GetString("Goku_blau") == "no")
            {
                comprarGokuBlau.SetActive(true);
                compratGokuBlau.SetActive(false);
                costGokuBlau.text = "Cost: 6000";
            }
            else
            {
                comprarGokuBlau.SetActive(false);
                compratGokuBlau.SetActive(true);
                costGokuBlau.text = "";
            }
            if (PlayerPrefs.GetString("Goku_groc") == "no")
            {
                comprarGokuGroc.SetActive(true);
                compratGokuGroc.SetActive(false);
                costGokuGroc.text = "Cost: 7000";
            }
            else
            {
                comprarGokuGroc.SetActive(true);
                compratGokuGroc.SetActive(false);
                costGokuGroc.text = "";
            }
        }
        if (PlayerPrefs.GetString("Vegeta") == "no")
        {
            comprarVegetaVerd.SetActive(false);
            compratVegetaVerd.SetActive(false);
            costVegetaVerd.text = "Comprar primer el personatge: Vegeta";
            comprarVegetaBlau.SetActive(false);
            compratVegetaBlau.SetActive(false);
            costVegetaBlau.text = "Comprar primer el personatge: Vegeta";
            comprarVegetaGroc.SetActive(false);
            compratVegetaGroc.SetActive(false);
            costVegetaGroc.text = "Comprar primer el personatge: Vegeta";
        }
        else
        {
            if (PlayerPrefs.GetString("Vegeta_verd") == "no")
            {
                comprarVegetaVerd.SetActive(true);
                compratVegetaVerd.SetActive(false);
                costVegetaVerd.text = "Cost: 5000";
            }
            else
            {
                comprarVegetaVerd.SetActive(false);
                compratVegetaVerd.SetActive(true);
                costVegetaVerd.text = "";
            }
            if (PlayerPrefs.GetString("Vegeta_blau") == "no")
            {
                comprarVegetaBlau.SetActive(true);
                compratVegetaBlau.SetActive(false);
                costVegetaBlau.text = "Cost: 6000";
            }
            else
            {
                comprarVegetaBlau.SetActive(false);
                compratVegetaBlau.SetActive(true);
                costVegetaBlau.text = "";
            }
            if (PlayerPrefs.GetString("Vegeta_groc") == "no")
            {
                comprarVegetaGroc.SetActive(true);
                compratVegetaGroc.SetActive(false);
                costVegetaGroc.text = "Cost: 7000";
            }
            else
            {
                comprarVegetaGroc.SetActive(true);
                compratVegetaGroc.SetActive(false);
                costVegetaGroc.text = "";
            }
        }
        if (PlayerPrefs.GetString("Bardok_verd") == "no")
        {
            comprarBardokVerd.SetActive(true);
            compratBardokVerd.SetActive(false);
            costBardokVerd.text = "Cost: 5000";
        }
        else
        {
            comprarBardokVerd.SetActive(false);
            compratBardokVerd.SetActive(true);
            costBardokVerd.text = "";
        }
        if (PlayerPrefs.GetString("Bardok_blau") == "no")
        {
            comprarBardokBlau.SetActive(true);
            compratBardokBlau.SetActive(false);
            costBardokBlau.text = "Cost: 6000";
        }
        else
        {
            comprarBardokBlau.SetActive(false);
            compratBardokBlau.SetActive(true);
            costBardokBlau.text = "";
        }
        if (PlayerPrefs.GetString("Bardok_groc") == "no")
        {
            comprarBardokGroc.SetActive(true);
            compratBardokGroc.SetActive(false);
            costBardokGroc.text = "Cost: 7000";
        }
        else
        {
            comprarBardokGroc.SetActive(true);
            compratBardokGroc.SetActive(false);
            costBardokGroc.text = "";
        }
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Moneda", monedes);
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
    public void pantallaSkins()
    {
        if (skin_personatge.text == "Skins")
        {
            skin_personatge.text = "Personatges";
            tancarInfo();
            skins.SetActive(true);
            personatges.SetActive(false);
        } else
        {
            skin_personatge.text = "Skins";
            tancar();
            skins.SetActive(false);
            personatges.SetActive(true);
        }
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

    public void tornarEnrere()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void millorarGoku() {
        if (PlayerPrefs.GetString("Goku") == "no")
        {
            if (monedes >= 3500)
            {
                monedes = monedes - 3500;
                PlayerPrefs.SetString("Goku", "si");
            } else
            {
                preuInsuficient.SetActive(true);
            }
        } else
        {
            if (PlayerPrefs.GetInt("Nivell Goku") == 0)
            {
                if (monedes >= 4000)
                {
                    monedes = monedes - 4000;
                    PlayerPrefs.SetInt("Nivell Goku", 1);
                    PlayerPrefs.SetInt("Mal Goku", PlayerPrefs.GetInt("Mal Goku") + 1);
                    PlayerPrefs.SetInt("Mana Goku", PlayerPrefs.GetInt("Mana Goku") + 10);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 1)
            {
                if (monedes >= 5000)
                {
                    monedes = monedes - 5000;
                    PlayerPrefs.SetInt("Nivell Goku", 2);
                    PlayerPrefs.SetInt("Mal Goku", PlayerPrefs.GetInt("Mal Goku") + 1);
                    PlayerPrefs.SetInt("Vida Goku", PlayerPrefs.GetInt("Vida Goku") + 20);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 2)
            {
                if (monedes >= 6250)
                {
                    monedes = monedes - 6250;
                    PlayerPrefs.SetInt("Nivell Goku", 3);
                    PlayerPrefs.SetInt("Mal Goku", PlayerPrefs.GetInt("Mal Goku") + 1);
                    PlayerPrefs.SetInt("Mana Goku", PlayerPrefs.GetInt("Mana Goku") + 20);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 3)
            {
                if (monedes >= 7500)
                {
                    monedes = monedes - 7500;
                    PlayerPrefs.SetInt("Nivell Goku", 4);
                    PlayerPrefs.SetInt("Mal Goku", PlayerPrefs.GetInt("Mal Goku") + 1);
                    PlayerPrefs.SetInt("Vida Goku", PlayerPrefs.GetInt("Vida Goku") + 10);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Nivell Goku") == 4)
            {
                if (monedes >= 8000)
                {
                    monedes = monedes - 8000;
                    PlayerPrefs.SetInt("Nivell Goku", 5);
                    PlayerPrefs.SetInt("Mal Goku", PlayerPrefs.GetInt("Mal Goku") + 1);
                    PlayerPrefs.SetInt("Vida Goku", PlayerPrefs.GetInt("Vida Goku") + 10);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
        }
    }
    public void millorarVegeta()
    {
        if (PlayerPrefs.GetString("Vegeta") == "no")
        {
            if (monedes >= 8500)
            {
                monedes = monedes - 8500;
                PlayerPrefs.SetString("Vegeta", "si");
            }
            else
            {
                preuInsuficient.SetActive(true);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("Nivell Vegeta") == 0)
            {
                if (monedes >= 10000)
                {
                    monedes = monedes - 10000;
                    PlayerPrefs.SetInt("Nivell Vegeta", 1);
                    PlayerPrefs.SetInt("Mal Vegeta", PlayerPrefs.GetInt("Mal Vegeta") + 1);
                    PlayerPrefs.SetInt("Vida Vegeta", PlayerPrefs.GetInt("Vida Vegeta") + 20);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 1)
            {
                if (monedes >= 12000)
                {
                    monedes = monedes - 12000;
                    PlayerPrefs.SetInt("Nivell Vegeta", 2);
                    PlayerPrefs.SetInt("Mal Vegeta", PlayerPrefs.GetInt("Mal Vegeta") + 1);
                    PlayerPrefs.SetInt("Mana Vegeta", PlayerPrefs.GetInt("Mana Vegeta") + 10);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 2)
            {
                if (monedes >= 14000)
                {
                    monedes = monedes - 14000;
                    PlayerPrefs.SetInt("Nivell Vegeta", 3);
                    PlayerPrefs.SetInt("Mal Vegeta", PlayerPrefs.GetInt("Mal Vegeta") + 1);
                    PlayerPrefs.SetInt("Mana Vegeta", PlayerPrefs.GetInt("Vida Vegeta") + 20);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 3)
            {
                if (monedes >= 15500)
                {
                    monedes = monedes - 15500;
                    PlayerPrefs.SetInt("Nivell Vegeta", 4);
                    PlayerPrefs.SetInt("Mal Vegeta", PlayerPrefs.GetInt("Mal Vegeta") + 1);
                    PlayerPrefs.SetInt("Vida Vegeta", PlayerPrefs.GetInt("Vida Vegeta") + 20);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Nivell Vegeta") == 4)
            {
                if (monedes >= 17000)
                {
                    monedes = monedes - 17000;
                    PlayerPrefs.SetInt("Nivell Vegeta", 5);
                    PlayerPrefs.SetInt("Mal Vegeta", PlayerPrefs.GetInt("Mal Vegeta") + 2);
                    PlayerPrefs.SetInt("Vida Vegeta", PlayerPrefs.GetInt("Vida Vegeta") + 20);
                }
                else
                {
                    preuInsuficient.SetActive(true);
                }
            }
        }
    }
    public void millorarBardok()
    {
        if (PlayerPrefs.GetInt("Nivell Bardok") == 0)
        {
            if (monedes >= 750)
            {
                monedes = monedes - 750;
                PlayerPrefs.SetInt("Nivell Bardok", 1);
                PlayerPrefs.SetInt("Vida Bardok", PlayerPrefs.GetInt("Vida Bardok") + 10);
                PlayerPrefs.SetInt("Mana Bardok", PlayerPrefs.GetInt("Mana Bardok") + 10);
            }
            else
            {
                preuInsuficient.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 1)
        {
            if (monedes >= 1500)
            {
                monedes = monedes - 1500;
                PlayerPrefs.SetInt("Nivell Bardok", 2);
                PlayerPrefs.SetInt("Mal Bardok", PlayerPrefs.GetInt("Mal Bardok") + 1);
                PlayerPrefs.SetInt("Mana Bardok", PlayerPrefs.GetInt("Mana Bardok") + 20);
            }
            else
            {
                preuInsuficient.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 2)
        {
            if (monedes >= 2200)
            {
                monedes = monedes - 2200;
                PlayerPrefs.SetInt("Nivell Bardok", 3);
                PlayerPrefs.SetInt("Mal Bardok", PlayerPrefs.GetInt("Mal Bardok") + 1);
                PlayerPrefs.SetInt("Vida Bardok", PlayerPrefs.GetInt("Vida Bardok") + 20);
            }
            else
            {
                preuInsuficient.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 3)
        {
            if (monedes >= 3000)
            {
                monedes = monedes - 3000;
                PlayerPrefs.SetInt("Nivell Bardok", 4);
                PlayerPrefs.SetInt("Mana Bardok", PlayerPrefs.GetInt("Mana Bardok") + 20);
                PlayerPrefs.SetInt("Vida Bardok", PlayerPrefs.GetInt("Vida Bardok") + 10);
            }
            else
            {
                preuInsuficient.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("Nivell Bardok") == 4)
        {
            if (monedes >= 4500)
            {
                monedes = monedes - 4500;
                PlayerPrefs.SetInt("Nivell Bardok", 5);
                PlayerPrefs.SetInt("Mal Bardok", PlayerPrefs.GetInt("Mal Bardok") + 1);
                PlayerPrefs.SetInt("Vida Bardok", PlayerPrefs.GetInt("Vida Bardok") + 10);
            }
            else
            {
                preuInsuficient.SetActive(true);
            }
        }
    }
    public void compraGokuVerd()
    {
        if (monedes >= 5000)
        {
            monedes = monedes - 5000;
            PlayerPrefs.SetString("Goku_verd", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void compraGokuBlau()
    {
        if (monedes >= 6000)
        {
            monedes = monedes - 6000;
            PlayerPrefs.SetString("Goku_blau", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void compraGokuGroc()
    {
        if (monedes >= 7000)
        {
            monedes = monedes - 7000;
            PlayerPrefs.SetString("Goku_groc", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void compraVegetaVerd()
    {
        if (monedes >= 5000)
        {
            monedes = monedes - 5000;
            PlayerPrefs.SetString("Vegeta_verd", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void compraVegetaBlau()
    {
        if (monedes >= 6000)
        {
            monedes = monedes - 6000;
            PlayerPrefs.SetString("Vegeta_blau", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void compraVegetaGroc()
    {
        if (monedes >= 7000)
        {
            monedes = monedes - 7000;
            PlayerPrefs.SetString("Vegeta_groc", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void compraBardokVerd()
    {
        if (monedes >= 5000)
        {
            monedes = monedes - 5000;
            PlayerPrefs.SetString("Bardok_verd", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void compraBardokBlau()
    {
        if (monedes >= 6000)
        {
            monedes = monedes - 6000;
            PlayerPrefs.SetString("Bardok_blau", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void compraBardokGroc()
    {
        if (monedes >= 7000)
        {
            monedes = monedes - 7000;
            PlayerPrefs.SetString("Bardok_groc", "si");
        }
        else
        {
            preuInsuficient.SetActive(true);
        }
    }
    public void tancarAlerta()
    {
        preuInsuficient.SetActive(false);
    }
}
