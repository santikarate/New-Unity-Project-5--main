using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour
{
    CircleCollider2D attackCollider;

    public Transform bolaEnergiaInici;

    public GameObject slashPrefab;

    public GameObject vida;

    public GameObject mana;

    public Text monedes;

    bool rebreMal;

    private int monedesJoc;

    private void Awake()
    {
        Assert.IsNotNull(slashPrefab);
        llegirMoneda();
    }

    // Start is called before the first frame update
    
    void Start()
    {
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
        rebreMal = true;
    }

    // Update is called once per frame
    void Update()
    {
        monedes.text = monedesJoc.ToString();
        puño();
        atack1();
        atackEspecial();
        moveY();
        moveX();
    }
    private void moveX()
    {
        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving left", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            attackCollider.offset = new Vector2(0.4f, 0);
        }
        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving left", true);
            gameObject.GetComponent<Animator>().SetBool("pujar", false);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            attackCollider.offset = new Vector2(-0.4f, 0);

        }
        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving left", false);
        }
    }
    private void moveY()
    {
        if (Input.GetKey("up"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500f * Time.deltaTime));
            gameObject.GetComponent<Animator>().SetBool("pujar", true);
        }
        if (Input.GetKey("down"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -500f * Time.deltaTime));
            gameObject.GetComponent<Animator>().SetBool("pujar", true);
        }
        if (!Input.GetKey("up") && !Input.GetKey("down"))
        {
            gameObject.GetComponent<Animator>().SetBool("pujar", false);
        }
    }
    private void atack1()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        bool martillo = stateInfo.IsName("Golpe martillo");
        bool atacking = stateInfo.IsName("Puño");
        bool especial = stateInfo.IsName("atack especial");
        if (mana.GetComponent<ManaPlayer>().Mana > 20f)
        {
            if (Input.GetKeyDown(KeyCode.W) && !martillo && !atacking && !especial)
            {
                mana.SendMessage("GastarMana", 20f);
                gameObject.GetComponent<Animator>().SetTrigger("Martillo");
            }
        }
        if (atacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.4 && playbackTime < 0.7) attackCollider.enabled = true;
            else attackCollider.enabled = false;
        }
    }
    private void puño()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        bool atacking = stateInfo.IsName("Puño");
        bool martillo = stateInfo.IsName("Golpe martillo");
        bool especial = stateInfo.IsName("atack especial");
        if (mana.GetComponent<ManaPlayer>().Mana > 20f)
        {
            if (Input.GetKeyDown(KeyCode.E) && !atacking && !martillo && !especial)
            {
                mana.SendMessage("GastarMana", 20f);
                Convert.ToInt32(monedes);
                gameObject.GetComponent<Animator>().SetTrigger("Puño");
            }
        }
        if (martillo)
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.4 && playbackTime < 0.7) attackCollider.enabled = true;
            else attackCollider.enabled = false;
        }
    }
    private void atackEspecial()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        bool atacking = stateInfo.IsName("Puño");
        bool martillo = stateInfo.IsName("Golpe martillo");
        bool especial = stateInfo.IsName("atack especial");
        if (mana.GetComponent<ManaPlayer>().Mana > 40f)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !atacking && !martillo && !especial)
            {
                mana.SendMessage("GastarMana", 40f);
                gameObject.GetComponent<Animator>().SetTrigger("Atack especial");
                StartCoroutine(Esperar(0.9f));
            }
        }
    }
    IEnumerator Esperar(float second)
    {
        yield return new WaitForSecondsRealtime(second);
        Instantiate(slashPrefab, bolaEnergiaInici.position, bolaEnergiaInici.rotation, transform);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (rebreMal)
        {
            print("desactivant");
            StartCoroutine(temporitzador(0.5f));
            if (collision.tag == "Attack Enemy")
            {
                vida.SendMessage("PrendreMal", 20);
            }
        }
    }
    IEnumerator temporitzador(float second)
    {
        print("false");
        rebreMal = false;
        yield return new WaitForSecondsRealtime(second);
        rebreMal = true;
        print("true");
    }
    private void Mort()
    {
        print("Has mort");
        Destroy(gameObject);
    }
    public bool Pocio()
    {
        if (monedesJoc > 50)
        {
            monedesJoc = monedesJoc - 50;
            vida.SendMessage("RecuperarVida", 20);
            return true;
        } else
        {
            return false;
        }
    }
    
    private void PocioMana()
    {
        mana.SendMessage("RecuperarMana", 20);
    }
    public void pujarMonedes(int i)
    {
        monedesJoc = monedesJoc + i;
    }
    public void bajarMonedes(int i)
    {
        monedesJoc = monedesJoc - i;
    }
    public void guardarMoneda()
    {
        PlayerPrefs.SetInt("Moneda", monedesJoc);
    }
    public void llegirMoneda()
    {
        monedesJoc= PlayerPrefs.GetInt("Moneda");
    }
    private void OnDestroy()
    {
        guardarMoneda();
    }
}


   