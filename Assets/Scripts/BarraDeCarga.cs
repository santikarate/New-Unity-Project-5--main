using System.Collections;
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
        print("Carregant");
        Barra = 0f;
        bloquejador = false;
        carga.transform.localScale = new Vector2(0, 1);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (!bloquejador)
        {
            bloquejador = true;
            StartCoroutine(pujarCarrega());
        }
    }
    public void carregar(float quantitat)
    {
        Barra = Mathf.Clamp(Barra + quantitat, 0f, BarraMax);
        print(Barra / BarraMax);
        carga.transform.localScale = new Vector2(Barra / BarraMax, 1);
        if ((Barra / BarraMax) == 1)
        {
            bloquejador = false;
            SceneManager.LoadScene("Level1");
        }
    }
    IEnumerator pujarCarrega()
    {
        carregar(0.1f);
        yield return new WaitForSeconds(0.01f);
        bloquejador = false;
    }

}
