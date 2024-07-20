using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public enum TransformScenario
{
    AddingPosition,
    Translate,
    Lerp,
    MoveTowards,
    SmoothDamp,
    Slerp
}

public class TransformBasedMovement : MonoBehaviour
{
    public TransformScenario Scenario;
    public Vector3 Direction;
    public float Speed = 1f;

    public Transform Target;
    public Vector3 Velocity;
    public float Duration;
    public float MaxSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        switch (Scenario)
        {
            case TransformScenario.AddingPosition:
                transform.position = transform.position + Direction * Speed * Time.deltaTime;
                break;
            case TransformScenario.Translate:
                transform.Translate(Direction * Speed * Time.deltaTime, Space.World);
                break;
            case TransformScenario.Lerp:
                transform.position = Vector3.Lerp(transform.position, Target.position, Speed * Time.deltaTime);
                break;
            case TransformScenario.MoveTowards:
                transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
                break;
            case TransformScenario.SmoothDamp:
                transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref Velocity, Duration, MaxSpeed);
                break;
            case TransformScenario.Slerp:
                transform.position = Vector3.Slerp(transform.position, Target.position, Speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

}
