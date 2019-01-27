using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : MonoBehaviour
{
    public GameObject doorToOpen;//puerta que se quiere abrir
    Collider2D coll;
    Animator animator;
    void Start()
    {
        coll= doorToOpen.GetComponent<Collider2D>();
        animator= doorToOpen.GetComponent<Animator>();
        animator.enabled=false;
        coll.isTrigger=false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
          animator.enabled=true;
          coll.isTrigger=true;
            
        }
    }
}
