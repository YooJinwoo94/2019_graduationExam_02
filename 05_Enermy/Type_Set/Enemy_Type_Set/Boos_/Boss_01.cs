using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss_01 : MonoBehaviour {

    public Boss_01_Heart Boss_01_Heart_Script;
    public GameObject Warn;
    public Animator Boss_Heart_Ani;
    public GameObject Boss_Damaged;


    Rigidbody2D rid;
    Animator Boss_Ani;
    playy Player_Script;
    Camera_Move_02 shake_02;
    Score_Manager Score_Manager_Script;
    SpriteRenderer Enemy_Sprite;
    Sprite None_Sprites;
    BoxCollider2D Enemy_BoxCollider2D;




    //========================================================================== phase 01_01
    public UbhShotCtrl[] Phase_01_01_Shot_Gun_Down_Up;
    public UbhShotCtrl[] Phase_01_01_Fast_Bullet;
    Transform Player_Pos;


    //========================================================================== phase 01_02
    //============================================= bullet

    public UbhShotCtrl[] Bullet_Road_Phase_01_02;
    public UbhShotCtrl[] Phase_01_02;
    public GameObject[] Bullet_BG;



    //========================================================================== phase 01_03
    public UbhShotCtrl[] Phase_01_03;




    //=========================================================================================================

    //========================================================================== phase 02_01
    public GameObject[] Boss_Boost_Ani_Set;
    public GameObject Boss_Bosst_Game_Object;



    //========================================================================== phase 02_02
    public UbhShotCtrl[] Phase_02_02_Bullet;
    public GameObject[] Bullet_Spread_Phase_02_02;


    //========================================================================== phase 02_02
    public UbhShotCtrl[] Phase_02_03_Bullet;



    public Animator[] None_Loop_Shoot_Ani;
    public Animator[] Loop_Shoot_Ani;

     Boss_Sound_Manager Boss_Sound_Manager;







    private void Start()
    {
        Boss_Sound_Manager = GameObject.Find("Boss_Sound_Manager").GetComponent<Boss_Sound_Manager>();
        Boss_Ani = GetComponent<Animator>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
        Score_Manager_Script = GameObject.Find("Score_Manager").GetComponent<Score_Manager>();
        shake_02 = GameObject.Find("CameraShake_Manager_02").GetComponent<Camera_Move_02>();
        None_Sprites = Resources.Load<Sprite>("None");
        Enemy_BoxCollider2D = GetComponent<BoxCollider2D>();
        rid = GetComponent<Rigidbody2D>();
        Player_Pos = GameObject.Find("Player").transform;

        Boss_Hp_Down_Once = false;

        Boss_01_On();
    }











    void Boss_01_On()
    {
        StartCoroutine(Boss_01_On_Move());
        StartCoroutine(Boss_01_On_Time_Count());
    }

    int Boss_01_On_Count = 0;

    IEnumerator Boss_01_On_Time_Count()
    {
        if (Boss_01_On_Count > 5)
        {
            Boss_01_On_Count = 0;
            yield break;
        }
        Boss_01_On_Count++;
        yield return new WaitForSeconds(1f);

        StartCoroutine(Boss_01_On_Time_Count());
    }
    IEnumerator Boss_01_On_Move()
    {
        if (Boss_01_On_Count > 5)
        {
            Boss_01_On_Count = 0;

            Start_Phase_01_01();
            yield break;
        }

        Vector3 to_position = new Vector3(5.64f, 0f, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, to_position, 0.2f);


        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Boss_01_On_Move());
    }


















    // Phase 01
    //==================================================================================================

    // Phase_01 _01
    void Start_Phase_01_01()
    {
        if (Phase_02_Start == false)
        {
            StartCoroutine(Phase_01_01_Boss_Move());
            StartCoroutine(Phase_01_01_());

            for (int i = 0; i < 12; i++)
            {
                if (i % 2 != 0)
                {
                    Invoke("Start_Phase_01_01_Fast_Gun", i);
                    Invoke("Start_Shot_Gun_Down", i);
                }
                else
                {
                    Invoke("Start_Phase_01_01_Fast_Gun", i);
                    Invoke("Start_Shot_Gun_Up", i);
                }

                if (i >= 19)
                {
                    Stop_Phase_01_01_Shoot();
                }
            }
        }

        else if (Phase_02_Start == true)
        {
            Start_Phase_02_01();
        }
    }



    void Start_Phase_01_01_Fast_Gun()
    {
        Phase_01_01_Fast_Bullet[0].StartShotRoutine();
    }
    void Start_Shot_Gun_Up()
    {
        Boss_Sound_Manager.Boss_Shoot_Sound_No_Loop();

        None_Loop_Shoot_Ani[0].SetTrigger("Shoot");
        None_Loop_Shoot_Ani[1].SetTrigger("Shoot");

        Phase_01_01_Shot_Gun_Down_Up[0].StartShotRoutine();
    }
    void Start_Shot_Gun_Down()
    {
        Boss_Sound_Manager.Boss_Shoot_Sound_No_Loop();

        None_Loop_Shoot_Ani[0].SetTrigger("Shoot");
        None_Loop_Shoot_Ani[1].SetTrigger("Shoot");

        Phase_01_01_Shot_Gun_Down_Up[1].StartShotRoutine();
    }

    void Stop_Phase_01_01_Shoot()
    {
        Phase_01_01_Fast_Bullet[0].StopShotRoutine();
        Phase_01_01_Shot_Gun_Down_Up[0].StopShotRoutine();
        Phase_01_01_Shot_Gun_Down_Up[1].StopShotRoutine();
    }



    int Phase_01_01_Count = 0;
    IEnumerator Phase_01_01_()
    {
        if (Phase_01_01_Count > 12)
        {
            Phase_01_01_Count = 0;

            Stop_Phase_01_01_Shoot();
            Start_Phase_01_02();
            yield break;
        }

        Phase_01_01_Count++;

        yield return new WaitForSeconds(1f);

        StartCoroutine(Phase_01_01_());
    }
    IEnumerator Phase_01_01_Boss_Move()
    {
        if (Phase_01_01_Count >= 12)
        {
            yield break;
        }

        Vector3 to_position = new Vector3(
        transform.position.x, Player_Pos.position.y  -0.36f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, to_position, 0.02f);





        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Phase_01_01_Boss_Move());
    }


















    // Phase_01 _ 02
    void Start_Phase_01_02()
    {
        if (Phase_02_Start == false)
        {
            StartCoroutine(Phase_01_02_Boss_Move_Count());
            StartCoroutine(Phase_01_02_Boss_Move());
        }

        else if (Phase_02_Start == true)
        {
            Start_Phase_02_01();
        }
    }


    void Laser_Start_()
    {
        Boss_Sound_Manager.Boss_Shoot_Sound_Loop();

        Loop_Shoot_Ani[0].SetBool("Is_Shoot" , true);
        Loop_Shoot_Ani[1].SetBool("Is_Shoot", true);


        Bullet_Road_Phase_01_02[0].StartShotRoutine();
        Bullet_Road_Phase_01_02[1].StartShotRoutine();

        Phase_01_02[0].StartShotRoutine();
        Phase_01_02[1].StartShotRoutine();

        StartCoroutine(Phase_01_02_Count());
    }


   
    void Phase_01_02_Bullet_Off()
    {
        Boss_Sound_Manager.Boss_Loop_Off();

        Loop_Shoot_Ani[0].SetBool("Is_Shoot", false);
        Loop_Shoot_Ani[1].SetBool("Is_Shoot", false);

        Bullet_Road_Phase_01_02[0].StopShotRoutine();
        Bullet_Road_Phase_01_02[1].StopShotRoutine();

        Phase_01_02[0].StopShotRoutine();
        Phase_01_02[1].StopShotRoutine();
    }

    int Phase_01_02_Laser_Count = 0;
    IEnumerator Phase_01_02_Count()
    {
        if (Phase_01_02_Laser_Count > 10)
        {
            Phase_01_02_Laser_Count = 0;

            Start_Phase_01_03();

            yield break;
        }

        else if (Phase_01_02_Laser_Count == 7)
        {
            Phase_01_02_Bullet_Off();
        }


        Phase_01_02_Laser_Count++;

        yield return new WaitForSeconds(1f);

        StartCoroutine(Phase_01_02_Count());
    }



    //========================================== 공격 준비 및 공격 타이밍
    int Phase_01_02_Attack_Ready_Count = 0;
    IEnumerator Phase_01_02_Boss_Move()
    {

       if (transform.position.y == -1.4f)

        {
            Invoke("Laser_Start_", 1f);
            yield break;
        }
        Vector3 to_position = new Vector3(6.86f, -1.4f, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, to_position, 0.08f);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Phase_01_02_Boss_Move());
    }
    IEnumerator Phase_01_02_Boss_Move_Count()
    {
        if (Phase_01_02_Attack_Ready_Count >= 8)
        {
            Phase_01_02_Attack_Ready_Count = 0;
            yield break;
        }



        Phase_01_02_Attack_Ready_Count++;

        yield return new WaitForSeconds(1f);
        StartCoroutine(Phase_01_02_Boss_Move_Count());
    }














    void Phase_01_03_Shoot_Ani_Off()
    {
        Boss_Sound_Manager.Boss_Loop_Off();

        Loop_Shoot_Ani[0].SetBool("Is_Shoot", false);
        Loop_Shoot_Ani[1].SetBool("Is_Shoot", false);
    }


    // Phase_01 _03


   public void Phase_01_03_Shoot_Ani()
    {
        Boss_Sound_Manager.Boss_Shoot_Sound_Loop();

        Loop_Shoot_Ani[0].SetBool("Is_Shoot", true);
        Loop_Shoot_Ani[1].SetBool("Is_Shoot", true);
    }



    void Start_Phase_01_03()
    {
        if (Phase_02_Start == false)
        {
            StartCoroutine(Phase_01_03_Time_Count());
            StartCoroutine(Phase_01_03_Boss_Move());

            Invoke("Phase_01_03_Boss_Bullet", 1.5f);
        }

        else if (Phase_02_Start == true)
        {
            Start_Phase_02_01();
        }
    }

    void Phase_01_03_Boss_Bullet()
    {
        Invoke("Phase_01_03_Shoot_Ani", 0f);

        Invoke("Phase_01_03_Shoot_Ani_Off", 5.7f);

        Phase_01_03[0].StartShotRoutine();
    }
    int Phase_01_03_Count = 0;
    float Phase_01_03_Boss_Move_Speed = 0.02f;

    IEnumerator Phase_01_03_Time_Count()
    {
        if (Phase_01_03_Count == 6)
        {
            Phase_01_03_Boss_Move_Speed = 0.02f;
        }

        else if (Phase_01_03_Count == 3)
        {
            Phase_01_03_Boss_Move_Speed = 0.02f;
        }

        else if (Phase_01_03_Count == 11)
        {
            Phase_01_03_Count = 0;

            yield break;
        }

        Phase_01_03_Count++;

        yield return new WaitForSeconds(1f);
        StartCoroutine(Phase_01_03_Time_Count());
    }
    IEnumerator Phase_01_03_Boss_Move()
    {
        if (Phase_01_03_Count >= 10)
        {
            Phase_01_03_Boss_Move_Speed = 0.02f;
            Invoke("Start_Phase_01_01", 0f);
            yield break;
        }

 

        Player_Pos = GameObject.Find("Player").transform;

        Vector3 to_position = new Vector3(
        transform.position.x, Player_Pos.position.y - 0.36f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, to_position, Phase_01_03_Boss_Move_Speed);


        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Phase_01_03_Boss_Move());
    }






























    // Phase_02
    //============================================================================================================================


    // Phase_02_01
    void Start_Phase_02_01()
    {
        if (Phase_02_Start == true)
        {       
            Phase_02_01_Boss_Attack_Ready();
        }
    }

    void Instace_Bullet_BG()
    {
        Destroy(Instantiate(Bullet_BG[0], transform.position, transform.rotation), 11f);
    }

    int Phase_02_01_Count = 0;
    void Phase_02_01_Boss_Attack()
    {
        StartCoroutine(Phase_02_01_Boss_Move());
        StartCoroutine(Phase_02_01_Boss_Move_Count());
    }
    IEnumerator Phase_02_01_Boss_Move()
    {
        if (Phase_02_01_Count >= 3)
        {
            Boss_Boost_Ani_Set[0].SetActive(false);
            Boss_Boost_Ani_Set[1].SetActive(false);

            transform.position = new Vector3(13.07f, 0, 0);
            rid.velocity = Vector3.zero;

            Boss_Bosst_Game_Object.SetActive(false);

            Boss_Ani.SetBool("Is_Boss_Charging", false);
            Invoke("Boss_Come_Back_", 1.5f);

            yield break;
        }

        transform.Translate(transform.right  * -20f * Time.deltaTime);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Phase_02_01_Boss_Move());
    }
    IEnumerator Phase_02_01_Boss_Move_Count()
    {
        if (Phase_02_01_Count >= 5)
        {
            Phase_02_01_Count = 0;
            yield break;
        }

        Phase_02_01_Count++;

        yield return new WaitForSeconds(1f);
        StartCoroutine(Phase_02_01_Boss_Move_Count());
    }

    // ============================================= 위아래로 왔다 갔다 하기 
    void Phase_02_01_Boss_Attack_Ready()
    {
        StartCoroutine(Phase_02_01_Boss_Ready_());
        StartCoroutine(Phase_02_01_Boss_Ready_Count());
    }

    int Phase_02_01_Ready_Count = 0;
    IEnumerator Phase_02_01_Boss_Ready_()
    {
         if (Phase_02_01_Ready_Count == 1)
        {
            Vector3 to_position = new Vector3(
transform.position.x, Player_Pos.position.y - 0.36f, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, to_position, 0.1f);
        }

        else if (Phase_02_01_Ready_Count >= 2)
        {
            yield break;
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Phase_02_01_Boss_Ready_());
    }
    IEnumerator Phase_02_01_Boss_Ready_Count()
    {
        if (Phase_02_01_Ready_Count == 8)
        {

            Phase_02_01_Ready_Count = 0;
            yield break;
        }
        else if (Phase_02_01_Ready_Count == 1)
        {
            Boss_Bosst_Game_Object.SetActive(true);
            Invoke("Instace_Bullet_BG", 0f);
        }
        else if (Phase_02_01_Ready_Count == 2)
        {
            Boss_Ani.SetBool("Is_Boss_Charging", true);
            Invoke("Phase_02_01_Boss_Attack", 1.5f);
        }


        Phase_02_01_Ready_Count++;

        yield return new WaitForSeconds(1f);
        StartCoroutine(Phase_02_01_Boss_Ready_Count());
    }





    int Boss_Phsae_02_01_Come_Back = 0;
    // Come_Back
    //================================================================================
    void Boss_Come_Back_()
    {
        Boss_Boost_Ani_Set[0].SetActive(false);
        Boss_Boost_Ani_Set[1].SetActive(true);

        StartCoroutine(Boss_01_Come_Back());
        StartCoroutine(Boss_01_Come_Back_Move());

        Invoke("Start_Phase_02_02", 2.5f);
    }
    IEnumerator Boss_01_Come_Back()
    {
        if (Boss_Phsae_02_01_Come_Back == 7)
        {

            Boss_Phsae_02_01_Come_Back = 0;
            yield break;
        }

        Boss_Phsae_02_01_Come_Back++;
        yield return new WaitForSeconds(1f);

        StartCoroutine(Boss_01_Come_Back());
    }
    IEnumerator Boss_01_Come_Back_Move()
    {
        if (Boss_Phsae_02_01_Come_Back >= 7)
        {
            yield break;
        }

        Vector3 to_position = new Vector3(5.64f, 0f - 0.36f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, to_position, 0.1f);


        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Boss_01_Come_Back_Move());
    }
















    // Phase_02_02
    void Start_Phase_02_02()
    {
        Phase_02_02_Bullet_Spread();

        Invoke("Phase_02_02_Bullet_ATTACK_01", 1f);


        StartCoroutine(Phase_02_02_());
        StartCoroutine(Phase_02_02_Boss_Move());
    }

    void Phase_02_02_Bullet_ATTACK_01()
    {
        Boss_Sound_Manager.Boss_Shoot_Sound_No_Loop();

        Phase_02_02_Bullet[0].StartShotRoutine();

        None_Loop_Shoot_Ani[0].SetTrigger("Shoot");
        None_Loop_Shoot_Ani[1].SetTrigger("Shoot");
    }
    void Phase_02_02_Bullet_Spread()
    {
        for (int i =0; i<1; i++)
        {
            Destroy(Instantiate(Bullet_Spread_Phase_02_02[i] ,transform.position, transform.rotation), 8f);
        }
    }

    int Phase_02_02_Count = 0;
    IEnumerator Phase_02_02_()
    {
        if (Phase_02_02_Count == 8)
        {
            Phase_02_02_Count = 0;

            yield break;
        }

        Phase_02_02_Count++;

        yield return new WaitForSeconds(1f);

        StartCoroutine(Phase_02_02_());
    }
    IEnumerator Phase_02_02_Boss_Move()
    {
        if (Phase_02_02_Count >= 7)
        {
            Start_Phase_02_03();
            yield break;
        }
        Vector3 to_position = new Vector3(
        transform.position.x, Player_Pos.position.y - 0.36f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, to_position, 0.02f);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Phase_02_02_Boss_Move());
    }







    void Phase_02_03_Shoot_Ani()
    {
        Phase_02_03_Shoot_Ani_Off();
    }


    // phase_02_03
    void Start_Phase_02_03()
    {
        StartCoroutine(Phase_02_03_());
        StartCoroutine(Phase_02_03_Boss_Move());

        Invoke("Phase_02_03_Shoot_Start", 1.8f);
    }


    void Phase_02_03_Shoot_Start()
    {
        Boss_Sound_Manager.Boss_Shoot_Sound_Loop();

        Loop_Shoot_Ani[0].SetBool("Is_Shoot", true);
        Loop_Shoot_Ani[1].SetBool("Is_Shoot", true);

        Phase_02_03_Bullet[0].StartShotRoutine();
    }

    int Phase_02_03_Count = 0;
    IEnumerator Phase_02_03_()
    {
        if (Phase_02_03_Count == 7)
        {
            Start_Phase_02_01();
            Phase_02_03_Count = 0;
            yield break;
        }
        
        else if (Phase_02_03_Count == 6)
        {
            Invoke("Phase_02_03_Shoot_Ani", 0.32f);
        }

        Phase_02_03_Count++;

        yield return new WaitForSeconds(1f);

        StartCoroutine(Phase_02_03_());
    }
    IEnumerator Phase_02_03_Boss_Move()
    {
        if (Phase_02_03_Count >= 7)
        {
            yield break;
        }

        Vector3 to_position = new Vector3(
        transform.position.x, Player_Pos.position.y - 0.36f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, to_position, 0.02f);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Phase_02_03_Boss_Move());
    }



    void Phase_02_03_Shoot_Ani_Off()
    {
        Boss_Sound_Manager.Boss_Loop_Off();

        Loop_Shoot_Ani[0].SetBool("Is_Shoot", false);
        Loop_Shoot_Ani[1].SetBool("Is_Shoot", false);
    }



















    bool Boss_Hp_Down_Once = false;
    void Warn_Off()
    {
        Warn.SetActive(false);
    }

    bool Phase_02_Start = false;
    public void Boss_Hp_Down_Phase_02_Start()
    {
       if (Boss_01_Heart_Script.Boss_Hp < Boss_01_Heart_Script.Orginal_Boss_Hp / 2 && Boss_Hp_Down_Once == false)
        {
            Boss_Boost_Ani_Set[0].SetActive(false);
            Boss_Boost_Ani_Set[1].SetActive(true);

            Boss_Damaged.SetActive(true);
            Boss_Heart_Ani.SetTrigger("Boss_Danager");
            Boss_Hp_Down_Once = true;
            Phase_02_Start = true;
            Warn.SetActive(true);
            Invoke("Warn_Off", 2f);
        }
    }





    // 피격 처리
    //==================================================================================== 
    void OnTriggerEnter2D(Collider2D other)                                               
    {
        if (other.tag == "Player")
        {
            Player_Script.Player_Hit_Is_Hit_Normal_Enemy();
        }
    }
}
