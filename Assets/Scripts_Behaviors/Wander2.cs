using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander2 : MonoBehaviour
{



    float wanderCircleCenterOffset = 50.0f;
    float wanderCircleRadius = 5.0f;
    float maxWanderVariance = 10.0f;
    float speed = 1.0f;
    private Rigidbody mRigidBody;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {

            Vector3 currRandPt = WanderCirclePoint();
            Vector3 moveDir = (currRandPt - transform.position).normalized;
            mRigidBody.velocity = (moveDir * speed);
        
    }

    // Acquires a random wander circle point
    Vector3 WanderCirclePoint()
    {
        Vector3 wanderCircleCenter = transform.position + (Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * wanderCircleCenterOffset);
        Vector3 wanderCirclePoint = wanderCircleRadius * (new Vector3(Mathf.Cos(Random.Range(maxWanderVariance, Mathf.PI - maxWanderVariance)),
                                                            0.0f,
                                                            Mathf.Sin(Random.Range(maxWanderVariance, Mathf.PI - maxWanderVariance))));

        return (wanderCirclePoint + wanderCircleCenter);
    }
}
