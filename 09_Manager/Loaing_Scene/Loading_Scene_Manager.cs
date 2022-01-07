using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_Scene_Manager : MonoBehaviour {


    private void Start()
    {
        Invoke("Start_Button_Click", 2F);
    }
    public void Start_Button_Click()
    {
        SceneManager.LoadScene(3);
    }
}
