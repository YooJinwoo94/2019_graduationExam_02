using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot_Sound_Manager : MonoBehaviour {

    public AudioSource Player_Sound_Player;

    public AudioClip[] Player_Warp_AudioClip;





    void Start()
    {
        Player_Sound_Player = GetComponent<AudioSource>();
    }

    public void Loop_Off()
    {
        Player_Sound_Player.Stop();
        Player_Sound_Player.loop = false;
    }



    public void Service_()
    {
        /*
        Player_Sound_Player.volume = 0.3f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Warp_AudioClip[0];


        Player_Sound_Player.loop = true;
        Player_Sound_Player.Play();
        */
    }

    public void Shot_()
    {
        /*
        Player_Sound_Player.volume = 0.3f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Warp_AudioClip[1];


        Player_Sound_Player.loop = true;
        Player_Sound_Player.Play();
        */
    }

    public void Auto()
    {
        /*
        Player_Sound_Player.volume = 0.3f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Warp_AudioClip[2];

        Player_Sound_Player.loop = true;
        Player_Sound_Player.Play();
        */
    }

    public void Rail()
    {
        Player_Sound_Player.volume = 0.3f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Warp_AudioClip[3];


        Player_Sound_Player.loop = false;
        Player_Sound_Player.Play();
    }

    public void Rocket()
    {
        Player_Sound_Player.volume = 0.3f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Warp_AudioClip[4];

        Player_Sound_Player.loop = false;
        Player_Sound_Player.Play();
    }


    public void Heavy_Ready()
    {
        Player_Sound_Player.volume = 0.3f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Warp_AudioClip[5];

        Player_Sound_Player.loop = false;
        Player_Sound_Player.Play();
    }
}
