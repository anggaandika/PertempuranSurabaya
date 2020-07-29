using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent meshAgent;

    CharacterCombat combat;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        meshAgent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            meshAgent.SetDestination(target.position);

            if (distance <= meshAgent.stoppingDistance)
            {
                CharacterStats targetStat = target.GetComponent<CharacterStats>();
                if (targetStat != null)
                {
                    combat.Attack(targetStat);
                }
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 deraction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(deraction.x, 0, deraction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    
}
