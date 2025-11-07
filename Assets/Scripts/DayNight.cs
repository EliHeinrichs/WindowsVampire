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
    private List<GameObject> nightObjects = new List<GameObject>();
    
    [SerializeField]
    private List<GameObject> dayObjects = new List<GameObject>();
    
    public Image darkness;
    public Animator darknessAnimator;
    
    public GameObject enemyIndoors;
    

    private enum timeOfDay
    {
        Day,
        Night,
    }
    
    // Start is called before the first frame update
    void Start()
    {
  
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
        
        foreach (GameObject nightObject in nightObjects)
        {
            nightObject.SetActive(true);
        }

        foreach (GameObject dayObject in dayObjects)
        {
            dayObject.SetActive(false);
        }
        enemyIndoors.SetActive(false);
       
    }

    void DayTime()
    {
             dayOrNight = timeOfDay.Day;
        
        darknessAnimator.SetTrigger("Day");
        foreach (GameObject nightObject in nightObjects)
        {
            nightObject.SetActive(false);
        }

        foreach (GameObject dayObject in dayObjects)
        {
            dayObject.SetActive(true);
        }
        enemyIndoors.SetActive(false);
    }
}
