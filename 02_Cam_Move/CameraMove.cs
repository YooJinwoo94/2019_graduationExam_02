using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject MainCamera;

    public float shake = 0.4f;
    public float shakeAmount = 0.4f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;
    public bool CameraShaking;
    public bool Shaking_Stop;



    private void Start()
    {
        CameraShaking = false;
        Shaking_Stop = false;
    }


    private void OnEnable()
    {
        Shaking_Stop = false;
        CameraShaking = false;
        originalPos = MainCamera.transform.position;
    }

    private void Update()
    {
        if (Shaking_Stop == true)
        {

        }
        else if (CameraShaking)
        {
            if (shake > 0)
            {
                MainCamera.transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

                shake -= Time.deltaTime * decreaseFactor;

            }
            else
            {
                shake = 1f;
                MainCamera.transform.position = originalPos;
                CameraShaking = false;

            }
        }
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
}
