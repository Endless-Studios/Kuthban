using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Gravity : MonoBehaviour
{
    private Rigidbody rb;

    public float gravity = -30f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {

        rb.AddForce(Vector3.up * (gravity) * rb.mass);
    }
}
