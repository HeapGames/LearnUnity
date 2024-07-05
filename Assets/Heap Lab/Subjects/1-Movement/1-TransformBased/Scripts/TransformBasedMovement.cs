using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class TransformBasedMovement : MonoBehaviour
{
    public int Scenario;
    public Vector3 Direction;
    public float Speed = 1f;

    public Transform Target;
    public Vector3 Velocity;
    public float Duration;

    // Update is called once per frame
    void Update()
    {
        switch (Scenario)
        {
            case 0:
                transform.position = transform.position + Direction * Speed * Time.deltaTime;
                break;
            case 1:
                transform.Translate(Direction * Speed * Time.deltaTime, Space.World);
                break;
            case 2:
                transform.position = Vector3.Lerp(transform.position, Target.position, Speed * Time.deltaTime);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
                break;
            case 4:
                transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref Velocity, Duration);
                break;
            default:
                break;
        }
    }

}
