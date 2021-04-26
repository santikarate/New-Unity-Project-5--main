using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaFinal : MonoBehaviour
{
    public BoxCollider2D porta;
    // Start is called before the first frame update
    void Start()
    {
        porta.enabled = false;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            porta.enabled = true;
            gameObject.SetActive(false);
        }
    }

}
