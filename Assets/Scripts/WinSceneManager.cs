using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{

    public Animator text1Animator;
    public Animator text2Animator;


    float time = 0.0f;

    public float timeToShowText1;
    public float timeToShowText2;
    public float timeToShowText3;
    public float timeToShowText4;
    public float timeToDisappearCredits1;

    bool hasShownText1 = false;
    bool hasShownText2 = false;
    bool hasShownText3 = false;
    bool hasShownText4 = false;
    bool hasDissapearedCredits1 = false;


    public float timeToShowText1Credits2;
    public float timeToShowText2Credits2;
    public float timeToShowText3Credits2;
    public float timeToShowText4Credits2;
    public float timeToDisappearCredits2;

    bool hasShownText1Credits2 = false;
    bool hasShownText2Credits2 = false;
    bool hasShownText3Credits2 = false;
    bool hasShownText4Credits2 = false;
    bool hasDissapearedCredits2 = false;

    public float timeToFinish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timeToShowText1 && !hasShownText1)
        {
            text1Animator.SetTrigger("ShowText1");
            hasShownText1 = true;
        }

        if (time >= timeToShowText2 && !hasShownText2)
        {
            text1Animator.SetTrigger("ShowText2");
            hasShownText2 = true;
        }

        if (time >= timeToShowText3 && !hasShownText3)
        {
            text1Animator.SetTrigger("ShowText3");
            hasShownText3 = true;
        }

        if (time >= timeToShowText4 && !hasShownText4)
        {
            text1Animator.SetTrigger("ShowText4");
            hasShownText4 = true;
        }

        if (time >= timeToDisappearCredits1 && !hasDissapearedCredits1)
        {
            text1Animator.SetTrigger("Disappear");
            hasDissapearedCredits1 = true;
        }


        if (time >= timeToShowText1Credits2 && !hasShownText1Credits2)
        {
            text2Animator.SetTrigger("ShowText1");
            hasShownText1Credits2 = true;
        }

        if (time >= timeToShowText2Credits2 && !hasShownText2Credits2)
        {
            text2Animator.SetTrigger("ShowText2");
            hasShownText2Credits2 = true;
        }

        if (time >= timeToShowText3Credits2 && !hasShownText3Credits2)
        {
            text2Animator.SetTrigger("ShowText3");
            hasShownText3Credits2 = true;
        }

        if (time >= timeToShowText4Credits2 && !hasShownText4Credits2)
        {
            text2Animator.SetTrigger("ShowText4");
            hasShownText4Credits2 = true;
        }

        if (time >= timeToDisappearCredits2 && !hasDissapearedCredits2)
        {
            text2Animator.SetTrigger("Disappear");
            hasDissapearedCredits2 = true;
        }

        if (time >= timeToFinish)
        {
            SceneManager.LoadScene("01_Splash");
        }

    }
}
