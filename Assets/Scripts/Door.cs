using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject theDoor;
    private bool isInsideCollider;
    private float distanceBetweenPlayer;
    private float doorYrotation;
    private Collider otherObject;
    public AudioSource theDoorSound;
    public bool hasDoorSoundPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        isInsideCollider = false;
}

    // Update is called once per frame
    void Update()
    {
        if (isInsideCollider)
        {
            distanceBetweenPlayer = Vector3.Distance(otherObject.transform.position, transform.position);

            if(distanceBetweenPlayer >= 0.5f && distanceBetweenPlayer <= 1.775f)
            {
                if(distanceBetweenPlayer <= 1f && !hasDoorSoundPlayed)
                {
                    theDoorSound.Play();
                    hasDoorSoundPlayed = true;
                }

                doorYrotation = 85.0f - ((distanceBetweenPlayer-0.5f) / 0.015f);
                
                if (doorYrotation < 0.0f)
                {
                    doorYrotation = 0.0f;
                }
                else if (doorYrotation > 85.0f)
                {
                    doorYrotation = 85.0f;
                }
                                
                theDoor.transform.rotation = Quaternion.Euler(-90, 0, doorYrotation-270);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInsideCollider = true;
            otherObject = other;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        isInsideCollider = false;
        otherObject = other;
    }
}
