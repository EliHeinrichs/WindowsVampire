using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockVisual : MonoBehaviour
{
    
    public Sprite lockImage;
    public Sprite unlockImage;
    private Image  lockComponent;

    void OnEnable()
    {
        lockComponent = GetComponent<Image>();
        lockComponent.sprite = unlockImage;
        
    }

    public void ToggleLockState()
    {
      
        lockComponent.sprite =   lockImage ;
    }
}
