using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_To_Player_CAM_Shack_Manager_02 : MonoBehaviour {

    public GameObject MainCamera;
    public bool Cam_Move = false;
    public float shake = 1f;
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 0.25f;

    Vector3 originalPos;
    public bool CameraShaking;
    public bool Shaking_Stop;



    private void Start()
    {
        Shaking_Stop = false;
        CameraShaking = false;
    }


    private void OnEnable()
    {
        CameraShaking = false;
        originalPos = MainCamera.transform.position;
    }
    void ShakeCamera(float shaking)
    {
        if (!CameraShaking)
        {
            originalPos = MainCamera.transform.position;
        }

        shake = shaking;
        CameraShaking = true;
    }









    public void Shack_CAM_A()
    {
        if (Shaking_Stop == true)
        {

        }
        else
        {
            StartCoroutine(Shack_Cam());
        }
    }

    IEnumerator Shack_Cam()
    {
        if (Cam_Move == true)
        {

            shake = 1f;
            MainCamera.transform.position = originalPos;
            yield break;
        }

        else if (shake > 0)
        {
            MainCamera.transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;

        }

        else if (shake < 0)
        {
            shake = 1f;
            MainCamera.transform.position = originalPos;
            yield break;
        }

        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Shack_Cam());
    }
}
