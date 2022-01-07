using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TwoDLaserPack
{
    public class Player_Shoot : MonoBehaviour
    {
        bool Service_Gun_Bool = true;
        bool Shot_Gun_Bool = false;
        bool Auto_Gun_Bool = false;
        bool Laser_Gun_Bool = false;

        bool Rocket_Gun_Bool = false;
        bool Rail_Gun_Bool= false;

        //====================================================== 마우스 위치 
        [SerializeField]
        Transform Mouse_Pos;

        public GameObject Rocket_Launcher_Mouse_Pos;
        public SpriteRenderer Rocket_Launcher_Cross_Hair_Sprite_Renderer;

        public Transform Rail_Gun_Transform;
        public Transform Rocket_Launcher_Transform;


        //======================================================= 서비스 건 용
        [SerializeField]
        GameObject Service_Gun_Fire_Pos;

        [SerializeField]
        GameObject Service_Gun_projectile;



        //======================================================= 오토 건 
        [SerializeField]
        GameObject Auto_Gun_Fire_Pos;
        [SerializeField]
        GameObject Auto_Gun_Fire_Pos_02;

        [SerializeField]
        GameObject Auto_Gun_projectile;



        //======================================================= 샷건용 
        [SerializeField]
        GameObject Shot_Gun_firePos_top;
        [SerializeField]
        GameObject Shot_Gun_firePos_middle;
        [SerializeField]
        GameObject Shot_Gun_firePos_buttom;

        [SerializeField]
        GameObject Shot_Gun_projectile_top;
        [SerializeField]
        GameObject Shot_Gun_projectile_Middle;
        [SerializeField]
        GameObject Shot_Gun_projectile_buttom;


        //======================================================= 레일건 용 
        [SerializeField]
        GameObject Rail_Gun_firePos;

        [SerializeField]
        GameObject Rail_Gun_projectile;


        //=======================================================  로켓 런처
        [SerializeField]
        GameObject Rocket_Launcher_firePos;

        [SerializeField]
        GameObject Rocket_Launcher_projectile;



        //========================================================== 외부 스크립트 
        public In_Game_UI_Manager In_Game_UI_Manager_Script;
        public playy playy_Script;
        public GameObject Laser_On_Off;
        public SpriteBasedLaser SpriteBasedLaser_Script;



        //=========================================================== 무기 대미지 
        public int Player_Damage_ = 10;
        public float offset;



        //========================================================== 슈팅 딜레이
        bool Service_Gun_Shoot_Delay;
        bool Auto_Gun_Shoot_Delay;
        bool Shot_Gun_Shoot_Delay;

        bool Lazer_Shoot_Delay;
        bool Laser_Stop = false;

        bool Laser_Off_01_Start = false;
        bool Laser_Off_02_Start;
        bool Laser_Off_03_Start;

        bool Rocket_Shoot_Aim_Time_Stop_Delay;
        bool Rail_Gun_Aim_Time_Stop_Delay;

        bool Rail_Gun_Delay = false;

        //=========================================================== 무기의 애니메이션을 조정 
        public GameObject Player_Laser_Start_Ani_GameObject;
        public GameObject Player_Laser_End_Ani_GameObject;

        public Animator Player_Service_Gun_Animator;
        public Animator Player_Service_Gun_Ani_Animator;

        public Animator Player_Auto_Gun_Animator;
        public Animator Player_Auto_Gun__Ani_01_Animator;
        public Animator Player_Auto_Gun__Ani_02_Animator;


        public Animator Player_Shot_Gun_Animator;
        public Animator Player_Shot_Gun_Ani_Animator;

        public Animator Player_Lazer_Gun_Animator;
        public Animator Player_Lazer_Gun_Charge_Animator;

        public Animator Player_Rocket_Launcher_Animator;
        public Animator Player_Rocket_Launcher_Ani_Animator;

        public Animator Player_Rail_Gun_Animator;
        public Animator Player_Rail_Gun_Shoot_Animator;
        public Animator Player_Rail_Gun_Charge_Animator;




        //=========================================================== 무기의 이미지 바꾸기 + 발싸 이미지  
        public GameObject Player_Shot_Gun_GameObject;
        public GameObject Player_Auto_Gun_GameObject;
        public GameObject Player_Service_Gun_GameObject;
        public GameObject Lazer_GameObject;
        public GameObject Player_Rocket_Launcher_GameObject;

        public GameObject Player_Rail_Gun_GameObject;
        public GameObject Player_Rail_Gun_Pointer_GameObject;



        //=========================================================== 현재 무슨 무기를 가지고 있는지 알려줌
        bool IS_Player_Weapon_One = true;
        bool Player_Laser_Ani_Ready = false;

        bool IS_Player_Rocket_Launcher_Shoot = false;
        bool IS_Player_Rail_Gun_Shoot = false;
        bool Is_Player_Rail_Gun_Ready = false;
        bool Player_Roket_Launcher_Coroutine_Break = false;


        //============================================================ 무기의 이미지 
        public SpriteRenderer Player_Service_Gun_Sprite;
        public SpriteRenderer Player_Service_Gun_Fire_Sprite;

        public SpriteRenderer Player_Auto_Gun_Sprite;
        public SpriteRenderer Player_Auto_Gun_Fire_Sprite_01;
        public SpriteRenderer Player_Auto_Gun_Fire_Sprite_02;

        public SpriteRenderer Player_Shot_Gun_Sprite;
        public SpriteRenderer Player_Shot_Gun_Fire_Sprite;

        public SpriteRenderer Player_Laser_Gun_Sprite;
        public SpriteRenderer Player_Laser_Gun_Fire_Sprite;

        public SpriteRenderer Player_Rail_Gun_Sprite;
        public SpriteRenderer Player_Rail_Gun_Fire_Sprite;

        public SpriteRenderer Player_Rocket_Launcher_Sprite;
        public SpriteRenderer Player_Rocket_Launcher_Fire_Sprite;



        //============================================================ 무기의 초기화 이미지 
        public SpriteRenderer Service_Gun_Sprite;
        public SpriteRenderer Service_Gun_Fire_Sprite;

        public SpriteRenderer Auto_Gun_Sprite;
        public SpriteRenderer Auto_Gun_Fire_Sprite_01;
        public SpriteRenderer Auto_Gun_Fire_Sprite_02;

        public SpriteRenderer Shot_Gun_Sprite;
        public SpriteRenderer Shot_Gun_Fire_Sprite;

        public SpriteRenderer Laser_Gun_Sprite;
        public SpriteRenderer Laser_Gun_Fire_Sprite;

        public SpriteRenderer Rail_Gun_Sprite;
        public SpriteRenderer Rail_Gun_Fire_Sprite;

        public SpriteRenderer Rocket_Launcher_Sprite;
        public SpriteRenderer Rocket_Launcher_Fire_Sprite;

        //=============================================================== 무기의 이미지 변화 
        public GameObject[] Weapon_Image_Change;

        Player_Sound_Manager Player_Sound_Manager;
        Player_Shoot_Sound_Manager Player_Shoot_Sound_Manager;








        private void Start()
        {
            Player_Shoot_Sound_Manager = GameObject.Find("Player_Shoot_Sound_Manager").GetComponent<Player_Shoot_Sound_Manager>();
            Player_Sound_Manager = GameObject.Find("Player_Sound_Manager").GetComponent<Player_Sound_Manager>();

            Service_Gun_Shoot_Delay = true;
            Auto_Gun_Shoot_Delay = true;
            Shot_Gun_Shoot_Delay = true;
            Lazer_Shoot_Delay = true;
            Rocket_Shoot_Aim_Time_Stop_Delay = true;
            Rail_Gun_Aim_Time_Stop_Delay = true;
        }








        //Weapon_Image_Change[0] == 
        //Weapon_Image_Change[1] == 
        //Weapon_Image_Change[2] == 
        //Weapon_Image_Change[3] == 
        void Weapon_Image_Service_Gun()
        {
            Weapon_Image_Change[0].SetActive(true);
            Weapon_Image_Change[1].SetActive(false);
            Weapon_Image_Change[2].SetActive(false);
            Weapon_Image_Change[3].SetActive(false);
        }
        void Weapon_Image_Shot_Gun()
        {
            Weapon_Image_Change[0].SetActive(false);
            Weapon_Image_Change[1].SetActive(true);
            Weapon_Image_Change[2].SetActive(false);
            Weapon_Image_Change[3].SetActive(false);
        }
        void Weapon_Image_Auto_Gun()
        {
            Weapon_Image_Change[0].SetActive(false);
            Weapon_Image_Change[1].SetActive(false);
            Weapon_Image_Change[2].SetActive(true);
            Weapon_Image_Change[3].SetActive(false);
        }
        void Weapon_Image_Laser_Gun()
        {
            Weapon_Image_Change[0].SetActive(false);
            Weapon_Image_Change[1].SetActive(false);
            Weapon_Image_Change[2].SetActive(false);
            Weapon_Image_Change[3].SetActive(true);
        }







        //=========================== 현재 무기의 상태는 무엇?
        void Service_Gun_Bool_DD()
        {
            Service_Gun_Bool = true;
            Shot_Gun_Bool = false;
            Auto_Gun_Bool = false;
            Laser_Gun_Bool = false;
            Rocket_Gun_Bool = false;
            Rail_Gun_Bool = false;
        }
        void Shot_Gun_Bool_DD()
        {
            Service_Gun_Bool = false;
            Shot_Gun_Bool = true;
            Auto_Gun_Bool = false;
            Laser_Gun_Bool = false;
            Rocket_Gun_Bool = false;
            Rail_Gun_Bool = false;
        }
        void Auto_Gun_Bool_DD()
        {
            Service_Gun_Bool = false;
            Shot_Gun_Bool = false;
            Auto_Gun_Bool = true;
            Laser_Gun_Bool = false;
            Rocket_Gun_Bool = false;
            Rail_Gun_Bool = false;
        }
        void Laser_Gun_Bool_DD()
        {
            Service_Gun_Bool = false;
            Shot_Gun_Bool = false;
            Auto_Gun_Bool = false;
            Laser_Gun_Bool = true;
            Rocket_Gun_Bool = false;
            Rail_Gun_Bool = false;
        }
        void Rail_Gun_Bool_DD()
        {
            Service_Gun_Bool = false;
            Shot_Gun_Bool = false;
            Auto_Gun_Bool = false;
            Laser_Gun_Bool = false;
            Rocket_Gun_Bool = false;
            Rail_Gun_Bool = true;
        }
        void Rocket_Gun_Bool_DD()
        {
            Service_Gun_Bool = false;
            Shot_Gun_Bool = false;
            Auto_Gun_Bool = false;
            Laser_Gun_Bool = false;
            Rocket_Gun_Bool = true;
            Rail_Gun_Bool = false;
        }

        // 그럼 바꿔줘 
        void Service_Gun()
        {
            Player_Sound_Manager.Player_Weapon_Change();
            Service_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(true);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(false);

            Weapon_Image_Service_Gun();
            Rocket_Cross_Hair_Off();
            Gun_Change_Ani.SetTrigger("Gun_Change_Ani");
        }
        void Shot_Gun()
        {
            Player_Sound_Manager.Player_Weapon_Change();

            Shot_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(true);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(false);

            Weapon_Image_Shot_Gun();
            Rocket_Cross_Hair_Off();
            Gun_Change_Ani.SetTrigger("Gun_Change_Ani");
        }
        void Auto_Gun()
        {
            Player_Sound_Manager.Player_Weapon_Change();

            Auto_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(true);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(false);

            Weapon_Image_Auto_Gun();
            Rocket_Cross_Hair_Off();
            Gun_Change_Ani.SetTrigger("Gun_Change_Ani");
        }
        void Laser_Gun()
        {
            Player_Sound_Manager.Player_Weapon_Change();

            Laser_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(true);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(false);

            Weapon_Image_Laser_Gun();
            Rocket_Cross_Hair_Off();
            Gun_Change_Ani.SetTrigger("Gun_Change_Ani");
        }
        void Rail_Gun()
        {
            Player_Sound_Manager.Player_Weapon_Change();

            Rail_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(true);
            Player_Rail_Gun_Pointer_GameObject.SetActive(true);

            Rocket_Cross_Hair_Off();
            Gun_Change_Ani.SetTrigger("Gun_Change_Ani");
        }
        void Rocket_Gun()
        {
            Player_Sound_Manager.Player_Weapon_Change();

            Rocket_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(true);
            Player_Rocket_Launcher_GameObject.SetActive(true);
            Player_Rail_Gun_GameObject.SetActive(false);

            Rocket_Cross_Hair_ON();
            Gun_Change_Ani.SetTrigger("Gun_Change_Ani");
        }



        void Check_In_Heavy_To_Light()
        {
          if (Weapon_01 == "Shot")
            {
                Shot_Gun();
            }
          else if (Weapon_01 == "Laser")
            {
                Laser_Gun();
            }
          else if (Weapon_01 == "Auto")
            {
                Auto_Gun();
            }
          else if (Weapon_01 == "Service")
            {
                Service_Gun();
            }
        }

        public Image [] Weapon_02_Title_Image;
        public Image [] Heavy_Weapon_Title_Image;

        public Image[] Weapon_02_Name_Image;
        public Image []  Heavy_Weapon_Name_Image;




        public GameObject[] Weapon_01_UI_Set;
        public GameObject[] Weapon_02_UI_Set;
        public GameObject[] Heavy_Weapon_UI_Set;

        void Check_Weapon_Ui_01()
        {
            if (Weapon_01 =="Service")
            {
                Weapon_01_UI_Set[0].SetActive(true);
                Weapon_01_UI_Set[1].SetActive(false);
                Weapon_01_UI_Set[2].SetActive(false);
                Weapon_01_UI_Set[3].SetActive(false);
            }
            
            else if (Weapon_01 == "Shot")
            {
                Weapon_01_UI_Set[0].SetActive(false);
                Weapon_01_UI_Set[1].SetActive(true);
                Weapon_01_UI_Set[2].SetActive(false);
                Weapon_01_UI_Set[3].SetActive(false);
            }

            else if (Weapon_01 == "Auto")
            {
                Weapon_01_UI_Set[0].SetActive(false);
                Weapon_01_UI_Set[1].SetActive(false);
                Weapon_01_UI_Set[2].SetActive(true);
                Weapon_01_UI_Set[3].SetActive(false);
            }

            else if (Weapon_01 == "Laser")
            {
                Weapon_01_UI_Set[0].SetActive(false);
                Weapon_01_UI_Set[1].SetActive(false);
                Weapon_01_UI_Set[2].SetActive(false);
                Weapon_01_UI_Set[3].SetActive(true);
            }
        }
        void Check_Weapon_Ui_02()
        {
            if (Weapon_02 == "Service")
            {
                Weapon_02_UI_Set[0].SetActive(true);
                Weapon_02_UI_Set[1].SetActive(false);
                Weapon_02_UI_Set[2].SetActive(false);
                Weapon_02_UI_Set[3].SetActive(false);
                Weapon_02_UI_Set[4].SetActive(false);

                Weapon_02_Title_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[1].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[2].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[3].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[4].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
            }

            else if (Weapon_02 == "Shot")
            {
                Weapon_02_UI_Set[0].SetActive(false);
                Weapon_02_UI_Set[1].SetActive(true);
                Weapon_02_UI_Set[2].SetActive(false);
                Weapon_02_UI_Set[3].SetActive(false);
                Weapon_02_UI_Set[4].SetActive(false);

                Weapon_02_Title_Image[0].color = new Color(255/255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[1].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[2].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[3].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[4].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
            }

            else if (Weapon_02 == "Auto")
            {
                Weapon_02_UI_Set[0].SetActive(false);
                Weapon_02_UI_Set[1].SetActive(false);
                Weapon_02_UI_Set[2].SetActive(true);
                Weapon_02_UI_Set[3].SetActive(false);
                Weapon_02_UI_Set[4].SetActive(false);
                Weapon_02_Title_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[1].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[2].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[3].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[4].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
            }

            else if (Weapon_02 == "Laser")
            {
                Weapon_02_UI_Set[0].SetActive(false);
                Weapon_02_UI_Set[1].SetActive(false);
                Weapon_02_UI_Set[2].SetActive(false);
                Weapon_02_UI_Set[3].SetActive(true);
                Weapon_02_UI_Set[4].SetActive(false);

                Weapon_02_Title_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[1].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[2].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[3].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Weapon_02_Name_Image[4].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
            }

            else if (Weapon_02 == "Empty")
            {
                Weapon_02_UI_Set[0].SetActive(false);
                Weapon_02_UI_Set[1].SetActive(false);
                Weapon_02_UI_Set[2].SetActive(false);
                Weapon_02_UI_Set[3].SetActive(false);
                Weapon_02_UI_Set[4].SetActive(true);

                Weapon_02_Title_Image[0].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
                Weapon_02_Name_Image[0].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
                Weapon_02_Name_Image[1].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
                Weapon_02_Name_Image[2].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
                Weapon_02_Name_Image[3].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
                Weapon_02_Name_Image[4].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
            }
        }
        void Check_Weapon_UI()
        {
            if (Heavy_Weapon == "Rail")
            {
                Heavy_Weapon_UI_Set[0].SetActive(true);
                Heavy_Weapon_UI_Set[1].SetActive(false);
                Heavy_Weapon_UI_Set[2].SetActive(false);

                Heavy_Weapon_Title_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Heavy_Weapon_Name_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Heavy_Weapon_Name_Image[1].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Heavy_Weapon_Name_Image[2].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
            }

            else if (Heavy_Weapon == "Rocket")
            {
                Heavy_Weapon_UI_Set[0].SetActive(false);
                Heavy_Weapon_UI_Set[1].SetActive(true);
                Heavy_Weapon_UI_Set[2].SetActive(false);

                Heavy_Weapon_Title_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Heavy_Weapon_Name_Image[0].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Heavy_Weapon_Name_Image[1].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
                Heavy_Weapon_Name_Image[2].color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1);
            }

            else if (Heavy_Weapon == "Empty")
            {
                Heavy_Weapon_UI_Set[0].SetActive(false);
                Heavy_Weapon_UI_Set[1].SetActive(false);
                Heavy_Weapon_UI_Set[2].SetActive(true);

                Heavy_Weapon_Title_Image[0].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
                Heavy_Weapon_Name_Image[0].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
                Heavy_Weapon_Name_Image[1].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
                Heavy_Weapon_Name_Image[2].color = new Color(130 / 255f, 130 / 255f, 130 / 255f, 1);
            }
        }




        public GameObject Cross_Hair;
        public Animator Gun_Change_Ani;
        private void Update()
        {
            if (In_Game_UI_Manager_Script.Player_Shoot_Stop == false)
            {
                // 무기 바꾸기 
                if (Input.GetMouseButtonUp(1))
                {       
                    // 현재 중무장 무기를 가지고 있는 상태인 경우 
                    if (Rocket_Gun_Bool == true || Rail_Gun_Bool == true)
                    {
                        Check_In_Heavy_To_Light();
                    }
                    else
                    {
                        if (Weapon_02 == "Empty")
                        {
                            //
                        }
                        else
                        {
                            if (Weapon_01 == "Service")
                            {
                                 if (Weapon_02 == "Shot")
                                {
                                    Weapon_01 = "Shot";
                                    Weapon_02 = "Service";

                                    Shot_Gun();
                                }
                                else if (Weapon_02 == "Auto")
                                {
                                    Weapon_01 = "Auto";
                                    Weapon_02 = "Service";

                                    Auto_Gun();
                                }
                                else if (Weapon_02 == "Laser")
                                {
                                    Weapon_01 = "Laser";
                                    Weapon_02 = "Service";

                                    Laser_Gun();
                                }
                            }
                            else if (Weapon_01 == "Shot")
                            {
                                if (Weapon_02 == "Service")
                                {
                                    Weapon_01 = "Service";
                                    Weapon_02 = "Shot";

                                    Service_Gun();
                                }                              
                                else if (Weapon_02 == "Auto")
                                {
                                    Weapon_01 = "Auto";
                                    Weapon_02 = "Shot";

                                    Auto_Gun();
                                }
                                else if (Weapon_02 == "Laser")
                                {
                                    Weapon_01 = "Laser";
                                    Weapon_02 = "Shot";

                                    Laser_Gun();
                                }                             
                            }
                            else if (Weapon_01 == "Auto")
                            {
                                if (Weapon_02 == "Service")
                                {
                                    Weapon_01 = "Service";
                                    Weapon_02 = "Auto";

                                    Service_Gun();
                                }
                                else if (Weapon_02 == "Shot")
                                {
                                    Weapon_01 = "Shot";
                                    Weapon_02 = "Auto";

                                    Shot_Gun();
                                }
                                else if (Weapon_02 == "Laser")
                                {
                                    Weapon_01 = "Laser";
                                    Weapon_02 = "Auto";

                                    Laser_Gun();
                                }
                            }
                            else if (Weapon_01 == "Laser")
                            {
                                if (Weapon_02 == "Service")
                                {
                                    Weapon_01 = "Service";
                                    Weapon_02 = "Laser";

                                    Service_Gun();
                                }
                                else if (Weapon_02 == "Shot")
                                {
                                    Weapon_01 = "Shot";
                                    Weapon_02 = "Laser";

                                    Shot_Gun();
                                }
                                else if (Weapon_02 == "Auto")
                                {
                                    Weapon_01 = "Auto";
                                    Weapon_02 = "Laser";

                                    Auto_Gun();
                                }
                            }
                        }
                    }
                                    
                    Lazer_Shoot_Delay = true;
                    Player_Laser_Ani_Ready = false;

                    Is_Player_Rail_Gun_Ready = false;

                    transform.rotation = Quaternion.Euler(0f, 0f, 0);

                    Player_Gun_And_Fire_Reset();

                    Time_GO();

                    Check_Weapon_Ui_01();
                    Check_Weapon_Ui_02();
                    Debug.Log(Weapon_01);
                    Debug.Log(Weapon_02);
                    Debug.Log(Heavy_Weapon);
                }

                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (Heavy_Weapon == "Empty")
                    {
                        // 
                    }
                    else if (Heavy_Weapon != "Empty")
                    {
                        if (Heavy_Weapon == "Rail")
                        {
                            Rail_Gun();
                        }
                        else if (Heavy_Weapon =="Rocket")
                        {
                            Rocket_Gun();
                        }
                    }
                    Check_Weapon_UI();
                }

                //실제 발사 
                //==================================================================================================================================================================
                // 순간이동 상태가 아닌경우 
                else if (playy_Script.Is_Player_Move == true)
                {
                    Mouse_Pos.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    float rotz = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;

                    //샷건 
                    if (Shot_Gun_Bool == true)
                    {
                        if (Input.GetMouseButton(0) && Shot_Gun_Shoot_Delay == true)
                        {
                            Player_Shoot_Sound_Manager.Shot_();
                            /*
                            Player_Shot_Gun_Animator.SetTrigger("is_Shot_Gun");
                            */
                            Player_Shot_Gun_Ani_Animator.SetTrigger("is_Shot_Gun_Ani");


                            //================================================================ 딜레이 넣기 
                            Shot_Gun_Shoot_Delay = false;
                            StartCoroutine(WaitFor_Shot_Gun_Shoot());

                            //================================================================ 총알 발동 
                            Instantiate(Shot_Gun_projectile_top, Shot_Gun_firePos_top.transform.position, Quaternion.Euler(0f, 0f, 8));
                            Instantiate(Shot_Gun_projectile_top, Shot_Gun_firePos_top.transform.position, Quaternion.Euler(0f, 0f, 3));
                            Instantiate(Shot_Gun_projectile_Middle, Shot_Gun_firePos_middle.transform.position, transform.rotation);
                            Instantiate(Shot_Gun_projectile_buttom, Shot_Gun_firePos_buttom.transform.position, Quaternion.Euler(0f, 0f, -3));
                            Instantiate(Shot_Gun_projectile_top, Shot_Gun_firePos_buttom.transform.position, Quaternion.Euler(0f, 0f, -8));
                        }

                        else if (Input.GetMouseButtonUp(0))
                        {
                            Player_Shoot_Sound_Manager.Loop_Off();
                        }
                    }

                    // 오토건 
                    else if (Auto_Gun_Bool == true)
                    {
                        if (Input.GetMouseButton(0) && Auto_Gun_Shoot_Delay == true)
                        {
                            Player_Shoot_Sound_Manager.Auto();

                            //================================================================ 딜레이 넣기 
                            Auto_Gun_Shoot_Delay = false;
                            StartCoroutine(WaitFor_Auto_Gun_Shoot());

                            /*
                            //================================================================ 애니메이션 
                            Player_Auto_Gun_Animator.SetTrigger("is_Auto_Gun_Trigger");
                            Player_Auto_Gun_Animator.SetBool("is_Auto_Gun", true);
                             */

                            Player_Auto_Gun__Ani_01_Animator.SetBool("is_Auto_Gun_Fire_Ani", true);
                            Player_Auto_Gun__Ani_02_Animator.SetBool("is_Auto_Gun_Fire_Ani", true);


                            //================================================================ 총알 발동 
                            Instantiate(Auto_Gun_projectile, Auto_Gun_Fire_Pos.transform.position, transform.rotation);
                            Invoke("Auto_Gun_Shoot_02", 0.35f);
                        }
                        else if (Input.GetMouseButtonUp(0))
                        {
                            /*
                            Player_Auto_Gun_Animator.SetBool("is_Auto_Gun", false);
                            */
                            Player_Shoot_Sound_Manager.Loop_Off();

                            Player_Auto_Gun__Ani_01_Animator.SetBool("is_Auto_Gun_Fire_Ani", false);
                            Player_Auto_Gun__Ani_02_Animator.SetBool("is_Auto_Gun_Fire_Ani", false);

                        }
                    }

                    // 서비스 건 
                    else if (Service_Gun_Bool == true)
                    {
                        if (Input.GetMouseButton(0) && Service_Gun_Shoot_Delay == true)
                        {
                            Player_Shoot_Sound_Manager.Service_();

                            //=============================================================== 애니메이션 설정 
                            Player_Service_Gun_Ani_Animator.SetTrigger("is_Service_Gun_Fire_Ani");
                            /*
                        Player_Service_Gun_Animator.SetTrigger("is_Service_Gun");
                        */

                            //================================================================ 딜레이 넣기 
                            Service_Gun_Shoot_Delay = false;
                            StartCoroutine(WaitFor_Service_Gun_Shoot());

                            //================================================================ 총알 발동 
                            Instantiate(Service_Gun_projectile, Service_Gun_Fire_Pos.transform.position, transform.rotation);
                        }
                        else if (Input.GetMouseButtonUp(0))
                        {
                            Player_Shoot_Sound_Manager.Loop_Off();
                        }
                    }

                    // 레이저 건  
                    else if (Laser_Gun_Bool == true)
                    {
                        if (Input.GetMouseButtonUp(0) && Player_Laser_Ani_Ready == true)
                        {
                            // 레이저 끄기 
                            Lazer_Off_03();
                        }
                        else if (Input.GetMouseButtonDown(0) && Lazer_Shoot_Delay == true)
                        {
                            if (Player_Laser_Ani_Ready == false)
                            {
                                Player_Laser_Ani_Ready = true;

                                // 레이저 차징 애니메이션 
                                Player_Lazer_Gun_Charge_Animator.SetTrigger("is_Laser_Charge");

                                Invoke("Lazer_Ready", 0.5f);
                            }
                        }
                    }




                    //===========================================================================================    중화기
                    // 로켓 런처 
                    else if (Rocket_Gun_Bool == true)
                    {

                        if (IS_Player_Rocket_Launcher_Shoot == false)
                        {
                            // 마우스 범위에 따라 무기의 조준선이 바뀐다 
                            if ((rotz + offset) > -140 && (rotz + offset) < 45)
                            {
                                Rocket_Launcher_Transform.transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
                            }


                            if ((rotz + offset) > -145 && (rotz + offset) < 50)
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
                                    Rocket_Shoot_Aim_Time_Stop_Delay = true;

                                    Time_Stop();

                                    Player_Rocket_Launcher_Animator.SetTrigger("Is_Player_Rocket_Launcher_Charge");

                                    Player_Rocket_Launcher_Animator.SetBool("When_Finshed_Rocket_Launcher", true);

                                    Player_Shoot_Sound_Manager.Heavy_Ready();

                                    if (Rocket_Shoot_Aim_Time_Stop_Delay == true)
                                    {
                                        StartCoroutine(Rocket_Launcher_WaitFor_Time_Stop());
                                    }
                                }

                                else if (Input.GetMouseButtonUp(0) && Rocket_Shoot_Aim_Time_Stop_Delay == false)

                                {
                                    Vector2 ve =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                                    Destroy(Instantiate(Cross_Hair, ve, transform.rotation),1.5f);
                                    Time_GO();

                                    Player_Shoot_Sound_Manager.Rocket();

                                    IS_Player_Rocket_Launcher_Shoot = true;

                                    Rocket_Launcher_Mouse_Pos.SetActive(false);

                                    Rocket_Cross_Hair_Off();

                                    Player_Rocket_Launcher_Animator.SetTrigger("Is_Player_Rocket_Launcher");
                                    Player_Rocket_Launcher_Animator.SetBool("When_Finshed_Rocket_Launcher", false);
                                    Player_Rocket_Launcher_Ani_Animator.SetTrigger("Is_Player_Rocket_Launcher_Ani");

                                    Instantiate(Rocket_Launcher_projectile, Rocket_Launcher_firePos.transform.position, Rocket_Launcher_Transform.transform.rotation);

                                    Invoke("Fin_Heavy_weapons", 0.6f);
                                }

                                else if (Input.GetMouseButtonUp(0) && Rocket_Shoot_Aim_Time_Stop_Delay == true)
                                {
                                    Player_Rocket_Launcher_Animator.SetTrigger("Is_Player_Rocket_Launcher_Restart");

                                    Rocket_Shoot_Aim_Time_Stop_Delay = true;
                                    IS_Player_Rocket_Launcher_Shoot = false;

                                    Player_Rocket_Launcher_Sprite.sprite = Rocket_Launcher_Sprite.sprite;

                                    Time_GO();
                                }
                            }
                        }
                    }

                    // 레일건 
                    else if (Rail_Gun_Bool == true)
                    {

                        if (IS_Player_Rail_Gun_Shoot == false)
                        {
                            if (Input.GetMouseButtonDown(1))
                            {
                                Time_GO();
                            }

                            // 마우스 범위에 따라 무기의 조준선이 바뀐다 
                            if ((rotz + offset) > -140 && (rotz + offset) < 45)
                            {
                                Rail_Gun_Transform.transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
                            }

                            if ((rotz + offset) > -145 && (rotz + offset) < 50)
                            {
                                //  레일건  발싸 
                                if (Input.GetMouseButtonDown(0))
                                {
                                    Time_Stop();

                                    if (Is_Player_Rail_Gun_Ready == false)
                                    {
                                        StartCoroutine(Rail_Gun_WaitFor_Time_Stop());

                                        Rail_Gun_Aim_Time_Stop_Delay = true;
                                        Is_Player_Rail_Gun_Ready = true;
                                        Player_Rail_Gun_Charge_Animator.SetTrigger("is_Rail_Gun_Charge");

                                        Player_Shoot_Sound_Manager.Heavy_Ready();
                                    }
                                }

                                // 레일건  끝 
                                else if (Input.GetMouseButtonUp(0) && Rail_Gun_Aim_Time_Stop_Delay == false)
                                {
                                    Time_GO();

                                    Player_Shoot_Sound_Manager.Rail();

                                    Player_Rail_Gun_Pointer_GameObject.SetActive(false);

                                    IS_Player_Rail_Gun_Shoot = true;

                                    Player_Rail_Gun_Animator.SetBool("Is_Player_Rail_Gun_Shoot", true);
                                    Player_Rail_Gun_Shoot_Animator.SetBool("Is_Player_Rail_Gun_Shoot_Ani", true);

                                    Instantiate(Rail_Gun_projectile, Rail_Gun_firePos.transform.position, Rail_Gun_Transform.transform.rotation);

                                    Invoke("Rail_Gun_Shoot_Off", 0.5f);
                                    Invoke("Fin_Heavy_weapons", 0.8f);
                                }

                                // 먼저 손땐 경우 
                                else if (Input.GetMouseButtonUp(0) && Rail_Gun_Aim_Time_Stop_Delay == true)
                                {
                                    Time_GO();

                                    Player_Rail_Gun_Sprite.sprite = Rail_Gun_Sprite.sprite;

                                    Is_Player_Rail_Gun_Ready = false;

                                    Player_Rail_Gun_Charge_Animator.SetTrigger("Is_Rail_Gun_Re_Start");
                                }
                            }
                        }

                    }
                }
            }

        }



        //================================================================================= 아이템 흡수 처리
        // 공통 
        void Weapon_All()
        {
            Player_Sound_Manager.Player_Weapon_Eat();

            Weapon_Image_Shot_Gun();
            Player_Gun_And_Fire_Reset();
            Time_GO();
        }

        void Shot_Gun_On()
        {
            Shot_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(true);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(false);

            Weapon_Image_Shot_Gun();
            Rocket_Cross_Hair_Off();
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
        void Auto_Gun_On()
        {
            Auto_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(true);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(false);

            Weapon_Image_Auto_Gun();
            Rocket_Cross_Hair_Off();
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
        void Service_Gun_On()
        {
            Service_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(true);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(false);

            Weapon_Image_Service_Gun();
            Rocket_Cross_Hair_Off();
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
        void Laser_Gun_On()
        {
            Laser_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(true);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(false);

            Weapon_Image_Laser_Gun();
            Rocket_Cross_Hair_Off();
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
        void Rocket_On()
        {
            Rocket_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(true);
            Player_Rocket_Launcher_GameObject.SetActive(true);
            Player_Rail_Gun_GameObject.SetActive(false);

            Rocket_Cross_Hair_ON();
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
        void Rail_On()
        {
            Rail_Gun_Bool_DD();

            Player_Shot_Gun_GameObject.SetActive(false);
            Player_Auto_Gun_GameObject.SetActive(false);
            Player_Service_Gun_GameObject.SetActive(false);
            Lazer_GameObject.SetActive(false);
            Rocket_Launcher_Mouse_Pos.SetActive(false);
            Player_Rocket_Launcher_GameObject.SetActive(false);
            Player_Rail_Gun_GameObject.SetActive(true);
            Player_Rail_Gun_Pointer_GameObject.SetActive(true);

            Rocket_Cross_Hair_Off();
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }





        void U_Got_Mail()
        {
            U_Got_Mail_Game_Object.SetActive(false);
        }



        string Weapon_01 = "Service";
        string Weapon_02 = "Empty";
        string Heavy_Weapon = "Empty";

        

        public bool E_Button_Bool = false;
        public GameObject E_Button_Game_Object;
        public GameObject U_Got_Mail_Game_Object;

        








        void OnTriggerEnter2D(Collider2D other)                                                
        {
            if (other.tag == "Weapon_Type_Shot_Gun" ||
         other.tag == "Weapon_Type_Auto_Gun_Shoot" ||
         other.tag == "Weapon_Type_Service_Gun_Shoot" ||
         other.tag == "Weapon_Type_Laser_Shoot" ||
         other.tag == "Weapon_Type_Rocket_Launcher_Shoot" ||
         other.tag == "Weapon_Type_Rail_Gun_Shoot"
         )
            {
                E_Button_Game_Object.SetActive(true);
            }

        }

        private void OnTriggerStay2D(Collider2D other)
        {                  
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (other.tag == "Weapon_Type_Shot_Gun")
                    {
                        Shot_Gun_Bool_DD();
                        Destroy(other.gameObject);
                        Weapon_All();
      
                        if (Weapon_01 == "Shot")
                        {
                          //
                        }

                        //======================================= 처음으로 먹은것이 ? 
                        else if (IS_Player_Weapon_One == true)
                    {
                        Debug.Log("A");
                        Weapon_01 = "Shot";
                             Weapon_02 = "Service";
                             
                             IS_Player_Weapon_One = false;

                              Shot_Gun_On();                     
                    }
                   
                        else if (Weapon_01 == "Auto")
                        {                       
                             Weapon_01 = "Shot";
                             Weapon_02 = "Auto";

                             Shot_Gun_On();                               
                         }
                        else if (Weapon_01 == "Service")
                        {
                           Weapon_01 = "Shot";
                           Weapon_02 = "Service";

                           Shot_Gun_On();
                          
                         }
                        else if (Weapon_01 == "Laser")
                         {
                           Weapon_01 = "Shot";
                           Weapon_02 = "Laser";

                           Shot_Gun_On();
                         }              
                    }

                    else if (other.tag == "Weapon_Type_Auto_Gun_Shoot")
                    {
                        Auto_Gun_Bool_DD();
                        Destroy(other.gameObject);
                        Weapon_All();

                        if (Weapon_01 == "Auto")
                        {
                            //===============================================================
                        }

                        else if (IS_Player_Weapon_One == true)
                        {
                           IS_Player_Weapon_One = false;

                            Weapon_01 = "Auto";
                            Weapon_02 = "Service";

                            Auto_Gun_On();
                        }

                        else if (Weapon_01 == "Shot")
                        {
                           Weapon_01 = "Auto";
                           Weapon_02 = "Shot";

                           Auto_Gun_On();
                        }

                        else if (Weapon_01 == "Service")
                        {
                            Weapon_01 = "Auto";
                            Weapon_02 = "Service";

                            Auto_Gun_On();
                        }

                        else if (Weapon_01 == "Laser")
                        {
                           Weapon_01 = "Auto";
                           Weapon_02 = "Laser";

                           Auto_Gun_On();
                         }                                                                                                                  
                    }

                    else if (other.tag == "Weapon_Type_Service_Gun_Shoot")
                    {
                        Service_Gun_Bool_DD();
                        Destroy(other.gameObject);
                        Weapon_All();

                        if (Weapon_01 == "Service")
                        {
                            //===============================================================
                        }

                        else if (IS_Player_Weapon_One == true)
                        {
                            Weapon_01 = "Service";
                            IS_Player_Weapon_One = false;

                            Service_Gun_On();
                        }

                        else if (Weapon_01 == "Shot")
                        {
                           Weapon_01 = "Service";
                           Weapon_02 = "Shot";

                           Service_Gun_On();
                        }

                        else if (Weapon_01 == "Auto")
                        {
                           Weapon_01 = "Service";
                           Weapon_02 = "Auto";

                           Service_Gun_On();
                         }

                        else if (Weapon_01 == "Laser")
                        {
                           Weapon_01 = "Service";
                           Weapon_02 = "Laser";

                           Service_Gun_On();
                         }                   
                    }

                    else if (other.tag == "Weapon_Type_Laser_Shoot")
                    {
                        Laser_Gun_Bool_DD();
                        Destroy(other.gameObject);
                        Weapon_All();

                        if (Weapon_01 == "Laser")
                        {
                            //===============================================================
                        }

                        else if (IS_Player_Weapon_One == true)
                        {
                            IS_Player_Weapon_One = false;

                            Weapon_01 = "Laser";
                            Weapon_02 = "Service";

                            Laser_Gun_On();
                        }

                        else if (Weapon_01 == "Shot")
                        {
                           Weapon_01 = "Laser";
                           Weapon_02 = "Shot";

                           Laser_Gun_On();
                         }
                        else if (Weapon_01 == "Auto")
                        {
                          Weapon_01 = "Laser";
                          Weapon_02 = "Auto";

                           Laser_Gun_On();
                         }
                        else if (Weapon_01 == "Service")
                        {
                           Weapon_01 = "Laser";
                           Weapon_02 = "Service";

                           Laser_Gun_On();
                         }
                                        
                        Player_Laser_Ani_Ready = false;
                    }



                    //===============================================================================================
                    else if (other.tag == "Weapon_Type_Rocket_Launcher_Shoot")
                    {
                        Rocket_Gun_Bool_DD();
                        Destroy(other.gameObject);
                        Player_Gun_And_Fire_Reset();
                        Time_GO();
                       // Rocket_Cross_Hair_ON();
                        IS_Player_Rocket_Launcher_Shoot = false;
                        Rocket_Launcher_Mouse_Pos.SetActive(true);

                    if (Heavy_Weapon == "Rocket")
                        {
                            //==========================================================
                        }
                        
                        else if (Heavy_Weapon == "Rail" || Heavy_Weapon == "Empty")
                        {
                        Debug.Log("sadsadsa");
                           Heavy_Weapon = "Rocket";

                           Rocket_On();                     
                        }                   
                    }

                    else if (other.tag == "Weapon_Type_Rail_Gun_Shoot")
                    {
                        Rail_Gun_Bool_DD();
                        Rail_Gun_Aim_Time_Stop_Delay = true;
                        Destroy(other.gameObject);
                        Player_Gun_And_Fire_Reset();
                        Time_GO();
                        IS_Player_Rail_Gun_Shoot = false;
                        Is_Player_Rail_Gun_Ready = false;


                       if (Heavy_Weapon == "Rail")
                        {
                           //
                        }
                 
                       else if (Heavy_Weapon == "Rocket" || Heavy_Weapon == "Empty")
                        {
                            Heavy_Weapon = "Rail";

                            Rail_On();
                        }
                    }

                    Check_Weapon_Ui_01();
                    Check_Weapon_Ui_02();
                    Check_Weapon_UI();

                    U_Got_Mail_Game_Object.SetActive(true);
                    Invoke("U_Got_Mail", 1.3F);

                    E_Button_Game_Object.SetActive(false);
                    E_Button_Bool = true; 
                }              
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Weapon_Type_Shot_Gun" ||
              other.tag == "Weapon_Type_Auto_Gun_Shoot" ||
              other.tag == "Weapon_Type_Service_Gun_Shoot" ||
              other.tag == "Weapon_Type_Laser_Shoot" ||
              other.tag == "Weapon_Type_Rocket_Launcher_Shoot" ||
              other.tag == "Weapon_Type_Rail_Gun_Shoot"
              )
            {
                E_Button_Game_Object.SetActive(false);

            }
        }
        //================================================================================= 아이템 흡수 처리












        bool Laser_First_Shoot = true;

        int Laser_Wait_Time = 0;
        int Roket_Launcher_Wait_Time = 0;

        float Laser_Start_Delay = 0;
        float Rocket_Launcher_Cross_Hair_Alpa = 0;
        float Laser_Real_Reloading_Wait_Time = 0;

        


        //==================================================================== 딜레이 시간 함수 
          IEnumerator WaitFor_Service_Gun_Shoot()
        {
            yield return new WaitForSeconds(0.2f);
            Service_Gun_Shoot_Delay = true;
            yield break;
        }
          IEnumerator WaitFor_Shot_Gun_Shoot()
        {
            yield return new WaitForSeconds(0.5f);
            Shot_Gun_Shoot_Delay = true;
            yield break;
        }
          IEnumerator WaitFor_Lazer_Shoot()
        {          
            if (Laser_Wait_Time >= 1)
            {
                Laser_Wait_Time = 0;

                Lazer_Shoot_Delay = true;
                Player_Laser_Ani_Ready = false;

                Laser_Off_01_Start = false;
                Laser_Off_02_Start = false;
                Laser_Off_03_Start = false;

                Laser_First_Shoot = true;

                yield break;
            }

            Laser_Wait_Time += 1;
            yield return new WaitForSeconds(0.5f);

            StartCoroutine(WaitFor_Lazer_Shoot());
        }
          IEnumerator WaitFor_Auto_Gun_Shoot()
        {
            yield return new WaitForSeconds(0.2f);
            Auto_Gun_Shoot_Delay = true;
            yield break;
        }
          IEnumerator Rocket_Launcher_WaitFor_Time_Stop()
         {
            yield return new WaitForSeconds(0.26f);
            Rocket_Shoot_Aim_Time_Stop_Delay = false;
            yield break;
        }
          IEnumerator Rail_Gun_WaitFor_Time_Stop()
        {
            yield return new WaitForSeconds(0.15f);
            Rail_Gun_Aim_Time_Stop_Delay = false;
            yield break;           
        }
          IEnumerator WaitFor_Real_Reloading_Lazer_Shoot()
        {
            if (Laser_Real_Reloading_Wait_Time >= 1f)
            {
                Debug.Log("ad");
                Laser_Real_Reloading_Wait_Time = 0;

                Laser_Stop = false;

                yield break;
            }

            Laser_Real_Reloading_Wait_Time += 0.5f;
            yield return new WaitForSeconds(0.5f);

            StartCoroutine(WaitFor_Real_Reloading_Lazer_Shoot());
        }

          // 크로스 헤어 알팍값 조절 
          IEnumerator Rocket_Launcher_Cross_Hair_Alpa_Con()
        {
            Rocket_Launcher_Cross_Hair_Sprite_Renderer.color = new Color(1, 1, 1, Rocket_Launcher_Cross_Hair_Alpa);

            if (Rocket_Launcher_Cross_Hair_Alpa >= 1)
            {
                Rocket_Launcher_Cross_Hair_Alpa = 0;
                yield break;
            }

            Rocket_Launcher_Cross_Hair_Alpa += 0.1f;
            yield return new WaitForSeconds(0.1f);

            StartCoroutine(Rocket_Launcher_Cross_Hair_Alpa_Con());
        }

           // 레이저 발사 
           IEnumerator Laser_START()
        {
            // 제한 시간이 끝날 경우 
            if (Laser_Start_Delay >= 4f)
            {
                Laser_Start_Delay = 0;

                Laser_On_Off.SetActive(false);
                SpriteBasedLaser_Script.lerpLaserRotation = false;

                // 레이저 종료 애니메이션 발동 
                Lazer_End_Ani_On();

                // 레이저 종료 애니메이션 끄기 
                Invoke("Lazer_End_Ani_Off", 0.3f);

                // 레이저 쿨타임 
                Laser_Stop = false;
                StartCoroutine(WaitFor_Lazer_Shoot());

                //피격 당하기 
                playy_Script.Is_Player_Laser_Shoot = false;

                yield break;
            }

            // 발사중 
            else if (Laser_Off_02_Start == false && Laser_Off_03_Start == false)
            {
                if (Laser_First_Shoot == true)
                {
                    // 꺼주기 
                    Laser_First_Shoot = false;

                    //무적 상태 
                    playy_Script.Is_Player_Laser_Shoot = true;

                    Laser_Off_01_Start = true;

                    // 애니메이션 발동 
                    Lazer_Start_Ani_On();
                    // 실제 발사 
                    Invoke("Lazer_Shoot", 0.2f);

                    // 애니메이션 꺼주기 
                    Invoke("Lazer_Start_Ani_Off", 0.2f);

                    Laser_Stop = true;
                    // 딜레이 꺼주기
                    Lazer_Shoot_Delay = false;
                }
             }

            // 도중에 손을 땐 경우                 // 무기 전환 했을 경우 
            else if ((Laser_Off_02_Start == true || Laser_Off_03_Start == true))
            {
                Laser_Off_01_Start = true;

                Laser_On_Off.SetActive(false);
                SpriteBasedLaser_Script.lerpLaserRotation = false;

                // 레이저 종료 애니메이션 발동 
                Lazer_End_Ani_On();

                // 레이저 종료 애니메이션 끄기 
                Invoke("Lazer_End_Ani_Off", 0.3f);

                // 레이저 쿨타임 
                Laser_Stop = false;
                StartCoroutine(WaitFor_Lazer_Shoot());

                //피격 당하기 
                playy_Script.Is_Player_Laser_Shoot = false;

                Laser_Start_Delay = 0;

                yield break;
            }

        
            Laser_Start_Delay += 0.25f;
            yield return new WaitForSeconds(0.25f);

            StartCoroutine(Laser_START());
        }









        //====================================================================================================== 중화기를 사용할때 
        private void Time_Stop()
        {           
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;         
        }
        private void Time_GO()
        {         
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;        
        }
     
        //======================================================================= 중화기 사용후 기본무기로 바꿔주기 
         void Fin_Heavy_weapons()
        {
            Player_Gun_And_Fire_Reset();

            Heavy_Weapon = "Empty";
          
            if (Weapon_01 == "Shot")
            {
                Shot_Gun();
            }
            else if (Weapon_01 == "Auto")
            {
                Auto_Gun();
            }
            else if (Weapon_01 == "Service")
            {
                Service_Gun();
            }
            else if (Weapon_01 == "Laser")
            {
                Laser_Gun();
            }

            Check_Weapon_Ui_01();
            Check_Weapon_Ui_02();
            Check_Weapon_UI();
        }

        //========================================================================= 무기 바꾸면 이미지 초기화 
        void Player_Gun_And_Fire_Reset()
        {        
           Player_Service_Gun_Sprite.sprite =    Service_Gun_Sprite.sprite;
           Player_Service_Gun_Fire_Sprite.sprite =   Service_Gun_Fire_Sprite.sprite;
            
           Player_Auto_Gun_Sprite.sprite =   Auto_Gun_Sprite.sprite;
           Player_Auto_Gun_Fire_Sprite_01.sprite =  Auto_Gun_Fire_Sprite_01.sprite;
           Player_Auto_Gun_Fire_Sprite_02.sprite = Auto_Gun_Fire_Sprite_02.sprite;

           Player_Shot_Gun_Sprite.sprite      = Shot_Gun_Sprite.sprite;
            Player_Shot_Gun_Fire_Sprite.sprite = Shot_Gun_Fire_Sprite.sprite;

            Player_Laser_Gun_Sprite.sprite = Laser_Gun_Sprite.sprite;
            Player_Laser_Gun_Fire_Sprite.sprite = Laser_Gun_Fire_Sprite.sprite;
              

            Player_Rail_Gun_Sprite.sprite =  Rail_Gun_Sprite.sprite;
            Player_Rail_Gun_Fire_Sprite.sprite = Rail_Gun_Fire_Sprite.sprite;

            Player_Rocket_Launcher_Sprite.sprite = Rocket_Launcher_Sprite.sprite;
            Player_Rocket_Launcher_Fire_Sprite.sprite = Rocket_Launcher_Fire_Sprite.sprite;       
        }
















       



        //====================================================================================================================================== 무기별 함수 
        //====================================================================================================== 레일건 함수 
        void Rail_Gun_Shoot_Off()
        {
            Player_Rail_Gun_Animator.SetBool("Is_Player_Rail_Gun_Shoot", false);
            Player_Rail_Gun_Shoot_Animator.SetBool("Is_Player_Rail_Gun_Shoot_Ani", false);
        }
        void Rail_Gun_Off()
        {
          //  playy_Script.IS_Player_Rail_Gun_Shoot = false;
        }


        //====================================================================================================== 로켓 런처 함수 
        void Rocket_Launcher_Shoot()
        {

        }
        void Rocket_Launcher_Off()
        {
           // playy_Script.IS_Player_Rocket_Launcher_Shoot = false;
        }
        void Rocket_Cross_Hair_ON()
        {
            StartCoroutine(Rocket_Launcher_Cross_Hair_Alpa_Con());          
        }
        void Rocket_Cross_Hair_Off()
        {
            Rocket_Launcher_Cross_Hair_Sprite_Renderer.color = new Color(1, 1, 1, 0);
        }

        //====================================================================================================== 레이저 함수 
        void Lazer_Ready()
        {
            StartCoroutine(Laser_START());
        }
        void Lazer_Shoot()
        {
            Laser_On_Off.SetActive(true);
            SpriteBasedLaser_Script.lerpLaserRotation = true;
        }

        void Lazer_Off()
        {
            /*
            if (SpriteBasedLaser_Script.lerpLaserRotation == true && Laser_Off_02_Start == false && Laser_Off_03_Start == false)
            {
                Debug.Log("adasasdasdsadsad");

                Laser_Off_01_Start = true;

                Laser_On_Off.SetActive(false);
                SpriteBasedLaser_Script.lerpLaserRotation = false;

                // 레이저 종료 애니메이션 발동 
                //Lazer_End_Ani_On();

                // 레이저 종료 애니메이션 끄기 
                //Invoke("Lazer_End_Ani_Off", 0.3f);

                // 레이저 쿨타임 
                Laser_Stop = false;
                StartCoroutine(WaitFor_Lazer_Shoot());

                //피격 당하기 
                playy_Script.Is_Player_Laser_Shoot = false;
               
            }
             */
        }
        void Lazer_Off_02()
        {         
            Laser_Off_02_Start = true;
            /*
            Laser_On_Off.SetActive(false);
            SpriteBasedLaser_Script.lerpLaserRotation = false;

            // 레이저 쿨타임 
            Laser_Stop = false;
            StartCoroutine(WaitFor_Lazer_Shoot());

            //피격 당하기 
            playy_Script.Is_Player_Laser_Shoot = false;
            */
        }
        void Lazer_Off_03()
        {
            Laser_Off_03_Start = true;
            /*
            Laser_On_Off.SetActive(false);
            SpriteBasedLaser_Script.lerpLaserRotation = false;

            // 레이저 종료 애니메이션 발동 
            Lazer_End_Ani_On();

                // 레이저 종료 애니메이션 끄기 
                Invoke("Lazer_End_Ani_Off", 0.3f);
            
      

            // 레이저 쿨타임 
            Laser_Stop = false;
            StartCoroutine(WaitFor_Lazer_Shoot());

            //피격 당하기 
            playy_Script.Is_Player_Laser_Shoot = false;
            */
        }

        void Lazer_Start_Ani_On()
        {
            Player_Laser_Start_Ani_GameObject.SetActive(true);
        }
        void Lazer_Start_Ani_Off()
        {
            Player_Laser_Start_Ani_GameObject.SetActive(false);
        }

        void Lazer_End_Ani_On()
        {
            Player_Laser_End_Ani_GameObject.SetActive(true);
        }
        void Lazer_End_Ani_Off()
        {
            Player_Laser_End_Ani_GameObject.SetActive(false);
        }

        //====================================================================================================== 오토건
        void Auto_Gun_Shoot_02()
        {
            Instantiate(Auto_Gun_projectile, Auto_Gun_Fire_Pos_02.transform.position, transform.rotation);
        } 
    }
}
