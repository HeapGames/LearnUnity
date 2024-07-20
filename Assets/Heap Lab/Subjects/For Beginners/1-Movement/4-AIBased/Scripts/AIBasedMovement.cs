using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIScenario
{
    Velocity,
    Destination
}

public class AIBasedMovement : MonoBehaviour
{
    public AIScenario Scenario;
    public Transform Target;
    public Vector3 Direction;
    public float Speed = 1f;

    public NavMeshAgent Agent;

    private void Start()
    {
        if(Scenario == AIScenario.Destination)
        {
            Agent.SetDestination(Target.position);
        }
    }

    private void Update()
    {
        switch (Scenario)
        {
            case AIScenario.Velocity:
                Agent.velocity = Direction * Speed;
                break;
            case AIScenario.Destination:
                break;
            default:
                break;
        }
    }
}
