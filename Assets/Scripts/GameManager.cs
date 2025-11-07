using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    
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
    
   

    public GameObject pingObject;
    [SerializeField]
    private float pingAngle;
    [SerializeField]
    private float pingTime;
    
 
    
    
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    

    public void PingPopup(AbstractObject objectToPing)
    {
      //  pingAngle = Vector2.Angle(objectToPing.transform.position, pingObject.transform.position);
        
        
        Debug.Log(pingAngle + ": angle");
        
    }

    IEnumerator PingFollow(Transform target)
    {
        
        
        yield return new WaitForSeconds(pingTime);
    }
}
