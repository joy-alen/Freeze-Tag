using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{


    public GameObject target;

    public bool hasTarget;

    Quaternion lookWhereYoureGoing;
    Vector3 goalFacing;
    public float rotationSpeedRads = 4.0f;

    // -- Arrive Variables
    public float speed = 2.0f;
    public float nearSpeed = 1.5f;
    public float nearRadius = 1.0f;
    public float arrivalRadius = 2.0f;
    public float distanceFromTarget;

    private Rigidbody mRigidBody;

    private Seek seekTarget;



    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
        seekTarget = GetComponent<Seek>();
    }

    void Update()
    {

            AlignBehavior();
            ArriveBehavior();
     
    }

    private void ArriveBehavior()
    {
        if (tag == "Tagged Player")
        {
            target = seekTarget.target;
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
    }

    private void AlignBehavior()
    {
        target = seekTarget.target;

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
