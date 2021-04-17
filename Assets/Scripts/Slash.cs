using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D bolaEnergiaRB;

    public float tempsDeVida;
    public float speed;

    public float daño;



    private void Awake()
    {
        bolaEnergiaRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        if (player.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            bolaEnergiaRB.velocity = new Vector2(-speed, bolaEnergiaRB.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position = new Vector3(transform.position.x - 3.2f, transform.position.y + 0f, transform.position.y + 0f);
        } 
        else
        {
            bolaEnergiaRB.velocity = new Vector2(speed, bolaEnergiaRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "object")
        {
            yield return new WaitForSeconds(tempsDeVida);
            Destroy(gameObject);
        } else if (collision.tag != "Player" && collision.tag != "Attack")
        {
            if (collision.tag == "Enemic") collision.SendMessage("AttackedEspecial");
            Destroy(gameObject);
        }
    }
}

