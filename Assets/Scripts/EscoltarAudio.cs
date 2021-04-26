using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class EscoltarAudio : MonoBehaviour
{
    private EscoltarAudio instance;
    public EscoltarAudio Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        } else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
