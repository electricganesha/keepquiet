using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float initialAccel;
    private float accel;
    public float slowDown;
    private Vector3 dirV;
    //private Vector3 lastDirV;
    public Transform directionVector;
    private Animator JKCAnim; //Animator component attached to Junkochan

    private float timer;
    private bool colidiu;

    private KeyCode up, down, left, right, fire;
    private String joyX, joyY, fireJoy;
    private float currentX, currentZ;

    public Animator animator;

    public Camera theCamera;

    private Vector3 previousPosition; // variable to keep the previous position
    public float distanceTraveled;

    public AudioSource[] playerSounds; // 0 Hearbeat - 1 Match
    public AudioSource[] playerSteps; 

    void Awake()
    {
        // initialize to the current position
        previousPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        JKCAnim = this.GetComponent<Animator>();
        accel = initialAccel;

        joyX = "Horizontal";
        joyY = "Vertical";
        fireJoy = "Fire1";
}

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentX = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentX = 1;
        }

        if (Mathf.Abs(Input.GetAxis(joyX)) > 0.1f && animator.GetBool("lightmatch") == false)
        {
            currentX = Input.GetAxis(joyX);
        } else
        {
            currentX = 0;
        }

        if (Mathf.Abs(Input.GetAxis(joyY)) >0.1f && animator.GetBool("lightmatch") == false)
        {
            currentZ = Input.GetAxis(joyY);
        }
        else
        {
            currentZ = 0;
            JKCAnim.SetBool("Move", true);
        }

        Vector3 direction = new Vector3(currentX, 0, currentZ);
        if(direction.magnitude != 0)
        {
            rb.AddForce(direction * accel);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), 0.2f);
            JKCAnim.SetBool("Move", true);
        }
        else
        {
            transform.rotation = transform.rotation;
            //directionVector.transform.LookAt(lastDirV * 100);
            JKCAnim.SetBool("Move", false);
        }

        if (Input.GetButton(fireJoy) && animator.GetBool("lightmatch") == false)
        {

            animator.SetBool("lightmatch", true);
            playerSounds[1].Play();
            //rb.isKinematic = true;
            StartCoroutine("StopMoving");
            JKCAnim.SetBool("Move", false);
            JKCAnim.SetBool("Crouch", true);
            //JKCAnim.enabled = false;


        }

        // add the distance covered during the last frame
        distanceTraveled += (transform.position - previousPosition).magnitude;
        // update the 'previous' position to the current one
        previousPosition = transform.position;
        if (distanceTraveled >= 0.9f)
        {
            playerSteps[UnityEngine.Random.Range(0,1)].Play();
            distanceTraveled = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }

    private void OnTriggerStay(Collider target)
    {
        
    }

    IEnumerator StopMoving()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5.5f);
        //rb.isKinematic = false;
        animator.SetBool("lightmatch", false);
        JKCAnim.SetBool("Move", true);
        JKCAnim.SetBool("Crouch", false);
        //JKCAnim.SetBool("Move", false);
        //JKCAnim.enabled = true;

    }

    public AudioSource getPlayerSound(int index)
    {
        return playerSounds[index];
    }
}
