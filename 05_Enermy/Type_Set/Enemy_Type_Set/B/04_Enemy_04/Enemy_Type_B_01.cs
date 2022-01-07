using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Type_B_01 : MonoBehaviour {

    // ===================================================
    int Enemy_Hp = 18;
    // ===================================================

    private CameraMove shake;
    private Camera_Move_02 shake_02;



    // 쏘는 것 
    public UbhShotCtrl Normal_Shoot_On_Script;
    public UbhShotCtrl Fast_Shoot_On_Script;


    public DOTweenPath Enemy_Path;



    Score_Manager Score_Manager_Script;
    playy Player_Script;



    public SpriteRenderer Enemy_Sprite;
    public GameObject Enemy_Gun_GameObject;
    public Sprite None_Sprites;


    public BoxCollider2D Enemy_BoxCollider2D;
    public BoxCollider2D Enemy_Laser_Hit_BoxCollider2D;

    public Animator Enemy;
    public Animator Enemy_Ani;
    public Animator Enemy_Fiew_Ani;

    public GameObject[] Enemy_Boost_Ani_GameObject;
    public GameObject Normal_Shoot_GameObject;
    public GameObject Fast_Shoot_GameObject;

    //===================================================== 폭발 이팩트  
    public GameObject Enermy_Boom;
    public GameObject if_Rail_Gun_Hit_Boom_Effect;
    public GameObject if_Rocket_Launcher_Hit_Boom_Effect;

    public GameObject[] Fragment_Set;

    public GameObject Enemy_Will_Boom_Game_OBJECT;


     float Enermy_Speed = 7;
    float Enermy_Speed_Ver_02 = 0.2f;













      private void Start()
    {
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        Score_Manager_Script = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        None_Sprites = Resources.Load<Sprite>("None");

        shake = GameObject.Find("CameraShake_Manager").GetComponent<CameraMove>();
        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();

        StartCoroutine(Enemy_Move_B_01());
    }




  


    // 랜덤 생성 함수 
    //=======================================================================================
    // 파편 생성
    int Random_Fragment_Int = 0;
    void Random_Fragment_Out()
    {
        Random_Fragment_Int = Random.Range(0, 1);

        if (Random_Fragment_Int == 0)
        {
            Fragment_01_Made();
         //   Invoke("Fragment_02_Made", 0.1f);
        }
        else if (Random_Fragment_Int == 1)
        {
            Fragment_02_Made();
         //   Invoke("Fragment_03_Made", 0.1f);
        }
    }
    //=======================================================================================
    void Fragment_01_Made()
    {
        Destroy(Instantiate(Fragment_Set[0], transform.position, transform.rotation), 3f);
    }
    void Fragment_02_Made()
    {
        Destroy(Instantiate(Fragment_Set[1], transform.position, transform.rotation), 3f);
    }
    //=======================================================================================






    // 꺼주고 켜주는 함수 
    //=======================================================================================
    void Turn_On_Enemy_Shoot()
    {
        StartCoroutine(Enemy_Shoot_Count());          
    }

    //======================================= 적 개체의 애니메이션 및 슈팅 꺼주기 
    void Turn_Off_Enemy_Shoot()
    {
        Enemy_Dead = true;

        Normal_Shoot_GameObject.SetActive(false);
        Fast_Shoot_GameObject.SetActive(false);
    }

    void Turn_Off_Enemy_Ani()
    {
        Enemy.enabled = false;
        Enemy_Ani.enabled = false;
        Enemy_Fiew_Ani.enabled = false;
    }
    //=======================================================================================









    //충돌시 호출 함수들
    //========================================================================================================================
    // 플레이어 충돌 제외 + ============================================================================= 일반 상황 
    void Normal_Boom_When_Enemy_Boom()
    {
        if (transform.position != Vector3.zero)
        {
            Score_Manager_Script.Score_Up(50);
            //파편
            Random_Fragment_Out();

            Enemy_Sprite.sprite = None_Sprites;
            Enemy_Gun_GameObject.SetActive(false);
            Enemy_Boost_Ani_GameObject[0].SetActive(false);
            Enemy_Boost_Ani_GameObject[1].SetActive(false);

            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);

            Enemy_BoxCollider2D.enabled = false;
            Enemy_Laser_Hit_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;

            Destroy(gameObject, 0f);
        }
    }

    //============================================================================================================================












    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy_Cant_Go")                 
        {
            Turn_Off_Enemy_Ani();
            Turn_Off_Enemy_Shoot();
        }

        else if (other.tag == "Player")
        {
            Player_Script.Player_Hit_Is_Hit_Normal_Enemy();
        }

        else if (other.tag == "Player_Bullet" )                  //  피격 판정 및 무적여부 확인
        {
            Enemy_Hp -= 3;

            if (Enemy_Hp <= 0)
            {
                Turn_Off_Enemy_Ani();
                Turn_Off_Enemy_Shoot();

                Normal_Boom_When_Enemy_Boom();
            }

            else if (Enemy_Hp <= 5)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Boom_Item_Boom")
        {
            Normal_Boom_When_Enemy_Boom();
        }

        else if (other.tag == "Player_Shot_Gun_Bullet")
        {
            Enemy_Hp -= 2;

            if (Enemy_Hp <= 0)
            {
                Turn_Off_Enemy_Ani();
                Turn_Off_Enemy_Shoot();

                Normal_Boom_When_Enemy_Boom();
            }

            else if (Enemy_Hp <= 5)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Bullet_Auto_Gun")                  //  피격 판정 및 무적여부 확인
        {
            Enemy_Hp -= 2;

            if (Enemy_Hp <= 0)
            {
                Turn_Off_Enemy_Ani();
                Turn_Off_Enemy_Shoot();

                Normal_Boom_When_Enemy_Boom();
            }

            else if (Enemy_Hp <= 5)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
            }

            If_Player_Hit_Color_Change();
        }


        else if (other.tag == "Player_Railgun_bullet")
        {
            Enemy_Hp -= 20;

            if (Enemy_Hp <= 0)
            {
                Turn_Off_Enemy_Ani();
                Turn_Off_Enemy_Shoot();

                Normal_Boom_When_Enemy_Boom();
            }

            else if (Enemy_Hp <= 5)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Launcher_bullet")
        {
            Enemy_Hp -= 20;

            if (Enemy_Hp <= 0)
            {
                Turn_Off_Enemy_Ani();
                Turn_Off_Enemy_Shoot();

                Normal_Boom_When_Enemy_Boom();
            }

            else if (Enemy_Hp <= 5)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Boom")
        {
            Enemy_Hp -= 20;

            if (Enemy_Hp <= 0)
            {
                Turn_Off_Enemy_Ani();
                Turn_Off_Enemy_Shoot();

                Normal_Boom_When_Enemy_Boom();
            }

            else if (Enemy_Hp <= 5)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
            }

            If_Player_Hit_Color_Change();
        }

        else if(other.tag == "Player_Laser")
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









    //=======================================레이저 히트 판정
    bool is_Laser_Damage_End = false;
    int Laser_Hit_Count_Int = 0;

    IEnumerator Laser_Hit_Coroutine()
    {
        Laser_Hit_Count_Int += 1;

        Enemy_Hp -= 6;

     //   If_Player_Hit_Color_Change();


        if (Enemy_Hp <= 0)
        {
            Turn_Off_Enemy_Ani();
            Turn_Off_Enemy_Shoot();

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
    //==============================================================================




















    // 적 행동에 대해 

    void Left_Move()
    {
        transform.Translate(Vector2.left * Enermy_Speed * Time.deltaTime);
    }

    //==========================================적 행동 패턴 에 대한 루틴 
    bool Enemy_Dead = false;

    bool Shoot_A = true;
    bool Shoot_B = false;

    int Enemy_Move_Time_Count = 0;
    int Shoot_Count = 0;

    IEnumerator Enemy_Move_B_01()
    {
        //일정 거리까지 오기 
        if(Enemy_Move_Time_Count <= 30)
        {
            Left_Move();
        }

        else if (Enemy_Move_Time_Count >= 31)
        {       
            Turn_On_Enemy_Shoot();
            yield break;
        }

        Enemy_Move_Time_Count += 1;
        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Enemy_Move_B_01());
    }

    bool Enemy_Move_Start = false;
    IEnumerator Enemy_Shoot_Count()
    {
        if (Enemy_Dead == false)
        {
            
            if (Shoot_Count == 1 || Shoot_Count == 5 || Shoot_Count == 9 || Shoot_Count == 13 || Shoot_Count == 17)
            {
                Enemy_Ani.SetTrigger("Enemy_Fire");
                Enemy_Fiew_Ani.SetTrigger("Enemy_Fire");

                Normal_Shoot_On_Script.StartShotRoutine();
            }

            else if (Shoot_Count == 3 || Shoot_Count == 7 || Shoot_Count == 11 || Shoot_Count == 15)
            {
                Enemy_Ani.SetTrigger("Enemy_Fire");
                Enemy_Fiew_Ani.SetTrigger("Enemy_Fire");

                Fast_Shoot_On_Script.StartShotRoutine();
            }

            if (Enemy_Move_Start == false)
            {
                Enemy_Move_Start = true;
                Enemy_Path.DOPlay();
            }
        }
       
        else if ( Enemy_Dead == true)
        {
            Destroy(this.gameObject);
            yield break;
        }

        Shoot_Count += 1;
        yield return new WaitForSeconds(1f);

        StartCoroutine(Enemy_Shoot_Count());
    }
}
