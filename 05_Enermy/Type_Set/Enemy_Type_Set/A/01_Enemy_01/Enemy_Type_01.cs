using    System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type_01 : MonoBehaviour {

    // ===================================================
    int Enemy_Hp = 6;
    // ===================================================


    private Camera_Move_02 shake_02;
    Score_Manager Score_Manager_Script; 
    playy Player_Script;

    public UbhShotCtrl Liner_Lock_On_Script;


    public SpriteRenderer Enemy_Sprite;
    public Sprite None_Sprites;


    public BoxCollider2D Enemy_BoxCollider2D;

    public Animator Enemy_Ani;
    public Animator Enemy_Fire_Ani;

    public float Enermy_Speed;
    public GameObject Enemy_Boost_Ani_GameObject;


    //===================================================== 폭발 이팩트  
    public GameObject Enermy_Boom;
    public GameObject if_Rail_Gun_Hit_Boom_Effect;
    public GameObject if_Rocket_Launcher_Hit_Boom_Effect;
    // 파편 효과 
   // public GameObject Fragment_Set;

    public Boom_Effect_From_N_Enemy Enermy_Boom_Boom_Effect_From_N_Enemy;
    public Boom_Effect_From_N_Enemy Rail_Gun_Boom_Effect_From_N_Enemy;
    public Boom_Effect_From_N_Enemy Rocket_Launcher_Boom_Effect_From_N_Enemy;





    


    private void Start()
    {
        //StartCoroutine(Enemy_Fire_Ani_Coroutine());

        Score_Manager_Script = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        None_Sprites = Resources.Load<Sprite>("None");
        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
    }







  







    void Enemy_Dead_And_Fragment()
    {
        if (transform.position != Vector3.zero)
        {
            //Enemy_Ani.enabled = false;
            //Enemy_Boost_Ani_GameObject.SetActive(false);
            Score_Manager_Script.Score_Up(30);
            Liner_Lock_On_Script.StopShotRoutine();

            //Enemy_Sprite.sprite = None_Sprites;
            Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);

            //Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;              // 화면 흔들게 하기 

            Destroy(gameObject, 0f);
        }
    }









    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
        if (other.tag == "Enemy_Cant_Go")                  //  피격 판정 및 무적여부 확인
            {
            Enemy_Ani.enabled = false;

            Liner_Lock_On_Script.StopShotRoutine();
            }

        else if (other.tag == "Player")
        {
                Player_Script.Player_Hit_Is_Hit_Normal_Enemy();       
        }




        else if (other.tag == "Boom_Item_Boom")
        {
            Enemy_Dead_And_Fragment();

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Bullet")                  //  피격 판정 및 무적여부 확인
            {
               Enemy_Hp-=3;

            if (Enemy_Hp <=0)
               {
                Enemy_Dead_And_Fragment();
                }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Shot_Gun_Bullet")
        {
            Enemy_Hp -= 2;
            if (Enemy_Hp <= 0)
            {
                Enemy_Dead_And_Fragment();
            }
            If_Player_Hit_Color_Change();
        }
    
        else if (other.tag == "Player_Bullet_Auto_Gun")                  //  피격 판정 및 무적여부 확인
        {
            Enemy_Hp -= 2;
            if (Enemy_Hp <= 0)
            {
                Enemy_Dead_And_Fragment();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Railgun_bullet")
            {
            Enemy_Hp -= 20;
            if (Enemy_Hp <= 0)
            {
                Enemy_Dead_And_Fragment();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Launcher_bullet")
            {
            Enemy_Hp -= 20;
            if (Enemy_Hp <= 0)
            {
                Enemy_Dead_And_Fragment();
            }

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Boom")
            {
            Enemy_Hp -= 20;
            if (Enemy_Hp <= 0)
            {
                Enemy_Dead_And_Fragment();
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





    public float Shoot_Delay = 3.3f;
    bool Enemy_Fire = false ;
    IEnumerator Enemy_Fire_Ani_Coroutine()
    {
        if (Enemy_Fire == false)
        {
            yield return new WaitForSeconds(Shoot_Delay);

            Enemy_Fire_Ani.SetTrigger("Enemy_Fire");
            Liner_Lock_On_Script.StartShotRoutine();

            StartCoroutine(Enemy_Fire_Ani_Coroutine());
        }
    }

    public void Fire_Ani_On()
    {
        Enemy_Fire_Ani.SetTrigger("Enemy_Fire");
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


        if (Enemy_Hp <= 0)
        {
            Enemy_Dead_And_Fragment();
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

       // If_Player_Hit_Color_Change();

        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Laser_Hit_Coroutine());
    }

    bool is_Enemy_Laser_Hit = false;
    IEnumerator Laser_Hit()
    {
        Enemy_Hp -= 2;

        if (Enemy_Hp <= 0)
        {
            Enemy_Dead_And_Fragment();
            yield break;
        }
        else if (is_Enemy_Laser_Hit == false)
        {
            yield break;
        }

        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Laser_Hit());
    }
}
