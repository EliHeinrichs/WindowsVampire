using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowMinigame : MonoBehaviour
{

    public float speedMultiplier  = 1f;
    public float maxPowerBar = 10;
    public float windowClosesRange = 1;
    public float centrePointPercentPlacement = 0.75f;
    private float currentPower = 0.1f;
    public Slider powerSlider;
    
    public Color rangeColor = Color.green;
    public Color furthestColor = Color.red;
    private Color currentColor;
    
    
    
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
        currentColor = Color.Lerp(furthestColor, rangeColor,0.1f) * Time.deltaTime * speedMultiplier;
             
     
            float centrePoint = maxPowerBar * centrePointPercentPlacement  ;
            if (currentPower >= (centrePoint - windowClosesRange) && (currentPower <= (centrePoint + windowClosesRange)))
            { 
               
                
                Debug.Log("You won!");
                
            }
            else
            {
               
            }
            
            
        
        
            powerSlider.fillRect.gameObject.GetComponent<Image>().color = currentColor;
        powerSlider.value = currentPower;
        
    }
}
