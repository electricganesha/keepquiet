using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSound : MonoBehaviour
{
    public AudioSource theClock;
    public bool hasPlayed = false;

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
        if (other.gameObject.tag == "Player" && !hasPlayed)
        {
            theClock.Play();
            hasPlayed = true;
        }
    }
}
