using UnityEngine;

public class ChefSpawn : MonoBehaviour
{
    public GameObject chef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(chef);
    }
}
