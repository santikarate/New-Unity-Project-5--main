using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFreeza : MonoBehaviour
{
    private Rigidbody2D explosiu;
    private GameObject player;
    private GameObject JefeFinal;
    public float tempsDeVida;
    public float speed;
    public float daño;
    private bool final;
    private Vector3 direccio;
    private Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        JefeFinal = GameObject.FindGameObjectWithTag("Jefe");
        if (JefeFinal.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            transform.position = new Vector3(transform.position.x - 3.58f, transform.position.y + 0f, transform.position.z + 0f);
        }
        explosiu = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        final = false;
        direccio = player.GetComponent<Transform>().position;
        vector = new Vector3(direccio.x - gameObject.transform.position.x,direccio.y - gameObject.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (final)
        {
            AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            bool anim = stateInfo.IsName("explosio");
            if (!anim)
            {
                Destroy(gameObject);
            }
        }
        else
        {

            //transform.position = new Vector3(transform.position.x + vector.x, transform.position.y + vector.y, transform.position.y + 0f);
            Vector3 dir = (direccio - transform.position).normalized;
            explosiu.velocity = new Vector2(0.2f, 0.2f);
            gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + vector * 0.4f * speed * Time.deltaTime);
        }
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "object")
        {
            gameObject.GetComponent<Animator>().SetTrigger("Explosio");
            yield return new WaitForSeconds(tempsDeVida);
            final = true;
            //Destroy(gameObject);
        }
        else if (collision.tag != "Jefe" && collision.tag != "Attack")
        {
            if (collision.tag == "Player") {
                collision.SendMessage("atacatEspecial");
                gameObject.GetComponent<Animator>().SetTrigger("Explosio");
                final = true;
                //Destroy(gameObject);
            }
        }
    }
}
