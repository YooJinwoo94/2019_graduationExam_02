using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playy : SingletonMonoBehaviour<playy>
{
    public Animator[] Hp_Animator;


    public SpriteRenderer[] Player_Hp_Change_Sprite_Renderer;
    public SpriteRenderer Player_SpriteRenderer;
    public SpriteRenderer[] Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set;
    public SpriteRenderer Player_Rail_Gun_SpriteRenderer;
    public SpriteRenderer Player_Rocket_Launcher_SpriteRenderer;

    //================================================== 플레이어 UI
    public UISprite Player_Barrier_Sprite;
    public Image Player_Hp_Sprite;


    //=============================================== 스크립트 
    public In_Game_UI_Manager In_Game_UI_Manager_Script;
    public Player_Manager Player_Manager_Script;
    public ParticleSystem Player_Move_Praticle;
    private CameraMove shake;
    //=============================================== 스크립트 


    public float offset;
    float Shoot_Speed = 0.3f;
    public float movePower = 1f;
    public float Fast_movePower = 10f;

    public bool Is_Player_Laser_Shoot = false;
    public bool Player_IS_UnStop = false;
    public bool Is_Player_Move = true;
    bool is_Player_Warp_Cool_Time = false;
    public bool is_Player_Hit = false;


    // 무슨 무기를 먹고 있니? 
    //==================================================
    public bool Player_Weapon_Shot_Gun = true;
    public bool Player_Weapon_Auto_Gun = true;
    public bool Player_Weapon_Service_Gun = false;
    public bool Player_Weapon_Laser_Shoot = false;

    public bool Player_Weapon_Rocket_Launcher_Shoot = false;
    public bool Player_Weapon_Rail_Gun_Shoot = false;
    //==================================================


    // 현재 들고 있는 무기는? 
    // 일반샷 
    //==================================================
    public bool IS_Player_Shot_Gun_Shoot = true;
    public bool IS_Player_Auto_Gun_Shoot = true;
    public bool IS_Player_Service_Gun_Shoot = false;
    public bool IS_Player_Laser_Shoot = false;
    // 중화기 
    // 로켓 샷 + 레일건 샷 
    //==================================================
    public bool IS_Player_Rocket_Launcher_Shoot = false;
    public bool IS_Player_Rail_Gun_Shoot = false;

    // 특별샷 
    //==================================================
    public bool Player_Special_Shoot = true;

    // 플레이어 애니메이션 
    //==================================================
    public Animator Player_Warp;
    //  public Animator Player_Move_Point_Warp;

    public GameObject Player_Skill_Use_Smoke_Game_Object;
    public GameObject Player_Spark;
    public GameObject Player_Smoke;

    public BoxCollider2D Player_Box_Collider;


    BoxCollider2D Player_Collider2D;
    Rigidbody2D rigid2D;

    Vector3 movement;
    Vector3 Fast_movement;
    Player_Sound_Manager Player_Sound_Manager;
    Score_Manager Score_Manager;

    Boss_Up_Manager Boss_Up_Manager_Script;
    Enemy_Laser_Attack_Cam_Shack_Manager_01 Enemy_Laser_Attack_Cam_Shack_Manager_01_Script;
    Enemy_Laser_Attack_Cam_Shack_Manager_02 Enemy_Laser_Attack_Cam_Shack_Manager_02_Script;
    Enemy_Attack_To_Player_CAM_Shack_Manager_01 Enemy_Attack_To_Player_CAM_Shack_Manager_01;
    Enemy_Attack_To_Player_CAM_Shack_Manager_02 Enemy_Attack_To_Player_CAM_Shack_Manager_02;
    Camera_Move_02 Camera_Move_02;
    public GameObject Defeat_UI_GameObject;






    protected override void OnStart()
    {
        Player_Sound_Manager = GameObject.Find("Player_Sound_Manager").GetComponent<Player_Sound_Manager>();
        StartCoroutine(Counting_For_Player_Warp());
        StartCoroutine(Barrier_Up());
        StartCoroutine(Is_Player_Hp_Down_Spark_Smoke_On());
        Find_Compoent();


        Score_Manager = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        Boss_Up_Manager_Script = GameObject.Find("Boss_Up_Manager").GetComponent<Boss_Up_Manager>();
        Camera_Move_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
        Enemy_Laser_Attack_Cam_Shack_Manager_01_Script = GameObject.Find("Enemy_Laser_Attack_Cam_Shack_Manager_01").GetComponent<Enemy_Laser_Attack_Cam_Shack_Manager_01>();
        Enemy_Laser_Attack_Cam_Shack_Manager_02_Script = GameObject.Find("Enemy_Laser_Attack_Cam_Shack_Manager_02").GetComponent<Enemy_Laser_Attack_Cam_Shack_Manager_02>();
        Enemy_Attack_To_Player_CAM_Shack_Manager_01 = GameObject.Find("Enemy_Attack_To_Player_CAM_Shack_Manager_01").GetComponent<Enemy_Attack_To_Player_CAM_Shack_Manager_01>();
        Enemy_Attack_To_Player_CAM_Shack_Manager_02 = GameObject.Find("Enemy_Attack_To_Player_CAM_Shack_Manager_02").GetComponent<Enemy_Attack_To_Player_CAM_Shack_Manager_02>();
    }

    bool Off = true;
    int Move_Speed =0 ;
    public Transform TR_From;
    public Transform TR_To;
    public In_Game_Start_Scene_Manager In_Game_Start_Scene_Manager;

    private void Update()
    {
        if (Player_Hp_Count <= 0)
        {
            shake.Shaking_Stop = true;
            Camera_Move_02.Shaking_Stop = true;
            Enemy_Laser_Attack_Cam_Shack_Manager_01_Script.Shaking_Stop = true;
            Enemy_Laser_Attack_Cam_Shack_Manager_02_Script.Shaking_Stop = true;
            Enemy_Attack_To_Player_CAM_Shack_Manager_01.Shaking_Stop = true;
            Enemy_Attack_To_Player_CAM_Shack_Manager_02.Shaking_Stop = true;




            Score_Manager.Score_Fin();

            In_Game_UI_Manager_Script.Player_Shoot_Stop = true;
            Defeat_UI_GameObject.SetActive(true);

            Time.timeScale = 0f;
        }

        else if ( Player_Barrier_Sprite.fillAmount < 1)
        {
            Barrier_Set[0].SetActive(false);
        }

        if (In_Game_Start_Scene_Manager.Player_Move_ == false && transform.position.x >0f) 
        {
            rigid2D.constraints = RigidbodyConstraints2D.FreezePositionX;

            Invoke("OFFF", 1f);
          
            Off = false;
        }

        else if (In_Game_Start_Scene_Manager.Player_Move_ == false && Off ==true)
        {
                 Off = true;
                 Move_Speed = 1;
                 rigid2D.AddForce(new Vector2(Move_Speed, 0), ForceMode2D.Force);
        }

       else if (In_Game_UI_Manager_Script.Player_Shoot_Stop == false)
        {
            Check_If_Player_Go_Out();

            if (Is_Player_Move == false)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Time_GO();

                }
                
               else if (Player_Warp_On ==true)
                {
                    Time_GO();

                }
            }
            else if (Is_Player_Move == true)
            {
                float h = (Input.GetAxisRaw("Horizontal"));
                float v = (Input.GetAxisRaw("Vertical"));

                Run(h, v);

                if (warp_Count < 4 && warp_Count > 0)
                {
                    if (is_Player_Warp_Cool_Time == false)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Player_Warp_On = false;
                            is_Player_Warp_Cool_Time = true;
                            StartCoroutine(WaitFor_Warp());

                            if (Player_Hp_Sprite.fillAmount > 0.7f)
                            {
                                Player_Warp.SetBool("Is_Player_Hp_100_Warp", true);
                            }
                            else if (Player_Hp_Sprite.fillAmount < 0.7f && Player_Hp_Sprite.fillAmount > 0.5f)
                            {
                                Player_Warp.SetBool("Is_Player_Hp_70_Warp", true);
                            }
                            else if (Player_Hp_Sprite.fillAmount < 0.5f)
                            {
                                Player_Warp.SetBool("Is_Player_Hp_50_Warp", true);
                            }

                            Time_Stop();
                            Invoke("Time_GO", 0.5f);
                        }
                        if (Input.GetKeyUp(KeyCode.Space))
                        {
                            Invoke("Time_GO", 0f);
                        }
                    }
                }
            }
        }
    }
    void OFFF()
    {
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }





    void Find_Compoent()
    {
        Player_Collider2D = GetComponent<BoxCollider2D>();
        rigid2D = GetComponent<Rigidbody2D>();
        shake = GameObject.Find("CameraShake_Manager").GetComponent<CameraMove>();
    }
    void Run(float h, float v)
    {
        movement.Set(h, v, 0);
        movement = movement.normalized * movePower * Time.deltaTime;
        rigid2D.MovePosition(transform.position + movement);
    }


    float Dist;
    public GameObject Warp_Player_;
    // 워프시 원 밖에 나갔는지 여부를 확인하는 
    void Check_If_Player_Go_Out()
    {
        Dist = Vector3.Distance(transform.position, Warp_Player_.transform.position);
        if ( Dist >6f)
        {
            Player_Warp_On = true;
        }
    }

    bool Once_Warp_ = false;

    //========================================================
    private void Time_Stop()
    {
        Once_Warp_ = false;
        Player_Sound_Manager.Player_Warp_In();

        Player_Manager_Script.Player_Move_Over();

        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        Player_Skill_Use_Smoke_Game_Object.SetActive(true);

        If_Player_Warp_Skill_On();
    }
    private void Time_GO()
    {
        if ( Once_Warp_ == false)
        {
            Once_Warp_ = true;
            Player_Sound_Manager.Player_Warp_Out();
        }

        if (Player_Hp_Sprite.fillAmount > 0.7f)
        {
            Player_Warp.SetBool("Is_Player_Hp_100_Warp", false);
        }
        else if (Player_Hp_Sprite.fillAmount < 0.7f && Player_Hp_Sprite.fillAmount > 0.5f)
        {
            Player_Warp.SetBool("Is_Player_Hp_70_Warp", false);
        }
        else if (Player_Hp_Sprite.fillAmount < 0.5f)
        {
            Player_Warp.SetBool("Is_Player_Hp_50_Warp", false);
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        Player_Skill_Use_Smoke_Game_Object.SetActive(false);

        if (Is_Player_Move == false)
        {
            Player_Manager_Script.Player_Move_Over_Finished();
        }   
    }
    //========================================================
    void Transform_Player_Postion(float h, float v)
    {
        Fast_movement.Set(h, v, 0);
        Fast_movement = Fast_movement.normalized * Fast_movePower * 2 * Time.deltaTime;
        rigid2D.MovePosition(transform.position + Fast_movement);
    }
    //========================================================






    void player_HP_Down_eFFECT_Once_Game_Object_Off()
    {
        player_HP_Down_eFFECT_Once_Game_Object.SetActive(false);
    }

    public GameObject player_HP_Down_eFFECT_Once_Game_Object;
    // 피격
    //=========================================================================공통 부분 

    int Player_Hp_Count = 9;
        void Player_HP_Down()
    {
        Player_Hp_Count--;

         if (Player_Hp_Count == 8)
        {
            Hp_Animator[8].SetTrigger("Is_Hp_100_Down");
        }
        else if (Player_Hp_Count == 7)
        {
            Hp_Animator[7].SetTrigger("Is_Hp_100_Down");
        }
        else if (Player_Hp_Count == 6)
        {
            Hp_Animator[6].SetTrigger("Is_Hp_100_Down");

            Hp_Animator[5].SetTrigger("Hp50");
            Hp_Animator[4].SetTrigger("Hp50");
            Hp_Animator[3].SetTrigger("Hp50");
            Hp_Animator[2].SetTrigger("Hp50");
            Hp_Animator[1].SetTrigger("Hp50");
            Hp_Animator[0].SetTrigger("Hp50");
        }



        // 플레이어의 체력이 절반이하 
        else if (Player_Hp_Count == 5)
        {
            Hp_Animator[5].SetTrigger("Is_Hp_50_Down");
        }
        else if (Player_Hp_Count == 4)
        {
            Hp_Animator[4].SetTrigger("Is_Hp_50_Down");
        }
        else if (Player_Hp_Count == 3)
        {
            Hp_Animator[3].SetTrigger("Is_Hp_50_Down");

            Hp_Animator[2].SetTrigger("Hp25");
            Hp_Animator[1].SetTrigger("Hp25");
            Hp_Animator[0].SetTrigger("Hp25");
        }




        //플레이어의 체력이 거의 없음 
        else if (Player_Hp_Count == 2)
        {
            Hp_Animator[2].SetTrigger("Is_Hp_25_Down");
        }
        //플레이어의 체력이 거의 없음 
        else if (Player_Hp_Count == 1)
        {
            Hp_Animator[1].SetTrigger("Is_Hp_25_Down");
        }
        //플레이어의 체력이 거의 없음 
        else if (Player_Hp_Count == 0)
        {
            Hp_Animator[0].SetTrigger("Is_Hp_25_Down");
        }

        else if (Player_Hp_Count < 0)
        {
            Player_Hp_Count = 0;
        }
    }




    void Player_Hp_Up()
    {
        Player_Hp_Count++;

        if (Player_Hp_Count >9)
        {
            Player_Hp_Count = 9;
        }
        else if (Player_Hp_Count == 9)
        {
            Hp_Animator[8].SetTrigger("Is_Hp_100_Up");
        }
        else if (Player_Hp_Count == 8)
        {
            Hp_Animator[7].SetTrigger("Is_Hp_100_Up");
        }
        else if (Player_Hp_Count == 7)
        {
            Hp_Animator[6].SetTrigger("Is_Hp_100_Up");

            Hp_Animator[5].SetTrigger("Hp100");
            Hp_Animator[4].SetTrigger("Hp100");
            Hp_Animator[3].SetTrigger("Hp100");
            Hp_Animator[2].SetTrigger("Hp100");
            Hp_Animator[1].SetTrigger("Hp100");
            Hp_Animator[0].SetTrigger("Hp100");
        }



        // 플레이어의 체력이 절반이하 
        else if (Player_Hp_Count == 6)
        {
            Hp_Animator[5].SetTrigger("Is_Hp_50_Up");
        }
        else if (Player_Hp_Count == 5)
        {
            Hp_Animator[4].SetTrigger("Is_Hp_50_Up");
        }
        else if (Player_Hp_Count == 4)
        {
            Hp_Animator[3].SetTrigger("Is_Hp_50_Up");

            Hp_Animator[2].SetTrigger("Hp50");
            Hp_Animator[1].SetTrigger("Hp50");
            Hp_Animator[0].SetTrigger("Hp50");
        }




        //플레이어의 체력이 거의 없음 
        else if (Player_Hp_Count == 3)
        {
            Hp_Animator[2].SetTrigger("Is_Hp_25_Up");
        }
        //플레이어의 체력이 거의 없음 
        else if (Player_Hp_Count == 2)
        {
            Hp_Animator[1].SetTrigger("Is_Hp_25_Up");
        }
        //플레이어의 체력이 거의 없음 
        else if (Player_Hp_Count == 1)
        {
            Hp_Animator[0].SetTrigger("Is_Hp_25_Up");
        }
    }

    void If_Player_Hit_Color_Change()
    {
        if (Player_Barrier_Sprite.fillAmount >= 1)
        {

        }
        else
        {
            Invoke("Red", 0.01f);
            Invoke("White", 0.2f);
            Invoke("Red", 0.3f);
            Invoke("White", 0.4f);
            Invoke("Red", 0.5f);
            Invoke("White", 0.6f);
            Invoke("Red", 0.5f);
            Invoke("White", 0.6f);
            Invoke("Red", 0.7f);
            Invoke("White", 0.8f);
        }

    }
    void White()
    {
        Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set[0].color = new Color(255, 255, 255, 1);
        Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set[1].color = new Color(255, 255, 255, 1);
        Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set[2].color = new Color(255, 255, 255, 1);
        Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set[3].color = new Color(255, 255, 255, 1);

        Player_SpriteRenderer.color = new Color(255, 255, 255, 1);
        Player_Rail_Gun_SpriteRenderer.color = new Color(255, 255, 255, 1);
        Player_Rocket_Launcher_SpriteRenderer.color = new Color(255, 255, 255, 1);
    }
    void Red()
    {
        Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set[0].color = new Color(255, 0, 0, 1);
        Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set[1].color = new Color(255, 0, 0, 1);
        Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set[2].color = new Color(255, 0, 0, 1);
        Player_Weapon_Service_Shot_Auto_Laser_Sprite_Renderer_Set[3].color = new Color(255, 0, 0, 1);

        Player_SpriteRenderer.color = new Color(255, 0, 0, 1);
        Player_Rail_Gun_SpriteRenderer.color = new Color(255, 0, 0, 1);
        Player_Rocket_Launcher_SpriteRenderer.color = new Color(255, 0, 0, 1);
    }
    void If_Player_Hp_Up_Down_Sprite_Change()
    {
        if(Player_Hp_Sprite.fillAmount >=0.7f)
        {
            Player_Warp.SetBool("Player_State_100", true);
            Player_Warp.SetBool("Player_State_70", false);
            Player_Warp.SetBool("Player_State_50", false);
        }

        else if (Player_Hp_Sprite.fillAmount < 0.7f && Player_Hp_Sprite.fillAmount > 0.5f)
        {
            player_HP_Down_eFFECT_Once_Game_Object.SetActive(true);
            Invoke("player_HP_Down_eFFECT_Once_Game_Object_Off", 1.5f);                   

            Player_Warp.SetBool("Player_State_100", false);
            Player_Warp.SetBool("Player_State_70", true);
            Player_Warp.SetBool("Player_State_50", false);
        }

        else if (Player_Hp_Sprite.fillAmount < 0.5f)
        {

            Player_Warp.SetBool("Player_State_100", false);
            Player_Warp.SetBool("Player_State_70", false);
            Player_Warp.SetBool("Player_State_50", true);
        }
    }


    //========================================================================= 그냥 부딛히다
    public void Decrease_Hp_Is_Hit_Normal_Enemy()
    {
        Player_HP_Down();
        If_Player_Hp_Up_Down_Sprite_Change();
    }
    public void Decrease_Barrier_Is_Hit_Normal_Enemy()
    {
        Player_Barrier_Sprite.fillAmount -= 1f;
    }
    public void Decrease_Barrier_First_Is_Hit_Normal_Enemy()
    {
        if (Player_Barrier_Sprite.fillAmount >= 1 )
        {
            Barrier_Creak();
            Decrease_Barrier_Is_Hit_Normal_Enemy();
        }

        else
        {
            Decrease_Hp_Is_Hit_Normal_Enemy();
        }
    }

    public void Player_Hit_Is_Hit_Normal_Enemy()
    {
        if (is_Player_Hit == false)
        {
            is_Player_Hit = true;

            If_Player_Hit_Color_Change();

            shake.CameraShaking = true;              // 화면 흔들게 하기 

            // Player_Box_Collider.enabled = false;

            Decrease_Barrier_First_Is_Hit_Normal_Enemy();

            StartCoroutine("WaitFor_Other_Hit");
        }
    }


    //========================================================================= 적 기본 탄막 
    public void Decrease_Hp_Is_Hit_Normal_Enemy_Bullet_Normal()
    {
        Player_Hp_Sprite.fillAmount -= 0.2f;
        If_Player_Hp_Up_Down_Sprite_Change();
    }
    public void Decrease_Barrier_Is_Hit_Normal_Enemy_Bullet_Normal()
    {
        Player_Barrier_Sprite.fillAmount -= 1f;
    }
    public void Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Normal()
    {
        if (Player_Barrier_Sprite.fillAmount >= 1)
        {
            Barrier_Creak();
            Decrease_Barrier_Is_Hit_Normal_Enemy();
        }

        else
        {
            Decrease_Hp_Is_Hit_Normal_Enemy();
        }
    }

    public void Player_Hit_Is_Hit_Normal_Enemy_Bullet_Normal()
    {
        if (is_Player_Hit == false)
        {
            is_Player_Hit = true;

            If_Player_Hit_Color_Change();

            shake.CameraShaking = true;              // 화면 흔들게 하기 

            Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Normal();

            StartCoroutine("WaitFor_Other_Hit");
        }
    }


    //========================================================================= 적 샷건 탄막  
    public void Decrease_Hp_Is_Hit_Normal_Enemy_Bullet_Shot_Gun()
    {
        Player_Hp_Sprite.fillAmount -= 0.1f;
        If_Player_Hp_Up_Down_Sprite_Change();
    }
    public void Decrease_Barrier_Is_Hit_Normal_Enemy_Bullet_Shot_Gun()
    {
        Player_Barrier_Sprite.fillAmount -= 1f;
    }
    public void Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Shot_Gun()
    {
        if (Player_Barrier_Sprite.fillAmount >= 1)
        {
            Barrier_Creak();
            Decrease_Barrier_Is_Hit_Normal_Enemy();
        }

        else
        {
            Decrease_Hp_Is_Hit_Normal_Enemy();
        }
    }

    public void Player_Hit_Is_Hit_Normal_Enemy_Bullet_Shot_Gun()
    {
        if (is_Player_Hit == false)
        {
            is_Player_Hit = true;

            If_Player_Hit_Color_Change();

            shake.CameraShaking = true;              // 화면 흔들게 하기 

            Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Shot_Gun();

            StartCoroutine("WaitFor_Other_Hit");
        }
    }


    //========================================================================= 적 빠른 탄막 
    public void Decrease_Hp_Is_Hit_Normal_Enemy_Bullet_Speed_Shoot()
    {
        Player_Hp_Sprite.fillAmount -= 0.1f;
        If_Player_Hp_Up_Down_Sprite_Change();
    }
    public void Decrease_Barrier_Is_Hit_Normal_Enemy_Bullet_Speed_Shoot()
    {
        Player_Barrier_Sprite.fillAmount -= 1f;
    }
    public void Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Speed_Shoot()
    {
        if (Player_Barrier_Sprite.fillAmount >= 1)
        {
            Barrier_Creak();
            Decrease_Barrier_Is_Hit_Normal_Enemy();
        }

        else
        {
            Decrease_Hp_Is_Hit_Normal_Enemy();
        }
    }

    public void Player_Hit_Is_Hit_Normal_Enemy_Bullet_Speed_Shoot()
    {
        if (is_Player_Hit == false)
        {
            is_Player_Hit = true;

            If_Player_Hit_Color_Change();

            shake.CameraShaking = true;              // 화면 흔들게 하기 

            Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Speed_Shoot();

            StartCoroutine("WaitFor_Other_Hit");
        }
    }


    //========================================================================= 적 확산 탄막 
    public void Decrease_Hp_Is_Hit_Normal_Enemy_Bullet_Spread_Shoot()
    {
        Player_Hp_Sprite.fillAmount -= 0.3f;
        If_Player_Hp_Up_Down_Sprite_Change();
    }
    public void Decrease_Barrier_Is_Hit_Normal_Enemy_Bullet_Spread_Shoot()
    {
        Player_Barrier_Sprite.fillAmount -= 1f;
    }
    public void Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Spread_Shoot()
    {
        if (Player_Barrier_Sprite.fillAmount >= 1)
        {
            Barrier_Creak();
            Decrease_Barrier_Is_Hit_Normal_Enemy();
        }

        else
        {
            Decrease_Hp_Is_Hit_Normal_Enemy();
        }
    }

    public void Player_Hit_Is_Hit_Normal_Enemy_Bullet_Spread_Shoot()
    {
        if (is_Player_Hit == false)
        {
            is_Player_Hit = true;

            If_Player_Hit_Color_Change();

            shake.CameraShaking = true;              // 화면 흔들게 하기 

            Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Spread_Shoot();

            StartCoroutine("WaitFor_Other_Hit");
        }
    }


    //========================================================================= 적 레이저 공격 
    public void Decrease_Hp_Is_Hit_Normal_Enemy_Bullet_Laser_Shoot()
    {
        Player_Hp_Sprite.fillAmount -= 0.2f;
        If_Player_Hp_Up_Down_Sprite_Change();
    }
    public void Decrease_Barrier_Is_Hit_Normal_Enemy_Bullet_Laser_Shoot()
    {
        Player_Barrier_Sprite.fillAmount -= 1f;
    }
    public void Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Laser_Shoot()
    {
        if (Player_Barrier_Sprite.fillAmount >= 1)
        {
            Barrier_Creak();
            Decrease_Barrier_Is_Hit_Normal_Enemy();
        }

        else
        {
            Decrease_Hp_Is_Hit_Normal_Enemy();
        }
    }

    public void Player_Hit_Is_Hit_Normal_Enemy_Bullet_Laser_Shoot()
    {
        if (is_Player_Hit == false)
        {
            is_Player_Hit = true;

            If_Player_Hit_Color_Change();

            shake.CameraShaking = true;              // 화면 흔들게 하기 

            Decrease_Barrier_First_Is_Hit_Normal_Enemy_Bullet_Laser_Shoot();

            StartCoroutine("WaitFor_Other_Hit");
        }
    }





    bool Player_Warp_On = false;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy_Bullet_Laser")                  //  피격 판정 및 무적여부 확인
        {
            Player_Hit_Is_Hit_Normal_Enemy_Bullet_Laser_Shoot();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "Player_Hp_Item")
        {
            Destroy(other.gameObject);
            Player_Hp_Up();
            Invoke("Player_Hp_Up", 0.2f);
        }
    }





    //=================================================================================================================================
    bool Warp_Skill_Use_01 = false;
    bool Warp_Skill_Use_02 = false;
    bool Warp_Skill_Use_03 = false;

    public GameObject[] Warp_Count_Game_Object;
    //============================================= 도중에 스킬을 누를 경우 초기화 하기 위한 int 값 
    int Warp_Time_Count = 0;
    //============================================= 플레이어가 가지고 있는 웨프 가능 횟수 int 값 
    int warp_Count = 3;
    void warp_Count_For_Player()
    {
        if (warp_Count ==3)
        {
            Warp_Count_Game_Object[2].SetActive(true);
            Warp_Count_Game_Object[1].SetActive(true);
            Warp_Count_Game_Object[0].SetActive(true);
        }
        else if ( warp_Count == 2)
        {
            Warp_Count_Game_Object[2].SetActive(false);
            Warp_Count_Game_Object[1].SetActive(true);
            Warp_Count_Game_Object[0].SetActive(true);
        }
        else if (warp_Count == 1)
        {
            Warp_Count_Game_Object[2].SetActive(false);
            Warp_Count_Game_Object[1].SetActive(false);
            Warp_Count_Game_Object[0].SetActive(true);
        }
        else if (warp_Count == 0)
        {
            Warp_Count_Game_Object[2].SetActive(false);
            Warp_Count_Game_Object[1].SetActive(false);
            Warp_Count_Game_Object[0].SetActive(false);
        }
    }
    //===============================  워프 했을 경우 
    void If_Player_Warp_Skill_On()
    {
        Warp_Time_Count = 0;
        warp_Count--;
        warp_Count_For_Player();
    }
    //=================================================================================================================================



    bool on_Ani_Off = false;
   void Check_Barrier_Is_On()
    {
        if (Player_Barrier_Sprite.fillAmount >= 1 && on_Ani_Off == false)
        {
            Barrier_All_On();
            on_Ani_Off = true;
        }
        else if (Player_Barrier_Sprite.fillAmount <1)
        {
            on_Ani_Off = false;
        }
    }
    // 0 => BarrierAll
    //1 => Barrier_Creak
    public GameObject[] Barrier_Set;
    //=================================================================================================================================
    void Barrier_All_On()
    {
        Barrier_Set[2].SetActive(true);
        Invoke("Barrier_On_Ani", 1.4f);
        Barrier_Set[1].SetActive(false);
    }
    void Barrier_On_Ani()
    {
        Barrier_Set[0].SetActive(true);
        Barrier_Set[1].SetActive(false);
        Barrier_Set[2].SetActive(false);
    }
    void Barrier_Creak()
    {
        Barrier_Set[0].SetActive(false);
        Barrier_Set[1].SetActive(true);
        Barrier_Set[2].SetActive(false);
    }




    //=================================================================================================================================

    IEnumerator Counting_For_Player_Warp()
    {
        yield return new WaitForSeconds(1f);
        Warp_Time_Count++;

        if (Warp_Time_Count == 5)
        {
            if (warp_Count < 3)
            {
                Warp_Time_Count = 0;
                warp_Count++;
                warp_Count_For_Player();
            }

            else if (warp_Count >= 4)
            {          
                // 그 이상인 경우 워프 가능 값은 3으로 고정한다.  
                warp_Count = 3;
                Debug.Log(warp_Count);
                Warp_Time_Count = 0;
            }        
        }
        StartCoroutine(Counting_For_Player_Warp());
    }
    IEnumerator Barrier_Up()
    {
        yield return new WaitForSeconds(0.01f);

        Player_Barrier_Sprite.fillAmount += 0.002f;
        Check_Barrier_Is_On();
        StartCoroutine(Barrier_Up());
    }
    IEnumerator Is_Player_Hp_Down_Spark_Smoke_On()
    {
        // 스파크 온
        if (Player_Hp_Sprite.fillAmount >= 0.4 && Player_Hp_Sprite.fillAmount <= 0.6)
        {
          //  Debug.Log("AD1");
            Player_Spark.SetActive(true);
            Player_Smoke.SetActive(false);
        }
        else if (Player_Hp_Sprite.fillAmount <= 0.3)
        {
          //  Debug.Log("AD2");
            Player_Spark.SetActive(true);
            Player_Smoke.SetActive(true);
        }
        else if (Player_Hp_Sprite.fillAmount >= 0.7)
        {
          //  Debug.Log("AD3");
            Player_Spark.SetActive(false);
            Player_Smoke.SetActive(false);
        }

        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Is_Player_Hp_Down_Spark_Smoke_On());
    }
    IEnumerator WaitFor_Warp()
    {
        yield return new WaitForSeconds(0.8f);

        is_Player_Warp_Cool_Time = false;
        yield break;
    }
    IEnumerator WaitFor_Other_Hit()
    {
        yield return new WaitForSeconds(1f);

        is_Player_Hit = false;

        Player_Box_Collider.enabled = true;

        yield break;
    }
}

