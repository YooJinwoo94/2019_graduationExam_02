using UnityEngine;
using System.Collections;

public class BgMove_Up_01 : MonoBehaviour {

	float x = 0.0f;
	public float speed = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		x = x + Time.deltaTime * speed;
		GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (x, 0);

	}
}
