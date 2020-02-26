using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive2 : MonoBehaviour
{




    [Tooltip("The target to arrive at.")]
    public GameObject target;

    [Tooltip("True if we are aligning to a target.")]
    public bool hasTarget;

    Quaternion lookWhereYoureGoing;
    Vector3 goalFacing;
    float rotationSpeedRads = 3.5f;

    // -- Arrive Variables
    public float speed = 3.0f;
    public float nearSpeed = 2.0f;
   public  float nearRadius = 1.0f;
   public float arrivalRadius = 0.4f;
    float distanceFromTarget;

    private Rigidbody mRigidBody;




    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();

    }

    void Update()
    {

        AlignBehavior();
        ArriveBehavior();

    }

    private void ArriveBehavior()
    {
    
            distanceFromTarget = (target.transform.position - transform.position).magnitude;
            if (distanceFromTarget > nearRadius)
            {
                mRigidBody.velocity = ((target.transform.position - transform.position).normalized * speed);
            }
            else if (distanceFromTarget <= arrivalRadius)
            {

                mRigidBody.velocity = Vector3.zero;
                transform.position = target.transform.position;
            }
            else if (distanceFromTarget > arrivalRadius)
            {
                // If we're still greater than the arrival radius, continue with velocity
                mRigidBody.velocity = ((target.transform.position - transform.position).normalized * nearSpeed);
            }
            else
            {

                mRigidBody.velocity = Vector3.zero;
            }
        }
    

    private void AlignBehavior()
    {

        if (target)
        {
            hasTarget = true;
        }
        else
        {
            hasTarget = false;
        }

        // If there's a target, we use it to set our facing goal
        if (hasTarget)
        {
            goalFacing = (target.transform.position - transform.position).normalized;
            lookWhereYoureGoing = Quaternion.LookRotation(goalFacing, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookWhereYoureGoing, rotationSpeedRads);
        }
        else
        {

            goalFacing = mRigidBody.velocity.normalized;
            lookWhereYoureGoing = Quaternion.LookRotation(goalFacing, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookWhereYoureGoing, rotationSpeedRads);
        }
    }

}
