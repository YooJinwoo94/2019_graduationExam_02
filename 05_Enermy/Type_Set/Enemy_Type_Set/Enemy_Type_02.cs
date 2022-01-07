using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy_Type_02 : MonoBehaviour {

    // ===================================================
    int Enemy_Hp = 3;
    // ===================================================





    private Camera_Move_02 shake_02;


   // public UbhShotCtrl Liner_Lock_On_Script;
           playy Player_Script;


    public SpriteRenderer Enemy_Sprite;
    public Sprite None_Sprites;


    public BoxCollider2D Enemy_BoxCollider2D;


    public Animator Enemy_Ani;


    // 채크용 
    bool Enemy_Type_02_Boundery_In_Off;

    bool Enemy_Type_02_Flip_01;
    bool Enemy_Type_02_Flip_02;


    //===================================================== 폭발 이팩트  
    public GameObject Enermy_Boom;
    public GameObject if_Rail_Gun_Hit_Boom_Effect;
    public GameObject if_Rocket_Launcher_Hit_Boom_Effect;

    public Boom_Effect_From_N_Enemy Enermy_Boom_Boom_Effect_From_N_Enemy;
    public Boom_Effect_From_N_Enemy Rail_Gun_Boom_Effect_From_N_Enemy;
    public Boom_Effect_From_N_Enemy Rocket_Launcher_Boom_Effect_From_N_Enemy;

    public GameObject[] Item;













    public void Instance_Item()
    {
        int Random_Item = Random.Range(0, 10);

        Debug.Log(Random_Item);


        if (Random_Item < 2)
        {
            Instantiate(Item[3] , transform.position, transform.rotation);
        }

        else
        {

        }

    }

















    private void Start()
    {
        Player_Script = GameObject.Find("Player").GetComponent<playy>();

        None_Sprites = Resources.Load<Sprite>("None");

        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
    }






    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {      
        if (other.tag == "Enemy_Cant_Go")                  //  피격 판정 및 무적여부 확인
        {
            Enemy_Ani.enabled = false;

           // Liner_Lock_On_Script.StopShotRoutine();
        }
      
        else if (other.tag == "Player_Bullet" && Enemy_Type_02_Boundery_In_Off == true)                  //  피격 판정 및 무적여부 확인
        {
            Instance_Item();

            // Liner_Lock_On_Script.StopShotRoutine();
            Enemy_Ani.enabled = false;

            Enemy_Sprite.sprite = None_Sprites;

            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);
            //  Enermy_Boom_Boom_Effect_From_N_Enemy.Destory_Effect();

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;              // 화면 흔들게 하기 

            Destroy(gameObject, 1.5f);
        }

        else if (other.tag == "Player_Bullet_Auto_Gun" && Enemy_Type_02_Boundery_In_Off == true)                  //  피격 판정 및 무적여부 확인
        {
            Instance_Item();

            // Liner_Lock_On_Script.StopShotRoutine();
            Enemy_Ani.enabled = false;

            Enemy_Sprite.sprite = None_Sprites;

            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);
            //  Enermy_Boom_Boom_Effect_From_N_Enemy.Destory_Effect();

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;              // 화면 흔들게 하기 

            Destroy(gameObject, 1.5f);
        }


        //======================================================================================== 플레이어 충돌시 박살 
        else if (other.tag == "Player")                
        {
            if (Player_Script.is_Player_Hit == false)
            {
                Player_Script.Player_Hit_Is_Hit_Normal_Enemy();


                Enemy_Ani.enabled = false;

                Enemy_Sprite.sprite = None_Sprites;
                Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);
                // Enermy_Boom_Boom_Effect_From_N_Enemy.Destory_Effect();

                Enemy_BoxCollider2D.enabled = false;

                Destroy(gameObject, 1.5f);
            }

        }

        else if (other.tag == "Player_Laser")
        {
            Instance_Item();

            Enemy_Ani.enabled = false;

           // Liner_Lock_On_Script.StopShotRoutine();

            Enemy_Sprite.sprite = None_Sprites;
            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);
            //Enermy_Boom_Boom_Effect_From_N_Enemy.Destory_Effect();

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;              // 화면 흔들게 하기 

            Destroy(gameObject, 1.5f);
        }

        else if (other.tag == "Player_Railgun_bullet")
        {
            Instance_Item();

            // Liner_Lock_On_Script.StopShotRoutine();
            Enemy_Ani.enabled = false;

            shake_02.CameraShaking = true;    // 화면 흔들게 하기 

            Enemy_Sprite.sprite = None_Sprites;
            Destroy(Instantiate(if_Rail_Gun_Hit_Boom_Effect, transform.position, transform.rotation), 2f);
            // Rail_Gun_Boom_Effect_From_N_Enemy.Destory_Effect();

            Enemy_BoxCollider2D.enabled = false;

            Destroy(gameObject, 1.5f);
        }

        else if (other.tag == "Player_Rocket_Launcher_bullet")
        {
            Instance_Item();

            //  Liner_Lock_On_Script.StopShotRoutine();
            Enemy_Ani.enabled = false;

            shake_02.CameraShaking = true;    // 화면 흔들게 하기 

            Enemy_Sprite.sprite = None_Sprites;
            Destroy(Instantiate(if_Rocket_Launcher_Hit_Boom_Effect, transform.position, transform.rotation), 2f);
            // Rocket_Launcher_Boom_Effect_From_N_Enemy.Destory_Effect();

            Enemy_BoxCollider2D.enabled = false;

            Destroy(gameObject, 1.5f);
        }

        else if (other.tag == "Player_Rocket_Boom")
        {
            //  Liner_Lock_On_Script.StopShotRoutine();
            Enemy_Ani.enabled = false;

            shake_02.CameraShaking = true;    // 화면 흔들게 하기 

            Enemy_Sprite.sprite = None_Sprites;
            Destroy(Instantiate(if_Rocket_Launcher_Hit_Boom_Effect, transform.position, transform.rotation), 2f);
            // Rocket_Launcher_Boom_Effect_From_N_Enemy.Destory_Effect();

            Enemy_BoxCollider2D.enabled = false;

            Destroy(gameObject, 1.5f);
        }










        // 1
        else if (other.tag == "Enemy_Type_02_Boundary" && Enemy_Type_02_Boundery_In_Off == false)
        {
            Enemy_Type_02_Boundery_In_Off = true;
        }

        // 2
        else if (other.tag == "Enemy_Type_02_Boundary" && Enemy_Type_02_Boundery_In_Off == true)
        {
            Enemy_Type_02_Boundery_In_Off = false;
        }

        // 턴해야 함 
        else if (other.tag == "Enemy_Type_02_Go_Back_Point_01" && Enemy_Type_02_Flip_01 == false)
        {
            Enemy_Type_02_Flip_01 = true;
            Enemy_Sprite.flipX = true;
        }

        // 턴해야 함 
        else if (other.tag == "Enemy_Type_02_Go_Back_Point_02" && Enemy_Type_02_Flip_01 == true && Enemy_Type_02_Flip_02 == false)
        {
            Enemy_Type_02_Flip_02 = true;
            Enemy_Sprite.flipX = false;
        }
    }



}
