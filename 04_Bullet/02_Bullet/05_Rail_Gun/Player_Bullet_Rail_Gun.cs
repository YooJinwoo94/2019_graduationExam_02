using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Rail_Gun : MonoBehaviour {

    public float Player_Bullet_Speed;

    //======================================
    public GameObject Boom_Effect;

    bool Is_Bullet_On = true;



    private void Start()
    {
        Invoke("Destory_Bullet", 3f);
    }

    private void FixedUpdate()
    {
        if (Is_Bullet_On == true)
        {
            transform.Translate(Vector2.right * Player_Bullet_Speed * Time.deltaTime);

        }
    }

    void Destory_Bullet()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)                                                 // 피격 처리 
    {
        if (Is_Bullet_On == true)
        {
            if (other.tag == "Enemy")                  //  피격 판정 및 무적여부 확인
            {
                Debug.Log("");
            }
        }
    }
}
