using UnityEngine;
using System.Collections;

public class LedgeGrab : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			//hold player at position until jump is applied
		}
	}
}
