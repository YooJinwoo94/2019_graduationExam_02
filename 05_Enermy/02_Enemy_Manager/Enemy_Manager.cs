using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour {

    public In_Game_UI_Manager In_Game_UI_Manager_Script;
    public GameObject Defeat_UI_Game_Objcet;
    public GameObject[] Pattern_Game_Object;
    public GameObject[] Boss_On;
    public Boss_Up_Manager Boss_Up_Manager_Script;


    public GameObject[] Extra_Enemy;
    public GameObject[] Extra_Fragment;


    In_Game_Sound_Manager In_Game_Sound_Manager;


    private void Start()
    {
        In_Game_Sound_Manager = GameObject.Find("Sound_Manager").GetComponent<In_Game_Sound_Manager>();    
    }


   public void Enemy_On()
    {
        StartCoroutine(Enemy_Pattern_Set());
        StartCoroutine(Extra_Pattern_Set());
    }




 
    int Count_Time = 0;
    IEnumerator Enemy_Pattern_Set()
    {
        //=================================================== 1 
        if ( Count_Time == 1)
        {
            Instantiate(Pattern_Game_Object[0]);
        }

        //=================================================== 2
        else if (Count_Time == 6)
        {
            Instantiate(Pattern_Game_Object[1]);
        }

        //=================================================== 3
        else if (Count_Time == 18)
        {
            Instantiate(Pattern_Game_Object[3]);
        }

        //=================================================== 4
        else if (Count_Time == 26)
        {
            Instantiate(Pattern_Game_Object[4]);
        }

        //=================================================== 5
        else if (Count_Time == 33)
        {
            // Instantiate(Pattern_Game_Object[4]);
            Instantiate(Pattern_Game_Object[6]);
        }

        //=================================================== 6
        else if (Count_Time == 43)
        {
            // Instantiate(Pattern_Game_Object[5]);
            Instantiate(Pattern_Game_Object[7]);
        }

        //=================================================== 7
        else if (Count_Time == 49)
        {
 
            //  Instantiate(Pattern_Game_Object[6]);
            Instantiate(Pattern_Game_Object[8]);
        }

        //=================================================== 8
        else if (Count_Time == 55)
        {
            //  Instantiate(Pattern_Game_Object[7]);
            Instantiate(Pattern_Game_Object[9]);
        }

        //=================================================== 9
        else if (Count_Time == 64)
        {
            Debug.Log("ad");
            // Instantiate(Pattern_Game_Object[8]);
            Instantiate(Pattern_Game_Object[10]);
        }

        //=================================================== 10
        else if (Count_Time == 69)
        {
            //  Instantiate(Pattern_Game_Object[9]);
            Instantiate(Pattern_Game_Object[11]);
        }
        //===================================================================무조건 들어가야 함 
        //=================================================== 11
        else if (Count_Time == 84)
        {
            //   Instantiate(Pattern_Game_Object[10]);
            Instantiate(Pattern_Game_Object[12]);
        }

        //=================================================== 12
        else if (Count_Time == 90)
        {
            Instantiate(Pattern_Game_Object[13]);
        }

        //=================================================== 13
        else if (Count_Time == 98)
        {
            Instantiate(Pattern_Game_Object[14]);
        }

        //=============================================================================
        //=================================================== 14
        else if (Count_Time == 108)
        {
            Instantiate(Pattern_Game_Object[15]);
        }

        else if (Count_Time == 120)
        {
            In_Game_Sound_Manager.Boss_On();
        }

        //=================================================== 15
        else if (Count_Time == 122)
        {
            Instantiate(Boss_On[0]);
            Boss_Up_Manager_Script.On_Off();
        }

        Count_Time += 1;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Enemy_Pattern_Set());
    }

    /*
      In_Game_UI_Manager_Script.Player_Shoot_Stop = true;
            Defeat_UI_Game_Objcet.SetActive(true);
    */

    int Count_Extra_Time = 0;
    IEnumerator Extra_Pattern_Set()
    {

        if (Count_Extra_Time == 28)
        {
            Instantiate(Extra_Fragment[2]);
        }

        else if (Count_Extra_Time == 82)
        {
            Instantiate(Extra_Fragment[1]);
        }

        else if (Count_Extra_Time == 109)
        {
            Instantiate(Extra_Enemy[0]);
        }


        /*
        else if (Count_Extra_Time == 127)
        {
            Instantiate(Extra_Fragment[1]);
        }

        else if (Count_Extra_Time == 129)
        {
            Instantiate(Extra_Enemy[1]);
        }
        */

        Count_Extra_Time += 1;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Extra_Pattern_Set());
    }
}
