using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Enemy_Fragment_02_01 : MonoBehaviour {

    float x = 0;
    float Speed = -2f;
    float Y_Speed = -0.4f;

    public SpriteRenderer Fragment_Sprite_Renderer;

    private void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(Alapa_Con());
    }




    void End_Fragment()
    {
        Destroy(this.gameObject);
    }

    IEnumerator Move()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, Y_Speed * Time.deltaTime, 0);

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Move());
    }

    float Alapa_x = 1;
    IEnumerator Alapa_Con()
    {
        Fragment_Sprite_Renderer.color = new Color(255, 255, 255, Alapa_x);
          Alapa_x-=0.01f;
          yield return new WaitForSeconds(0.01f);

        StartCoroutine(Alapa_Con());
    }
}
