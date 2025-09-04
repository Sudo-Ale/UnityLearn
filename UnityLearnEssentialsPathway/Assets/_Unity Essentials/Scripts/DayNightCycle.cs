using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Variable to control how long a full day lasts in seconds
    [Header("Day-Night Cycle Settings")]
    public float secondsPerDay = 60f;  // Time in seconds for one full cycle (default is 60 seconds for a full day)

    // Internal variable to track rotation progress
    private float rotationSpeed;

    void Start()
    {
        // Calculate the rotation speed based on the total seconds in a day
        rotationSpeed = 360f / secondsPerDay;
    }

    void Update()
    {
        // Rotate the Directional Light around the X-axis (assuming the light is rotating around the Y-axis)
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
