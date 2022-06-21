using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private HealthVisual healthVisual;
    private GameObject car;
    private TrackCheckpoints trackCheckpoints;
   

    // Start is called before the first frame update
    void Start()
    {
        
        healthVisual = GameObject.Find("HealthVisual").GetComponent<HealthVisual>();
        car = GameObject.Find("Cars").transform.Find("Red Car Sticky").gameObject;
        trackCheckpoints = GameObject.Find("CheckpointControl").GetComponent<TrackCheckpoints>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(healthVisual.health <= 0)
        {
            healthVisual.health = healthVisual.maxHealth;
            car.transform.position = trackCheckpoints.checkpointSingleList[trackCheckpoints.currCheckpointIndex].transform.position;
            //car.transform.LookAt(trackCheckpoints.checkpointSingleList[trackCheckpoints.currCheckpointIndex].transform);
            //car.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            Vector3 temp = car.transform.rotation.eulerAngles;
            //temp.y = trackCheckpoints.checkpointSingleList[trackCheckpoints.currCheckpointIndex].transform.localEulerAngles.y;
            //car.transform.rotation = Quaternion.Euler(temp);
            car.transform.rotation = trackCheckpoints.checkpointSingleList[trackCheckpoints.currCheckpointIndex].transform.rotation;
            car.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
