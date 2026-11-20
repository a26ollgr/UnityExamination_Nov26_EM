using UnityEngine;

public class OnEnableScript : MonoBehaviour
{

    private GameObject player;
    
    void OnEnable()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       player.transform.position = transform.position; 
    }
    
}
