using UnityEngine;
using UnityEngine.SceneManagement;

public class ChefBrain : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent chef;

    private int destPoint = 0;
    public Transform[] points;
    public bool canPlayerBeSeen = true;

    void Awake()
    {
        HidingSpot.hidden += RatGone;
        HidingSpot.canSee += PlayerLeft;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chef = GetComponent<UnityEngine.AI.NavMeshAgent>();
        chef.autoBraking = false;
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!chef.pathPending && chef.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        chef.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void RatGone()
    {
        GotoNextPoint();
        canPlayerBeSeen = false;
    }

    void PlayerLeft()
    {
        canPlayerBeSeen = true;
    }

    void OnTriggerStay(Collider collider)
    {
        if (canPlayerBeSeen == true)
        {
            if (collider.gameObject.tag == "Player")
            {
                chef.SetDestination(collider.transform.position);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Lose");
        }
    }
}
