using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladordepartida : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject bardok;
    public GameObject goku;
    public GameObject vegeta;
    private string personatge;
    void Start()
    {
        personatge = PlayerPrefs.GetString("Player");
        if (personatge == "Bardok")
        {
            bardok.SetActive(true);
        } else if (personatge == "Goku")
        {
            goku.SetActive(true);
        } else if (personatge == "Vegeta")
        {
            vegeta.SetActive(true);
        }
    }
}
