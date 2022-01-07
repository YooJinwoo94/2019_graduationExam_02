using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Enemy_Fragment_01 : MonoBehaviour {

    float x = 0;

    Rigidbody2D Fragment_RigidBody2D;

    private void Start()
    {
        Fragment_RigidBody2D = GetComponent<Rigidbody2D>();

        StartCoroutine(Rotation_Fragment());
        StartCoroutine(Move());

        Invoke("End_Fragment", 10f);
    }




    void End_Fragment()
    {
        Destroy(this.gameObject);
    }

    IEnumerator Move()
    {
        Fragment_RigidBody2D.AddForce(new Vector2(-5, -11), ForceMode2D.Force);

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Move());
    }
    IEnumerator Rotation_Fragment()
    {
        x += 5f;
        transform.rotation = Quaternion.Euler(0, 0, x);

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Rotation_Fragment());
    }
}
