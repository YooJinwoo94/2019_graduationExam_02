using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score_Manager : MonoBehaviour {

    Text Player_Score_Text;
    public Text Fin_Text;


    private void Start()
    {
        Player_Score_Text = GameObject.Find("Player_Score_InGame").GetComponent<Text>();
    }



    int Now_Score = 0;
    public void Score_Up(int x)
    {
        Now_Score += x;
        Player_Score_Text.text = Now_Score.ToString();
    }


    public void Score_Fin()
    {
        Fin_Text.text= Player_Score_Text.text;
    }
}
