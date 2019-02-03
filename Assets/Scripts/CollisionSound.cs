using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{

    public AudioSource theSound;
    public bool hasPlayed = false;
    public float coolDown = 1.0f;
    public float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= coolDown && hasPlayed)
        {
            hasPlayed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !hasPlayed)
        {
            theSound.Play();
            hasPlayed = true;
        }
    }
}
