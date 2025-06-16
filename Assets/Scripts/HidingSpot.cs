using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public delegate void PlayerHidden();
    public static event PlayerHidden hidden;

    public delegate void PlayerLeft();
    public static event PlayerLeft canSee;

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
