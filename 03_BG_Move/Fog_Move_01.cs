using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog_Move_01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Enemy_Move());
    }

    public float Enermy_Speed = 0.2f;
    void Enemy_Move_Left()
    {
        transform.Translate(Vector2.left * Enermy_Speed * Time.deltaTime);
    }
    IEnumerator Enemy_Move()
    {
        Enemy_Move_Left();

        if (transform.position.x <-231f)
        {
            Vector2 Orgin_Pos = new Vector2(20, 0);
            transform.position = Orgin_Pos;
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Enemy_Move());
    }
}
