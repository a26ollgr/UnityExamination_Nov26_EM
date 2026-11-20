using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    private GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player =  GameObject.FindGameObjectWithTag("Player");
    }

    public void PickedUp()
    {
        transform.parent = player.transform;
        player.GetComponentInChildren<PlayerInteractions>().hasBall = true;
    }

}
