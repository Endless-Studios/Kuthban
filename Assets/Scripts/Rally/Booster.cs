using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Booster : MonoBehaviour
{
    

   
    public Image BoosterBar;
    
    public Color startColor = Color.red;
    public Color endColor = Color.grey;
    public float fillSpeed = 3f;
    public float currBoost;

    float  maxBoost = 100;
    float lerpSpeed;

   
    private void Start()
    {
        currBoost = 0;
    }

    private void Update()
    {
        currBoost += Time.deltaTime * fillSpeed;
        if (currBoost > maxBoost) currBoost = maxBoost;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();

       
    }

    void HealthBarFiller()
    {
        //healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);
        BoosterBar.fillAmount = Mathf.Lerp(BoosterBar.fillAmount, (currBoost / maxBoost), lerpSpeed);

        //for (int i = 0; i < healthPoints.Length; i++)
        //{
        //    healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        //}
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(endColor, startColor, (5f * currBoost / maxBoost));
        //healthBar.color = healthColor;
        BoosterBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    public void Damage(float damagePoints)
    {
        
        if (currBoost > 0)
            currBoost -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (currBoost < maxBoost)
            currBoost += healingPoints;
    }
}
