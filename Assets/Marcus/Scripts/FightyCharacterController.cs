using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;  //used from standard assets 2D

[RequireComponent(typeof (FightyCharacterMovement))]
public class FightyCharacterController : MonoBehaviour 
{
	private FightyCharacterMovement character;
	private bool jump;
	
	
	private void Awake()
	{
		character = GetComponent<FightyCharacterMovement>();
	}
	
	
	private void Update()
	{
		if (!jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}
	}
	
	
	private void FixedUpdate()
	{
		// Read the inputs.
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		character.Move(h, jump);
		jump = false;
	}
}
