using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float slowdownFactor = 0.05f;
    public float slowdownDuration = 4f;
    private bool stoptime;

    private void Start()
    {
        stoptime = false;
    }
    private void Update()
    {
        if (stoptime)
        {
            return;
        }
        Time.timeScale += (1f / slowdownDuration) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void slowDownMotion() 
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void stop()
    {
        Time.timeScale = 0;
    }
    public void fullstop()
    {
        Time.timeScale = 0;
        stoptime = true;
    }
    public void resume()
    {
        Time.timeScale = 1;
        stoptime = false;
    }
    public void fullslowDownMotion()
    {
        stoptime = true;
        Time.timeScale = 0.02f;
    }
}
