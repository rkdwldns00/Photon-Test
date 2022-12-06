using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Control : MonoBehaviourPun
{
    Mover mover;
    Camera cam;
    Attacker attacker;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButton(0))
            {
                Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(mouseRay, out hit);
                if (hit.point != Vector3.zero)
                {
                    mover.Tracking(hit.point);
                }
            }
            if (Input.GetMouseButton(1))
            {
                attacker.UseAttack();
            }
        }
    }
}
