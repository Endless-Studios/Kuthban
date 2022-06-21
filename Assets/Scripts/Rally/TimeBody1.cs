using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody1 : MonoBehaviour
{

    public bool isRewinding = false;

    List<PointInTime> pointsInTime;
    Rigidbody rb;
    public float RewindTime = 5f;


    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            StopRewind();
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
        if (pointsInTime.Count > 5)
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
