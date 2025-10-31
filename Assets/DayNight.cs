using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    public Image darkness;
    private Animator darknessAnimator;
    
    private enum timeOfDay
    {
        Day,
        Night,
    }
    
    // Start is called before the first frame update
    void Start()
    {
        dayOrNight = timeOfDay.Day;
        darknessAnimator = darkness.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (dayOrNight == timeOfDay.Day && currentTimer >= dayDuration)
        {
            NightTime();
            currentTimer = 0;
        }
        else if (dayOrNight == timeOfDay.Night && currentTimer >= nightDuration)
        {
            DayTime();  
            currentTimer = 0;
        }
        else
        {
            currentTimer += Time.deltaTime;

        }
        
        
        
    }
    


    void NightTime()
    {
        dayOrNight = timeOfDay.Night;
        darknessAnimator.SetTrigger("Night");
        foreach (GameObject obj in nightObjects)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in dayObjects)
        {
            obj.SetActive(false);
        }
    }

    void DayTime()
    {
             dayOrNight = timeOfDay.Day;
        darknessAnimator.SetTrigger("Day");
        foreach (GameObject obj in nightObjects)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in dayObjects)
        {
            obj.SetActive(true);
        }
    }
}
