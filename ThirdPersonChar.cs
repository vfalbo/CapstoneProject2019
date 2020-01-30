
using System.Collections;

using System;

using System.Collections.Generic;

using UnityEngine;



public class ThirdPersonChar : MonoBehaviour

{
	//TODO: 
	//*Incrimented Speed
	//*Implement Jumping
	//*



    //Movement Speeds
	public float sprintSpeed;
	public float jumpForce = 100f;
	public float normalSpeed;
	private float speed;
	
		
	//Rotation Speeds	
	public float mouseSpeed;
	public Transform CameraOrigin;
	
	
	
	private float mouseX, mouseY;
	
	//Player Components
    private CharacterController characterController;
	private Animator playerAnimator;
    private Rigidbody playerRB;
	private Vector3 playerMovement; 
	public float currentJumpSpeed;
	private int setJumpSpeed;
	private int gravity;

	
	
	void Start()
	{
		speed = normalSpeed;//At start, set the speed to normal speed not sprinting speed(when incremened speed is added this will get depricated probably)
		Cursor.visible = false;//set the cursor to invisible
        Cursor.lockState = CursorLockMode.Locked;//lock the cursorto the center of the screen
		gravity = -2;
		setJumpSpeed = 25;
		currentJumpSpeed = 0;
		
	}
    void Update()

    {
		playerRB = GetComponent<Rigidbody>();//RigidBody attached to the player empty
		characterController = GetComponent<CharacterController>();//Character controller attached to the player empty
		playerAnimator = GetComponent<Animator>();
		
		//Jump();
        PlayerMovement();//Moves Player 
		PlayerLook();//Rotates player/camera
		
		Debug.Log(characterController.isGrounded);
	
    }



    void PlayerMovement()

    {     
		
		
		
        float hor = (Input.GetAxis("Horizontal")); //Move right or left
        float ver = (Input.GetAxis("Vertical")); // Move forward or back
		
		
	
		//Player movement consists of two vectors, vertical and horizontal.
		
		playerMovement = ((gameObject.transform.forward * Input.GetAxis("Vertical")) + (Input.GetAxis("Horizontal") * gameObject.transform.right)) * speed + (gameObject.transform.up * -10);
		
		
		
		
		characterController.Move(playerMovement * Time.deltaTime);
		
		
		
		
		//Sprinting
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {

            speed = sprintSpeed;
        }

        else

        {

            speed = normalSpeed;

        }
		
		
		//Jumping
		
		
		
		//TODO: when a animation is added to move right and left, change code underneath
		
		if(hor != 0 || ver != 0)//If horizontal or vertical does not equal 0, start the run animation
		{
			setPlayerAnimation(1);
		}
		else
		{
			setPlayerAnimation(0);
		}
			
    
	}
	void PlayerLook()
	{
		
		mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        mouseY += -Input.GetAxis("Mouse Y") * mouseSpeed;
		mouseY = Mathf.Clamp(mouseY, -35, 60);
		
		transform.rotation = Quaternion.Euler(0,mouseX,0);
		CameraOrigin.rotation =  Quaternion.Euler(mouseY,mouseX,0);
		
	}
	void setPlayerAnimation(int state)
	{
		
		switch(state)
		{
			case 0: //Idle
				playerAnimator.SetInteger("PlayerAnimationState", 0);
				break;
			
			case 1: //Running
				playerAnimator.SetInteger("PlayerAnimationState", 1);
				break;
			
			case 2: //Tag
				playerAnimator.SetInteger("PlayerAnimationState", 2);
				break;
			
			default:
				playerAnimator.SetInteger("PlayerAnimationState",0);
				break;
				
				
		}
	}
		/*float Jump()
		{
			
				
			}
			if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded == true)
			{
				isJumping = true
				currentJumpSpeed = 0
			}
			if(isJumping = true)
			{
				currentJumpSpeed++
			}
			if(currentJumpSpeed > 9)
			{
				isJumping = false
			}
			if(currentJumpSpeed < -9.81)
			{
				currentJumpSpeed = -9.81f;
			}
			else
			{	
				currentJumpSpeed = currentJumpSpeed - 2.5f;
			}
			return currentJumpSpeed; 
			
		}*/
		
		
	}




