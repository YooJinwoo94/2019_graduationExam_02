using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Team_05_01 : MonoBehaviour {

    //====================================================  사망시 확신 이팩트 탄환 생성 
    public GameObject Enemy_Bullet_Spread;

    //===================================================== 폭발 이팩트  
    public GameObject Enermy_Boom;



    public bool TtBb = false ;

    Camera_Move_02 shake_02;
    playy Player_Script;
    Enemy_Attack_To_Player_CAM_Shack_Manager_01 Enemy_Attack_To_Player_CAM_Shack_Manager_01;
    Enemy_Attack_To_Player_CAM_Shack_Manager_02 Enemy_Attack_To_Player_CAM_Shack_Manager_02;


    public UbhShotCtrl Enmey_Bullet_Shoot_Script;
    public Animator Enemy_Ani;
    public SpriteRenderer Enemy_SpriteRenderer;



    float Enermy_Speed = 5f;




    private void Start()
    {
        StartCoroutine(Enemy_Move_To_Point());

        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        Enemy_Attack_To_Player_CAM_Shack_Manager_01 = GameObject.Find("Enemy_Attack_To_Player_CAM_Shack_Manager_01").GetComponent<Enemy_Attack_To_Player_CAM_Shack_Manager_01>();
        Enemy_Attack_To_Player_CAM_Shack_Manager_02 = GameObject.Find("Enemy_Attack_To_Player_CAM_Shack_Manager_02").GetComponent<Enemy_Attack_To_Player_CAM_Shack_Manager_02>();
    }






    void Enemy_Move()
    {
        transform.Translate(Vector2.up * Enermy_Speed * Time.deltaTime);
    }

    void Enemy_Ready()
    {

    }

    void Enemy_Start()
    {
        Enemy_Ani.enabled = false;
        Enemy_SpriteRenderer.enabled = false;
        Enmey_Bullet_Shoot_Script.StartShotRoutine();

        if(TtBb == true)
        {
            Enemy_Attack_To_Player_CAM_Shack_Manager_01.Shack_CAM_A();
        }
        else if ( TtBb == false)
        {
            Enemy_Attack_To_Player_CAM_Shack_Manager_02.Shack_CAM_A();
        }
    }



    public float Enemy_Attack_Time_01 = 2.6f;
    public float Enemy_Attack_Time_02 = 2.7f;

    int Enemy_Move_Int = 0;

    IEnumerator Enemy_Move_To_Point()
    {
        if (Enemy_Move_Int >38)
        {
            Enemy_Move_Int = 0;
            Invoke("Enemy_Start", Enemy_Attack_Time_01);
          
            Destroy(gameObject, Enemy_Attack_Time_02);
            yield break;
        }
        Enemy_Move();

        Enemy_Move_Int += 1;

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Enemy_Move_To_Point());
    }











    void If_Player_Hit_Color_Change()
    {
            Invoke("Red", 0.01f);
            Invoke("White", 0.1f);
            Invoke("Red", 0.2f);
            Invoke("White", 0.3f);
    }

    void White()
    {
        Enemy_SpriteRenderer.color = new Color(255, 255, 255, 1);
    }
    void Red()
    {
        Enemy_SpriteRenderer.color = new Color(255, 0, 0, 1);
    }





    void Dead()
    {
        Instantiate(Enemy_Bullet_Spread, transform.position, transform.rotation);
        Destroy(Instantiate(Enermy_Boom, transform.position, transform.rotation), 2f);

        shake_02.CameraShaking = true;              // 화면 흔들게 하기 

        Destroy(gameObject, 0f);
    }







    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {    
       if (other.tag == "Player")
        {
            Player_Script.Player_Hit_Is_Hit_Normal_Enemy();
        }

        else if (other.tag == "Boom_Item_Boom")
        {
            Dead();
        }






        else if (other.tag == "Player_Bullet")
        {
            If_Player_Hit_Color_Change();
        }


        else if (other.tag == "Player_Shot_Gun_Bullet")
        {
            If_Player_Hit_Color_Change();
        }


        else if (other.tag == "Player_Bullet_Auto_Gun")
        {
            If_Player_Hit_Color_Change();
        }



        else if (other.tag == "Player_Railgun_bullet")
        {
            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Launcher_bullet")
        {
            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Boom")
        {
            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Laser")
        {

        }
    }
}
