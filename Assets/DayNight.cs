using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

    public float dayDuration;
    public float nightDuration;

    public float currentTimer;
    
    public timeOfDay dayOrNight;
    public enum timeOfDay
    {
        Day,
        Night,
    }
    
    // Start is called before the first frame update
    void Start()
    {
        dayOrNight = timeOfDay.Day;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        
        
    }
}
