using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackplayer : MonoBehaviour
{
    
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f);
        if (collision.tag == "Enemic")
        {
            GameObject.FindGameObjectWithTag("Enemic").GetComponent<Enemy2>().Attacked();
            print("cop");
            //collision.SendMessage("Attacked");
        }
    }
}
