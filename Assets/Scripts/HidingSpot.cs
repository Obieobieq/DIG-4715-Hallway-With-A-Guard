using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public delegate void PlayerHidden();
    public static event PlayerHidden hidden;

    public delegate void PlayerLeft();
    public static event PlayerLeft canSee;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hidden.Invoke();
            Debug.Log("Hidden!");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canSee.Invoke();
            Debug.Log("Player left!");
        }
    }
}
