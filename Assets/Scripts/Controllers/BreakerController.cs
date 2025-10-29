using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerController : MonoBehaviour
{
    public Pawn wirePawn;   
    public WireController wireController;
    public GameObject prefab;
    public TrailRenderer wireTrail;
    void Start()
    {                  
        if(wireController != null)
            wireController.Possess(wirePawn);

        StartGame();
    }

    void Update()
    {
        ListenForInput();
    }

    public void StartGame()
    {
        
        wirePawn.ResetPosition();
        wireController.ResetMovementFloats();
        wireTrail.Clear();
    }

    private void ListenForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            prefab.SetActive(false);
        }
    }
}
