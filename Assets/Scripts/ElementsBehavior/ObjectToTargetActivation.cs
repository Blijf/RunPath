using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToTargetActivation : MonoBehaviour
{
    public List<Transform> objsToMoveTransforms;
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
            for(int i=0; i<objsToMoveTransforms.Count;i++)
            {

                float step= speed*Time.deltaTime;
                objsToMoveTransforms[i].position=Vector2.MoveTowards(objsToMoveTransforms[i].position, targetTransform.position, step);
            }
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
