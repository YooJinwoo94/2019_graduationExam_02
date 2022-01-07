using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_BG_Bullet_01 : MonoBehaviour {

    Vector3 target;
    private playy Player_Script;
    Transform Player_Pos;
    CameraMove shake;

    SpriteRenderer Bullet_Sprite;
    BoxCollider2D Bullet_BoxCollider2D;
    Animator Bullet_Ani;
    public GameObject Normal_BUllet_Boom;


    public SpriteRenderer None_Sprite;



    public float x = 0;
    public float y = 0;







    private void Start()
    {
        Bullet_Sprite = GetComponent<SpriteRenderer>();
        Bullet_BoxCollider2D = GetComponent<BoxCollider2D>();
        Bullet_Ani = GetComponent<Animator>();

        shake = GameObject.Find("CameraShake_Manager").GetComponent<CameraMove>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        Player_Pos = GameObject.Find("Player").GetComponent<Transform>();

        Box_Collider_Off();
        Invoke("Box_Collider_On", 0.7f);
        Bullet_BG_Start();
    }

    void Bullet_BG_Start()
    {
        target = new Vector3(Player_Pos.position.x + x , Player_Pos.position.y + y , transform.position.z);

        StartCoroutine(Bullet_BG_Count());
        StartCoroutine(Bullet_Move());
    }




    void Box_Collider_Off()
    {
        Bullet_BoxCollider2D.enabled = false;
    }
    void Box_Collider_On()
    {
        Bullet_BoxCollider2D.enabled = true;
    }



    IEnumerator Bullet_Move()
    {
        if (Count > 3)
        {
            yield break;
        }

        transform.position = Vector3.Lerp(transform.position, target, 0.15f);

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Bullet_Move());
    }

    int Count = 0;
    IEnumerator Bullet_BG_Count()
    {
        
        Count++;

        if (Count >4)
        {
            Count = 0;

            Destroy(Instantiate(Normal_BUllet_Boom, transform.position, transform.rotation), 0.6f);

            Bullet_Ani.enabled = false;
            Bullet_BoxCollider2D.enabled = false;
            Bullet_Sprite.sprite = None_Sprite.sprite;

            //Invoke("Bullet_Destory", 0f);
            yield break;
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(Bullet_BG_Count());
    }








    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
       if (other.tag == "Player")
        {
            if (Player_Script.is_Player_Hit == false)
            {
                Player_Script.Player_Hit_Is_Hit_Normal_Enemy_Bullet_Normal();




                Destroy(Instantiate(Normal_BUllet_Boom, transform.position, transform.rotation), 0.6f);

                Bullet_Ani.enabled = false;
                Bullet_BoxCollider2D.enabled = false;
                Bullet_Sprite.sprite = None_Sprite.sprite;

                Destroy(this);

                StopCoroutine(Bullet_BG_Count());
            }
        }
    }
}
