using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Type_01 : MonoBehaviour {


    private CameraMove shake;
    private playy Player_Script;

 //   public Animator Bullet_Boom_Ani;

    public BoxCollider2D Bullet_BoxCollider2D;
    public GameObject Normal_BUllet_Boom;

    public SpriteRenderer Bullet_Sprite; 
    public SpriteRenderer None_Sprite;
    public Animator Bullet_Ani;



    private void Awake()
    {
        shake = GameObject.Find("CameraShake_Manager").GetComponent<CameraMove>();
        Player_Script = GameObject.Find("Player").GetComponent<playy>();
    }

    void Bullet_Destory()
    {
        Destroy(gameObject);
    }




    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
        if (other.tag == "Enemy_Cant_Go")                  //  피격 판정 및 무적여부 확인
        {
            Destroy(gameObject);
        }

        else if (other.tag == "Player")
        {        
            if ( Player_Script.is_Player_Hit == false)
            {
                Player_Script.Player_Hit_Is_Hit_Normal_Enemy_Bullet_Normal();
                Destroy(Instantiate(Normal_BUllet_Boom, transform.position, transform.rotation), 0.6f);

                Bullet_Ani.enabled = false;
                Bullet_BoxCollider2D.enabled = false;
                Bullet_Sprite.sprite = None_Sprite.sprite;

                Invoke("Bullet_Destory", 1.0f);
            }
            Destroy(Instantiate(Normal_BUllet_Boom, transform.position, transform.rotation), 0.6f);

            Bullet_Ani.enabled = false;
            Bullet_BoxCollider2D.enabled = false;
            Bullet_Sprite.sprite = None_Sprite.sprite;

            Invoke("Bullet_Destory", 1.0f);
        }   
    }
}
