using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraManager : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent player;

    private void Update()
    {
        CheckClicks();
    }

    private void CheckClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(Quaternion.Angle(Quaternion.Euler(hit.normal), Quaternion.identity));
                print(hit.point);
                player.SetDestination(hit.point);
            }
        }
    }
}
