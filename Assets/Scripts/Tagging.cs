using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Tagging : MonoBehaviour
{


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Tagged Player")
        {

            if (tag != "Frozen" && tag != "Tagged Player")
            {
                // Set its tag to be frozen and freeze it.
                tag = "Frozen";

                col.GetComponent<Seek>().target = null;
                

                GameController.numNotFrozenExceptTagged--;
                GameController.lastFrozenCharacter = this.gameObject;
                GameController.lastTaggedCharacter = col.gameObject;
            }
        }

        else if (col.gameObject.tag == "Not Frozen" && this.tag == "Frozen")
        {

            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            this.tag = "Not Frozen";

            col.GetComponent<Seek>().target = null;

            GameController.numNotFrozenExceptTagged++;
            if (GameController.lastFrozenCharacter == this.gameObject)
            {
                GameController.lastFrozenCharacter = null;
            }
        }
    }
}
