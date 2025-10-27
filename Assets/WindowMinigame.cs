using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowMinigame : MonoBehaviour
{

    public float speedMultiplier  = 1f;
    public float maxPowerBar = 10;

    public float windowClosesPercentRange = 0.1f;
    public float windowSlammedPercentRange = 0.2f;
    public int windowSlightlyMovesIntervals = 3;
    private float currentPower = 0.1f;
    public Slider powerSlider;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        powerSlider.maxValue = maxPowerBar;
    }

    // Update is called once per frame
    void Update()
    {
        currentPower += Time.deltaTime * speedMultiplier;

        if (currentPower >= maxPowerBar)
        {
            speedMultiplier = -speedMultiplier;

        }

        if (currentPower <= 0)
        {
            
            speedMultiplier = -speedMultiplier;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            float midPoint = (maxPowerBar - (maxPowerBar * windowSlammedPercentRange)) / 2  ;
            if (currentPower >= midPoint && currentPower <= midPoint + (maxPowerBar * windowClosesPercentRange))
            {
                
                Debug.Log("You won!");
                
            }
            
        }
        
        
        powerSlider.value = currentPower;
        
    }
}
