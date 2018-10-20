using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour {
	public Transform goal;
	private Animator cont;
	bool test;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cont = this.GetComponent<Animator> ();
		if (!test) {
			cont.SetTrigger ("Run");
			test = true;
		}
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = goal.position;
	}
}
