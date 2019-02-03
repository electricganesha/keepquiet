using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour
{
    private KeyCode up, down, left, right, fire;
    private String joyX, joyY, fireJoy;
    public Animator theAnimator;

    // Start is called before the first frame update
    void Start()
    {
        fireJoy = "Fire1";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(fireJoy))
        {
                theAnimator.SetTrigger("Fade-Out");
                StartCoroutine("LoadNextLevel");
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("01_Splash");
    }
}
