using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Up_Manager : MonoBehaviour {

    public Transform[] Black_Up_Panel_Set;
    public Transform[] Black_Down_Panel_Set;

    public In_Game_UI_Manager In_Game_UI_Manager_Script;
    public GameObject Defeat_UI_GameObject;

    In_Game_Sound_Manager In_Game_Sound_Manager;


    // 
    private void Start()
    {
        In_Game_UI_Manager_Script = GameObject.Find("ui_mANAGER").GetComponent<In_Game_UI_Manager>();
        In_Game_Sound_Manager = GameObject.Find("Sound_Manager").GetComponent<In_Game_Sound_Manager>();
    }



    public void UI_Up()
    {
        Invoke("a", 6.5f); 

    }

    public void a ()
    {
        In_Game_UI_Manager_Script.Player_Shoot_Stop = true;
        Defeat_UI_GameObject.SetActive(true);
    }





    void Boss_BGM_oN()
    {
        In_Game_Sound_Manager.Boss_BGM();
    }

    public void On_Off()
    {
        //In_Game_Sound_Manager.Boss_Intro();
        Invoke("Boss_BGM_oN", 1.8f);

        On();
        Invoke("Off", 1.9f);
    }
    
    void On()
    {
        In_Game_UI_Manager_Script.Player_Shoot_Stop = true;

        Up_Panel_0n();
        Down_Panel_0n();
        Time_Slow();
    }
    void Off()
    {


        In_Game_UI_Manager_Script.Player_Shoot_Stop = false;

        Up_Panel_0ff();
        Down_Panel_0ff();
        Time_Normal();
    }




    void Time_Slow()
    {
        Time.timeScale = 0.7f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    void Time_Normal()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }





    void Up_Panel_0n()
    {
        StartCoroutine(Up_Panel_On_Countting());
        StartCoroutine(Up_Panel_On_());
    }
    void Up_Panel_0ff()
    {
        StartCoroutine(Up_Panel_Off_Countting());
        StartCoroutine(Up_Panel_Off_());
    }
    //===========================================================
    void Down_Panel_0n()
    {
        StartCoroutine(Down_Panel_On_());
        StartCoroutine(Down_Panel_On_Countting());
    }
    void Down_Panel_0ff()
    {
        StartCoroutine(Down_Panel_Off_());
        StartCoroutine(Down_Panel_Off_Countting());
    }















    //
    // Up Panel
    //================================================================
    int Up_Panel_ON_Count = 0;
    IEnumerator Up_Panel_On_Countting()
    {
        if (Up_Panel_ON_Count == 8)
        {
            Up_Panel_ON_Count = 0;
            yield break;
        }


        Up_Panel_ON_Count++;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Up_Panel_On_Countting());
    }
    IEnumerator Up_Panel_On_()
    {
        if (Up_Panel_ON_Count >= 6)
        {
            yield break;
        }

        Vector3 to_position = new Vector3(0, 22, transform.position.z);
        Black_Up_Panel_Set[0].position = Vector3.MoveTowards(Black_Up_Panel_Set[0].position, to_position, 0.1f);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Up_Panel_On_());
    }

    int Up_Panel_Off_Count = 0;
    IEnumerator Up_Panel_Off_Countting()
    {
        if (Up_Panel_Off_Count == 8)
        {
            Up_Panel_Off_Count = 0;
            yield break;
        }


        Up_Panel_Off_Count++;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Up_Panel_Off_Countting());
    }
    IEnumerator Up_Panel_Off_()
    {
        if (Up_Panel_Off_Count >= 5)
        {
            yield break;
        }

        Vector3 to_position = new Vector3(0, 27, transform.position.z);
        Black_Up_Panel_Set[0].position = Vector3.MoveTowards(Black_Up_Panel_Set[0].position, to_position, 0.2f);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Up_Panel_Off_());
    }





    // 
    // Down Panel
    //=================================================================
    int Down_Panel_ON_Count = 0;
    IEnumerator Down_Panel_On_Countting()
    {
        if (Down_Panel_ON_Count == 8)
        {
            Down_Panel_ON_Count = 0;
            yield break;
        }


        Down_Panel_ON_Count++;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Down_Panel_On_Countting());
    }
    IEnumerator Down_Panel_On_()
    {
        if (Down_Panel_ON_Count >= 6)
        {
            yield break;
        }


        Vector2 to_position = new Vector2(0f, -22);
        Black_Down_Panel_Set[0].position = Vector2.MoveTowards(Black_Down_Panel_Set[0].position, to_position, 0.1f);



        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Down_Panel_On_());
    }

    int Down_Panel_Off_Count = 0;
    IEnumerator Down_Panel_Off_Countting()
    {
        if (Down_Panel_Off_Count == 8)
        {
            Down_Panel_Off_Count = 0;
            yield break;
        }


        Down_Panel_Off_Count++;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Down_Panel_Off_Countting());
    }
    IEnumerator Down_Panel_Off_()
    {
        if (Down_Panel_Off_Count >= 5)
        {
            yield break;
        }

        Vector3 to_position = new Vector3(0, -27, transform.position.z);
        Black_Down_Panel_Set[0].position = Vector3.MoveTowards(Black_Down_Panel_Set[0].position, to_position, 0.2f);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Down_Panel_Off_());
    }
}
