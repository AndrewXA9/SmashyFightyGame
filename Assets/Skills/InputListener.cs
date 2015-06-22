using UnityEngine;
using System.Collections;

public class InputListener : MonoBehaviour {
	
	public MonoBehaviour AS;
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			AS.enabled = true;
		}
		if(Input.GetMouseButtonDown(1)){
			this.SendMessage("Interrupt");
		}
	}
}
