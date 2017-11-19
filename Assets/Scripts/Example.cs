using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<string> dinosaurs = new List<string>();

        dinosaurs.Add("dyman");

        Debug.Log("Name : " + dinosaurs[0]);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
