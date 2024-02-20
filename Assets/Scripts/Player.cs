using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    new SpriteRenderer renderer;
    float moveSpeed = 0.05f;
    KeyCode upKey = KeyCode.W;
    KeyCode downKey = KeyCode.S;
    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;
    KeyCode attackKey = KeyCode.J;

    void Start()
    {
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(rightKey))
        {
            transform.Translate(moveSpeed, 0f, 0f);
            renderer.flipX = false;
            anim.SetBool("run", true);
            Attack();
        }
        else if(Input.GetKey(leftKey))
        {
            transform.Translate(-moveSpeed, 0f, 0f);
            renderer.flipX = true;
            anim.SetBool("run", true);
            Attack();
        }
        else if(Input.GetKey(upKey))
        {
            transform.Translate(0f, moveSpeed, 0f);
            anim.SetBool("run", true);
            Attack();
        }
        else if(Input.GetKey(downKey))
        {
            transform.Translate(0f, -moveSpeed, 0f);
            anim.SetBool("run", true);
            Attack();
        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", false);
        }
        Attack();
    }

    void Attack()
    {
        if(Input.GetKey(attackKey))
        {
            anim.SetBool("attack", true);
        }
    }
}
