using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    public Animator theAnimator;
    public AudioSource theAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            theAnimator.SetBool("TvIsOn", true);
            theAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            theAnimator.SetBool("TvIsOn", false);
            theAudio.Stop();
        }
    }
}
