using System;
using UnityEngine;

public class MovingPart : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private float startYpos;
    private float x = 0;
    private float waveOffset = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startYpos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {   
        waveOffset = (float)Math.Sin(Time.time);
        
        transform.position = new Vector3(transform.position.x, startYpos + moveSpeed * waveOffset, transform.position.z);
    }
}
