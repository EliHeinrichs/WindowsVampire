using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]
    private int nightCount;
    
    [SerializeField]
    private TextMeshProUGUI nightText;
    
    private enum timeOfDay
    {
        Day,
        Night,
    }
    
    // Start is called before the first frame update
    void Start()
    {
  
        darknessAnimator = darkness.GetComponent<Animator>();
        nightCount = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
       
        if (dayOrNight == timeOfDay.Day && currentTimer >= dayDuration)
        {
            
            NightTime();
            nightCount++;
            nightText.text = "night: " + nightCount.ToString();
            currentTimer = 0;
        }
        else if (dayOrNight == timeOfDay.Night && currentTimer >= nightDuration)
        {
           
            nightText.text = "night over";
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
    }
}
