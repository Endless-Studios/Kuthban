using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewind : MonoBehaviour
{

    public Image rewindBar;

    public Color startColor = Color.red;
    public Color endColor = Color.grey;
    public float fillSpeed = 3f;
    public float currFill;

    float maxFill = 100;
    float lerpSpeed;


    private void Start()
    {
        currFill = 0;
    }

    private void Update()
    {
        currFill += Time.deltaTime * fillSpeed;
        if (currFill > maxFill) currFill = maxFill;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();


    }

    void HealthBarFiller()
    {
        //healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);
        rewindBar.fillAmount = Mathf.Lerp(rewindBar.fillAmount, (currFill / maxFill), lerpSpeed);

        //for (int i = 0; i < healthPoints.Length; i++)
        //{
        //    healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        //}
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(endColor, startColor, (5f * currFill / maxFill));
        //healthBar.color = healthColor;
        rewindBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }

    public void Damage(float damagePoints)
    {

        if (currFill > 0)
            currFill -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (currFill < maxFill)
            currFill += healingPoints;
    }
}
