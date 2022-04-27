using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    Rigidbody rb;
    AudioSource AS;
    [SerializeField] float thrustForce = 100f;
    [SerializeField] float rotateForce = 100f;
    [SerializeField] AudioClip mainEngine;

    
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem rightBooster;

    void Start()
    {
        AS= GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        ProcessThrust ();
        ProcessRotation ();

    }

    void ProcessThrust (){
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();

        }
        else
        {
            StopThrust();
        }
    }

    void ProcessRotation (){
        
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            LeftRotation();

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RightRotation();

        }
    }

    private void StartThrust()
    {
        if (!AS.isPlaying)
        {
            AS.PlayOneShot(mainEngine);
        }

        mainBooster.Play();

        rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
    }

    private void StopThrust()
    {
        AS.Stop();
    }


    private void LeftRotation()
    {
        rightBooster.Play();
        ApplyRotation(rotateForce);
    }

    private void RightRotation()
    {
        leftBooster.Play();
        ApplyRotation(-rotateForce);
    }


    void ApplyRotation(float rotationThisFrame)
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationZ; //freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY; //unfreeze rotation so physics rotation can take over
    }
}
