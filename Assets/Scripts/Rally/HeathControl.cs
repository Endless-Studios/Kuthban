using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathControl : MonoBehaviour
{
    public GameObject healthVisual;
    private float damage;
    private float speed;


    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            //Debug.Log("Collide");
            speed = rb.velocity.magnitude * 2.23693629f;
            damage = speed * 1;

            healthVisual.GetComponent<HealthVisual>().Damage(damage);

            //hslider.value -= speed;
        }
        
    }
}
