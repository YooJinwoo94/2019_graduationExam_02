using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Laser : MonoBehaviour {

    private LineRenderer LineRenderer;
    public Transform LaserHit;

    private void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.enabled = false;
        LineRenderer.useWorldSpace = true;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        LaserHit.position = hit.point;
        LineRenderer.SetPosition(0, transform.position);
        LineRenderer.SetPosition(1, LaserHit.position);

        if (Input.GetKey(KeyCode.Z))
        {
            LineRenderer.enabled = true;
        }
        else
        {
            LineRenderer.enabled = false;
        }
    }
}
