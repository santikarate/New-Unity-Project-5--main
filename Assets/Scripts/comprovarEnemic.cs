using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comprovarEnemic : MonoBehaviour
{
    public List<GameObject> enemic;
    public BoxCollider2D porta;
    private int capacitat;
    private int total;
    // Start is called before the first frame update
    void Start()
    {
        porta.enabled = true;
        capacitat = enemic.Count;
    }

    // Update is called once per frame
    void Update()
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
            porta.enabled = false;
        }
    }
        
    
}
