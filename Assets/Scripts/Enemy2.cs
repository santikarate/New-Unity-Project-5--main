using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Enemy2 : MonoBehaviour
{
    public float visionRadius;
    public float attackRadius;
    public float speed;
    [Tooltip("Temps d'epera per atacar")]
    public float Espera;
    CircleCollider2D attackCollider;
    bool attacking;
    private bool muerto;
    GameObject player;
    CapsuleCollider2D col;
    bool attacked;
    bool esperant;
    [Tooltip("Velocitat d'atac (segons entre atacs)")]
    public float attackSpeed = 2f;
    private bool mortActive;

    [Tooltip("Puntos de vida")]
    public int maxHp = 10;

    [Tooltip("Vida actual")]
    public int hp;

    Vector3 initialPosition;
    Vector3 target;

    Animator anim;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mortActive = false;
        initialPosition = transform.position;
        attacked = false;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
        hp = maxHp;
        muerto = false;
        col = GetComponent<CapsuleCollider2D>();
        esperant = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (muerto)
        {
            if (!mortActive)
            {
                mortActive = true;
                StartCoroutine(Morir());
            }
        }
        else
        {
            comprovarColl();
            if (col.tag == "Attack" && !attacked)
            {
                Attacked();
            }
            AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            if (!stateInfo.IsName("Puño"))
            {
                attacking = false;
            }
            Vector3 target = initialPosition;
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                player.transform.position - transform.position,
                visionRadius,
                1 << LayerMask.NameToLayer("Player")
                );
            Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
            Debug.DrawRay(transform.position, forward, Color.red);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    target = player.transform.position;
                }
            }
            float distance = Vector3.Distance(target, transform.position);
            Vector3 dir = (target - transform.position).normalized;


            if (target != initialPosition && distance < attackRadius && !attacked)
            {
                anim.SetBool("move", false);
                if (!attacking)
                {
                    if (!esperant)
                    {
                        Attack();
                    } 
                }
                
            }
            else
            {
                bool puñ = stateInfo.IsName("Puño");
                if (!puñ && !attacked)
                {
                    rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
                    anim.SetBool("move", true);
                }


            }
            if (target == initialPosition && distance < 0.02f && !attacked)
            {
                anim.SetBool("move", false);
                transform.position = initialPosition;
            }
            if (anim.GetBool("move") && !attacked)
            {
                if (dir.x > 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    attackCollider.offset = new Vector2(0.4f, 0);
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    attackCollider.offset = new Vector2(-0.4f, 0);
                }
            }
            Debug.DrawLine(transform.position, target, Color.green);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
    private void Attack()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        StartCoroutine(esperar());
        attacking = true;
        if (target != initialPosition)
        {
            anim.SetTrigger("atack1");
        }
        
    }
    public void Attacked()
    {
        if (--hp <= 0)
        {
            muerto = true;
        } else
        {
            StartCoroutine(EstarAtacat(1.5f));
        }

    }
    private void OnGUI()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Box(
            new Rect(
                pos.x - 20,
                Screen.height - pos.y + 90,
                40,
                24
            ), hp + "/" + maxHp);
    }
    IEnumerator EstarAtacat(float seconds)
    {
        anim.SetTrigger("Daño");
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
        attacked = true;
        StartCoroutine(colorNormal());
        yield return new WaitForSeconds(seconds);
        attacked = false;
    }
    IEnumerator colorNormal()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }
    IEnumerator Morir()
    {
        anim.SetTrigger("mort");
        muerto = true;
        yield return new WaitForSeconds(2.7f);
        Destroy(gameObject);
    }
    IEnumerator esperar()
    {
        esperant = true;
        yield return new WaitForSeconds(Espera);
        esperant = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Attack" && !attacked)
        {
            print("hola");
            Attacked();
        }
    }
    private void comprovarColl()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        bool atacking = stateInfo.IsName("Puño");
        if (atacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.3 && playbackTime < 0.6) attackCollider.enabled = true;
            else attackCollider.enabled = false;
        } else
        {
            attackCollider.enabled = false;
        }
        
    }
    /*IEnumerator SuperAttack(float seconds)
    {
        attacking = true;
        if (target != initialPosition)
        {
            anim.SetTrigger("kame");
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }*/
}
