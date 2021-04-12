using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comprovarEnemic : MonoBehaviour
{
    public List<GameObject> enemic;
    public List<GameObject> enemic2;
    public BoxCollider2D porta;
    public BoxCollider2D portaAnterior;
    public BoxCollider2D entrada;
    public BoxCollider2D porta2;
    private int capacitat, capacitat2;
    private int total;
    bool secondRound;
    // Start is called before the first frame update
    void Start()
    {
        porta.enabled = true;
        porta2.enabled = true;
        portaAnterior.enabled = false;
        capacitat = enemic.Count;
        secondRound = false;
        capacitat2 = enemic2.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (!secondRound)
        {
            total = 0;
            if (porta.enabled)
            {
                for (int i = 0; enemic.Count > i; i++)
                {
                    if (enemic[i] == null)
                    {
                        total++;
                    }
                }
            }
            if (total == capacitat)
            {
                segonaRonda();
            }
        } else
        {
            total = 0;
            if (porta.enabled)
            {
                for (int i = 0; enemic2.Count > i; i++)
                {
                    if (enemic2[i] == null)
                    {
                        total++;
                    }
                }
            }
            if (total == capacitat2)
            {
                porta.enabled = false;
                porta2.enabled = false;
                portaAnterior.enabled = false;
            }
        }
    }

    void segonaRonda()
    {
        for (int i = 0; enemic2.Count > i; i++)
        {
            enemic2[i].SetActive(true);
        }
        secondRound = true;
    }
    public void deteccioDePlayer()
    {
        portaAnterior.enabled = true;
    }
    
}
