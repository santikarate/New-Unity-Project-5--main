using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludPlayer : MonoBehaviour
{
    Rigidbody2D body;

    public  GameObject mal;

    public float BumpX, BumY;
    // Start is called before the first frame update
    void Start()
    {
        //mal.GetComponent<VidaPlayer>().PrendreMal();
        body = GetComponent<Rigidbody2D>();
    }

    /*void OnTriggerEnter2D(CapsuleCollider2D col)
    {
        if (col.tag == "Attack Enemy")
        {
            body.velocity = new Vector2(BumpX, BumY);
        }
    }*/
}
