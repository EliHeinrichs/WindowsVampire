using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorMinigame : MonoBehaviour
{

    public float blockSizeRange = 10f;
    public int totalBlocks = 5;
    
    public float speedMuliplier = 200f;

    public Image spinSprite;
    
    private float[] blocks;
    
    private float currentAngle = 0f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += Time.deltaTime * speedMuliplier;

        if (currentAngle >= 360 || currentAngle <= -360) 
        {
            currentAngle = 0;
        }
        
        spinSprite.rectTransform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        
        
        //controller.transform . rotation = Quaternion . AngleAxis (angle - 90 , Vector3 . forward);
    }
}
