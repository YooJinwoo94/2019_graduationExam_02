using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Type_Laser_Shoot : MonoBehaviour {


    public float Enemy_Speed = 0.4f;


    private void Start()
    {
        StartCoroutine(Move_Left_Coroutine());
    }

    void Move_Left()
    {
        transform.Translate(Vector2.left * Enemy_Speed * Time.deltaTime);
    }



    IEnumerator Move_Left_Coroutine()
    {
        Move_Left();

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Move_Left_Coroutine());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy_Cant_Go")
        {
            Destroy(gameObject);
        }
    }
}
