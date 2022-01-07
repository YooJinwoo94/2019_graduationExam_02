using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Game_Sound_Manager : MonoBehaviour {

    public AudioSource In_Game_Sound_Player;

    public AudioClip[] In_Game_Back_Ground;





    private void Start()
    {
        In_Game_Sound_Player = GetComponent<AudioSource>();
        In_Game_Sound_Player.clip = In_Game_Back_Ground[0];

        In_Game_Sound_Player.loop = false;
        Alarm();
    }


    // 첫 경고음 
    public void Alarm()
    {
        In_Game_Sound_Player.Stop();
        In_Game_Sound_Player.clip = In_Game_Back_Ground[5];

        In_Game_Sound_Player.loop = false;
        In_Game_Sound_Player.Play();
    }


    // 첫 경고음 
    public void Text_Sound()
    {
        In_Game_Sound_Player.Stop();
        In_Game_Sound_Player.clip = In_Game_Back_Ground[6];

        In_Game_Sound_Player.loop = false;
        In_Game_Sound_Player.Play();
    }






    public void InGame_Intro()
    {
        In_Game_Sound_Player.Stop();
        In_Game_Sound_Player.clip = In_Game_Back_Ground[0];
        In_Game_Sound_Player.loop = false;
        In_Game_Sound_Player.Play();
    }




    // 보스 등장
    public void Boss_On()
    {
        In_Game_Sound_Player.Stop();
        In_Game_Sound_Player.clip = In_Game_Back_Ground[1];

        In_Game_Sound_Player.loop = false;
        In_Game_Sound_Player.Play();
    }


    //보스 도입부 
    public  void Boss_Intro()
    {
        In_Game_Sound_Player.Stop();
        In_Game_Sound_Player.clip = In_Game_Back_Ground[2];

        In_Game_Sound_Player.loop = false;
        In_Game_Sound_Player.Play();
    }


    //보스 bgm
    public void Boss_BGM()
    {
        In_Game_Sound_Player.Stop();
        In_Game_Sound_Player.clip = In_Game_Back_Ground[3];

        In_Game_Sound_Player.loop = true;
        In_Game_Sound_Player.Play();
    }


    //보스 out
    public void Boss_Dead()
    {
        In_Game_Sound_Player.Stop();
        In_Game_Sound_Player.clip = In_Game_Back_Ground[4];

        In_Game_Sound_Player.loop = false;
        In_Game_Sound_Player.Play();
    }



}
