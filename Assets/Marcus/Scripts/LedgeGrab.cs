using UnityEngine;
using System.Collections;

public class LedgeGrab : MonoBehaviour 
{
	[SerializeField] private Vector3 ledgeBuffer;

	private Transform playerObject;

	// Use this for initialization
	void Start () 
	{
		playerObject = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			GrabLedge();
		}
	}

	void OnTriggerStay(Collider other)
	{

	}

	void GrabLedge()
	{
		playerObject.transform.position = transform.position + ledgeBuffer;
	}
}
