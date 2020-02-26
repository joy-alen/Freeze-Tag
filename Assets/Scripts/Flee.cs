using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{


    [Tooltip("The target to flee from.")]
    public GameObject target;

    // The speed for fleeing
    public float speed = 1.0f;

    private float fleeDistanceThreshold = 1.0f;

    private float angleThreshold = 1.0f;

    // This unit's rigidbody
    private Rigidbody mRigidBody;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        KinematicFlee();

    }


    private void KinematicFlee()
    {
        Debug.Log("fLEEIN");
        target = GameObject.FindGameObjectWithTag("Tagged Player");
        Vector3 fleeDir = transform.position - target.transform.position;
        if (fleeDir.magnitude < fleeDistanceThreshold)
        {
            // Step away immediately
            transform.Translate(fleeDir.normalized * speed * Time.deltaTime, Space.World);
        }
        else
  
            if (Vector3.Angle(transform.forward, fleeDir) <= angleThreshold)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            }
        

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(fleeDir), 180.0f * Time.deltaTime);
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{


    public GameObject target;

    // The speed for fleeing
    public float speed = 2.0f;

    public float fleeDistanceThreshold = 2.0f;

    public float stepAwayThreshold = 0.2f;

    public float angleThreshold = 0.5f;

    public float safeDistance = 4.0f;

    public float rotationSpeedRads = 5.0f;

    float distanceFromTarget;

    Vector3 faceAway;
    private Quaternion lookWhereYoureGoing;

    // This unit's rigidbody
    private Rigidbody mRigidBody;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        FleeBehavior();

        //FleeingStepAway();


    }

    private void FleeBehavior()
    {

        distanceFromTarget = (target.transform.position - transform.position).magnitude;
        if (distanceFromTarget < fleeDistanceThreshold)
        {
            Debug.Log("Fleeing");
            mRigidBody.velocity = -((target.transform.position - transform.position).normalized * speed);
            faceAway = (target.transform.position - transform.position).normalized;
            lookWhereYoureGoing = Quaternion.LookRotation(faceAway, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookWhereYoureGoing, -rotationSpeedRads);
        }
        else if (distanceFromTarget < stepAwayThreshold)
        {
            Debug.Log("Distance threshold flee");
            transform.Translate((target.transform.position - transform.position).normalized * speed * Time.deltaTime, Space.World);
        }
        else if (distanceFromTarget >= safeDistance)
        {
            Debug.Log("wandering");
            Wander wn = gameObject.GetComponent<Wander>();
            wn.Update();

        }

    }

    private void FleeingStepAway()
    {
        Vector3 fleeDir = transform.position - target.transform.position;
        if (fleeDir.magnitude < fleeDistanceThreshold)
        {
            // Step away immediately
            Debug.Log("Inside Flee Distance threshold");
            transform.Translate(fleeDir.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            if (Vector3.Angle(transform.forward, fleeDir) <= angleThreshold)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            }
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(fleeDir), 180.0f * Time.deltaTime);
    }
}*/
