using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class powerups : MonoBehaviour{

    public float boostForce;
    public float fieldOfView;
    //public int boost_count;
    public MMFeedbacks Boost_Feedback;

    public Camera camera;
    public GameObject boosterVisual;
    [SerializeField] GameObject player;
    carController speed_change;

    [SerializeField] float boost_duration = 3f;
    [SerializeField] float Boost_duration = 3f;
    private bool boost_active = false;


    //float currBoost; 

    void Start()
    {
        camera = FindObjectOfType<Camera>();
        //currBoost = ;

    }

    private void Awake()
    {
        speed_change = player.GetComponent<carController>();
        boost_active = false;
    }

    void Update(){
        //if(Input.GetKeyDown(KeyCode.LeftShift) && (boost_count > 0)) 
        //{
        //    Boost_Feedback?.PlayFeedbacks();
        //    Nitrus n = new Nitrus();
        //    n.boost(gameObject , boostForce , camera , fieldOfView);
        //    boost_count -= 1;
        //}
        if (Input.GetKeyDown(KeyCode.LeftShift) && boosterVisual.GetComponent<Booster>().currBoost >= 100)
        {
            Boost_Feedback?.PlayFeedbacks();
            Nitrus n = new Nitrus();
            n.boost(gameObject, boostForce, camera, fieldOfView);
            speed_change.speed += boostForce;
            //boost_count -= 1;
            boosterVisual.GetComponent<Booster>().currBoost = -boosterVisual.GetComponent<Booster>().fillSpeed;
            
            boost_active = true;
        }

        if (boost_active)
        {
            if (boost_duration >= 0)
            {
                boost_duration -= 1 * Time.deltaTime;
            }
            else
            {
                boost_duration = Boost_duration;
                speed_change.speed -= boostForce;
                boost_active = false;
            }
            
        }

        
    }

}


