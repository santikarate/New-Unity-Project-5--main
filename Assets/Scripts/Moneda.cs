using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneda : MonoBehaviour
{
    // Start is called before the first frame update

    private string textValue;
    public Text textElement;
    void Start()
    {
        textValue = PlayerPrefs.GetInt("Moneda").ToString();
        textElement.text = textValue;
    }

    // Update is called once per frame
    void Update()
    {
        textElement.text = textValue;
    }
}
