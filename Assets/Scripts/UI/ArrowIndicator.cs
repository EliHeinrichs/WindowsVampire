using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{

    public Transform player;

    public List<Transform> targets;

    public Camera cam;

    public GameObject arrowPrefab;

    public float edgePadding = 50f;

    private List<GameObject> arrows = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in targets)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform);
            arrow.SetActive(false);         
            arrows.Add(arrow);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetVectorForTargets();
    }

    private void GetVectorForTargets()
    {
        for(int i = 0;  i < targets.Count; i++) 
        {
            Transform target = targets[i];
            GameObject arrow = arrows[i];

            arrow.SetActive(false);

            if ((targets[i].TryGetComponent<Door>(out Door door) && !door.active) || (targets[i].TryGetComponent<Window>(out Window window) && !window.active))
            {
                arrow.SetActive(true);

                //Vector from player to target object 
                Vector3 dir = target.position - player.position;
                Vector3 playerToTarget = player.position + dir.normalized * 4f;


                Vector2 screenPos = cam.WorldToScreenPoint(playerToTarget);

                screenPos.x = Mathf.Clamp(screenPos.x, edgePadding, Screen.width - edgePadding);
                screenPos.y = Mathf.Clamp(screenPos.y, edgePadding, Screen.height - edgePadding);

                Vector2 worldPos = cam.ScreenToWorldPoint(screenPos);

                arrow.transform.position = worldPos;

                //Angle of player to target for rotation
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                arrow.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
            }
            
        }
    }
}
