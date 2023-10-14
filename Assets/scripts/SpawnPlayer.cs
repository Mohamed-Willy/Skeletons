using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject Player;
    private const float min_x = -7.8f, max_x = 8.2f, min_y = 4.5f, max_y = -3.27f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 random_position = new Vector2(Random.Range(min_x, max_x), Random.Range(min_y, max_y));
        PhotonNetwork.Instantiate(Player.name, random_position, Quaternion.identity);
    }
}
