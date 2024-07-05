using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RigidbodyBasedMovement : MonoBehaviour
{
    public int Scenario;
    public Vector3 Direction;
    public float Power = 10f;
    public float Speed = 10f;
    public Transform Target;
    public bool AddExplosionForce;
    public bool ResetPos;
    private Rigidbody rb;
    private Vector3 initialPosition;
    private Vector3 initialEulerAngles;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialEulerAngles = transform.eulerAngles;
    }

    void FixedUpdate()
    {
        rb.isKinematic = false;
        switch (Scenario)
        {
            case 0:
                rb.AddForce(Direction * Power);
                break;
            case 1:
                rb.AddRelativeForce(Direction * Power);
                break;
            case 2:
                rb.AddTorque(Direction * Power); 
                break;
            case 3:
                rb.velocity = Direction * Speed;
                break;
            case 4:
                rb.angularVelocity = Direction * Speed;
                break;
            case 5:
                rb.isKinematic = true;
                rb.MovePosition(Vector3.Lerp(transform.position, Target.position, Time.deltaTime * Speed));
                rb.MoveRotation(Quaternion.Lerp(transform.rotation, Target.rotation, Time.deltaTime * Speed)); 
                break;
            default:
                break;
        }


        if (AddExplosionForce)
        {
            rb.AddExplosionForce(Power, transform.position, 5f, 1f, ForceMode.Impulse);
            AddExplosionForce = false;
        }

        if (ResetPos) 
        {
            rb.isKinematic = true;
            transform.position = initialPosition;
            transform.eulerAngles = initialEulerAngles;
            ResetPos = false;
            rb.velocity = Vector3.zero;
            rb.isKinematic = false;
        }
    }
}
