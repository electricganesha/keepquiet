using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressController : MonoBehaviour
{

    public int stressPoints = 0;
    public float timeToReduceStress = 2.0f;
    private float time;
    private float bedroomTime = 0.0f;
    private AudioSource theAudioSource;
    public int maxStress = 100;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        theAudioSource = gameObject.GetComponent<PlayerController>().getPlayerSound(0);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if(time >= timeToReduceStress)
        {
            if (stressPoints >= 0)
                stressPoints -= 1;
            time = 0.0f;
        }

        theAudioSource.volume = stressPoints / 100f;
        theAudioSource.pitch = (stressPoints / 100f) + .65f;

        if(stressPoints == maxStress)
        {
            levelManager.LoseGame();
        }
    }

    public void AddStress(int stressPointsAcquired)
    {
        if(stressPoints <= maxStress)
            stressPoints += stressPointsAcquired;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "CollisionObject")
        {
            GiveStress gs = collision.gameObject.GetComponent<GiveStress>();
            AddStress(gs.GetStressWeight());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollisionObject")
        {
            GiveStress gs = other.gameObject.GetComponent<GiveStress>();
            AddStress(gs.GetStressWeight());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        bedroomTime += Time.deltaTime;
        if (other.gameObject.tag == "ParentsBedroom")
        {
            if(bedroomTime >= 1.0f)
            {
                GiveStress gs = other.gameObject.GetComponent<GiveStress>();
                AddStress(gs.GetStressWeight());
                bedroomTime = 0;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bedroomTime = 0;
    }
}
