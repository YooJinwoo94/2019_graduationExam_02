using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Pointer : MonoBehaviour {


    public float movePower = 1f;
    public bool Is_Move_Point_ = false;

    public SpriteRenderer Player_Move_Sprite_Render;
    public SpriteRenderer Player_Gun;

    public Vector2 pan_Limit;
    Vector3 movement;
    Rigidbody2D rigid2D;
    BoxCollider2D box_Collioder_2D;

    // 캐릭터 라인 랜더
    //=====================================================================
    LineRenderer lr;
    public Transform A_Pos, B_Pos;
    //=====================================================================







    private void Awake()
    {
        // 캐릭터 라인 랜더
        //=====================================================================
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.5f;
        lr.endWidth = 0.5f;    
        //=====================================================================

        rigid2D = GetComponent<Rigidbody2D>();
        Player_Move_Sprite_Render = GetComponent<SpriteRenderer>();
        box_Collioder_2D = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    private void FixedUpdate() {

        if (Is_Move_Point_ == true)
        {
            lr.enabled = true;
            lr.SetPosition(0, A_Pos.position);
            lr.SetPosition(1, B_Pos.position);

            float h = (Input.GetAxisRaw("Horizontal"));
            float v = (Input.GetAxisRaw("Vertical"));
            
            Run(h, v);                 
        }
        else if (Is_Move_Point_ == false)
        {
            lr.enabled = false;
        }
    }

    void Run(float h, float v)
    {
            movement.Set(h, v, 0);
            movement = movement.normalized * movePower * Time.deltaTime;
            rigid2D.MovePosition(transform.position + movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player_Cant_Go")
        {
            box_Collioder_2D.isTrigger = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player_Cant_Go")
        {
            box_Collioder_2D.isTrigger = true;
        }
    }
}
