using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject enemy;
    private float time_btween_spawn;
    // Update is called once per frame
    void Update()
    {
        if(!PhotonNetwork.IsMasterClient || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        { return; }
        if(time_btween_spawn <= 0)
        {
            time_btween_spawn = 1;
            Vector3 spawn_pos = spawnpoints[Random.Range(0, spawnpoints.Length)].position;
            PhotonNetwork.Instantiate(enemy.name, spawn_pos, Quaternion.identity);
        }
        else
        {
            time_btween_spawn -= Time.deltaTime;
        }
    }
}
