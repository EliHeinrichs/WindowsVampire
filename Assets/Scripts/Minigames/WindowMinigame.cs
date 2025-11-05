using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WindowMinigame : MonoBehaviour
{

    public int maxRandomPresses = 20;
    public int minRandomPresses = 12;
    private int neededPresses;
    private int currentPresses = 0;

    public float maxTime = 10;
    private float currentTime = 10;

    public Window attachedWindow;

    public PlayerController playerController;

    public GameObject windowImageObject;

    private Vector2 windowBasePos;
    private Vector2 windowClosePos;
    private Vector2 windowCloseStartPos;

    public float closeDuration = 1.0f;
    public float closeSpeed = 3f;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;
    private bool isClosing = false;
    float elapsed = 0f;
    private void OnEnable()
    {
  
        currentTime = maxTime;
        currentPresses = 0;
        neededPresses = Random.Range(minRandomPresses, maxRandomPresses);

        if (windowBasePos != new Vector2(0, 0))
        {
           windowImageObject.transform.localPosition = windowBasePos;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            PressedEvent();
        }

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Debug.Log("You lose");
           StartCoroutine(WaitForAnimationEnd(GetComponent<Animator>(), "Out", "WindowFadeOut")); 

        }   

        if(isClosing)
            CloseTimer();

    }
 
    
    IEnumerator WaitForAnimationEnd(Animator animator,string triggerName,string animationName)
    {
        animator.SetTrigger(triggerName);
        

        yield return new WaitForSeconds(1.5f);
        
        UIManager.instance.DisableMiniGame();
        // Code to execute after animation finishes
    }

    void PressedEvent()
    {
        
        if (currentPresses >= maxRandomPresses)
        {
            return;
        }
        currentPresses += 1;

        if (currentPresses < maxRandomPresses)
        {
            ShakeWindow();
        }


        if (currentPresses >= maxRandomPresses)
        {   
            Debug.Log("You Win");
            CloseWindow();
            StartCoroutine(WaitForAnimationEnd(GetComponent<Animator>(), "Out", "WindowFadeOut")); 
            attachedWindow.active = true;
            
        }
            
    }

    

    // Start is called before the first frame update
    void Start()
    {     
        windowBasePos = windowImageObject.transform.localPosition;
        windowClosePos = windowBasePos + new Vector2(0, -250);
    }
   

    public void CloseWindow()
    {
        elapsed = 0;
        isClosing = true;
        

        windowCloseStartPos = windowImageObject.transform.localPosition;

        StopAllCoroutines();
    }

    private void CloseTimer()
    {
        elapsed += Time.deltaTime;
        float t = elapsed * closeSpeed;
        windowImageObject.transform.localPosition = Vector2.Lerp(windowCloseStartPos, windowClosePos, t);
        
        if (elapsed >= closeDuration)
        {
            isClosing = false;
                 
            return;
        }

    }

    public void ShakeWindow()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector2 randomOffset = Random.insideUnitCircle * shakeMagnitude;
            windowImageObject.transform.localPosition = windowBasePos + randomOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        windowImageObject.transform.localPosition = windowBasePos;
    }

}
