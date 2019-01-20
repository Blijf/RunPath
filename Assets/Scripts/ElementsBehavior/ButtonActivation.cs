using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    public GameObject doorToOpen;//puerta que se quiere abrir
    Collider2D collider2D;
    Animator animator;
    void Start()
    {
        collider2D= doorToOpen.GetComponent<Collider2D>();
        animator= doorToOpen.GetComponent<Animator>();
        animator.enabled=false;
        collider2D.isTrigger=false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
          animator.enabled=true;
          collider2D.isTrigger=true;
            
        }
    }
}
