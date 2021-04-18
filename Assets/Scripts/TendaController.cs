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
    public Text skin_personatge;
    void Start()
    {
        infoBardok.SetActive(false);
        infoGoku.SetActive(false);
        infoVegeta.SetActive(false);
        bardokVerd.SetActive(false);
        bardokGroc.SetActive(false);
        bardokBlau.SetActive(false);
        gokuVerd.SetActive(false);
        gokuGroc.SetActive(false);
        gokuBlau.SetActive(false);
        vegetaVerd.SetActive(false);
        vegetaGroc.SetActive(false);
        vegetaBlau.SetActive(false);
        skins.SetActive(false);
        personatges.SetActive(true);
        skin_personatge.text = "Skins";
}

    public void  informacioVegeta()
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
}
