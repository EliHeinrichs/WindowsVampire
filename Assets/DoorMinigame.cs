using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
public class DoorMinigame : MonoBehaviour
{

    public float blockSizeRange = 10f;
    public float blockHeight = 10f;
    public int totalBlocks = 5;
    
    public float speedMuliplier = 200f;
    
    public float clickCooldown = 1f;

    public Image spinSprite;
    
    public  List<float> blocks = new List<float>();
    
    private float currentAngle = 0f;

    public Image slotImage;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalBlocks; i++)
        {
            float angle = Random.Range(0, 360);
            
            blocks.Add(angle);
           
            slotImage.rectTransform.sizeDelta = new Vector2(blockSizeRange, blockHeight);
            slotImage.rectTransform.localRotation =  Quaternion.Euler(0f, 0f, angle);
            


        }
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += Time.deltaTime * speedMuliplier;

        if (currentAngle >= 360) 
        {
            currentAngle = 0;
        }
        
        spinSprite.rectTransform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(currentAngle);
            if(HitBlock())
            {
                Debug.Log("Block Hit");
                
            }
        }
        //controller.transform . rotation = Quaternion . AngleAxis (angle - 90 , Vector3 . forward);
    }

    bool HitBlock()
    {
        bool returnValue = false;
        foreach (float block in blocks)
        {
            if (currentAngle < (block + blockSizeRange) && currentAngle > (block - blockSizeRange))
            {
                returnValue = true;
            }
            
        }

        return returnValue;
    }
}
