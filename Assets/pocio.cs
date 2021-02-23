using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocio : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                player.transform.position - transform.position,
                visionRadius,
                1 << LayerMask.NameToLayer("Player")
                );*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.SendMessage("Pocio");
            Destroy(gameObject);
        }
    }
}
