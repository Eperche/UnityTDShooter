using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

 
    public void Moving(float x,float y)
    {
        animator.SetFloat("vertical",y);
        animator.SetFloat("horizantal",x);
    }
 
}
