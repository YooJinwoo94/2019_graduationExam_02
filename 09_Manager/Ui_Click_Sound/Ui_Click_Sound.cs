using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Click_Sound : MonoBehaviour {


    public AudioSource Boss_Shoot_Player;

    public AudioClip[] Boss_AudioClip;




    void Start()
    {
        Boss_Shoot_Player = GetComponent<AudioSource>();
    }




    public void Click_Sound()
    {
        Boss_Shoot_Player.volume = 0.2f;

        Boss_Shoot_Player.Stop();

        Boss_Shoot_Player.clip = Boss_AudioClip[0];

        Boss_Shoot_Player.loop = false;
        Boss_Shoot_Player.Play();
    }

    public void Weapon_On_Sound()
    {
        Boss_Shoot_Player.volume = 0.3f;

        Boss_Shoot_Player.Stop();

        Boss_Shoot_Player.clip = Boss_AudioClip[1];

        Boss_Shoot_Player.loop = false;
        Boss_Shoot_Player.Play();
    }
}
