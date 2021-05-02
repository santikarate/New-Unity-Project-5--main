using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class passarDeEscena : MonoBehaviour
{
    public void passarA(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
