using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Air_Select_Scene_Manager : MonoBehaviour {

    public Scrollbar Skill_Button_Scroll_Bar;

    public GameObject Notice_UI;


    public Image[] Skill_Button_Image_01;
    public Image[] Skill_Button_Image_02;


    public Sprite Button_1_On;
    public Sprite Button_1_Off;
    public Sprite Button_2_On;
    public Sprite Button_2_Off;

    private void Start()
    {
        Skill_Button_Scroll_Bar.value = 0;
        Skill_Button_Scroll_Bar.size = 0.3f;
    }


    public void Start_Button_Click()
    {
        SceneManager.LoadScene(2);
    }

    public void Notice_UI_Off()
    {
        Notice_UI.SetActive(false);
    }


    bool Skill_Button_01 = false;
    bool Skill_Button_02 = false;

    public void Skill_Button_01_Click()
    {
        if (Skill_Button_01 == false)
        {
            Skill_Button_01 = true;
            Skill_Button_01_On();
        }
        else if (Skill_Button_01 == true)
        {
            Skill_Button_01 = false;
            Skill_Button_01_Off();
        }
    }
    public void Skill_Button_02_Click()
    {
        Debug.Log(Skill_Button_02);
        if (Skill_Button_02 == false)
        {
            Skill_Button_02 = true;
            Skill_Button_02_On();
        }
        else if (Skill_Button_02 == true)
        {
            Skill_Button_02 = false;
            Skill_Button_02_Off();
        }
    }






    public void Skill_Button_01_On()
    {
        Skill_Button_Image_01[0].sprite = Button_1_On;
    }
    public void Skill_Button_01_Off()
    {
        Skill_Button_Image_01[0].sprite = Button_1_Off;
    }



    public void Skill_Button_02_On()
    {
        Skill_Button_Image_02[0].sprite = Button_2_On;
    }

    public void Skill_Button_02_Off()
    {
        Skill_Button_Image_02[0].sprite = Button_2_Off;

    }
}
            