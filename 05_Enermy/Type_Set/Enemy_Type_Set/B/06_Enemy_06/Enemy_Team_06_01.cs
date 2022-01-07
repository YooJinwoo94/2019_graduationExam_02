using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Team_06_01 : MonoBehaviour {
    public bool IS_He_Top_Enemy_ = false;
    Enemy_Laser_Attack_Cam_Shack_Manager_01 Enemy_Laser_Attack_Cam_Shack_Manager_01;
     Enemy_Laser_Attack_Cam_Shack_Manager_02 Enemy_Laser_Attack_Cam_Shack_Manager_02;



    // ===================================================
    int Enemy_Hp = 18;
    // ===================================================




    private Camera_Move_02 shake_02;
    Score_Manager Score_Manager_Script;
    playy Player_Script;

    public SpriteRenderer Enemy_Sprite;
    public Sprite None_Sprites;
    public BoxCollider2D Enemy_BoxCollider2D;

    public Animator Enemy_Ani;
    public GameObject[] Enemy_Boost_Ani_GameObject;
    //===================================================== 폭발 이팩트  
    public GameObject Enermy_Boom;



    // 랜덤 요소
    public GameObject[] Fragment_Set;

    public GameObject Enemy_Will_Boom_Game_OBJECT;

















    // 랜덤 생성 함수 
    //=======================================================================================
    // 파편 생성
    int Random_Fragment_Int = 0;
    void Random_Fragment_Out()
    {
        Random_Fragment_Int = Random.Range(0, 2);

        if (Random_Fragment_Int == 0)
        {
            Fragment_01_Made();
            //   Invoke("Fragment_02_Made", 0.1f);
        }
        else if (Random_Fragment_Int == 1)
        {
            Fragment_02_Made();
            // Invoke("Fragment_03_Made", 0.1f);
        }
        else if (Random_Fragment_Int == 2)
        {
            Fragment_03_Made();
            //  Invoke("Fragment_04_Made", 0.1f);
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
    void Fragment_03_Made()
    {
        Destroy(Instantiate(Fragment_Set[2], transform.position, transform.rotation), 3f);
    }



    


    // 사망 처리 관련 함수 
    void Service_Shot_Auto_Bullet_Hit()
    {
        if (transform.position != Vector3.zero)
        {
            if (IS_He_Top_Enemy_ == false)
            {
                Enemy_Laser_Attack_Cam_Shack_Manager_01.Cam_Move = true;
            }
            else if (IS_He_Top_Enemy_ == true)
            {
                Enemy_Laser_Attack_Cam_Shack_Manager_02.Cam_Move = true;
            }

            Score_Manager_Script.Score_Up(50);
            Random_Fragment_Out();

            Enemy_Ani.enabled = false;
            Enemy_Boost_Ani_GameObject[0].SetActive(false);
            Enemy_Boost_Ani_GameObject[1].SetActive(false);

            Enemy_Sprite.sprite = None_Sprites;
            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;              // 화면 흔들게 하기 

            Enemy_Laser_GameObject.SetActive(false);

            Destroy(gameObject, 0f);
        }  
    }


    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
        if (other.tag == "Enemy_Cant_Go")
        {
            Destroy(gameObject);
        }


        else if (other.tag == "Player")
        {
            Player_Script.Player_Hit_Is_Hit_Normal_Enemy();
        }

        else if (other.tag == "Boom_Item_Boom")
        {
            Service_Shot_Auto_Bullet_Hit();
        }



        else if (other.tag == "Player_Bullet")
        {
            Enemy_Hp -= 3;

            if (Enemy_Hp <= 0)
            {
                Service_Shot_Auto_Bullet_Hit();
            }
            
           else if (Enemy_Hp <= 4)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Shot_Gun_Bullet")
        {
            Enemy_Hp -= 2;

            if (Enemy_Hp <= 0)
            {
                Service_Shot_Auto_Bullet_Hit();
            }

            else if (Enemy_Hp <= 4)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Bullet_Auto_Gun")
        {
            Enemy_Hp -= 2;

            if (Enemy_Hp <= 0)
            {
                Service_Shot_Auto_Bullet_Hit();
            }

            else if (Enemy_Hp <= 4)
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
                Service_Shot_Auto_Bullet_Hit();
            }

            else if (Enemy_Hp <= 4)
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
                Service_Shot_Auto_Bullet_Hit();
            }

            else if (Enemy_Hp <= 4)
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
                Service_Shot_Auto_Bullet_Hit();
            }

            else if (Enemy_Hp <= 4)
            {
                Enemy_Will_Boom_Game_OBJECT.SetActive(true);
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








    //=======================================레이저 히트 판정
    bool is_Laser_Damage_End = false;
    int Laser_Hit_Count_Int = 0;
    IEnumerator Laser_Hit_Coroutine()
    {
        Laser_Hit_Count_Int += 1;
        Enemy_Hp -= 6;

      //  If_Player_Hit_Color_Change();

        if (Enemy_Hp <= 0)
        {
            Service_Shot_Auto_Bullet_Hit();
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



    // 중복 내용들 
    //===========================================================================================================================
   public  float Enermy_Speed = 0.5f;
    public GameObject Enemy_Laser_GameObject;
    private void Start()
    {
        Score_Manager_Script = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        None_Sprites = Resources.Load<Sprite>("None");
        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
        Enemy_Laser_Attack_Cam_Shack_Manager_01 = GameObject.Find("Enemy_Laser_Attack_Cam_Shack_Manager_01").GetComponent<Enemy_Laser_Attack_Cam_Shack_Manager_01>();
        Enemy_Laser_Attack_Cam_Shack_Manager_02 = GameObject.Find("Enemy_Laser_Attack_Cam_Shack_Manager_02").GetComponent<Enemy_Laser_Attack_Cam_Shack_Manager_02>();

        StartCoroutine(Enemy_Manager());
        StartCoroutine(Enemy_Move());
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















    // 00 = charging
    // 01 = Start
    // 02 = End
    public GameObject[] Laser_Charging_Start_End;
    public GameObject Laser_Shoot_GameObject;





    // 전체 이미지 끄고 키는 용도 
    // laser Manager
    void Laser_Shoot_On()
    {
        Laser_Shoot_GameObject.SetActive(true);
    }
    void Laser_Shoot_Off()
    {
        Laser_Shoot_GameObject.SetActive(false);
    }


    // Ani Manager
    //====================================================
    void Laser_Charing_On()
    {
        Enemy_Ani.SetTrigger("Laser_Open");
        Laser_Charging_Start_End[0].SetActive(true);
    }
    void Laser_Charing_Off()
    {
        Laser_Charging_Start_End[0].SetActive(false);
    }

    void Laser_Start_On()
    {
        if (IS_He_Top_Enemy_ == false)
        {
            Enemy_Laser_Attack_Cam_Shack_Manager_01.Cam_Move = false;
            Enemy_Laser_Attack_Cam_Shack_Manager_01.Shack_CAM_A();
        }
        else if (IS_He_Top_Enemy_ == true)
        {
            Enemy_Laser_Attack_Cam_Shack_Manager_02.Cam_Move = false;
            Enemy_Laser_Attack_Cam_Shack_Manager_02.Shack_CAM_A();
        }


        Laser_Charging_Start_End[1].SetActive(true);
    }
    void Laser_Start_Off()
    {
        Laser_Charging_Start_End[1].SetActive(false);
    }

    void Laser_End_On()
    {
        if (IS_He_Top_Enemy_ == false)
        {
            Enemy_Laser_Attack_Cam_Shack_Manager_01.Cam_Move = true;
        }
        else if (IS_He_Top_Enemy_ == true)
        {
            Enemy_Laser_Attack_Cam_Shack_Manager_02.Cam_Move = true;
        }

        Enemy_Ani.SetTrigger("Laser_Close");
        Laser_Charging_Start_End[2].SetActive(true);
    }
    void Laser_End_Off()
    {
        Enemy_Ani.SetTrigger("Laser_Normal");
        Laser_Charging_Start_End[2].SetActive(false);
    }



    void Enemy_Type()
    {
        Laser_Charing_On();
        Invoke("Laser_Charing_Off", 1.2f);

        Invoke("Laser_Start_On", 1.2f);
        Invoke("Laser_Start_Off", 1.4f);

        Invoke("Laser_Shoot_On", 1.4f);
        Invoke("Laser_Shoot_Off", 5f);

        Invoke("Laser_End_On", 5.1f);
        Invoke("Laser_End_Off", 5.5f);
    }


    void Enemy_Move_Left()
    {
        transform.Translate(Vector2.left * Enermy_Speed * Time.deltaTime);
    }





    int Enemy_Manager_Count = 0;
    IEnumerator Enemy_Manager()
    {
        if (Enemy_Manager_Count > 35)
        {
            Enemy_Type();
            yield break;
        }

        else if (Enemy_Manager_Count == 29)
        {
            Enemy_Type();
        }

        else if (Enemy_Manager_Count == 23)
        {
            Enemy_Type();
        }

        else if (Enemy_Manager_Count == 17)
        {
            Enemy_Type();
        }

        else if (Enemy_Manager_Count == 11)
        {
            Enemy_Type();
        }

        else if (Enemy_Manager_Count ==5)
        {         
            Enemy_Type();
        }




        Enemy_Manager_Count += 1;

         yield return new WaitForSeconds(1f);
        StartCoroutine(Enemy_Manager());
    }

    IEnumerator Enemy_Move()
    {
        Enemy_Move_Left();

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Enemy_Move());
    }
}
