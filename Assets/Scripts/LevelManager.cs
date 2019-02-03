using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AudioSource[] levelSounds;

    float time = 0.0f;
    public float timeToPlayIntroSound;
    public float timeToPlayAmbientSound;
    public float timeToFadeIn;
    bool hasPlayedIntroSound = false;
    bool hasPlayedAmbientSound = false;
    bool hasFadedIn = false;

    public Animator fadeInScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= timeToPlayIntroSound && !hasPlayedIntroSound)
        {
            levelSounds[0].Play();
            hasPlayedIntroSound = true;
        }

        if(time >= timeToFadeIn && !hasFadedIn)
        {
            fadeInScreen.SetTrigger("Fade-In");
            hasFadedIn = true;
        }

        if (time >= timeToPlayAmbientSound && !hasPlayedAmbientSound)
        {
            
            levelSounds[1].Play();
            hasPlayedAmbientSound = true;
        }
    }

    public void WinGame()
    {
        fadeInScreen.SetTrigger("Fade-Out");
        StartCoroutine("LoadWin"); 
    }

    public void LoseGame()
    {
        fadeInScreen.SetTrigger("Fade-Out");
        StartCoroutine("LoadLose");
    }

    private IEnumerator LoadWin()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("WinScene");
    }

    private IEnumerator LoadLose()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LoseScene");
    }
}
