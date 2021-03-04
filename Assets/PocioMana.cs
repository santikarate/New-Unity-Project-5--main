using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocioMana : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.SendMessage("PocioMana");
            Destroy(gameObject);
        }
    }
}
