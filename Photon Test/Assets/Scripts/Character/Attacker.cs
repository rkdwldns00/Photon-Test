using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    Animator animator;
    float timer;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void UseAttack()
    {
        if (timer <= 0)
        {
            timer = 1;
            animator.SetTrigger("useAttack");
            PhotonNetwork.Instantiate(prefab.name, transform.position, transform.rotation);
        }
    }
}
