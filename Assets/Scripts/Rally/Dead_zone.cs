using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_zone : MonoBehaviour
{

    [SerializeField] HealthVisual healthvisual;
    [SerializeField] GameObject car_health;

    private void Awake()
    {
        healthvisual = car_health.GetComponent<HealthVisual>();
      
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "ignoreSensor")
        {
            healthvisual.health = 0;
        }
    }
}
