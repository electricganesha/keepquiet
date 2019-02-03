using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageScripts : MonoBehaviour
{
    public Animator message1;
    public Animator message2;
    public Animator theAnimator;
    float time;
    public float timeToStart;

    bool isMessage1Fired = false;
    bool isMessage2Fired = false;

    private KeyCode up, down, left, right, fire;
    private String joyX, joyY, fireJoy;
    float coolDownTime = 1.0f;

    public AudioSource[] messageSounds;

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
        if (Input.GetButton(fireJoy) && time >= coolDownTime)
        {
            time = 0;
            if (isMessage1Fired)
            {
                messageSounds[1].Play();
                message2.SetTrigger("MessageInFromRight");
                isMessage2Fired = true;
                isMessage1Fired = false;


            }
            else if (isMessage2Fired)
            {
                theAnimator.SetTrigger("Fade-Out");
                StartCoroutine("LoadNextLevel");
            }
            else
            {
                messageSounds[0].Play();
                message1.SetTrigger("MessageInFromLeft");
                isMessage1Fired = true;
            }
            
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("KeepQuiet");
    }
}
