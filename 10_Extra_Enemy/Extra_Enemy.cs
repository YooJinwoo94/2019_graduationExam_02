using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extra_Enemy : MonoBehaviour {


    public float Enemy_Speed = 1.2f;


    private void Start()
    {

        StartCoroutine(Move_Left_Coroutine());
    }

    void Move_Left()
    {
        transform.position += new Vector3(-0.025f, 0, 0);
        // transform.Translate(Vector2.left * Enemy_Speed * Time.deltaTime);
    }



    IEnumerator Move_Left_Coroutine()
    {
        Move_Left();

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Move_Left_Coroutine());
    }
}
