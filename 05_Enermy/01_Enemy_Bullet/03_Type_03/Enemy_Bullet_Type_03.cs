using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Type_03 : MonoBehaviour {

    private CameraMove shake;
    private playy Player_Script;

    public SpriteRenderer Bullet_Sprite;

    public GameObject Speed_Bullet_Boom_GameObject;



    //public SpriteRenderer Bullet_Orginal_Sprite;
    //  public SpriteRenderer None_Sprite;


    private void Start()
    {
        //  Bullet_Sprite.sprite = Bullet_Orginal_Sprite.sprite;
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
            if (Player_Script.is_Player_Hit == false)
            {
                Player_Script.Player_Hit_Is_Hit_Normal_Enemy_Bullet_Speed_Shoot();

                Destroy(Instantiate(Speed_Bullet_Boom_GameObject, transform.position, transform.rotation),1.5f);

                Invoke("Bullet_Destory", 0f);
            }
            Destroy(Instantiate(Speed_Bullet_Boom_GameObject, transform.position, transform.rotation), 1.5f);

            Invoke("Bullet_Destory", 0f);
        }
    }
}
