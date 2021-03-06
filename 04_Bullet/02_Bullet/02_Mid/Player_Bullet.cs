using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour {

    public float Player_Bullet_Speed;
    public float Life_Time;
    public BoxCollider2D Bullet_Collider2D;

    //======================================
    public GameObject Boom_Effect;
    public SpriteRenderer Bullet_Renderer;
    bool Is_Bullet_On = true;




    private void FixedUpdate()
    {
        if (Is_Bullet_On == true)
        {
            transform.Translate(Vector2.right * Player_Bullet_Speed * Time.deltaTime);
        }     
    }

    void Destory_Bullet()
    {
       // Instantiate(Destory_Effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
        if (Is_Bullet_On == true)
        {
            if (other.tag == "Player_Bullet_Cant_Go")                  //  피격 판정 및 무적여부 확인
            {
                Destory_Bullet();
            }
            else if (other.tag == "Enemy")                  //  피격 판정 및 무적여부 확인
            {
                Bullet_Collider2D.enabled = false;
                Bullet_Renderer.enabled = false;
                Is_Bullet_On = false;
                Boom_Effect.SetActive(true);
                Invoke("Destory_Bullet", 1f);
            }
        }


    }
}
