using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type_03 : MonoBehaviour {

    // ===================================================
    int Enemy_Hp = 6;
    // ===================================================






    private CameraMove shake;
    private Camera_Move_02 shake_02;
    Score_Manager Score_Manager_Script;
    playy Player_Script;

    public UbhShotCtrl Liner_Lock_On_Script;


    public SpriteRenderer Enemy_Sprite;
    public Sprite None_Sprites;
    public BoxCollider2D Enemy_BoxCollider2D;

    public float Enermy_Speed;

    public GameObject Enemy_Boost_Ani_GameObject;
    public Animator Enemy_Ani;
    public Animator Enemy_Fire_Ani;


    // 채크용 
    bool Enemy_Type_01_Go_Back;
    bool Is_Enemy_Type_01_End;


    //===================================================== 폭발 이팩트  
    public GameObject Enermy_Boom;
    public GameObject if_Rail_Gun_Hit_Boom_Effect;
    public GameObject if_Rocket_Launcher_Hit_Boom_Effect;


    public Boom_Effect_From_N_Enemy Enermy_Boom_Boom_Effect_From_N_Enemy;
    public Boom_Effect_From_N_Enemy Rail_Gun_Boom_Effect_From_N_Enemy;
    public Boom_Effect_From_N_Enemy Rocket_Launcher_Boom_Effect_From_N_Enemy;

    public GameObject[] Warp;
















    private void Start()
    {
        // StartCoroutine(Enemy_Fire_Ani_Coroutine());
        Score_Manager_Script = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        None_Sprites = Resources.Load<Sprite>("None");
        shake = GameObject.Find("CameraShake_Manager").GetComponent<CameraMove>();
        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
    }

    private void FixedUpdate()
    {
        if (Is_Enemy_Type_01_End == false)
        {
            Type_01_Left_Move();
        }
    }







    public void Enemy_Type_01_Move_Back()
    {
        transform.position = new Vector2(11, -4);
    }


    public void Type_01_Left_Move()
    {
        transform.Translate(Vector2.left * Enermy_Speed * Time.deltaTime);
    }



  





    void Enemy_Dead ()
    {
        if (transform.position != Vector3.zero)
        {
            Score_Manager_Script.Score_Up(30);
            Enemy_Ani.enabled = false;
            Enemy_Boost_Ani_GameObject.SetActive(false);

            Liner_Lock_On_Script.StopShotRoutine();
            Is_Enemy_Type_01_End = true;

            Enemy_Sprite.sprite = None_Sprites;
            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;

            Destroy(gameObject, 0f);
        }
    }




    //애니메이션 및 스프라이트 관리 및 전진 금지 관리   
    void Ani_And_Sprite_On()
    {
        Is_Enemy_Type_01_End = false;

        Enemy_Ani.enabled = true;
    }
    void Ani_And_Sprite_Off()
    {
        //움직임 멈추기 
        Is_Enemy_Type_01_End = true;

        Enemy_Ani.enabled = false;
        Enemy_Sprite.sprite = None_Sprites;
    }

    public float x = 5f;
    public float y = 0f;

    //워프 애니메이션 in 틀어주기 
    void Warp_Ani_In()
    {
        Warp[0].SetActive(true);
    }
    //워프 애니메이션 out 틀어주기 
    void Warp_Ani_Out()
    {
        Enemy_Type_01_Go_Back = true;
        transform.position = new Vector2(x, y);

        Warp[1].SetActive(true);
    }



    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
        if (Is_Enemy_Type_01_End == false)
        {
            if (other.tag == "Enemy_Type_01_Go_Back_Point" && Enemy_Type_01_Go_Back == false)                  //  피격 판정 및 무적여부 확인
            {
                Ani_And_Sprite_Off();
                Warp_Ani_In();

                Invoke("Warp_Ani_Out", 0.7f);
                Invoke("Ani_And_Sprite_On", 1f);
            }

            else if (other.tag == "Enemy_Cant_Go")                
            {
                Enemy_Ani.enabled = false;

                Destroy(gameObject);
            }


            else if (other.tag == "Player")
            {
                Player_Script.Player_Hit_Is_Hit_Normal_Enemy();
            }


            else if (other.tag == "Boom_Item_Boom")
            {
                Enemy_Dead();
            }


            else if (other.tag == "Player_Bullet")                  //  피격 판정 및 무적여부 확인
            {
                Enemy_Hp -= 3;
                if (Enemy_Hp <= 0)
                {
                    Enemy_Dead();
                }

                If_Player_Hit_Color_Change();
            }

            else if (other.tag == "Player_Shot_Gun_Bullet")                  //  피격 판정 및 무적여부 확인
            {
                Enemy_Hp -= 2;
                if (Enemy_Hp <= 0)
                {
                    Enemy_Dead();
                }

                If_Player_Hit_Color_Change();
            }


            else if (other.tag == "Player_Bullet_Auto_Gun")                  //  피격 판정 및 무적여부 확인
            {
                Enemy_Hp -= 2;
                if (Enemy_Hp <= 0)
                {
                    Enemy_Dead();
                }

                If_Player_Hit_Color_Change();
            }

            else if (other.tag == "Player_Railgun_bullet")
            {
                Enemy_Hp -= 20;
                if (Enemy_Hp <= 0)
                {
                    Enemy_Dead();
                }

                If_Player_Hit_Color_Change();
            }

            else if (other.tag == "Player_Rocket_Launcher_bullet")
            {
                Enemy_Hp -= 20;
                if (Enemy_Hp <= 0)
                {
                    Enemy_Dead();
                }

                If_Player_Hit_Color_Change();
            }

            else if (other.tag == "Player_Rocket_Boom")
            {
                Enemy_Hp -= 20;
                if (Enemy_Hp <= 0)
                {
                    Enemy_Dead();
                }

                If_Player_Hit_Color_Change();
            }

           else  if (other.tag == "Player_Laser")
            {
                StartCoroutine(Laser_Hit_Coroutine());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player_Laser")
        {
            is_Laser_Damage_End = true;
        }
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








    bool is_Laser_Damage_End = false;
    int Laser_Hit_Count_Int = 0;
    IEnumerator Laser_Hit_Coroutine()
    {
        Laser_Hit_Count_Int += 1;

        Enemy_Hp -= 2;

    //    If_Player_Hit_Color_Change();


        if (Enemy_Hp <= 0)
        {
            Enemy_Dead();
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



    //Enemy_Fire_Ani
    bool Enemy_Fire_Ani_Bool = false;
    IEnumerator Enemy_Fire_Ani_Coroutine()
    {
        if (Enemy_Fire_Ani_Bool ==false)
        {
            yield return new WaitForSeconds(0.5f);
            Enemy_Fire_Ani_Bool = true;
            Enemy_Fire_Ani.SetTrigger("Enemy_Fire");

            StartCoroutine(Enemy_Fire_Ani_Coroutine());
        }
        else if (Enemy_Fire_Ani_Bool == true)
        {
            yield return new WaitForSeconds(2.5f);
            Enemy_Fire_Ani.SetTrigger("Enemy_Fire");

            StartCoroutine(Enemy_Fire_Ani_Coroutine());
        }
    }
    public void Fire_Ani_On()
    {
        Enemy_Fire_Ani.SetTrigger("Enemy_Fire");
    }
}
