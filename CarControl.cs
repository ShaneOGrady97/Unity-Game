using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{

    public GameObject FL; // wheel gameObjects
    public GameObject FR;
    public GameObject BL;
    public GameObject BR;


    public WheelCollider WheelFL; // wheel colliders
    public WheelCollider WheelFR;
    public WheelCollider WheelBL;
    public WheelCollider WheelBR;


    public float topSpeed = 250f; // top speed
    public float maxTorque = 200f; // maximum torque to apply to wheels
    public float maxSteerAngle = 45f;
    public float currentSpeed;
    public float maxBrakeTorque = 2200;

    private float Forward;
    private float Turn;
    private float Brake;

    private Rigidbody rb; // rigid body of car
    private Vector3 com;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;
    }

    void FixedUpdate()
    { // fixed update is more realistic physics

        
        Forward = Input.GetAxis("Vertical");
        Turn = Input.GetAxis("Horizontal");
        Brake = Input.GetAxis("Jump");

        WheelFL.steerAngle = maxSteerAngle * Turn;
        WheelFR.steerAngle = maxSteerAngle * Turn;

        currentSpeed = 2 * 22 / 7 * WheelBL.radius * WheelBL.rpm * 60 / 1000; // formula for calculating speed in kmph

        if (currentSpeed < topSpeed)
        {
            WheelFL.motorTorque = maxTorque * Forward; 
            WheelFR.motorTorque = maxTorque * Forward;
        }

 
        WheelBL.brakeTorque = maxBrakeTorque * Brake;
        WheelBR.brakeTorque = maxBrakeTorque * Brake;
        WheelFL.brakeTorque = maxBrakeTorque * Brake;
        WheelFR.brakeTorque = maxBrakeTorque * Brake;

    }

    void Update()
    {
        Quaternion flq; //rotation of wheel collider
        Vector3 flv; // position of wheel collider
        WheelFL.GetWorldPose(out flv, out flq); // get wheel collider position and rotation
        FL.transform.position = flv;
        FL.transform.rotation = flq;

        Quaternion frq; //rotation of wheel collider
        Vector3 frv; // position of wheel collider
        WheelFR.GetWorldPose(out frv, out frq); // get wheel collider position and rotation
        FR.transform.position = frv;
        FR.transform.rotation = frq;

        Quaternion blq; //rotation of wheel collider
        Vector3 blv; // position of wheel collider
        WheelBL.GetWorldPose(out blv, out blq); // get wheel collider position and rotation
        BL.transform.position = blv;
        BL.transform.rotation = blq;

        Quaternion brq; //rotation of wheel collider
        Vector3 brv; // position of wheel collider
        WheelBR.GetWorldPose(out brv, out brq); // get wheel collider position and rotation
        BR.transform.position = brv;
        BR.transform.rotation = brq;
    }
}
