using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public abstract class FighterAI : MonoBehaviour {

    public Animator animator;
    public NavMeshAgent agent;

    private void Update()
    {
        ManageAnimations();
    }

    private void ManageAnimations()
    {
        Vector3 v3 = transform.InverseTransformDirection(agent.velocity);

        animator.SetFloat("Fspeed", v3.z);
        animator.SetFloat("Lspeed", v3.x);
    }

}
