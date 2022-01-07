using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Team_04 : MonoBehaviour {

    int Wait_Time_Int = 0;
    public GameObject[] Enemy;


    public void Enemy_Team_01_01_End()
    {
        Destroy(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(WaitFor_Enemy_Destroy());
    }


    IEnumerator WaitFor_Enemy_Destroy()
    {
        if (Wait_Time_Int >= 30f)
        {
            Wait_Time_Int = 0;
            Destroy(this.gameObject);
            yield break;
        }

        Wait_Time_Int += 1;
        yield return new WaitForSeconds(1f);

        StartCoroutine(WaitFor_Enemy_Destroy());
    }

}
