using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;  //used from standard assets 2D

[RequireComponent(typeof (FightyCharacterMovement))]
public class FightyCharacterController : MonoBehaviour 
{
	[SerializeField] private int PlayerIndex = 1;

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
			//jump = CrossPlatformInputManager.GetButtonDown("Jump");
			jump = Movement.GetJump(PlayerIndex);
		}
	}
	
	
	private void FixedUpdate()
	{
		// Read the inputs.
		//float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float h = Movement.GetHorizontal(PlayerIndex);
		Debug.Log (h);
		// Pass all parameters to the character control script.
		character.Move(h, jump);
		jump = false;
	}
}
