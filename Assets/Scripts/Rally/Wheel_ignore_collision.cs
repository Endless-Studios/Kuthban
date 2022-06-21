using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_ignore_collision : MonoBehaviour
{
    [SerializeField] GameObject wheels;

    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "theobjectToIgnore")
        {
            Physics.IgnoreCollision(wheels.GetComponent<Collider>(), GetComponent<Collider>());
        }

    }
}
