using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public PlayerController playerController;
    private GameObject currentActiveMiniGame;
    public GameObject doorMiniGame;
    public GameObject lightMiniGame;
    public GameObject windowMiniGame;
    public GameObject closetMiniGame;

    public void UpdateCurrentActiveMiniGame(GameObject nextMiniGame)
    {
        
        currentActiveMiniGame = nextMiniGame;
        currentActiveMiniGame.SetActive(true);
        playerController.ToggleMovement(false);
        
    }

    public void DisableMiniGame()
    {
        currentActiveMiniGame.SetActive(false);
        playerController.ToggleMovement(true);
    }

    public void PlayerEnabled(bool status)
    {
        playerController.gameObject.SetActive(status);
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

 
}
