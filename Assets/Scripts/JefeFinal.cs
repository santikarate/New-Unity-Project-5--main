using System.Collections;
using UnityEngine;
public class JefeFinal : MonoBehaviour
{
    public float visionRadius;
    public float attackRadius;
    public float attacEspecialRadius;
    public float speed;
    
    [Tooltip("Temps d'epera per atacar")]
    public float Espera;
    CircleCollider2D attackCollider;
    bool attacking;
    bool attackingEspecial, attackEspecial;
    private bool muerto;
    GameObject player;
    bool attacked;
    bool esperant;
    [Tooltip("Velocitat d'atac (segons entre atacs)")]
    private bool mortActive;

    [Tooltip("Puntos de vida")]
    public float maxHp = 10;

    [Tooltip("Vida actual")]
    public float hp;

    Vector3 initialPosition;
    Vector3 target;

    Animator anim;
    Rigidbody2D rb2d;

    public GameObject slashPrefab;
    public Transform bolaEnergiaInici;
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
        hp = maxHp;
        muerto = false;
        esperant = false;
        attackingEspecial = false;
        attackEspecial = false;
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
                    if (!stateInfo.IsName("puñ"))
                    {
                        attacking = false;
                    }
                    if (stateInfo.IsName("mal"))
                    {
                        anim.SetBool("move", false);
                    }
                    if (stateInfo.IsName("especial"))
                    {
                        attackingEspecial = true;
                    } else
                    {
                        attackingEspecial = false;
                    }
                    Vector3 target = initialPosition;
                    RaycastHit2D hit = Physics2D.Raycast(
                        transform.position,
                        player.transform.position - transform.position,
                        attacEspecialRadius,
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
                        Vector3 dir = (target - transform.position).normalized;
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
                        float distance = Vector3.Distance(target, transform.position);
                        if (target != initialPosition && distance < attackRadius)
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
                        else if(distance > attackRadius && distance < visionRadius)
                        {
                            bool puñ = stateInfo.IsName("puñ");
                            if (!puñ && !attacked && !attackingEspecial)
                            {
                                dir = (target - transform.position).normalized;
                                rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
                                anim.SetBool("move", true);
                            }
                        }
                        if (target == initialPosition && distance < 0.02f)
                        {
                            anim.SetBool("move", false);
                            transform.position = initialPosition;
                        } else if (distance < attacEspecialRadius && distance > visionRadius)
                        {
                            anim.SetBool("move", false);
                            if (!attackEspecial)
                            {
                                anim.SetTrigger("especial");
                                attackEspecial = true;
                                StartCoroutine(AtacEspecial());
                            }
                        }
                    }
                    else
                    {
                        anim.SetBool("move", false);
                    }
                }
                else
                {
                    Vector3 dir = (target - transform.position).normalized;
                    bool x = player.GetComponents<SpriteRenderer>()[0].flipX;
                    if (x)
                    {
                        rb2d.AddForce(new Vector2(-500f / 2 * Time.deltaTime, 0));
                    }
                    else
                    {
                        rb2d.AddForce(new Vector2(500f / 2 * Time.deltaTime, 0));
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
        Gizmos.DrawWireSphere(transform.position, attacEspecialRadius);
    }
    private void Attack()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        StartCoroutine(esperar());
        attacking = true;
        if (target != initialPosition)
        {
            anim.SetTrigger("puñ");
        }

    }
    public void Attacked2()
    {
        int mal = 0;
        if (PlayerPrefs.GetString("Player") == "Bardok")
        {
            mal = PlayerPrefs.GetInt("Mal Bardok");
        }
        else if (PlayerPrefs.GetString("Player") == "Goku")
        {
            mal = PlayerPrefs.GetInt("Mal Goku");
        }
        else if (PlayerPrefs.GetString("Player") == "Vegeta")
        {
            mal = PlayerPrefs.GetInt("Mal Vegeta");
        }
        hp = hp - (mal * (2 + (2 * (mal / 2.5f))));
        if (hp <= 0)
        {
            muerto = true;
        }
        else
        {
            StartCoroutine(EstarAtacat(1f));
        }

    }
    public void Attacked()
    {
        int mal = 0;
        if (PlayerPrefs.GetString("Player") == "Bardok")
        {
            mal = PlayerPrefs.GetInt("Mal Bardok");
        }
        else if (PlayerPrefs.GetString("Player") == "Goku")
        {
            mal = PlayerPrefs.GetInt("Mal Goku");
        }
        else if (PlayerPrefs.GetString("Player") == "Vegeta")
        {
            mal = PlayerPrefs.GetInt("Mal Vegeta");
        }
        hp = hp - (1 + (1 * (mal / 2.5f)));
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
        anim.SetTrigger("mal");
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
        player.SendMessage("pujarMonedes", 400);
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
        }
        else if (collision.tag == "AttackEspecial" && !attacked)
        {
            Attacked2();
        }
    }
    IEnumerator AtacEspecial()
    {
        yield return new WaitForSecondsRealtime(0.8f);        
        Instantiate(slashPrefab, bolaEnergiaInici.position, bolaEnergiaInici.rotation, transform);
        yield return new WaitForSecondsRealtime(3f);
        attackEspecial = false;
    }
}
