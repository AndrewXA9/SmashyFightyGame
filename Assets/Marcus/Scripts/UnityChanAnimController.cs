using UnityEngine;
using System.Collections;

public class UnityChanAnimController : MonoBehaviour 
{

	private Animator anim;
	float movement;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		movement = Input.GetAxis("Horizontal");
		anim.SetFloat("movement",movement);
	}
}
