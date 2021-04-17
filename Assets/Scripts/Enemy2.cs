using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    bool attacked;
    bool esperant;
    [Tooltip("Velocitat d'atac (segons entre atacs)")]
    private bool mortActive;

    [Tooltip("Puntos de vida")]
    public int maxHp = 10;

    [Tooltip("Vida actual")]
    public int hp;

    Vector3 initialPosition;
    Vector3 target;
    public Text alert;
    Animator anim;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        alert.text = "";
        player = GameObject.FindGameObjectWithTag("Player");
        mortActive = false;
        initialPosition = transform.position;
        attacked = false;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        hp = maxHp;
        muerto = false;
        esperant = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
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
                if (!attacked)
                {
                    AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
                    if (!stateInfo.IsName("Puño"))
                    {
                        attacking = false;
                    }
                    if (stateInfo.IsName("Daño"))
                    {
                        anim.SetBool("move", false);
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
                        float distance = Vector3.Distance(target, transform.position);
                        if (distance < visionRadius)
                        {
                            alert.text = "!";
                        }
                        else 
                        {
                            alert.text = "";
                        }
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
                    } else
                    {
                        anim.SetBool("move", false);
                    }
                } else
                {
                    if (transform.position != initialPosition) {
                        Vector3 dir = (target - transform.position).normalized;
                        bool x = player.GetComponents<SpriteRenderer>()[0].flipX;
                        if (x)
                        {
                            rb2d.AddForce(new Vector2(-500f / 2 * Time.deltaTime, 0));
                        } else
                        {
                            rb2d.AddForce(new Vector2(500f / 2 * Time.deltaTime, 0));
                        }
                    }
                }
            }
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
            StartCoroutine(EstarAtacat(1f));
        }

    }
    public void AttackedEspecial()
    {
        print("2");
        hp = hp - 2;
        if (hp <= 0)
        {
            muerto = true;
        }
        else
        {
            StartCoroutine(EstarAtacat(1f));
        }

    }
    IEnumerator EstarAtacat(float seconds)
    {
        anim.SetTrigger("daño");
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
        player.SendMessage("pujarMonedes", 100);
    }
    IEnumerator esperar()
    {
        esperant = true;
        yield return new WaitForSeconds(Espera);
        esperant = false;
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Attack" && !attacked)
        {
            Attacked();
        } else if(collision.tag == "AttackEspecial" && !attacked)
        {
            AttackedEspecial();
        }
    }
    
    
}
