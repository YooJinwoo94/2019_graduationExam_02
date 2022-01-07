using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour {

    public playy playy_Script;
    public Player_Move_Pointer Player_Move_Pointer_Script;

    public Transform Orginal_Player_Move_Pointer_Pos;

    public GameObject[] Player_Warp_Set;

    private void Start()
    {
       // Player_Move_Over_Finished();
    }


    public void Player_Move_Over()
    {
        Player_Move_Pointer_Script.Player_Move_Sprite_Render.color = new Color(240, 255, 0, 1);

        Player_Move_Pointer_Script.transform.position = Orginal_Player_Move_Pointer_Pos.transform.position;
        
        playy_Script.Is_Player_Move = false;
        Player_Move_Pointer_Script.Is_Move_Point_ = true;
    }

    public void Player_Move_Over_Finished()
    {
       Player_Move_Pointer_Script.Player_Move_Sprite_Render.color = new Color(240, 255, 0, 0);

        Destroy(Instantiate(Player_Warp_Set[0], Player_Move_Pointer_Script.transform.position, Player_Move_Pointer_Script.transform.rotation), 1f);
        Destroy(Instantiate(Player_Warp_Set[1], playy_Script.transform.position, playy_Script.transform.rotation), 1f);

        playy_Script.transform.position = Player_Move_Pointer_Script.transform.position;
        Player_Move_Pointer_Script.transform.position = playy_Script.transform.position;
       

        playy_Script.Is_Player_Move = true;
        Player_Move_Pointer_Script.Is_Move_Point_ = false;
    }
}
