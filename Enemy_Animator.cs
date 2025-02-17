using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy_Animator : MonoBehaviour
{
    public GameObject EnemyModel;
    public GameObject Enemy;
    public GameObject DeadShinobi;
    public GameObject BloodParticles;
    private Animator Enem;
    public GameObject EnemySword;
    private NavMeshAgent Agent;

    int AnimVal;

    private static int stance;
    private static float equationChoice;

    public static bool alive = true;

    void Start()
    {
        Enem = EnemyModel.GetComponent<Animator>();
        Agent = Enemy.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        GetVariables();
        EnemyMovement();
    }

    void GetVariables()
    {
        stance = BasicLinearEquation_03.stance;
        equationChoice = BasicLinearEquation_03.equationChoice;
    }

    void Punishment()
    {
        Enem.SetBool("Punishment", true);
        enemySwordActivate();
    }

    void EnemyMovement()    //Pursue player or idle?    //////
    {
        if (Vector3.Distance(EnemyModel.transform.position, Agent.destination) <= 2.4f)
        {
            Enem.SetBool("EnemyIdle", true);
            Enem.SetBool("EnemyPursuit", false);
        }
        else
        {
            Enem.SetBool("EnemyPursuit", true);
            Enem.SetBool("EnemyIdle", false);
        }
    }

    void EnemyDeathAnim()
    {
        GameObject Temporary_Dead_Handler;
        Temporary_Dead_Handler = Instantiate(DeadShinobi, transform.position, transform.rotation) as GameObject;

        GameObject Temporary_Blood_Handler;
        Temporary_Blood_Handler = Instantiate(BloodParticles, transform.position, transform.rotation) as GameObject;

        this.gameObject.SetActive(false);

        //alive = false;
        //Enem.SetBool("Enemy_Dying", true);

        //if (Enem.GetCurrentAnimatorStateInfo(0).IsName("Dying"))    //Check if animation is at end of clip before terminating.
        //{
        //    return;
        //}
        //else
        //{
        //    EnemySword.SetActive(false);
        //    Enem.SetBool("Enemy_Dying", false);
        //    Enem.SetBool("Enemy_Dead", true);
        //}
    }

    //Activating enemy sword
    void enemySwordActivate()
    {
        EnemySword.SetActive(true);
    }

    public void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.CompareTag("Slope_Enemy"))      //If attacking Slope Enemy.
        if (this.gameObject.tag == "Slope_Enemy")
        {
            Debug.Log("Slope Enemy Collision");

            //if (Input.GetKeyDown(KeyCode.Minus))        //Change to Mouse 1 && stance == 2
            if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 2)
            {
                Debug.Log("Minus Key, Slope Enemy");

                if (equationChoice <= 1)
                {
                    Debug.Log("equationChoice 1");

                    //Destroy(this.gameObject);
                    EnemyDeathAnim();
                }
                else
                {
                    Punishment();
                }
            }
            //else if (Input.GetKeyDown(KeyCode.Equals))        //Plus key.        //Change to Mouse 1 && stance == 3
            else if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 3)
            {
                Debug.Log("KeyCode.Plus, Slope Enemy");

                if (equationChoice == 3)
                {
                    Debug.Log("equationChoice == 3");
                    //Destroy(this.gameObject);
                    EnemyDeathAnim();
                }
                else
                {
                    Punishment();
                }
            }
            //else
            //{
            //    damagePlayer();
            //}
        }

        //if (other.gameObject.CompareTag("Constant_Enemy"))      //If attacking Constant Enemy.
        if (this.gameObject.tag == "Constant_Enemy")
        {
            Debug.Log("Constant_Enemy Collision");

            //if (Input.GetKeyDown(KeyCode.Slash))        //Change to Mouse 1 && stance == 1
            if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 1)
            {
                Debug.Log("KeyCode.Slash, Constant_Enemy");
                //Destroy(this.gameObject);
                EnemyDeathAnim();
            }
            //else
            //{
            // Punishment();
            //}
        }

        //Add Y_Constant condition, when time comes.

        //if (other.gameObject.CompareTag("Mx_Enemy"))        //If attacking Mx Enemy.
        if (this.gameObject.tag == "Constant_X_Enemy")
        {
            Debug.Log("Mx_Enemy Collision");

            //if (Input.GetKeyDown(KeyCode.Minus))        //Change to Mouse 1 && stance == 2
            if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 2)
            {
                Debug.Log("KeyCode.Minus, Mx_Enemy");

                if (equationChoice == 2)
                {
                    Debug.Log("equationChoice == 2");

                    //Destroy(this.gameObject);
                    EnemyDeathAnim();

                }
                else
                {
                    Punishment();
                }
            }
            //else if (Input.GetKeyDown(KeyCode.Equals))      //Plus key.        //Change to Mouse 1 && stance == 3
            else if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 3)
            {
                Debug.Log("KeyCode.Plus, Mx_Enemy");

                if (equationChoice > 3)     //Equation choice 4
                {
                    Debug.Log("equationChoice > 3");

                    //Destroy(this.gameObject);
                    EnemyDeathAnim();

                }
                else
                {
                    Punishment();
                }
            }
            //else
            //{
            //    damagePlayer();
            //}
        }

        //if (other.gameObject.CompareTag("Enemy"))
        if (this.gameObject.tag == "Enemy")       //If attacking Enemy
        {
            Debug.Log("Enemy Collision");

            //if ((Input.GetKeyDown(KeyCode.Equals)) || (Input.GetKeyDown(KeyCode.Minus)) || (Input.GetKeyDown(KeyCode.Slash)))        //Change to Mouse 1 && stance == 1 || stance == 2 || stance == 3
            if (Input.GetKeyDown(KeyCode.Mouse0) && (stance == 1 || stance == 2 || stance == 3))
            {
                Debug.Log("damagePlayer, Enemy, KeyCode.Plus, Minus, or Slash");
                Punishment();
            }
        }

        //Trigger enemy to attack
        if (this.gameObject.name == "Enemy")
        {
            enemySwordActivate();
            //Enem.SetBool("EnemyAttack", true);
            attack();
        }

        //if (this.gameObject.tag == "Enemy")
        //{
        //    Destroy(other.gameObject);
        //}
    }

    void attack()
    {
        float randAttack = Mathf.Ceil(Random.Range(1, 3));
        int RandAttack = (int)randAttack;

        if (RandAttack == 1)
        {
            Enem.SetBool("EnemyAttack", true);
        }
        else if (RandAttack == 2)
        {
            Enem.SetBool("Attack2", true);
        }
        else if (RandAttack == 3)
        {
            Enem.SetBool("Attack3", true);
        }
        else
        {
            Enem.SetBool("EnemyIdle", true);
            Enem.SetBool("EnemyAttack", false);
            Enem.SetBool("Attack2", false);
            Enem.SetBool("Attack3", false);
        }

    }

    //Animations only
    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.name == "Enemy")
        {
            if (Enem.GetCurrentAnimatorStateInfo(0).IsName("Attack_02"))    //Check if animation is at end of clip before terminating.
            {
                return;
            }
            else
            {
                EnemySword.SetActive(false);
                Enem.SetBool("EnemyAttack", false);
            }
        }
        else
            return;

        if (this.gameObject.name == "Enemy")
        {
            if (Enem.GetCurrentAnimatorStateInfo(0).IsName("Punishment"))    //Check if animation is at end of clip before terminating.
            {
                return;
            }
            else
            {
                EnemySword.SetActive(false);
                Enem.SetBool("Punishment", false);
            }
        }
        else
            return;

        if (this.gameObject.name == "Enemy")
        {
            if (Enem.GetCurrentAnimatorStateInfo(0).IsName("RisingCut"))    //Check if animation is at end of clip before terminating.
            {
                return;
            }
            else
            {
                EnemySword.SetActive(false);
                Enem.SetBool("Attack2", false);
            }
        }
        else
            return;

        if (this.gameObject.name == "Enemy")
        {
            if (Enem.GetCurrentAnimatorStateInfo(0).IsName("JumpSpin"))    //Check if animation is at end of clip before terminating.
            {
                return;
            }
            else
            {
                EnemySword.SetActive(false);
                Enem.SetBool("Attack3", false);
            }
        }
        else
            return;
    }
}
