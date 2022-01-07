using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Enemy_Fragment_01_02 : MonoBehaviour {

    float x = 0;
    float Speed = -4f;
    float Y_Speed = 1.2f;


    public SpriteRenderer Fragment_Sprite_Renderer;

    private void Start()
    {
        StartCoroutine(Rotation_Fragment());
        StartCoroutine(Move());
        StartCoroutine(Alapa_Con());
        //  Invoke("End_Fragment", 10f);
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
    IEnumerator Rotation_Fragment()
    {
        x += 1f;
        transform.rotation = Quaternion.Euler(0, 0, x);

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Rotation_Fragment());
    }

    float Alapa_x = 1;
    IEnumerator Alapa_Con()
    {
        Fragment_Sprite_Renderer.color = new Color(255, 255, 255, Alapa_x);
        Alapa_x -= 0.01f;
        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Alapa_Con());
    }
}
