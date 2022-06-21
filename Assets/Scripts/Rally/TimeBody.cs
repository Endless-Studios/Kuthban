using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    public bool isRewinding = false;
    public GameObject rewindVisual;

    List<PointInTime> pointsInTime;
    Rigidbody rb;
    public float RewindTime = 5f;

    public time_manager timeManager;


    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(pointsInTime.Count);
        if (Input.GetKeyDown(KeyCode.E) && rewindVisual.GetComponent<Rewind>().currFill >= 100)
        {
            rewindVisual.GetComponent<Rewind>().currFill = -rewindVisual.GetComponent<Rewind>().fillSpeed;
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            StopRewind();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            //timeManager.DoSlowMotion();
        }

    }

    private void LateUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
        
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pointintime = pointsInTime[0];
            transform.position = pointintime.position;
            transform.rotation = pointintime.rotation;
            pointsInTime.RemoveAt(0);
            
        }

        else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(RewindTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
