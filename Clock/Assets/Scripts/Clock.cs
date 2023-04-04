using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;

    const int hoursToDegrees = -30;
    const int minutesToDegrees = -6;
    const int secondsToDegrees = -6;

    void Awake () 
    {
        updateArmRotations();
    }

    void updateArmRotations()
    {
        TimeSpan now = DateTime.Now.TimeOfDay;
        float secondsZRotation = secondsPivot.localRotation.eulerAngles.z;
        secondsPivot.localRotation = Quaternion.Euler(0, 0, secondsToDegrees * now.Seconds); // We want the seconds arm to jolt every second

        if(secondsZRotation != secondsPivot.localRotation.eulerAngles.z){
            hoursPivot.localRotation = Quaternion.Euler(0, 0, hoursToDegrees * (float)now.TotalHours);
            minutesPivot.localRotation = Quaternion.Euler(0, 0, minutesToDegrees * (float)now.TotalMinutes);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateArmRotations();
    }
    
}
