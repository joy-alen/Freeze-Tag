using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{


    [Tooltip("All possible players (units) in the game.")]
    public GameObject[] players;

    // The number of non-frozen characters, to unfreeze if all got frozen/only tagged player
    public static int numNotFrozenExceptTagged = 4;
    public static int MAX_NUM_PLAYERS_EXCEPT_TAGGED = 4;

    // The last frozen character
    public static GameObject lastFrozenCharacter = null;
    public static GameObject lastTaggedCharacter = null;



    // Initialize possible players
    void Awake()
    {
        int TaggedPlayer = Random.Range(1, players.Length);
        players[TaggedPlayer - 1].tag = "Tagged Player";

    }

    void Update()
    {


        if (numNotFrozenExceptTagged == 0 && lastFrozenCharacter)
        {
            lastFrozenCharacter.tag = "Tagged Player";
            lastFrozenCharacter.transform.position = new Vector3(0.0f, lastFrozenCharacter.transform.position.y, 5.0f);
            lastTaggedCharacter.transform.position = new Vector3(0.0f, lastTaggedCharacter.transform.position.y, -5.0f);
            lastFrozenCharacter.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            lastTaggedCharacter.tag = "Not Frozen";
            lastTaggedCharacter.GetComponent<Seek>().target = null;
            numNotFrozenExceptTagged = 1;
            lastFrozenCharacter = null;
            lastTaggedCharacter = null;
        }
    }

    // Returns the possible players array for finding targets
    public GameObject[] GetPlayers()
    {
        return players;
    }
}
