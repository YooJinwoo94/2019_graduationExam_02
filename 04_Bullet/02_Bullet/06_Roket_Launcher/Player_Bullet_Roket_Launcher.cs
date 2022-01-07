using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Roket_Launcher : MonoBehaviour {




    public float Player_Bullet_Speed;
    public BoxCollider2D Player_Bullet_BoxCollider2D;
    public BoxCollider2D Boom_BoxCollider2D;

    public Animator Player_Bullet_Rocket_Launcher_Ani;

    public SpriteRenderer Player_Bullet_Rocket_Launcher_Sprite_Renderer;
    Sprite None_Sprites;
    //======================================
    public GameObject Boom_Effect;

    bool Is_Bullet_On = true;



    private void Start()
    {
        None_Sprites = Resources.Load<Sprite>("None");
        Invoke("Destory_Bullet", 1f);
    }

    private void FixedUpdate()
    {
        if (Is_Bullet_On == true)
        {
            transform.Translate(Vector2.right * Player_Bullet_Speed * Time.deltaTime);
        }
    }


    void Off_Boom_BoxCollider2D()
    {
        Boom_BoxCollider2D.enabled = false;
    }

    void Destory_Bullet()
    {
        Destroy(gameObject);
    }

    void Bullet_Boom()
    {
        Is_Bullet_On = false;

        Player_Bullet_Rocket_Launcher_Ani.enabled = false;
        Player_Bullet_Rocket_Launcher_Sprite_Renderer.sprite = None_Sprites;
        Player_Bullet_BoxCollider2D.enabled = false;

        Boom_Effect.SetActive(true);


        Invoke("Off_Boom_BoxCollider2D", 0.4f);
        Invoke("Destory_Bullet", 1.5f);
    }

    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
        if (Is_Bullet_On == true)
        {
            if (other.tag == "Enemy" )                  //  피격 판정 및 무적여부 확인
            {
                Bullet_Boom();
            }

            else if ( other.tag == "Cross_Hair")
            {
                Invoke("Bullet_Boom", 0.08f); 
            }
        }
    }
}
