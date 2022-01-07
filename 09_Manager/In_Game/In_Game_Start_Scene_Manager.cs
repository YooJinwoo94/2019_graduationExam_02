using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Game_Start_Scene_Manager : MonoBehaviour {

    public Transform[] Black_Up_Panel_Set;
    public Transform[] Black_Down_Panel_Set;

    public Enemy_Manager Enemy_Manager_Script;
    public Canvas Ingame_UI_;
    public In_Game_Sound_Manager In_Game_Sound_Manager_Script;
    public In_Game_UI_Manager In_Game_UI_Manager_Script;
    public Transform Player_Transform;
    public BoxCollider2D Player_Box;
    public GameObject[] Extra_Player_Set;
    public GameObject Good_Luck;

    public Transform Extra_Trasnform_01;
    public Transform Extra_Trasnform_02;

    public Transform target;
    public bool Player_Move_ = false;

    public Transform BB_From;
    public Transform BB_To;


    public GameObject Player_Barrier;






    private void Update()
    {
        /*
        if (Move_ == true)
        {
          //  BB_From.position = Vector2.MoveTowards(BB_From.position, BB_To.position, 0.01f);
        }
        */
    }


    private void Start()
    {  
        Black_Ui_On();

        Ingame_UI_.enabled = false;
        In_Game_UI_Manager_Script.Player_Shoot_Stop = true;


        Invoke("BB_Move", 1f);
        Invoke("Extra_Player_On", 1.5f);   
        Invoke("Good_Luck_On", 6f);
        Invoke("Black_Ui_Off", 14f);
    }

    bool Move_ = false;
    void BB_Move()
    {
        Move_ = true;
    }
    void BB_Stop()
    {
        Move_ = false;
    }



    void Good_Luck_On()
    {
        In_Game_Sound_Manager_Script.Text_Sound();
        Good_Luck.SetActive(true);
        Invoke("Good_Luck_Off", 3f);
    }
    void Good_Luck_Off()
    {
        Good_Luck.SetActive(false);
    }


  

    

    void Extra_Player_On()
    {
        Destroy(Instantiate(Extra_Player_Set[0], Extra_Trasnform_01.position, transform.rotation), 10.6f);
        Destroy(Instantiate(Extra_Player_Set[1], Extra_Trasnform_02.position, transform.rotation), 10.6f);
    }




    public void Black_Ui_On()
    {
        /*
        StartCoroutine(Up_Panel_On_Countting());
        StartCoroutine(Up_Panel_On_());
        StartCoroutine(Down_Panel_On_());
        StartCoroutine(Down_Panel_On_Countting());
        */
    }
    public void Black_Ui_Off()
    {
        /*
        StartCoroutine(Up_Panel_Off_Countting());
        StartCoroutine(Up_Panel_Off_());
        StartCoroutine(Down_Panel_Off_());
        StartCoroutine(Down_Panel_Off_Countting());
        */

        Player_Move_ = true;
        Enemy_Manager_Script.Enemy_On();
        Ingame_UI_.enabled = true;
        In_Game_UI_Manager_Script.Player_Shoot_Stop = false;
        BB_Stop();
        In_Game_Sound_Manager_Script.InGame_Intro();


        Player_Box.enabled = true;

        Player_Barrier.SetActive(true);
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

        Vector3 to_position = new Vector3(0, 23.88f, transform.position.z);
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
        Black_Up_Panel_Set[0].position = Vector3.MoveTowards(Black_Up_Panel_Set[0].position, to_position, 0.1f);

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


        Vector2 to_position = new Vector2(0f, -23.88f);
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
        Black_Down_Panel_Set[0].position = Vector3.MoveTowards(Black_Down_Panel_Set[0].position, to_position, 0.1f);

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Down_Panel_Off_());
    }
}
