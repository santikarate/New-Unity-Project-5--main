using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.Audio;

public class PlayerController2 : MonoBehaviour
{
    CircleCollider2D attackCollider;

    public Transform bolaEnergiaInici;

    public GameObject slashPrefab;

    public GameObject vida;

    public GameObject mana;

    public GameObject jefe;

    public Text monedes;

    bool rebreMal;

    private int monedesJoc;

    private bool golpejat, morint, num;

    private Color color;
    public Color groc, blau, blanc, verd;
    public AudioSource mal, cop;

    private void Awake()
    {
        Assert.IsNotNull(slashPrefab);
        llegirMoneda();
    }

    // Start is called before the first frame update

    void Start()
    {
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        //attackCollider.enabled = false;
        rebreMal = true;
        morint = false;
        golpejat = false;
        num = false;
        if (PlayerPrefs.GetString("Color") == "Groc")
        {
            color = groc;
        }
        else if (PlayerPrefs.GetString("Color") == "Blanc")
        {
            color = blanc;
        }
        else if (PlayerPrefs.GetString("Color") == "Verd")
        {
            color = verd;
        }
        else if (PlayerPrefs.GetString("Color") == "Blau")
        {
            color = blau;
        }
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
    // Update is called once per frame
    void Update()
    {
        if (!morint && !golpejat)
        {
            monedes.text = monedesJoc.ToString();
            puño();
            atack1();
            atackEspecial();
            moveY();
            moveX();
        }
        else if (golpejat)
        {
            if (num)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f / 2 * Time.deltaTime, 0));
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f / 2 * Time.deltaTime, 0));
            }
        }
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
        bool martillo = stateInfo.IsName("colze");
        bool atacking = stateInfo.IsName("puño");
        bool especial = stateInfo.IsName("especial");
        if (mana.GetComponent<ManaPlayer>().Mana >= 5f)
        {
            if (Input.GetKeyDown(KeyCode.W) && !martillo && !atacking && !especial)
            {
                mana.SendMessage("GastarMana", 5f);
                gameObject.GetComponent<Animator>().SetTrigger("Martillo");
            }
        }
    }
    private void puño()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        bool martillo = stateInfo.IsName("colze");
        bool atacking = stateInfo.IsName("puño");
        bool especial = stateInfo.IsName("especial");
        if (mana.GetComponent<ManaPlayer>().Mana >= 5f)
        {
            if (Input.GetKeyDown(KeyCode.E) && !atacking && !martillo && !especial)
            {
                mana.SendMessage("GastarMana", 5f);
                Convert.ToInt32(monedes);
                gameObject.GetComponent<Animator>().SetTrigger("Puño");
                cop.Play();
            }
        }
    }
    private void atackEspecial()
    {
        AnimatorStateInfo stateInfo = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        bool martillo = stateInfo.IsName("colze");
        bool atacking = stateInfo.IsName("puño");
        bool especial = stateInfo.IsName("especial");
        if (mana.GetComponent<ManaPlayer>().Mana >= 30f)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !atacking && !martillo && !especial)
            {
                mana.SendMessage("GastarMana", 30f);
                gameObject.GetComponent<Animator>().SetTrigger("Atack especial");
                StartCoroutine(Esperar(0.9f));
                cop.Play();
            }
        }
    }
    IEnumerator Esperar(float second)
    {
        yield return new WaitForSecondsRealtime(second);
        Instantiate(slashPrefab, bolaEnergiaInici.position, bolaEnergiaInici.rotation, transform);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rebreMal)
        {
            if (collision.tag == "Attack Enemy")
            {
                num = collision.GetComponentsInParent<SpriteRenderer>()[0].flipX;
                vida.SendMessage("PrendreMal", 10);
                if (!morint)
                {
                    StartCoroutine(temporitzador(0.5f));
                }
            }
            else if (collision.tag == "AttackFinalJefe")
            {
                num = jefe.GetComponentsInParent<SpriteRenderer>()[0].flipX;
                vida.SendMessage("PrendreMal", 30);
                if (!morint)
                {
                    StartCoroutine(temporitzador(0.5f));
                }
            }
        }
    }
    IEnumerator temporitzador(float second)
    {
        rebreMal = false;
        gameObject.GetComponent<Animator>().SetTrigger("Mal");
        StartCoroutine(canviColor());
        golpejat = true;
        yield return new WaitForSeconds(0.3f);
        mal.Play();
        yield return new WaitForSeconds(0.5f);
        rebreMal = true;
        golpejat = false;
    }
    IEnumerator canviColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
    private void Mort()
    {
        if (!morint)
        {
            StartCoroutine(Morir());
        }
    }
    public bool Pocio()
    {
        if (monedesJoc > 50)
        {
            monedesJoc = monedesJoc - 50;
            vida.SendMessage("RecuperarVida", 20);
            return true;
        }
        else
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
        mana.SendMessage("RecuperarMana", 60);
    }
    public void bajarMonedes(int i)
    {
        monedesJoc = monedesJoc - i;
    }
    public void guardarMoneda()
    {
        PlayerPrefs.SetInt("Moneda", monedesJoc + PlayerPrefs.GetInt("Moneda"));
    }
    public void llegirMoneda()
    {
        monedesJoc = 0;
    }
    private void OnDestroy()
    {
        guardarMoneda();
    }
    IEnumerator Morir()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Morir");
        morint = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}


