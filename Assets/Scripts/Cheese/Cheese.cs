using UnityEngine;

public class Cheese : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotation;
    [SerializeField]
    private float speed = 3f;

    private float speed2 = 1f;
    private float height = 0.1f;

    private Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float newY = Mathf.Sin(Time.time * speed2) * height + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
