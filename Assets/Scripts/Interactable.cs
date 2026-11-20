using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    [SerializeField] public UnityEvent PlayerInRange;
    [SerializeField] public UnityEvent PlayerOutOfRange;

    [SerializeField] public UnityEvent PlayerInteracts;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
