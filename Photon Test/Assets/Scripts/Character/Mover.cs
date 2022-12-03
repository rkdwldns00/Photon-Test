using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Photon.Pun;
using UnityEngine.AI;

public class Mover : MonoBehaviourPun
{
    NavMeshAgent nav;
    Animator animator;

    public float Speed
    {
        get { return nav.speed;}
        set { nav.speed = value;}
    }

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        nav.angularSpeed = 2000;
        Debug.Log(nav.angularSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            animator.SetBool("isWalk", Speed > 0 && !nav.isStopped);
            if (!nav.isStopped && Vector3.Distance(transform.position,nav.destination) < 1)
            {
                nav.isStopped = true;
            }
        }
    }

    public void Tracking(Vector3 targetPos)
    {
        if (photonView.IsMine)
        {
            nav.SetDestination(targetPos);
            nav.isStopped = false;
        }
    }
}
