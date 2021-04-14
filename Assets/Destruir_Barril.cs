using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir_Barril : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack Enemy" || collision.gameObject.tag == "AttackFinalJefe" || collision.gameObject.tag == "Attack" || collision.gameObject.tag == "AttackEspecial")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack Enemy" || collision.tag == "AttackFinalJefe" || collision.tag == "Attack" || collision.tag == "AttackEspecial")
        {
            Destroy(gameObject);
        }
    }
}
