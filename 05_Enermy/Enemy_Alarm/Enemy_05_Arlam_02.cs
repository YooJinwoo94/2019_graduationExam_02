using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_05_Arlam_02 : MonoBehaviour {




    public GameObject Allam_Mark_Game_Object;

    private void Start()
    {
        Allam_Mark_Game_Object.SetActive(false);
        StartCoroutine(Alarm());
    }





    void Mark_On()
    {
        Is_Mark_On = true;
        Allam_Mark_Game_Object.SetActive(true);
    }
    void Mark_Off()
    {
        Allam_Mark_Game_Object.SetActive(false);
    }


    bool Is_Mark_On = false;
    int Count = 0;


    IEnumerator Alarm()
    {
        if (Count >= 7 && Is_Mark_On == false)
        {
            Mark_On();
        }

        else if (Count > 11)
        {
            Mark_Off();
            yield break;
        }

        Count += 1;
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(Alarm());
    }






    /*
    // 피벗 센터 RIGHT


    int Alarm_Count = 0;
    float offset = -180;

    public GameObject Arlam_Renderer;

    public SpriteRenderer Arlam_Sprite_Renderer;

    Transform Player_Transform;


    bool Alarm_Bool = false;


    void Sprite_Renderer_On()
    {
        Arlam_Sprite_Renderer.enabled = true;
    }

    void Sprite_Renderer_Off ()
    {
        Arlam_Sprite_Renderer.enabled = false;
    }

    void ON_Game_Object()
    {
        Arlam_Renderer.SetActive(true);
    }

    void Off_Game_Object()
    {
        Arlam_Renderer.SetActive(false);
    }



    private void Start()
    {
        Sprite_Renderer_Off();

        Player_Transform = GameObject.Find("Player").GetComponent<Transform>();

        StartCoroutine(Enemy_Alarm());
    }





    IEnumerator Enemy_Alarm()
    {
        //일정 거리까지 오기 
        if (Alarm_Count >= 360)
        {
            Off_Game_Object();
            yield break;
        }

        else if (Alarm_Count > 165)
        {
            Alarm_Bool = true;
            Sprite_Renderer_On();
            ON_Game_Object();
        }


        Vector3 Difference = Player_Transform.position - transform.position;
            float rotz = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
        



    



        Alarm_Count += 1;
        yield return new WaitForSeconds(0.01f);

        StartCoroutine(Enemy_Alarm());
    }

    */
}
