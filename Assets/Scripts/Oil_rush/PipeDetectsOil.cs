using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDetectsOil : MonoBehaviour
{
    public float score;
   // public List<GameObject> fadeStars;
    public List<GameObject> brightStars;
    public List<GameObject> particleClusters;
    float totalParticles;
   public float percentComplete;

    private void Start()
    {
       
        int numberP = 0;
        foreach(var particleCluster in particleClusters)
        {
            numberP++;
        }
       // Debug.Log(numberP);
        totalParticles = numberP * 20;
       /// Debug.Log(totalParticles);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Oil"))
        {
            score++;
            percentComplete = score / totalParticles;
            Destroy(collision.gameObject);
        }
    }

    public void Update()
    {
        //percentComplete = score / totalParticles;
        //percentComplete = 
        //Debug.Log(percentComplete);
        if (percentComplete == 0.93f)
        {
            brightStars[2].SetActive(true);
            GameManager.gameWon = true;
        }   
        else if(percentComplete >= 0.66f)
            brightStars[1].SetActive(true);
        else if (percentComplete >= 0.33f)
            brightStars[0].SetActive(true);
    }
}
