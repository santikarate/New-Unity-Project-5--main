using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladordepartida : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject bardok;
    public GameObject goku;
    public GameObject vegeta;
    public string personatge;
    void Start()
    {
        personatge = PlayerPrefs.GetString("jugador");
        if (personatge == "bardok")
        {
            bardok.SetActive(true);
        } else if (personatge == "goku")
        {
            goku.SetActive(true);
        } else if (personatge == "vegeta")
        {
            vegeta.SetActive(true);
        }
    }
}
