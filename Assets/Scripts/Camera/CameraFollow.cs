using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target; // The target object to follow

    [SerializeField]
    private float smoothSpeed = 0.125f; // The speed of the camera's smoothing

    [SerializeField]
    private Vector2 maxBounds;

    [SerializeField]
    private Vector2 minBounds;

    private Camera camera;
    private float camWidth;
    private float camHeight;

    //offset to keep the camera 
    private float zOffset = -10f;

    void Start()
    {
        //printing log warning if script has no target
        if(target == null)
        {
            Debug.LogWarning(gameObject.name + " CameraFollow has no target assigned!" + this);
        }

        //grabbing the main camera in the scene 
        camera = Camera.main;

        //grabbing camera height and width 
        camHeight = camera.orthographicSize;
        camWidth = camHeight * camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }


    private void MoveCamera()
    {
        //making new vectors for the current and target position with the zOffset
        Vector3 currentCameraPosition = new Vector3(transform.position.x, transform.position.y, zOffset);
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, zOffset);

        //clamping the target position to the bounds + offset 
        float clampedX = Mathf.Clamp(targetPosition.x, minBounds.x + camWidth, maxBounds.x - camWidth);
        float clampedY = Mathf.Clamp(targetPosition.y, minBounds.y + camHeight, maxBounds.y - camHeight);

        //making new vector with the clamped values
        Vector3 clampedTargetPosition = new Vector3(clampedX, clampedY, zOffset);

        //interpolating the current camera position to the target using the smooth speed
        Vector3 smoothedPosition = Vector3.Lerp(currentCameraPosition, clampedTargetPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}