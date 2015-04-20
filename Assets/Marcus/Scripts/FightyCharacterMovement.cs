using UnityEngine;
using System.Collections;

public class FightyCharacterMovement : MonoBehaviour 
{
	[SerializeField] private float maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float jumpForce = 400f;                  // Amount of force added when the player jumps.
	[SerializeField] private bool airControl = false;                 // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask whatIsGround;                  // A mask determining what is ground to the character
	
	private Transform groundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool grounded;            // Whether or not the player is grounded.
	private Transform ceilingCheck;   // A position marking where to check for ceilings
	const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D characterRigidbody2D;
	private bool facingRight2D = true;  // For determining which way the player is currently facing.
	private bool doubleJump = false;


	private void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		characterRigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		grounded = false;
		
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
			}
		}

		if(grounded)
		{
			doubleJump = false;
		}


	}

	public void Move(float move, bool jump)
	{

		//only control the player if grounded or airControl is turned on
		if (grounded || airControl)
		{
			// Move the character
			characterRigidbody2D.velocity = new Vector2(move*maxSpeed, characterRigidbody2D.velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !facingRight2D)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && facingRight2D)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player can jump or double jump
		if ((grounded || !doubleJump)&& jump)
		{
			// Add a vertical force to the player.
			grounded = false;
			characterRigidbody2D.AddForce(new Vector2(0f, jumpForce));

			// Check if grounded, if not activate
			if(!grounded)
			{
				doubleJump = true;
			}
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight2D = !facingRight2D;
		

		// Sets the player direction to movement direction
		if(!facingRight2D)
		{
			transform.localRotation = Quaternion.LookRotation(Vector3.left);
		}
		else if(facingRight2D)
		{
			transform.localRotation = Quaternion.LookRotation(Vector3.right);
		}


	}

}
