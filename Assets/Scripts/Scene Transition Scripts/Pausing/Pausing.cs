using UnityEngine;

public class Pausing : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetButtonDown("Pause") && isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
        }

        if (Input.GetButtonDown("Pause") && isPaused == true)
        {
            Time.timeScale = 1;
            isPaused = false;
        }

    }
}
