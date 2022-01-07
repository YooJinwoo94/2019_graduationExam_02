using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sound_Manager : MonoBehaviour {

    public AudioSource Boss_Shoot_Player;

    public AudioClip[] Boss_AudioClip;


    void Start()
    {
        Boss_Shoot_Player = GetComponent<AudioSource>();
    }




    public void Boss_Shoot_Sound_No_Loop()
    {
        Boss_Shoot_Player.volume = 0.3f;

        Boss_Shoot_Player.Stop();

        Boss_Shoot_Player.clip = Boss_AudioClip[0];

        Boss_Shoot_Player.loop = false;
        Boss_Shoot_Player.Play();
    }

    public void Boss_Shoot_Sound_Loop()
    {
        Boss_Shoot_Player.volume = 0.3f;

        Boss_Shoot_Player.Stop();

        Boss_Shoot_Player.clip = Boss_AudioClip[0];

        Boss_Shoot_Player.loop = true;
        Boss_Shoot_Player.Play();
    }


    public void Boss_Loop_Off()
    {
        Boss_Shoot_Player.loop = false;
    }

    public void Boss_Sound_Off()
    {
        Boss_Shoot_Player.Stop();
    }
}
