using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{

    public float threshold = 5f;
    public float soundThreshold = 8f;
    float time = 0;
    public Light theLight;

    bool thunderLightIsOver = false;
    bool thunderSoundisOver = false;
    public AudioSource thunderSound;

    public float randomThreshold;

    // Start is called before the first frame update
    void Start()
    {
        randomThreshold = Random.Range(5.0f, 30.0f);
        threshold += randomThreshold;
        soundThreshold += randomThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= threshold)
        {
            

            if (!thunderLightIsOver)
            {
                theLight.intensity = 50;
                StartCoroutine("StopThunderLight");
                thunderLightIsOver = true;
            }
            

            if (time >= soundThreshold && !thunderSoundisOver)
            {
                thunderSound.Play();
                StartCoroutine("StopThunderSound");
                thunderSoundisOver = true;
                time = 0.0f;
            }
        }

        
    }

    IEnumerator StopThunderLight()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(0.25f);
        theLight.intensity = 0;
    }

    IEnumerator StopThunderSound()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(3f);
        thunderLightIsOver = false;
        thunderSoundisOver = false;
        randomThreshold = Random.Range(5.0f, 30.0f);
        threshold += randomThreshold;
        soundThreshold += randomThreshold;
    }
}
