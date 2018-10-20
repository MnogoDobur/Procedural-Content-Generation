using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerFollowPlayer : MonoBehaviour {
	public GameObject player;
	public GameObject viewer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = new Vector3 (player.gameObject.transform.position.x,0,player.gameObject.transform.position.z);
		viewer.transform.position = playerPos;
	}
}
