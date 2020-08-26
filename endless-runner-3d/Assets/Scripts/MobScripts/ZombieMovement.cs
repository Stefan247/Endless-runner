using System;
using UnityEngine;
using UnityEngine.AI;

namespace MobScripts
{
    public class ZombieMovement : MonoBehaviour
    {
        private NavMeshAgent navAgent;
        private Vector3 destination;

        private void Start()
        {
            destination = new Vector3(2.25f, 0.25f, -3.75f);
            navAgent = GetComponent<NavMeshAgent>();
            navAgent.SetDestination(destination);
        }
    }
}
