using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{

    public AudioSource theCatSound;
    bool hasPlayedSound = false;
    public float coolDown = 1.0f;
    public float time = 0.0f;

    public bool isCatStressed = false;
    public bool hasCatReachedSafeArea = false;

    public Transform[] catPoints;
    public Animator catAnimator;
    public float speed = 2.0f;

    public int timesStressed = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


        if (time >= coolDown && hasPlayedSound)
        {
            hasPlayedSound = false;
        }

        if(isCatStressed)
        {
            catAnimator.SetBool("isIdle", false);
            catAnimator.SetBool("isRunning", true);
            transform.position = Vector3.MoveTowards(transform.position, catPoints[timesStressed].transform.position, Time.deltaTime * speed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position, Vector3.up), 0.2f);
        }

        if(hasCatReachedSafeArea)
        {
            isCatStressed = false;
            catAnimator.SetBool("isIdle", true);
            catAnimator.SetBool("isRunning", false);
            hasCatReachedSafeArea = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !hasPlayedSound)
        {
            theCatSound.Play();
            hasPlayedSound = true;
            isCatStressed = true;
            if (timesStressed != 2)
                timesStressed++;
            else
                timesStressed = 0;
        }

        if(other.gameObject.tag == "CatArea" && !hasCatReachedSafeArea)
        {
            hasCatReachedSafeArea = true;
        }
    }
}
