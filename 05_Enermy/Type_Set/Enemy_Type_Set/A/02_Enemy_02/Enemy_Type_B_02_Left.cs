using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type_B_02_Left : MonoBehaviour {

    // ===================================================
    int Enemy_Hp = 6;
    // ===================================================



    int Enemy_Delay = 0;
    int Enemy_Move_Time_Count = 0;

    float Enermy_Speed = 8f;
    float Enemy_Attack_Speed = 7f;

    Rigidbody2D Enemy_Rigidbody2D;





    private Camera_Move_02 shake_02;
    public SpriteRenderer Enemy_Sprite;
    public Sprite None_Sprites;
    public GameObject Enemy_Boost_Ani_GameObject;
    public BoxCollider2D Enemy_BoxCollider2D;
    //===================================================== 폭발 이팩트  
    public GameObject Enermy_Boom;

    public GameObject if_Rail_Gun_Hit_Boom_Effect;
    public GameObject if_Rocket_Launcher_Hit_Boom_Effect;

    public Transform Boost_Transform_Pos;
    public SpriteRenderer Boost_SpriteRenderer;

    SpriteRenderer _Sprite_Renederer;
    Transform Player_Pos;
    playy Player_Script;
    Score_Manager Score_Manager_Script;




    // Use this for initialization
    void Start()
    {
        Score_Manager_Script = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        _Sprite_Renederer = GetComponent<SpriteRenderer>();
        Enemy_Rigidbody2D = GetComponent<Rigidbody2D>();
        None_Sprites = Resources.Load<Sprite>("None");
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
        Player_Pos = GameObject.Find("Player").GetComponent<Transform>();

        StartCoroutine(Move_Point());
    }






    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy_Cant_Go")
        {
            Destroy(this.gameObject);
        }

        else if (other.tag == "Player")
        {
            Player_Script.Player_Hit_Is_Hit_Normal_Enemy();
          //  Normal_Boom_When_Enemy_Boom();
        }

        else if (other.tag == "Boom_Item_Boom")
        {
            Normal_Boom_When_Enemy_Boom();
        }

        else if (other.tag == "Player_Bullet")                  //  피격 판정 및 무적여부 확인
        {
            Enemy_Hp -= 3;
            if (Enemy_Hp <= 0)
            {
                Normal_Boom_When_Enemy_Boom();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Shot_Gun_Bullet")
        {
            Enemy_Hp -= 2;
            if (Enemy_Hp <= 0)
            {
                Normal_Boom_When_Enemy_Boom();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Bullet_Auto_Gun")                  //  피격 판정 및 무적여부 확인
        {
            Enemy_Hp -= 2;
            if (Enemy_Hp <= 0)
            {
                Normal_Boom_When_Enemy_Boom();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Railgun_bullet")
        {
            Enemy_Hp -= 20;
            if (Enemy_Hp <= 0)
            {
                Rail_Gun_Boom_When_Enemy_Boom();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Launcher_bullet")
        {
            Enemy_Hp -= 20;
            if (Enemy_Hp <= 0)
            {
                Rocket_Launcher_Boom_When_Enemy_Boom();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Boom")
        {
            Enemy_Hp -= 20;
            if (Enemy_Hp <= 0)
            {
                Rocket_Launcher_Boom_Effect_Boom_When_Enemty_Boom();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Laser")
        {
            StartCoroutine(Laser_Hit_Coroutine());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player_Laser")
        {
            is_Laser_Damage_End = true;
        }
    }








    public float Move_Speed = 0.05f;
    float Move_Time_Count = 0;
    int Enemy_Go = 1;
    IEnumerator Move_Point()
    {
        if (Move_Time_Count >= Enemy_Go)
        {
            StartCoroutine(Attack_Time());
            yield break;
        }
        Move_Time_Count += 0.01f;
        transform.position += new Vector3(1f * Time.deltaTime, 0, 0);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Move_Point());
    }

    int Enemy_Attack_Time_Count = 0;
    int Enemy_Attack_Go = 0;
    IEnumerator Attack_Time()
    {
        if (Enemy_Attack_Time_Count >= Enemy_Attack_Go)
        {
            StartCoroutine(Move_Type_Enemy());
            yield break;
        }
        Enemy_Attack_Time_Count += 1;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Attack_Time());
    }

    IEnumerator Move_Type_Enemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player_Pos.position, Move_Speed);
        // transform.position = Vector3.Lerp(transform.position, Player_Pos.transform.position, 0.05f);

        //회전 
        if (Player_Pos.transform.position.x > transform.position.x)
        {
            Boost_Transform_Pos.transform.localPosition = new Vector2(-4.03f, -0.63f);
            Boost_SpriteRenderer.flipX = true;

            _Sprite_Renederer.flipX = true;
        }
        else if (Player_Pos.transform.position.x < transform.position.x)
        {
            Boost_Transform_Pos.transform.localPosition = new Vector2(4.03f, -0.63f);
            Boost_SpriteRenderer.flipX = false;

            _Sprite_Renederer.flipX = false;
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Move_Type_Enemy());
    }















    void If_Player_Hit_Color_Change()
    {
        if (Enemy_Hp <= 0)
        {

        }

        else
        {
            Invoke("Red", 0.01f);
            Invoke("White", 0.1f);
            Invoke("Red", 0.2f);
            Invoke("White", 0.3f);
        }
    }

    void White()
    {
        Enemy_Sprite.color = new Color(255, 255, 255, 1);
    }
    void Red()
    {
        Enemy_Sprite.color = new Color(255, 0, 0, 1);
    }










    // ===================================================  레이저 히트 
    bool is_Laser_Damage_End = false;
    int Laser_Hit_Count_Int = 0;
    IEnumerator Laser_Hit_Coroutine()
    {
        Laser_Hit_Count_Int += 1;
        Enemy_Hp -= 2;

       // If_Player_Hit_Color_Change();


        if (Enemy_Hp <= 0)
        {
            Normal_Boom_When_Enemy_Boom();
            yield break;
        }

        else if (is_Laser_Damage_End == true)
        {
            is_Laser_Damage_End = false;
            yield break;
        }

        else if (Input.GetMouseButton(0))
        {

        }

        else if (Laser_Hit_Count_Int > 1)
        {
            yield break;
        }



        yield return new WaitForSeconds(0.3f);

        StartCoroutine(Laser_Hit_Coroutine());
    }

    bool is_Enemy_Laser_Hit = false;
    IEnumerator Laser_Hit()
    {
        Enemy_Hp -= 2;

        if (Enemy_Hp <= 0)
        {
            Normal_Boom_When_Enemy_Boom();
            yield break;
        }

        else if (is_Enemy_Laser_Hit == false)
        {
            yield break;
        }

        yield return new WaitForSeconds(0.3f);

        StartCoroutine(Laser_Hit());
    }



    //충돌시 호출 함수들
    //========================================================================================================================

    // 플레이어 충돌 제외 + ============================================================================= 일반 상황 
    void Normal_Boom_When_Enemy_Boom()
    {
        if (transform.position != Vector3.zero)
        {
            Score_Manager_Script.Score_Up(30);
            Enemy_Sprite.sprite = None_Sprites;

            Enemy_Boost_Ani_GameObject.SetActive(false);

            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;

            Destroy(gameObject, 0f);
        }
    }


    //=================================================================================================== 중화기 
    //=================================================================================================== 레일건 
    void Rail_Gun_Boom_When_Enemy_Boom()
    {
        if (transform.position != Vector3.zero)
        {
            Score_Manager_Script.Score_Up(30);
            Enemy_Sprite.sprite = None_Sprites;

            Destroy(Instantiate(if_Rail_Gun_Hit_Boom_Effect, transform.position, transform.rotation), 2f);

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;

            Destroy(gameObject, 0f);
        }
    }

    void Rocket_Launcher_Boom_When_Enemy_Boom()
    {
        if (transform.position != Vector3.zero)
        {
            Score_Manager_Script.Score_Up(30);
            Enemy_Sprite.sprite = None_Sprites;

            Destroy(Instantiate(if_Rocket_Launcher_Hit_Boom_Effect, transform.position, transform.rotation), 2f);

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;

            Destroy(gameObject, 0);
        }
    }

    void Rocket_Launcher_Boom_Effect_Boom_When_Enemty_Boom()
    {
        if (transform.position != Vector3.zero)
        {
            Score_Manager_Script.Score_Up(30);
            shake_02.CameraShaking = true;

            Enemy_Sprite.sprite = None_Sprites;

            Destroy(Instantiate(if_Rocket_Launcher_Hit_Boom_Effect, transform.position, transform.rotation), 2f);

            Enemy_BoxCollider2D.enabled = false;

            Destroy(gameObject, 0f);
        }
    }


    //======================================================================================================
    // 플레이어 충돌 포함 
    void Normal_Boom_When_Enemy_Boom__And_Player_Hit()
    {
        if (transform.position != Vector3.zero)
        {
            Enemy_Sprite.sprite = None_Sprites;

            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);

            Enemy_BoxCollider2D.enabled = false;

            Destroy(gameObject, 0f);
        }
    }
    //============================================================================================================================  
}
