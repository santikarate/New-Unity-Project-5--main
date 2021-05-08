using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class pocio : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject player;
    public Text missatge;
    private bool destruit;
    private bool treureText;
    public float distancia;
    private string personatge;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        personatge = PlayerPrefs.GetString("Player");
        destruit = false;
        treureText = false;
    }
    private void Update()
    {
        if (player != null)
        {
            if (comprovarDistancia())
            {
                if (!destruit)
                {
                    treureText = false;
                    missatge.text = "Pocio de vida - Preu: 50 monedes \n Clica-> [P] - Per Comprar";
                    if (Input.GetKey(KeyCode.P))
                    {
                        curar();
                        missatge.text = "";
                    }
                }
                else
                {
                    if (!treureText)
                    {
                        treureText = true;
                        missatge.text = "";
                    }
                }
            }
            else
            {
                if (!treureText)
                {
                    treureText = true;
                    missatge.text = "";
                }
            }
        }
    }
    private bool comprovarDistancia()
    {
        Vector3 target = player.transform.position;
        float distance = Vector3.Distance(target, transform.position);
        if (distance <= distancia)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDestroy()
    {
        destruit = true;
    }
    private void curar()
    {
        if (personatge == "Goku")
        {
            if (!player.GetComponent<PlayerController2>().Pocio())
            {
                return;
            }
        }
        else if (personatge == "Bardok")
        {
            if (!player.GetComponent<PlayerController>().Pocio())
            {
                return;
            }
        } else if (personatge == "Vegeta")
        {
            if (!player.GetComponent<PlayerController3>().Pocio())
            {
                return;
            }
        }
        Destroy(gameObject);
    }
}
