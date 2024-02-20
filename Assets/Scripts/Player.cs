using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    new SpriteRenderer renderer;
    float moveSpeed = 0.05f;
    void Start()
    {
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed, 0f, 0f);
            renderer.flipX = false;
            anim.SetBool("run", true);
            Attack();
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed, 0f, 0f);
            renderer.flipX = true;
            anim.SetBool("run", true);
            Attack();
        }
        else if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, moveSpeed, 0f);
            anim.SetBool("run", true);
            Attack();
        }
        else if(Input.GetKey(KeyCode.S))
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
        if(Input.GetKey(KeyCode.J))
        {
            anim.SetBool("attack", true);
        }
    }
}
