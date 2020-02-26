using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{


    const float POS_OFFSET = 0.3f;

    void OnTriggerEnter(Collider col)
    {
        if (this.gameObject.tag == "Top Boundary")
        {
            Vector3 oldPosition = col.gameObject.transform.position;
            float newZ = -oldPosition.z;
            col.gameObject.transform.position = new Vector3(oldPosition.x, oldPosition.y, newZ + POS_OFFSET);
        }
        else if (this.gameObject.tag == "Bottom Boundary")
        {
      
            Vector3 oldPosition = col.gameObject.transform.position;
            float newZ = -oldPosition.z;
            col.gameObject.transform.position = new Vector3(oldPosition.x, oldPosition.y, newZ - POS_OFFSET);
        }
        else if (this.gameObject.tag == "Right Boundary")
        {
            
            Vector3 oldPosition = col.gameObject.transform.position;
            float newX = -oldPosition.x;
            col.gameObject.transform.position = new Vector3(newX + POS_OFFSET, oldPosition.y, oldPosition.z);
        }
        else if (this.gameObject.tag =="Left Boundary")
        {

            Vector3 oldPosition = col.gameObject.transform.position;
            float newX = -oldPosition.x;
            col.gameObject.transform.position = new Vector3(newX - POS_OFFSET, oldPosition.y, oldPosition.z);
        }
    }
}
