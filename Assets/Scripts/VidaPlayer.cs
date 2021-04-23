using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaPlayer : MonoBehaviour
{
    public float Hp = 20f;
    public float maxHp = 20f;
    public Image vida;
    public GameObject player;
    public Text vidaText;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (PlayerPrefs.GetString("Player") == "Bardok")
        {
            maxHp = PlayerPrefs.GetInt("Vida Bardok");
        }
        else if (PlayerPrefs.GetString("Player") == "Goku")
        {
            maxHp = PlayerPrefs.GetInt("Vida Goku");
        }
        else if (PlayerPrefs.GetString("Player") == "Vegeta")
        {
            maxHp = PlayerPrefs.GetInt("Vida Vegeta");
        }
        
        Hp = maxHp;
    }
    private void Update()
    {
        vidaText.text = Hp +" / " + maxHp;
    }

    public void PrendreMal(float quantitat)
    {
        Hp = Mathf.Clamp(Hp - quantitat, 0f, maxHp);
        vida.transform.localScale = new Vector2(Hp / maxHp, 1);
        if (Hp <= 0f)
        {
            player.SendMessage("Mort");
        }
    }
    public void RecuperarVida(float quantitat)
    {
        Hp = Mathf.Clamp(Hp + quantitat, 0f, maxHp);
        vida.transform.localScale = new Vector2(Hp / maxHp, 1);
    }
}
