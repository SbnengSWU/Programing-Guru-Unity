using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    float h;
    float v;

    bool isHorizonMove;
    bool isVerticalMove;

    Rigidbody2D rigid;

    SpriteRenderer spriteRenderer;
    Animator anim;

    private static PlayerMove instance;

    public string currentMapName;

    GameObject scanObject;

    public GameManager manager;


    Vector3 dirVec;

    // Start is called before the first frame update
    void Awake()
    {
        //if (instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //else
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}

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

        //버튼 이동 방향 체크
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //수평 이동 체크
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //방향
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left ;
        else if (hDown && h == 1)
            dirVec = Vector3.right;



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


        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            Debug.Log(scanObject.name);
            manager.Action(scanObject);
            Debug.Log("print");
        }
    }

    private void FixedUpdate()
    {

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.8f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.8f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }


}
