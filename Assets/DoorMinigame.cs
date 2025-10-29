using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class DoorMinigame : MonoBehaviour
{

    public float blockSizeRange = 10f;
    public float blockHeight = 10f;
    public int totalBlocks = 5;
    public float speedMuliplier = 200f;
    
    public float clickCooldown = 1f;
    private float clickTimer = 1;
    
    public Image spinSprite;
    
    private  Dictionary<float,Image> blocks = new Dictionary<float, Image>();
    
    private float currentAngle = 0f;

    public Image slotImage;
    public RectTransform startRectTransform;

    private bool reverseSpin = false;


    public void CloseMinigame()
    {
           
        gameObject.SetActive(false);
        
        
    }

    public bool wonGame()
    {

        if (blocks.Keys.Count > 0)
        {
            return false;
        }
        return true;
        
    }
    
    
    // Start is called before the first frame update
    void OnEnable()
    {

   
       GenerateAngles();

    }

   
    
    

    void GenerateAngles()
    {
        blocks.Clear(); 
        for (int i = 0; i <= totalBlocks; i++)
        {
                float angle = Random.Range(0, 360);


                Image slot = Instantiate(slotImage, startRectTransform);

                slot.name = "slot" + i;
                blocks.Add(angle,slot);
                Debug.Log(blocks.Keys);
                slot.rectTransform.anchoredPosition = startRectTransform.anchoredPosition;
               
              
                slot.rectTransform.sizeDelta = new Vector2(blockSizeRange * 2, blockHeight);
                slot.rectTransform.localRotation = Quaternion.Euler(0f, 0f, angle);
                
                slot.gameObject.SetActive(true);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
       clickTimer -= Time.deltaTime;

        if (reverseSpin)
        {
               currentAngle -= Time.deltaTime * speedMuliplier;
        }
        else
        {
            currentAngle += Time.deltaTime * speedMuliplier;
        }
        
        if (currentAngle >= 360 && !reverseSpin) 
        {
            currentAngle = 0;
        }

        if (currentAngle <= 0 && reverseSpin)
        {
            currentAngle = 360;
        }
        spinSprite.rectTransform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

        if (Input.anyKeyDown && clickTimer <= 0)
        {
            Debug.Log(currentAngle);
            reverseSpin = !reverseSpin;
            HitBlock();

        }
        //controller.transform . rotation = Quaternion . AngleAxis (angle - 90 , Vector3 . forward);
    } 
    
    void HitBlock()
    {
        foreach (KeyValuePair<float,Image> block in blocks)
        {
            if (currentAngle < (block.Key + blockSizeRange) && currentAngle > (block.Key - blockSizeRange))
            {
                Destroy(block.Value.gameObject);    
                blocks.Remove(block.Key);
                if (wonGame())
                {
                    CloseMinigame();
                }
   
            }
            else
            {
                clickTimer = clickCooldown; 
            }
            
        }

    
    }
}
