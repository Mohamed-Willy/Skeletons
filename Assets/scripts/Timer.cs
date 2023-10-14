using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject panel;
    public Text gold, timer;
    private int g, s, m;
    float c = 0;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        g = 1000;
        s = 0;
        m = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (g <= 0)
        {
            panel.SetActive(true);
        }
        gold.text = "GOLD: " + g.ToString();
        timer.text = "TIMER: " + m.ToString() + ":" + s.ToString();
        if (PhotonNetwork.CurrentRoom.PlayerCount != 2 || g <= 0)
        { return; }
        c += Time.deltaTime;
        if (c >= 1)
        {
            c = 0;
            s++;
        }
        if (s > 60)
        {
            s = 0;
            m++;
        }
    }
    public void steel()
    {
        view.RPC("steelRPC", RpcTarget.All);
    }
    [PunRPC]
    public void steelRPC()
    {
        if(g>0)
            g -= 100;
    }
}
