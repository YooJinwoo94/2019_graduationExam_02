using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Type_04 : MonoBehaviour {

    private CameraMove shake;
    private playy Player_Script;

    //=========================================== 이미지 끄기 
    public Animator Bullet_Ani;
    public BoxCollider2D Bullet_BoxCollider2D;

    public GameObject BUllet_Boom;

    public SpriteRenderer Bullet_Sprite;
    public Sprite None_Sprites;

    public UbhShotCtrl Enemy_Bullet_Type_04_UbhShotCtrl;

    float Enermy_Speed = 0.7f;




    private void Start()
    {
        StartCoroutine(Move_Move_To_Left());
        StartCoroutine(Bullet_Boom_Timeline());

        if (Is_Boss_== true)
        {
            Bullet_BG_Start();
        }
    }
    private void Awake()
    {
        None_Sprites = Resources.Load<Sprite>("None");
        shake = GameObject.Find("CameraShake_Manager").GetComponent<CameraMove>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
    }





    // ============================= 보스 탄 전용 함수 
    Vector3 target;
    public float BOSS_x = 0;
    public float BOSS_y = 0;

    void Bullet_BG_Start()
    {
        target = new Vector3(BOSS_x, BOSS_y, 0);

        StartCoroutine(Bullet_BG_Count());
        StartCoroutine(Bullet_Move());
    }
    IEnumerator Bullet_Move()
    {
        if (Count > 3)
        {
            yield break;
        }

        transform.position = Vector3.Lerp(transform.position, target, 0.03f);

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Bullet_Move());
    }

    int Count = 0;
    IEnumerator Bullet_BG_Count()
    {
        Count++;

        if (Count > 3)
        {
            Count = 0;
            yield break;
        }
        else if (Count == 1)
        {
            Bullet_BoxCollider2D.enabled = false;
        }
        else if (Count == 2)
        {
            Bullet_BoxCollider2D.enabled = true;
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(Bullet_BG_Count());
    }



    // ============================= 보스 탄 전용 함수 













    void Bullet_Destory()
    {
        Destroy(gameObject);
    }
    void Move_Left()
    {
        if (Bullet_Move_Up == true)
        {
            transform.Translate(Vector2.up * Enermy_Speed * Time.deltaTime);
        }
        if (Bullet_Move_Up == false)
        {
            transform.Translate(Vector2.down * Enermy_Speed * Time.deltaTime);
        }
    }




    bool Dead_Bool = false;

    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
        if (other.tag == "Enemy_Cant_Go")                  //  피격 판정 및 무적여부 확인
        {
            Destroy(gameObject);
        }

        else if (other.tag == "Player")
        {
            if (Player_Script.is_Player_Hit == false)
            {
                Dead_Bool = true;

                Player_Script.Player_Hit_Is_Hit_Normal_Enemy_Bullet_Spread_Shoot();
                Enemy_Bullet_Type_04_UbhShotCtrl.StartShotRoutine();
                Destroy(Instantiate(BUllet_Boom, transform.position, transform.rotation), 0.7f);

                Bullet_BoxCollider2D.enabled = false;
                Bullet_Sprite.sprite = None_Sprites;
                Bullet_Ani.enabled = false;

                Invoke("Bullet_Destory",1.5f);
            }

            Enemy_Bullet_Type_04_UbhShotCtrl.StartShotRoutine();
            Destroy(Instantiate(BUllet_Boom, transform.position, transform.rotation), 0.7f);

            Bullet_BoxCollider2D.enabled = false;
            Bullet_Sprite.sprite = None_Sprites;
            Bullet_Ani.enabled = false;

            Invoke("Bullet_Destory", 1.5f);
        }
    }


    public bool Is_Boss_ = false;

    IEnumerator Move_Move_To_Left()
    {
        if (bullet_Time_Count >4)
        {
            yield break;
        }
        if (Is_Boss_ == false)
        {
            Move_Left();
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Move_Move_To_Left());
    }

    public bool Bullet_Move_Up = true;
    public int Count_x = 3;
    //======================================  확산한다ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ뀨
    public int bullet_Time_Count = 0;
    IEnumerator Bullet_Boom_Timeline()
    {
        if (Dead_Bool == true)
        {
            yield break;
        }
        else if (bullet_Time_Count > Count_x)
        {
            Destroy(Instantiate(BUllet_Boom, transform.position, transform.rotation), 0.7f);
            Enemy_Bullet_Type_04_UbhShotCtrl.StartShotRoutine();

            Bullet_Ani.enabled = false;
            Bullet_BoxCollider2D.enabled = false;
            Bullet_Sprite.sprite = None_Sprites;
          
            Invoke("Bullet_Destory", 1f);
            yield break;
        }

        bullet_Time_Count += 1;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Bullet_Boom_Timeline());
    }
}
