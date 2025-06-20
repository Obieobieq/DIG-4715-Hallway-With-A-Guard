using UnityEngine;

public class ChefSpawn : MonoBehaviour
{
    public Transform TP;
    public GameObject Chef;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }



}
