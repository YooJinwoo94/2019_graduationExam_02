using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sound_Manager : MonoBehaviour {

    public AudioSource Player_Sound_Player;

    public AudioClip[] Player_Warp_AudioClip;
    public AudioClip[] Player_Weapon_Eat_AudioClip;
    public AudioClip[] Player_Weapon_Change_AudioClip;





    void Start()
    {
        Player_Sound_Player = GetComponent<AudioSource>();

    }











    public void Player_Warp_In()
    {
        Player_Sound_Player.volume = 0.42f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Warp_AudioClip[0];

        Player_Sound_Player.loop = false;
        Player_Sound_Player.Play();
    }
    public void Player_Warp_Out()
    {
        Player_Sound_Player.volume = 0.32f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Warp_AudioClip[1];

        Player_Sound_Player.loop = false;
        Player_Sound_Player.Play();
    }


   public void Player_Weapon_Eat()
    {
        Player_Sound_Player.Stop();
        Player_Sound_Player.volume = 0.3f;


        Player_Sound_Player.clip = Player_Weapon_Eat_AudioClip[0];

        Player_Sound_Player.loop = false;
        Player_Sound_Player.Play();
    }

    public void Player_Weapon_Change()
    {
        Player_Sound_Player.volume = 0.1f;

        Player_Sound_Player.Stop();

        Player_Sound_Player.clip = Player_Weapon_Change_AudioClip[0];

        Player_Sound_Player.loop = false;
        Player_Sound_Player.Play();
    }
}
