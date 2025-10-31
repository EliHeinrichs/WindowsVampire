using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField]
    private float dayDuration;
    [SerializeField]
    private float nightDuration;

    
    public float currentTimer;
    [SerializeField]
    private timeOfDay dayOrNight;
    
    [SerializeField]
    private List<GameObject> nightObjects;
    
    [SerializeField]
    private List<GameObject> dayObjects;
    
    private enum timeOfDay
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
       
        if (dayOrNight == timeOfDay.Day && currentTimer >= dayDuration)
        {
            
        }
        else if (dayOrNight == timeOfDay.Night && currentTimer >= nightDuration)
        {
            
        }
        else
        {
            currentTimer += Time.deltaTime;

        }
        
        
        
    }
}
