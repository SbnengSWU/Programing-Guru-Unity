using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    float h;
    float v;

    Rigidbody2D rigid;

    SpriteRenderer spriteRenderer;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //이동
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v) * speed;
        rigid.velocity = dir;

        //애니메이션
        if (v == -1)
        {
            anim.SetBool("WalkFront", true);
        }
        else if (v == 1)
        {
            anim.SetBool("WalkBack", true);
        }
        else
        {
            anim.SetBool("WalkFront", false);
            anim.SetBool("WalkBack", false);
        }
    }
    

}
