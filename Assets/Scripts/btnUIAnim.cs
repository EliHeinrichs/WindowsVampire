using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnUIAnim : MonoBehaviour
{
       
    [SerializeField]
    private float animSpeed;
    [SerializeField]
    private Sprite sprite1;
    [SerializeField]
    private Sprite sprite2;

  
    private float currentAnimTime;
    
    public Image image;

    // Update is called once per frame

    void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        currentAnimTime -= Time.deltaTime;
        if (currentAnimTime <= 0)
        {
           ToggleSprite();
            currentAnimTime = animSpeed;
        }
    }

    private void ToggleSprite()
    {
        if (image.sprite == sprite1)
        {
            image.sprite = sprite2;
        }
        else
        {
            image.sprite = sprite1;
        }
    }
    
    
    
}
