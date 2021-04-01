using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFreeza : MonoBehaviour
{
    private Rigidbody2D explosiu;
    public GameObject player;
    public float tempsDeVida;
    public float speed;
    public float daño;

    // Start is called before the first frame update
    void Start()
    {
        explosiu = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Jefe");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            explosiu.velocity = new Vector2(-speed, explosiu.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position = new Vector3(transform.position.x - 3.2f, transform.position.y + 0f, transform.position.y + 0f);
        }
        else
        {
            explosiu.velocity = new Vector2(speed, explosiu.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "object")
        {
            yield return new WaitForSeconds(tempsDeVida);
            Destroy(gameObject);
        }
        else if (collision.tag != "Jefe" && collision.tag != "Attack")
        {
            if (collision.tag == "Player") {
                collision.SendMessage("Attacked");
                Destroy(gameObject);
            }
        }
    }
}
