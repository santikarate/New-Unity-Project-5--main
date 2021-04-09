﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaPlayer : MonoBehaviour
{
    public float Mana = 200f;
    public float maxMana = 200f;
    public Image mana;
    public GameObject player;
    public Text manaText;
    private void Start()
    {
        Mana = maxMana;
    }
    private void Update()
    {
        manaText.text = Mana + " / " + maxMana;
    }
    public void GastarMana(float quantitat)
    {
        Mana = Mathf.Clamp(Mana - quantitat, 0f, maxMana);
        mana.transform.localScale = new Vector2(Mana / maxMana, 1);
    }
    public void RecuperarMana(float quantitat)
    {
        Mana = Mathf.Clamp(Mana + quantitat, 0f, maxMana);
        mana.transform.localScale = new Vector2(Mana / maxMana, 1);
    }
}
