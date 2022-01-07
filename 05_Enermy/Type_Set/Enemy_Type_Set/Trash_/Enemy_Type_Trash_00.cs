using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type_Trash_00 : MonoBehaviour {

    // ===================================================
    int Enemy_Hp = 13;
    // ===================================================

    private Camera_Move_02 shake_02;

    playy Player_Script;

    public SpriteRenderer Enemy_Sprite;
    public Sprite None_Sprites;
    public BoxCollider2D Enemy_BoxCollider2D;

    //===================================================== 폭발 이팩트  
    //public GameObject Enermy_Boom;
    //=======================================================================================


       

    private void Start()
    {
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        None_Sprites = Resources.Load<Sprite>("None");
        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();

    //    StartCoroutine(Enemy_Move());
    }





    public GameObject[] Fragment_Boom_GameObject;
    int Random_Boom_Count = 0;
    void Random_Boom()
    {
        Random_Boom_Count= Random.Range(0, 1);

        if (Random_Boom_Count ==0)
        {
            Destroy(Instantiate(Fragment_Boom_GameObject[0], transform.position, transform.rotation),1.5f);
        }
        else if (Random_Boom_Count == 1)
        {
            Destroy(Instantiate(Fragment_Boom_GameObject[1], transform.position, transform.rotation), 1.5f);
        }
    }







    // 사망 처리 관련 함수 
    void Service_Shot_Auto_Bullet_Hit()
    {
        if (transform.position != Vector3.zero)
        {
            Debug.Log("ad");

            Enemy_Sprite.sprite = None_Sprites;
            Random_Boom();

            Enemy_BoxCollider2D.enabled = false;

            shake_02.CameraShaking = true;              // 화면 흔들게 하기 

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

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Shot_Gun_Bullet")
        {
            Enemy_Hp -= 2;
            if (Enemy_Hp <= 0)
            {
                Service_Shot_Auto_Bullet_Hit();
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

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Railgun_bullet")
        {
            Enemy_Hp -= 20;
            if (Enemy_Hp <= 0)
            {
                Service_Shot_Auto_Bullet_Hit();
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

            If_Player_Hit_Color_Change();
        }

        else if (other.tag == "Player_Rocket_Boom")
        {
            Enemy_Hp -= 20;
            if (Enemy_Hp <= 0)
            {
                Service_Shot_Auto_Bullet_Hit();
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
        Enemy_Hp -= 2;

       // If_Player_Hit_Color_Change(); 

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
}
