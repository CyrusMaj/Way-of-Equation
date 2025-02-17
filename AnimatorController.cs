using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;

    public GameObject sheath;
    public GameObject sheathDummy;

    int stance = 1;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement();
        attack();
    }

    void movement()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            stance++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stance--;
        }

        if (stance > 3)
        {
            stance = 1;
        }
        if (stance < 1)
        {
            stance = 3;
        }

        if (stance == 1)
        {

        }
        else if (stance == 2)
        {

        }
        else if (stance == 3)
        {

        }

        //Moving Blend Tree
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("idle", false);
            animator.SetBool("running", true);

            animator.SetFloat("Forward", 1);

            animator.SetFloat("Idle_Forward", 0);     //Weird behaviors
                                                      //animator.SetFloat("Right", 0);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("idle", false);
            animator.SetBool("running", true);

            animator.SetFloat("Forward", -1);

            animator.SetFloat("Idle_Forward", 0);     //Weird behaviors
                                                      //animator.SetFloat("Right", 0);

        }
        else
        {
            animator.SetFloat("Forward", 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("idle", false);
            animator.SetBool("running", true);

            animator.SetFloat("Right", -1);

            animator.SetFloat("Idle_Right", 0);     //Weird behaviors
                                                    //animator.SetFloat("Forward", 0);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("idle", false);
            animator.SetBool("running", true);

            animator.SetFloat("Right", 1);

            animator.SetFloat("Idle_Right", 0);     //Weird behaviors
                                                    //animator.SetFloat("Forward", 0);

        }
        else
        {
            animator.SetFloat("Right", 0);
        }

        //Idle Blend Tree
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("idle", true);
            animator.SetBool("running", false);

            animator.SetFloat("Forward", 1);    //Weird behaviors
                                                //animator.SetFloat("Idle_Forward", 1);
                                                //animator.SetFloat("Idle_Right", 0);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("idle", true);
            animator.SetBool("running", false);

            animator.SetFloat("Forward", -1);    //Weird behaviors
                                                 //animator.SetFloat("Idle_Forward", -1);
                                                 //animator.SetFloat("Idle_Right", 0);
        }
        else
        {
            animator.SetFloat("Idle_Forward", 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("idle", true);
            animator.SetBool("running", false);

            animator.SetFloat("Right", -1);    //Weird behaviors
                                               //animator.SetFloat("Idle_Right", -1);
                                               //animator.SetFloat("Idle_Forward", 0);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("idle", true);
            animator.SetBool("running", false);

            animator.SetFloat("Right", 1);    //Weird behaviors
                                              //animator.SetFloat("Idle_Right", 1);
                                              //animator.SetFloat("Idle_Forward", 0);
        }
        else
        {
            animator.SetFloat("Idle_Right", 0);
        }
    }

    void attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("idle", false);
            animator.SetBool("Attack", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("idle", true);
            animator.SetBool("Attack", false);
        }

        //animator.SetBool("idle", false);
        //animator.SetBool("Attack", true);
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Slash"))
        //{
        //    return;
        //}
        //else
        //{
        //    animator.SetBool("idle", true);
        //    animator.SetBool("Attack", false);
        //}
    }
}
