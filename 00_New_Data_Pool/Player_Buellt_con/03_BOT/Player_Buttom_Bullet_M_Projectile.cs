using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Buttom_Bullet_M_Projectile : MonoBehaviour {

    float m_speed = 10f;
    // Use this for initialization

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BG_Out")
        {
          //  playy.Instance.RemoveProjectile_Bot(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * m_speed * Time.deltaTime;
    }
}
