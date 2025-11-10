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
        playerController.ToggleMovement(false);
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
            ClosePanel();

        }   

        if(isClosing)
            CloseTimer();

    }
    void ClosePanel()
    {
        playerController.ToggleMovement(true);
        gameObject.SetActive(false);
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

            attachedWindow.active = true;
            CloseWindow();
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
            ClosePanel();         
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
