using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pocio : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Text missatge;
    private bool destruit;
    private bool treureText;
    public float distancia;
    private void Start()
    {
        destruit = false;
        treureText = false;
    }
    private void Update()
    {

        if (comprovarDistancia())
        {
            if (!destruit) { 
                treureText = false;
                missatge.text = "Pocio de vida - Preu: 50 monedes \n Clica->Enter - Per Comprar";
                if (Input.GetKey(KeyCode.P))
                {
                    curar();
                }
            } else
            {
                if (!treureText)
                {
                    treureText = true;
                    missatge.text = "";
                }
            }
        } else
        {
            if (!treureText)
            {
                treureText = true;
                missatge.text = "";
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
        print(player.GetComponent<PlayerController>().Pocio());
        if (player.GetComponent<PlayerController>().Pocio())
        {
            Destroy(gameObject);
        }
    }
}
