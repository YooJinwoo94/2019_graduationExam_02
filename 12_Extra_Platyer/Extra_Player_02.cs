using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extra_Player_02 : MonoBehaviour {

    public Transform Extra_Player_Transform;
    public SpriteRenderer Extra_Player_Sprite_Render;
    public SpriteRenderer EXTRA_Boost_Ani;
    public SpriteRenderer Null;

    public GameObject Warp_Ready;
    public GameObject Warp;
    public Animator[] Ex_Animator;

    static float x = -0.85f;
    static float y = -1.93f;

    Vector2 target = new Vector2(-0.8f, -1.93f);
    Vector2 target_02 = new Vector2(15f, -1.93f);

    Player_Sound_Manager Player_Sound_Manager;








    private void Update()
    {
        if ( bb ==false )
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0.05f);
        }
        else if (bb == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target_02, 0.06f);
        }
    }

    private void Start()
    {
        Player_Sound_Manager = GameObject.Find("Player_Sound_Manager").GetComponent<Player_Sound_Manager>();


        Invoke("Go_Front", 8f);
        Invoke("Skill_Ready", 8.5f);
        Invoke("Skill_On", 10f);
    }






    bool bb = false;
    void Go_Front()
    {
        bb = true;
    }





    void Skill_Ready()
    {
        Player_Sound_Manager.Player_Warp_In();
        Ex_Animator[0].SetTrigger("Is_EX_Player_Skill_On");
        Warp_Ready.SetActive(true);
    }


    void Skill_On()
    {
  
        Player_Sound_Manager.Player_Warp_Out();
        Warp.SetActive(true);
        EXTRA_Boost_Ani.sprite = Null.sprite;
        Extra_Player_Sprite_Render.sprite = Null.sprite;
        Ex_Animator[0].enabled = false;
        Ex_Animator[1].enabled = false;
    }
}
