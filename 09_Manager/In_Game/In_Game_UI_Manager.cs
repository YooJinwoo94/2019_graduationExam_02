using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class In_Game_UI_Manager : MonoBehaviour {

    public bool Player_Shoot_Stop = false;
    
    public GameObject Defect_Game_Object;


    public void Retry_Button()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    public void Menu_Button()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
