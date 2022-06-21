
using UnityEngine;

public class time_manager : MonoBehaviour
{
    public float SlowDownFactor = 0.25f;
    public float SlowDownLength = 3f;


    private void Update()
    {
        Time.timeScale += (1f / SlowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
    public void DoSlowMotion()
    {
        Time.timeScale = SlowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}
