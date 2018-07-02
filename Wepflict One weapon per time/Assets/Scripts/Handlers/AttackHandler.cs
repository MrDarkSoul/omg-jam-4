using System;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    BLUNT,
    SLASH,
    CLUSTER,
    SINGLE
}

class AttackHandler : MonoBehaviour
{
    private Dictionary<AttackType, Func<Transform, float, float, RaycastHit[], bool>> attackMap;

    public void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        attackMap = new Dictionary<AttackType, Func<Transform, float, float, RaycastHit[], bool>>
        {
            { AttackType.BLUNT, (t,a,d,h) => { return Blunt(t,a,d, out h); } },
            { AttackType.SLASH, (t,a,d,h) => { return Slash(t,a,d, out h); } },
            { AttackType.SINGLE, (t,a,d,h) => { return Single(t,a,d, out h); } },
        };
    }

    private bool Blunt(Transform attacker, float accurracy, float maxDistance, out RaycastHit[] hits)
    {
        accurracy = 1 - Mathf.Clamp01(accurracy / 100);

        Vector3 spread = new Vector3(
                UnityEngine.Random.Range(-accurracy, accurracy),
                UnityEngine.Random.Range(-accurracy, accurracy),
                UnityEngine.Random.Range(-accurracy, accurracy)
            );

        Vector3 direction = attacker.forward + spread;
        direction.Normalize();

        Ray ray = new Ray(attacker.position, direction);

        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, maxDistance))
        {
            hits = null;
            return false;
        }

        hits = new RaycastHit[1];
        hits[0] = hit;

        return true;
    }

    private bool Slash(Transform attacker, float accurracy, float maxDistance, out RaycastHit[] hits)
    {
        accurracy = 1 - Mathf.Clamp01(accurracy / 100);

        Vector3 spread = new Vector3(
                UnityEngine.Random.Range(-accurracy, accurracy),
                UnityEngine.Random.Range(-accurracy, accurracy),
                UnityEngine.Random.Range(-accurracy, accurracy)
            );

        Vector3 direction = attacker.forward + spread;
        direction.Normalize();

        Ray ray = new Ray(attacker.position, direction);

        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, maxDistance))
        {
            hits = null;
            return false;
        }

        hits = new RaycastHit[1];
        hits[0] = hit;

        return true;
    }

    private bool Cluster(Transform attacker, float accurracy, float maxDistance, out RaycastHit[] hits)
    {
        hits = null;
        return false;
    }

    private bool Single(Transform attacker, float accurracy, float maxDistance, out RaycastHit[] hits)
    {
        hits = null;
        return false;
    }
}