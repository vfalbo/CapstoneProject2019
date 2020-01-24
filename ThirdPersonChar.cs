
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
	public Animator playerAnimator;
    private Rigidbody playerRB;
	
	void Start()
	{
		speed = normalSpeed;//At start, set the speed to normal speed not sprinting speed(when incremened speed is added this will get depricated probably)
		Cursor.visible = false;//set the cursor to invisible
        Cursor.lockState = CursorLockMode.Locked;//lock the cursorto the center of the screen
	}
    void Update()

    {
		characterController = GetComponent<CharacterController>();//Character controller attached to the player empty
		playerRB = GetComponent<Rigidbody>();//RigidBody attached to the player empty
		
        PlayerMovement();//Moves Player 
		PlayerLook();//Rotates player/camera
		
    }



    void PlayerMovement()

    {     
		
		
		
        float hor = (Input.GetAxis("Horizontal")); //Move right or left
        float ver = (Input.GetAxis("Vertical")); // Move forward or back
		
		
		//Player movement consists of two vectors, vertical and horizontal.
        Vector3 playerMovement = (gameObject.transform.forward * Input.GetAxis("Vertical")) + (Input.GetAxis("Horizontal") * gameObject.transform.right);
		
		
		
		
		characterController.Move(playerMovement * speed * Time.deltaTime);
		
		
		
		
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
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
			playerRB.AddForce(jumpForce * transform.up,ForceMode.Impulse);
			
		//}
		
		
		
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
				playerAnimator.SetInteger("PlayerState", 0);
				break;
			
			case 1: //Running
				playerAnimator.SetInteger("PlayerState", 1);
				break;
			
			case 2: //Tag
				playerAnimator.SetInteger("PlayerState", 2);
				break;
			
			default:
				playerAnimator.SetInteger("PlayerState",0);
				break;
				
				
		}
		
		
		
	}




}