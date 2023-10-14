using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PhotonView view;
    Timer timer;
    Trasure[] treassures;
    Trasure target;
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        treassures = FindObjectsOfType<Trasure>();
        timer = FindObjectOfType<Timer>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        float d1 = Vector2.Distance(transform.position, treassures[0].transform.position);
        float d2 = Vector2.Distance(transform.position, treassures[1].transform.position);
        float d3 = Vector2.Distance(transform.position, treassures[2].transform.position);
        float d4 = Vector2.Distance(transform.position, treassures[3].transform.position);
        if(d1 <= d2 && d1 <= d3 && d1 <= d4)
        {
            target = treassures[0];
        }
        if(d2 <= d3 &&d2 <= d4 && d2 <= d1)
        {
            target = treassures[1];
        }
        if (d3 <= d4 &&d3 <= d1 && d3 <= d2)
        {
            target = treassures[2];
        }
        if (d4 <= d1 && d4 <= d2 && d4 <= d3)
        {
            target = treassures[3];
        }
        if (target != null)
        {
            Vector3 cur = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if(cur.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (view.IsMine)
        {
            if (collision.gameObject.tag == "treasure")
            {
                timer.steel();
                PhotonNetwork.Destroy(this.gameObject);
            }
            if (collision.gameObject.tag == "player")
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
        }

    }

}
