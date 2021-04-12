using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class Detectar_Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject col;
    private bool accio;
    private void Start()
    {
        accio = false;
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        yield return new WaitForSeconds(0f);
        if (collision.tag == "Player")
        {
            print("ey");
            if (!accio)
            {
                accio = true;
                print("hola");
                col.GetComponent<comprovarEnemic>().deteccioDePlayer();
            }
        }
    }
}
