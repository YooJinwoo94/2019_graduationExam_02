using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type_05 : MonoBehaviour {

    public bool IS_He_Top_Enemy_ = false;
    // ===================================================
    int Enemy_Hp = 10;
    // ===================================================


    private Camera_Move_02 shake_02;

    Score_Manager Score_Manager_Script;
    playy Player_Script;

    public SpriteRenderer Enemy_Sprite;
    public Sprite None_Sprites;
    public BoxCollider2D Enemy_BoxCollider2D;

    public float Enermy_Speed;


    public Animator Enemy_Ani;
    public GameObject Enemy_Boost_Ani_GameObject;

    //====================================================  사망시 확신 이팩트 탄환 생성 
    public GameObject Enemy_Bullet_Spread;

    //===================================================== 폭발 이팩트  
    public GameObject Enermy_Boom;



    // 랜덤 요소
    public GameObject[] Fragment_Set;

    public GameObject Enemy_Will_Boom_Game_OBJECT;








    private void Start()
    {
        Score_Manager_Script = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        None_Sprites = Resources.Load<Sprite>("None");
        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
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
           // Invoke("Fragment_03_Made", 0.1f);
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










    // 사망 처리 관련 함수 
    void Service_Shot_Auto_Bullet_Hit ()
    {     
        if (transform.position != Vector3.zero)
        {
            Score_Manager_Script.Score_Up(50);
            Random_Fragment_Out();
            Instantiate(Enemy_Bullet_Spread, transform.position, transform.rotation);
            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);


            Enemy_Ani.enabled = false;
            Enemy_Boost_Ani_GameObject.SetActive(false);

            Enemy_Sprite.sprite = None_Sprites;


            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;              // 화면 흔들게 하기 

            Destroy(gameObject, 0f);
        }

    }
    //==================================================





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

            else if (Enemy_Hp <= 5)
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
              //  other.gameObject.layer = 27;
                     
                Service_Shot_Auto_Bullet_Hit();
            }
            else if (Enemy_Hp <= 5)
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
                Service_Shot_Auto_Bullet_Hit();
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
                Service_Shot_Auto_Bullet_Hit();
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
                Service_Shot_Auto_Bullet_Hit();
            }
            else if (Enemy_Hp <= 5)
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
         if ( other.tag == "Player_Laser")
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
        Enemy_Hp -= 2;

     //   If_Player_Hit_Color_Change();

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







    /*
    public void Shack_CAM_A()
    {
        if (IS_He_Top_Enemy_ == false)
        {
            StartCoroutine(Shack_Cam());
        }
        else
        {
            StartCoroutine(Shack_Cam_B());
        }
    }
    public bool Cam_Move = false;
    public GameObject MainCamera;
    public float shake = 0.08f;
    public float shakeAmount = 0.08f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;


    IEnumerator Shack_Cam()
    {
        if (Cam_Move == true)
        {
            shake = 1f;
            MainCamera.transform.position = originalPos;
            yield break;
        }

        else if (shake > 0)
        {
            MainCamera.transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;

        }


        else if (shake < 0)
        {
            shake = 1f;
            MainCamera.transform.position = originalPos;
            yield break;
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Shack_Cam());
    }
    IEnumerator Shack_Cam_B()
    {
        if (Cam_Move == true)
        {
            shake = 1f;
            MainCamera.transform.position = originalPos;
            yield break;
        }

        else if (shake > 0)
        {
            MainCamera.transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;

        }


        else if (shake < 0)
        {
            shake = 1f;
            MainCamera.transform.position = originalPos;
            yield break;
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Shack_Cam_B());
    }

    */
}
