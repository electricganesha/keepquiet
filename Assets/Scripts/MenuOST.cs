using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOST : MonoBehaviour
{
    static bool AudioBegin = false;
    AudioSource audio;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    void Awake()
    {
        if (!AudioBegin)
        {
            audio.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "KeepQuiet")
        {
            audio.Stop();
            AudioBegin = false;
        }
    }
}
