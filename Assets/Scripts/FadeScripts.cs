using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class FadeScripts : MonoBehaviour
{
    public Animator theAnimator;
    float time;
    public float timeToStart;

    private KeyCode up, down, left, right, fire;
    private String joyX, joyY, fireJoy;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        fireJoy = "Fire1";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= timeToStart)
        {
            theAnimator.SetTrigger("Fade-In");
        }

        if (Input.GetButton(fireJoy))
        {
            theAnimator.SetTrigger("Fade-Out");
            StartCoroutine("LoadNextLevel");
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("02_Messages");
    }
}
