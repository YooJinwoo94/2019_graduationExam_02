using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom_Item : MonoBehaviour {



    Sprite None_Sprites;
    public float Enemy_Speed = 0.6f;

    public GameObject Boom_Effect;
    public SpriteRenderer Boom_Item_Is_HereSPRITE_RENDERER;
    public SpriteRenderer Boom_Item_SPRITE_RENDERER;
    public Animator Boom_Item_Is_Here_Ani;
    public Animator Boom_Item_Ani;
    public BoxCollider2D Item_Boom_BoxCollider2D;
    public BoxCollider2D Boom_BoxCollider2D;



    private void Start()
    {
        StartCoroutine(Move_Left_Coroutine());
        None_Sprites = Resources.Load<Sprite>("None");
    }

    


    void OFF_Item()
    {
        Item_Boom_BoxCollider2D.enabled = false;
        Boom_Item_Ani.enabled = false;
        Boom_Item_Is_Here_Ani.enabled = false;
        Boom_Item_Is_HereSPRITE_RENDERER.sprite = None_Sprites;
        Boom_Item_SPRITE_RENDERER.sprite = None_Sprites;
        Boom_Effect.SetActive(true);

        Invoke("Off_Boom", 0);
        Destroy(gameObject, 2F);
    }

    void Off_Boom()
    {
        Invoke("Off_Collider", 0.08f);
        //Destroy(gameObject, 0F);
    }
    void Off_Collider()
    {
        Boom_BoxCollider2D.enabled = false;
    }





    void Move_Left()
    {
        transform.Translate(Vector2.left * Enemy_Speed * Time.deltaTime);
    }
    IEnumerator Move_Left_Coroutine()
    {
        Move_Left();

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Move_Left_Coroutine());
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy_Cant_Go")
        {
            Destroy(gameObject);
        }
        else if ( other.tag == "Player_Bullet" ||
                  other.tag == "Player_Shot_Gun_Bullet" ||
                  other.tag == "Player_Bullet_Auto_Gun" ||
                  other.tag == "Player_Laser" ||
                  other.tag == "Player_Railgun_bullet" ||
                  other.tag == "Player_Rocket_Launcher_bullet" ||
                   other.tag == "Player_Rocket_Boom")
        {
            OFF_Item();
            // Invoke("OFF_Item", 0);
        }
    }
    
}
