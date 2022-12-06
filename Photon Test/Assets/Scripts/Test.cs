using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviourPun
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            transform.position += transform.rotation * Vector3.forward * 5 * Time.deltaTime;
        }
    }
}
