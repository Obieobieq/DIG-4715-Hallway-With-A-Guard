using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;
    float rotationY = 0;

    public Transform orientation;

    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Pausing.currentlyPaused += stopLooking;
        Pausing.notPaused += resumeLooking;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (isPaused == false)
        {
            orientation.rotation = Quaternion.Euler(0, rotationY, 0);

            rotationX += (-Input.GetAxis("Mouse Y") * lookSpeed);
            rotationY += (Input.GetAxis("Mouse X") * lookSpeed);
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
            transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * lookSpeed, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
    }

    void stopLooking()
    {
        isPaused = true;
    }

    void resumeLooking()
    {
        isPaused = false;
    }
}
