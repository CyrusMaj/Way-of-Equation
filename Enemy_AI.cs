using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent Agent;

    public GameObject Character;
    private Animator Anim;

    public float RotationSpeed = 7;

    public static bool pursue = false;

    private static bool alive = true;

    void Start()
    {
        Agent = this.GetComponent<NavMeshAgent>();
        Anim = Character.GetComponent<Animator>();
    }

    void Update()
    {
        //Enemy is always looking at player.
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        this.transform.LookAt(targetPosition);

        //Debug.Log(Agent.velocity);

        pursuePlayer();     

        //RandomRangeTimer();

        //pursue = EnemyAI.pursue;
        //if (pursue == true)
        //{
        //    pursuePlayer();
        //}

        extraRotation();
    }

    void pursuePlayer()
    {
        //alive = Enemy_Animator.alive;

        //if (alive == true)
        //{
            this.Agent.SetDestination(target.transform.position);

        //}
        //else
        //    this.Agent.SetDestination(Character.transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        //if (this.gameObject.tag == "Enemy")
        //{
        //    Destroy(this.gameObject);
        //}

        //Idles when reaching player, before striking.      //////
        //if (other.gameObject.name == "Player")
        //{
        //    if (Vector3.Distance(transform.position, Agent.destination) <= 2.4f)
        //    {
        //        Anim.SetBool("EnemyIdle", true);
        //        Anim.SetBool("EnemyPursuit", false);
        //    }
        //    else
        //    {
        //        Anim.SetBool("EnemyIdle", false);
        //        Anim.SetBool("EnemyPursuit", true);
        //    }
        //}

        //if attacking correct enemy with corret attack
        //if this.name ==' '
        //Destroy this.gameObject;
        //if this.name ==' '
        //block and immediately counterattack (coroutine)

        //pursuePlayer();
    }

    void RandomRangeTimer()
    {
        float rand;
        rand = Random.Range(1, 50);
        Mathf.Ceil(rand);
        if (rand == 25)
        {
            StartCoroutine("SendEnemyTimer");
        }
    }

    IEnumerator SendEnemyTimer()
    {
        yield return new WaitForSeconds(5f);
        pursuePlayer();
    }

    void extraRotation()
    {
        if (Agent.desiredVelocity.sqrMagnitude > Mathf.Epsilon)
        {
            Quaternion lookRotation = Quaternion.LookRotation(Agent.desiredVelocity, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, RotationSpeed * Time.deltaTime);
        }
    }
}
