using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsControl : MonoBehaviour
{



    private Rigidbody mRigidBody;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "Frozen")
        {
            mRigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
