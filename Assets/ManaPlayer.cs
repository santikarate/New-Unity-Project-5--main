using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaPlayer : MonoBehaviour
{
    public float Mana = 200f;
    public float maxMana = 200f;
    public Image mana;
    public GameObject player;
    private void Start()
    {
        Mana = maxMana;
    }

    public void GastarMana(float quantitat)
    {
        Mana = Mathf.Clamp(Mana - quantitat, 0f, maxMana);
        mana.transform.localScale = new Vector2(Mana / maxMana, 1);
        if (Mana <= 0f)
        {
            player.SendMessage("Mort");
        }
    }
    public void RecuperarMana(float quantitat)
    {
        Mana = Mathf.Clamp(Mana + quantitat, 0f, maxMana);
        mana.transform.localScale = new Vector2(Mana / maxMana, 1);
    }
}
