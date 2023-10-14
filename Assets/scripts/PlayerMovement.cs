using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool lor, top = true, buttom = true;
    PhotonView view;
    public int speed;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            
            Vector2 move_input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 move_amount = move_input.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)move_amount;


            animator.SetBool("run", false);
            lor = false;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetBool("run", true);
                if (!top)
                {
                    animator.SetBool("top", false);
                }
                if (!buttom)
                {
                    animator.SetBool("bottum", false);
                }
                lor = true;
                animator.SetBool("left", true);
                animator.SetBool("right", false);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetBool("run", true);
                if (!top)
                {
                    animator.SetBool("top", false);
                }
                if (!buttom)
                {
                    animator.SetBool("bottum", false);
                }
                lor = true;
                animator.SetBool("right", true);
                animator.SetBool("left", false);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetBool("run", true);
                top = true;
                if (!lor)
                {
                    animator.SetBool("right", false);
                    animator.SetBool("left", false);
                }
                animator.SetBool("top", true);
                animator.SetBool("bottum", false);
            }
            else
            {
                top = false;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("run", true);
                buttom = true;
                if (!lor)
                {
                    animator.SetBool("right", false);
                    animator.SetBool("left", false);
                }
                animator.SetBool("bottum", true);
                animator.SetBool("top", false);
            }
            else
            {
                buttom = false;
            }
        }
    }
}
