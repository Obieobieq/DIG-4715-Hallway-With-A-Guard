using UnityEngine;
using UnityEngine.SceneManagement;

public class ChefBrain : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent chef;

    private int destPoint = 0;

    [SerializeField]
    private Transform[] points;

    private bool canPlayerBeSeen = true;
    private bool fixingChefSpeed = false;

    public Animator animator;

    [SerializeField]
    private float boostMultiplier = 2.5f;

    //Initializes events
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


        Transform[] points = GameObject.FindGameObjectWithTag("Point").transform;

        GotoNextPoint();
    }

    // Has the chef go to the next point when close enough to its current objective
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

    //Tells the chef to return to his pathing when the player is hidden
    void RatGone()
    {
        GotoNextPoint();
        canPlayerBeSeen = false;
        animator.SetBool("seeRat", false);
        if (fixingChefSpeed == true)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed /= boostMultiplier;
            fixingChefSpeed = false;
        }
    }

    //Tells the chef that the player can now be seen
    void PlayerLeft()
    {
        canPlayerBeSeen = true;
    }

    //If player enters FOV, chases player at boostMultiplier speed
    void OnTriggerStay(Collider collider)
    {
        if (canPlayerBeSeen == true)
        {
            if (collider.gameObject.tag == "Player")
            {
                chef.SetDestination(collider.transform.position);
                animator.SetBool("seeRat", true);
                
                if (fixingChefSpeed == false)
                {
                    GetComponent<UnityEngine.AI.NavMeshAgent>().speed *= boostMultiplier;
                    fixingChefSpeed = true;
                }
                
            }
        }
    }

    // If player is touched, sends player to GameOver screen
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("canAttack", true);
            Invoke("lost", 2);
            GetComponent<UnityEngine.AI.NavMeshAgent>().speed /= boostMultiplier;
        }
    }

    void lost()
    {
        SceneManager.LoadScene("Lose");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
