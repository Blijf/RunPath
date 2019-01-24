using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeActivation : MonoBehaviour
{
    public Transform objectToMoveTransform;
    public Transform targetTransform;
    public float speed;
    bool start;

    void Start() 
    {
        start=false;
    }
    void Update()
    {
        if(start)
        {
            float step= speed*Time.deltaTime;
            objectToMoveTransform.position=Vector2.MoveTowards(objectToMoveTransform.position, targetTransform.position, step);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            start=true;   
        }
    }

}
