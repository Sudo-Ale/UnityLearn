using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public float patrolTime = 10f;
    public float aggroRange = 10f;
    public Transform[] waypoints;   //collection of data

    //without access modifier(public, private... = private)
    int index;  //what index we're on our waypoints arr
    float speed, agentSpeed;    //what current speed is and what component is
    Transform player;   //need to know where the player it is

    Animator anim;
    NavMeshAgent agent;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agentSpeed = agent.speed;
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        index = Random.Range(0, waypoints.Length);

        InvokeRepeating(nameof(Tick), 0, 0.5f);

        if (waypoints.Length > 0)
        {
            InvokeRepeating(nameof(Patrol), 0, patrolTime);
        }
    }
    void Patrol() //set the index we re using
    {
        index = index == waypoints.Length - 1 ? 0 : index + 1;
    }
    void Tick() 
    {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed / 2;

        if (player != null && Vector3.Distance(transform.position, player.position) < aggroRange)
        {
            agent.destination = player.position;
            agent.speed = agentSpeed;
        }
    }
}
