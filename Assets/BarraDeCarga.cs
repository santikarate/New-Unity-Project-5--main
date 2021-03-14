using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeCarga : MonoBehaviour
{
    // Start is called before the first frame update
    private float Barra = 0f;
    private float BarraMax = 20f;
    public Image carga;
    private bool bloquejador;
   
    private void Start()
    {
        bloquejador = false;
    }

    private void Update()
    {
        if (!bloquejador)
        {
            bloquejador = true;
            StartCoroutine(pujarCarrega());
        }
    }
    public void RecuperarVida(float quantitat)
    {
        Barra = Mathf.Clamp(Barra + quantitat, 0f, BarraMax);
        print(Barra / BarraMax);
        carga.transform.localScale = new Vector2(Barra / BarraMax, 1);
        if ((Barra / BarraMax) == 1)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("Level1");
        }
    }
    IEnumerator pujarCarrega()
    {
        RecuperarVida(1f);
        yield return new WaitForSeconds(0.4f);
        bloquejador = false;
    }
}
