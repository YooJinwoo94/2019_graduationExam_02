using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobel_Sound_Manager : MonoBehaviour {



    public AudioSource Lobel_Sound_Player;

    public AudioClip[] Lobel_Back_Ground;



    // Use this for initialization
    void Start () {
        Lobel_Sound_Player = GetComponent<AudioSource>();

        Lobel_Sound_Player.clip = Lobel_Back_Ground[0];
        Lobel_Sound_Player.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
