using System.Collections;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    // [Header("fov settings")]
    // public float veiwangle = 90f;
    // public float veiwradius = 15f;
    // public LayerMask obstacleMask;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        GameObject playerObj = GameObject.FindWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
     
    }

    void Update()
    {
        if (player != null )
        {
            agent.SetDestination(player.position);
        }
    }

    // bool CanseePlayer()
    // {
    //     Vector3 dirToPlayer = (player.position - transform.position).normalized;
    //     float distanceToPlayer = Vector3.Distance(transform.position, player.position);
    //     if (distanceToPlayer <= veiwradius)
    //     {
    //         if (!Physics.Raycast(transform.position + Vector3.up, dirToPlayer, distanceToPlayer, obstacleMask))
    //         {
    //             return true;
    //         }
    //     }
    //     return false;


    //}
    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.blueViolet;
    //     Gizmos.DrawWireSphere(transform.position, veiwradius);
    //     Vector3 left = Quaternion.Euler(0, -veiwangle / 2f, 0) * transform.forward;
    //     Vector3 right = Quaternion.Euler(0, veiwangle / 2f, 0) * transform.forward;
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawRay(transform.position, left * veiwradius);
    //     Gizmos.DrawRay(transform.position, right * veiwradius);
    // }
    

}

