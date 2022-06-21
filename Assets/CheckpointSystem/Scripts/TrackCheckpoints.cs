using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{


    public List<CheckpointSingle> checkpointSingleList;
    
   
    public int currCheckpointIndex;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();

            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);
        }
        
        currCheckpointIndex = 0;
       
    }

    public void CarThroughCheckpoint(CheckpointSingle checkpointSingle, Transform carTransform)
    {

        if (checkpointSingleList.IndexOf(checkpointSingle) > currCheckpointIndex)
        {
            currCheckpointIndex = checkpointSingleList.IndexOf(checkpointSingle);
            // Correct checkpoint
            //Debug.Log("Correct");
            //Debug.Log(checkpointSingle.transform.position);
            //Debug.Log(checkpointSingleList[currCheckpointIndex].transform.position);
            // GameObject.Find("object").transform.position = checkpointSingle.transform.position;

        }
        
    }


}
