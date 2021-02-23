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
    private void Start()
    {
        Hp = maxHp;
    }

    public void PrendreMal(float quantitat)
    {
        Hp = Mathf.Clamp(Hp - quantitat, 0f, maxHp);
        vida.transform.localScale = new Vector2(Hp / maxHp, 1);
        if (Hp >= 0f)
        {
            player.SendMessage("Mort");
        }
    }
}
