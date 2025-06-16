using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 180.0f;
    float rotationX = 0;
    float rotationY = 0;

    public Transform orientation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationY += Input.GetAxis("Mouse X") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
            transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * lookSpeed, Input.GetAxis("Mouse X") * lookSpeed, 0);

            orientation.rotation = Quaternion.Euler(0, rotationY, 0);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
    }
}
