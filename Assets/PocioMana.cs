using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocioMana : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public TextMesh missatge;
    private bool destruit;
    private void Start()
    {
        destruit = false;
    }
    private void Update()
    {
        
        if (comprovarDistancia())
        {
            missatge.text = "Pocio de vida - Preu: 50 monedes \n Clica->Enter - Per Comprar";
        }
    }
    private bool comprovarDistancia()
    {
        Vector3 target = player.transform.position;
        float distance = Vector3.Distance(target, transform.position);
        if (distance < 50)
        {
            return true;
        } else
        {
            return false;
        }
    }
    private void OnDestroy()
    {
        destruit = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.SendMessage("PocioMana");
            Destroy(gameObject);
        }
        
    }
}
