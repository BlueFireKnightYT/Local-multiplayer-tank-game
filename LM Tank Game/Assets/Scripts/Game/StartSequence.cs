using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequence : MonoBehaviour
{
    public List<Transform> spawnPositions = new List<Transform>();
    public GameObject[] allPlayers;
    IEnumerator Start()
    {
        yield return null;
        //Finds all GameObjects with the tag "Player"
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        //Assigns the spawnpoints per player and puts them there
        for (int i = 0; i < allPlayers.Length; i++)
        {
            HPandRespawn hpScript = allPlayers[i].GetComponent<HPandRespawn>();
            hpScript.playerNum = i + 1;
            hpScript.respawnPoint = spawnPositions[i];
            allPlayers[i].transform.position = spawnPositions[i].transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
