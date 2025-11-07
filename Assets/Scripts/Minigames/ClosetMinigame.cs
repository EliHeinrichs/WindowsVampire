using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClosetMinigame : MonoBehaviour
{
    [SerializeField]
    private float currentTimer;
    [SerializeField]
    private float indexFloatRange;
    [SerializeField]
    private float baseTimer;

    public Image statusBar;
    
    
    private float currentHealth;
    [SerializeField]
    private float maxHealth = 400;
    [SerializeField]
    private float degenRate;
    
    
    private float currentLosingBuffer;

    public inputs currentRequiredInput;
    
    private float barScaleMultiplier = 100;
    
    
    public inputs playerInput;


    public Image rightKey;
    public Image leftKey;

    public Sprite downSprite;
    public Sprite upSprite;

   
    
    
    public enum inputs
    {
        left,
        right,
        none
    }
    
    

    void UpdateSprite(Image host, Sprite upOrDown)
    {
        host.sprite = upOrDown;
    }
    
    
    // Start is called before the first frame update
    void OnEnable()
    {
      currentHealth = maxHealth;
      
    
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;

        if (currentTimer <= 0)
        {
            currentTimer = RandomTime();
            currentRequiredInput = GetRandomEnum<inputs>();
        }


        if (currentHealth <= 0)
        {
            UIManager.instance.EnablePlayer();
            UIManager.instance.DisableMiniGame();
        }
        HandlePlayerInputs();
        HandleVisuals();    
   
        
        //if correct status
        if (!PlayerStatus())
        {
            PlayerWrong();
        }
        

        statusBar.rectTransform.sizeDelta = new Vector2(currentHealth * barScaleMultiplier, statusBar.rectTransform.sizeDelta.y);
        
        
    }

  


    void PlayerWrong()
    { 
        currentHealth -= Time.deltaTime * degenRate;
    }
    
    
    


    bool PlayerStatus()
    {
        return playerInput == currentRequiredInput ? true : false;
    }

    void HandlePlayerInputs()
    {
        
       float currentInput = Input.GetAxisRaw("Horizontal");

     
           switch (currentInput)
           {
               case > 0:
                  
                   playerInput = inputs.right;
                   break;
               case < 0:
                   
                   playerInput = inputs.left;
                   break;
               case 0:
             
                   playerInput = inputs.none; 
                   break;
             
           }


 
       
  
        
       
    }



    void HandleVisuals()
    {
        switch (currentRequiredInput)
        {
            case inputs.none:
                UpdateSprite(rightKey, upSprite);
                UpdateSprite(leftKey, upSprite);
                
                break;
            case inputs.left:
                UpdateSprite(rightKey, upSprite);
                UpdateSprite(leftKey, downSprite);
                break;
            case inputs.right:
                UpdateSprite(rightKey, downSprite);
                UpdateSprite(leftKey, upSprite);
                break;
        }
    }
    
    float RandomTime()
    {
        return Random.Range(baseTimer - indexFloatRange, baseTimer + indexFloatRange);
    }
  
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
        return V;
    }
}
