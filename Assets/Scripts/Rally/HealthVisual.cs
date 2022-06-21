using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisual : MonoBehaviour
{
    private const float DAMAGED_HEALTH_FADE_TIMER_MAX = .6f;
    public Color damagedColor = Color.white;
    private float damagedHealthFadeTimer;


    public Image ringHealthBar, damagedHealthBar;
    public Color startColor = Color.red;
    public Color endColor = Color.grey;

    public float health, maxHealth = 100;
    float lerpSpeed;

    private void Awake()
    {

        damagedColor.a = 0f;
        damagedHealthBar.color = damagedColor;
    }
    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        
        if (health > maxHealth) health = maxHealth;
        if(health <= 0)
        {
            int index = GameObject.Find("CheckpointControl").GetComponent<TrackCheckpoints>().currCheckpointIndex;
            GameObject.Find("Red Sticky Car").transform.position = GameObject.Find("CheckpointControl").GetComponent<TrackCheckpoints>().checkpointSingleList[index].transform.position;
        }

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

        if (damagedColor.a > 0)
        {
            damagedHealthFadeTimer -= Time.deltaTime;
            if (damagedHealthFadeTimer < 0)
            {
                float fadeAmount = 5f;
                damagedColor.a -= fadeAmount * Time.deltaTime;
                damagedHealthBar.color = damagedColor;
            }
        }
    }

    void HealthBarFiller()
    {
       
        ringHealthBar.fillAmount = Mathf.Lerp(ringHealthBar.fillAmount, (health / maxHealth), lerpSpeed);

       
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(endColor, startColor, (5f * health / maxHealth));
        
        ringHealthBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    public void Damage(float damagePoints)
    {
        if (damagedColor.a <= 0)
        {
            // Damaged bar image is invisible
            damagedHealthBar.fillAmount = ringHealthBar.fillAmount;
        }
        damagedColor.a = 1;
        damagedHealthBar.color = damagedColor;
        damagedHealthFadeTimer = DAMAGED_HEALTH_FADE_TIMER_MAX;
        if (health > 0)
            health -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;
    }
}
