using System.Collections;
using System.Collections.Generic;
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
    private void OnEnable()
    {
        playerController.ToggleMovement(false);
        currentTime = maxTime;
        currentPresses = 0;
        neededPresses = Random.Range(minRandomPresses, maxRandomPresses);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            PressedEvent();
        }



        if (0 >= currentTime)
        {
            Debug.Log("You lose");
            ClosePanel();

        }

        currentTime -= Time.deltaTime;


    }
    void ClosePanel()
    {
        playerController.ToggleMovement(true);
        gameObject.SetActive(false);
    }


    void PressedEvent()
    {
        currentPresses += 1;

        if (currentPresses >= maxRandomPresses)
        {
            Debug.Log("You Win");
            attachedWindow.active = true;
            ClosePanel();
        }

    }

}
