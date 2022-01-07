using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_01_Heart : MonoBehaviour {

    public int Boss_Hp = 250;
    public int Orginal_Boss_Hp = 250;

    public Boss_01 Boss_01_Script;
    public GameObject Boss_Dead_Effect;
    public GameObject Boss_;
    public Transform Boss_Transform;

    Score_Manager Score_Manager;
    playy Player_Script;
    SpriteRenderer Boss_Heart_Hit;
    Boss_Up_Manager Boss_Up_Manager_Script;
    In_Game_Sound_Manager In_Game_Sound_Manager;
    Boss_Sound_Manager Boss_Sound_Manager;



    private void Start()
    {
        Boss_Sound_Manager = GameObject.Find("Boss_Sound_Manager").GetComponent<Boss_Sound_Manager>();
        Score_Manager = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        In_Game_Sound_Manager = GameObject.Find("Sound_Manager").GetComponent<In_Game_Sound_Manager>();
        Boss_Heart_Hit = GetComponent<SpriteRenderer>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        Boss_Up_Manager_Script = GameObject.Find("Boss_Up_Manager").GetComponent<Boss_Up_Manager>();
    }








    void If_Player_Hit_Color_Change()
    {
        {
            Invoke("Red", 0.01f);
            Invoke("White", 0.2f);
        }

    }
    void White()
    {
        Boss_Heart_Hit.color = new Color(255, 255, 255, 1);
    }
    void Red()
    {
        Boss_Heart_Hit.color = new Color(255, 0, 0, 1);
    }



    void Boss_Dead()
    {
        In_Game_Sound_Manager.Boss_Dead();
        Destroy(Instantiate(Boss_Dead_Effect, Boss_Transform.position, Boss_Transform.rotation),3f);

        Boss_Sound_Manager.Boss_Sound_Off();
        Score_Manager.Score_Fin();

        Boss_Up_Manager_Script.UI_Up();
        Destroy(Boss_);
    }














    // 피격 처리
    //==================================================================================== 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player_Script.Player_Hit_Is_Hit_Normal_Enemy();
        }

        else if (other.tag == "Player_Bullet")                  //  피격 판정 및 무적여부 확인
        {
            Boss_Hp -= 3;
            Debug.Log(Boss_Hp);
            if (Boss_Hp <= 0)
            {
                Debug.Log(Boss_Hp);
                Boss_Dead();
            }
            If_Player_Hit_Color_Change();
            Boss_01_Script.Boss_Hp_Down_Phase_02_Start();
        }

        else if (other.tag == "Player_Shot_Gun_Bullet")
        {
            Boss_Hp -= 2;
            if (Boss_Hp <= 0)
            {
                Boss_Dead();
            }
            If_Player_Hit_Color_Change();
            Boss_01_Script.Boss_Hp_Down_Phase_02_Start();
        }

        else if (other.tag == "Player_Bullet_Auto_Gun")                  //  피격 판정 및 무적여부 확인
        {
            Boss_Hp -= 2;
            if (Boss_Hp <= 0)
            {
                Boss_Dead();
            }
            If_Player_Hit_Color_Change();
            Boss_01_Script.Boss_Hp_Down_Phase_02_Start();
        }

        else if (other.tag == "Player_Railgun_bullet")
        {
            Boss_Hp -= 20;
            if (Boss_Hp <= 0)
            {
                Boss_Dead();
            }
            If_Player_Hit_Color_Change();
            Boss_01_Script.Boss_Hp_Down_Phase_02_Start();
        }

        else if (other.tag == "Player_Rocket_Launcher_bullet")
        {
            Boss_Hp -= 20;
            if (Boss_Hp <= 0)
            {
                Boss_Dead();
            }
            If_Player_Hit_Color_Change();
            Boss_01_Script.Boss_Hp_Down_Phase_02_Start();
        }

        else if (other.tag == "Player_Rocket_Boom")
        {
            Boss_Hp -= 20;
            if (Boss_Hp <= 0)
            {
                Boss_Dead();
            }
            If_Player_Hit_Color_Change();
            Boss_01_Script.Boss_Hp_Down_Phase_02_Start();
        }

        else if (other.tag == "Player_Laser")
        {
            If_Player_Hit_Color_Change();
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


    bool is_Laser_Damage_End = false;
    int Laser_Hit_Count_Int = 0;
    IEnumerator Laser_Hit_Coroutine()
    {
        Laser_Hit_Count_Int += 1;

        Boss_Hp -= 2;

        Boss_01_Script.Boss_Hp_Down_Phase_02_Start();

        if (Boss_Hp <= 0)
        {
            Boss_Dead();
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
}
