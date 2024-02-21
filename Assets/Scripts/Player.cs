using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    new SpriteRenderer renderer;
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    float moveX;//左右移动输入
    bool moveY;//跳跃输入
    bool isOnFloor = true;//判断在空中还是在地上
    KeyCode attackKey;

    void Start()
    {
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        attackKey = KeyCode.J;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetButtonDown("Jump");
        MoveY();
    }

    void FixedUpdate()
    {
        
        MoveX();
        Attack();
    }

    void MoveX()
    {
        
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        if(moveX != 0)
        {
            transform.localScale = new Vector3(moveX * 3, 3, 1);
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
        
    }

    void MoveY()
    {
        if(moveY && isOnFloor)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            isOnFloor = false;
            anim.SetBool("jump", true);
        }
    }

    void Attack()
    {
        if(Input.GetKey(attackKey))
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("other.contacts[0].normal" + other.contacts[0].normal);
        if(other.contacts[0].normal == Vector2.up)
        {
            Debug.Log("OnFloor");
            isOnFloor = true;
            anim.SetBool("jump", false);
        }
    }
}
