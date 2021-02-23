using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float visionRadius;
    public float attackRadius;
    public float speed;
    CircleCollider2D attackCollider;
    bool attacking;
    bool muerto;
    GameObject player;

    [Tooltip("Velocitat d'atac (segons entre atacs")]
    public float attackSpeed = 2f;

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

        initialPosition = transform.position;

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
        hp = maxHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        Vector3 target = initialPosition;
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            visionRadius,
            1<< LayerMask.NameToLayer("Default")
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

       
        if (target != initialPosition && distance < attackRadius)
        {
            anim.SetBool("move", false);
            if (!attacking)
            {
                StartCoroutine(Attack(attackSpeed));
            } 
            else
            {
                float playbackTime = stateInfo.normalizedTime;
                if (0.55 < playbackTime && playbackTime < 0.75)
                {
                    attackCollider.enabled = true;
                }
                else
                {
                    attackCollider.enabled = false;
                }
            }
        }
        else
        {
            bool puñ = stateInfo.IsName("Puño");
            if (!puñ)
            {
                rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
                anim.SetBool("move", true);
                attackCollider.enabled = false;
            }
            
        }
        if (target == initialPosition && distance < 0.02f)
        {
            anim.SetBool("move", false);
            transform.position = initialPosition;
        }
        if (anim.GetBool("move"))
        {
            if (dir.x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                attackCollider.offset = new Vector2(0.66f, 0);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                attackCollider.offset = new Vector2(-0.66f, 0);
            }
        }
        Debug.DrawLine(transform.position, target, Color.green);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
    IEnumerator Attack(float seconds)
    {
        attacking = true;
        if (target != initialPosition) 
        {
            anim.SetTrigger("atack1");
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }
    public void Attacked()
    {
        if (--hp <= 0)
        {
            anim.SetTrigger("muerte");
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            bool muerte = stateInfo.IsName("Muerte");
            if (muerte)
            {
                muerto = true;
            } else
            {
                Destroy(gameObject);
            }

        }
    }
    IEnumerator esperarAnim(float seconds)
    {
        attacking = true;
        if (target != initialPosition)
        {
            anim.SetTrigger("atack1");
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }
    private void OnGUI()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint (transform.position);

        GUI.Box(
            new Rect(
                pos.x - 20,
                Screen.height - pos.y + 90,
                40,
                24
            ), hp + "/" + maxHp);
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
