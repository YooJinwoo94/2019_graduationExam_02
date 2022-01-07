using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour {

    public GameObject Option_Object;
    public GameObject Main_Menu_Game_Object;
    public SpriteRenderer Title_Label;
    public Ui_Click_Sound Ui_Click_Sound;



    private void Start()
    {
        StartCoroutine(Shack_Cam());
    }
    public void Update()
    {
        if(Input.anyKeyDown && One_Click == false)
        {
            Ui_Click_Sound.Click_Sound();
            Turn_On_Mainmenu();
        }
    }

    bool One_Click = false;
    void Turn_On_Mainmenu()
    {
        One_Click = true;
        Main_Menu_Game_Object.SetActive(true);
    }


    public void Start_Game_Button()
    {
        SceneManager.LoadScene(1);
    }

    public void Option_Button()
    {
       // Option_Object.SetActive(true);
     //   Main_Menu_Game_Object.SetActive(false);
    }

    public void Exit_Button()
    {
        One_Click = false;
        Main_Menu_Game_Object.SetActive(false);
        //Application.Quit();
    }



    bool Count = false;
    IEnumerator Shack_Cam()
    {
        if (Count ==false)
        {
            Title_Label.color = new Color(255, 255, 255, 0);
            Count = true;
        }
        else if (Count == true)
        {
            Title_Label.color = new Color(255, 255, 255, 1);
            Count = false;
        }
            yield return new WaitForSeconds(0.5f);

        StartCoroutine(Shack_Cam());
    }

}
