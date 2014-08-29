using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 1f;

    public bool isInfinite = false;

    private Animator animator;

	private float normalizedHorizontalSpeed = 0;
	bool _right;
	bool _left;
	bool _up;

	public float slayingTime = 0.2F;
	//public float gravity = 5;
	public float speed = 8;
	//public float jumpPower = 10;
	public SendDamageCollider sendDamageColliderR;	
	public SendDamageCollider sendDamageColliderL;
	
	/*public AudioClip jumpSound;
	public AudioClip attackSound;*/

	public Joystick joystickLeft;
	public Joystick joystickRight;
	public Joystick joystickAttack;
	public Joystick joystickJump;
	[HideInInspector]
	public bool sceneSwitch = false;

	bool inputJumpPressed = false;
	bool inputAttackPressed = false;
	bool isSlaying = false;
	bool lookRight = true;
	bool inputJump = false;
	//float velocity = 0;
	Vector3 moveDirection = Vector3.zero;
	CharacterController characterController;
	//SpriteController spriteController;
	HealthController healthController;

	void Awake()
	{
        animator = GetComponent<Animator>();
	}
	
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		//spriteController = GetComponent<SpriteController>();
		healthController = GetComponent<HealthController>();
	}
	
	// Update is called once per frame
	void Update () {
	    InputCheck();
		//Move();
		//SetAnimation();
		Fight();

        _up = _up || Input.GetButtonDown("Jump");

        if (!isInfinite)
            _right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || joystickRight.isPressed;
        else
            _right = true;
        
        _left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || joystickLeft.isPressed;
	}

	//
	void FixedUpdate()
	{
		// grab our current _velocity to use as a base for all calculations
		moveDirection = characterController.velocity;
		
		if( characterController.isGrounded )
			moveDirection.y = 0;
		
		if(_right)
		{
			normalizedHorizontalSpeed = 1;
            animator.SetFloat("Speed", normalizedHorizontalSpeed);
            
            if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
		else if(_left)
		{
			normalizedHorizontalSpeed = -1;
            animator.SetFloat("Speed", normalizedHorizontalSpeed);
            
            if(transform.localScale.x > 0f)
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
		else
		{
			normalizedHorizontalSpeed = 0;
            animator.SetFloat("Speed", normalizedHorizontalSpeed);
		}
		
		// we can only jump whilst grounded
		if( characterController.isGrounded && _up)
		{
            animator.SetBool("inputJump", true);
            //AudioSource.PlayClipAtPoint(jumpSound, transform.position, 1);
            moveDirection.y = Mathf.Sqrt(2f * jumpHeight * gravity);
		}
		
		
		// apply horizontal speed smoothing it
		var smoothedMovementFactor = characterController.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		moveDirection.x = Mathf.Lerp( moveDirection.x, normalizedHorizontalSpeed * runSpeed, Time.fixedDeltaTime * smoothedMovementFactor );
		
		// apply gravity before moving
		moveDirection.y -= gravity * Time.fixedDeltaTime;

        if (healthController.currentHealth > 0)
		    characterController.Move(moveDirection * Time.fixedDeltaTime);

		// reset input
		_up = false;

        if (characterController.isGrounded)
            animator.SetBool("inputJump", false);
	}

	void InputCheck()
	{	
		if ((healthController.currentHealth > 0)&&(!sceneSwitch))
		{
			/*
			velocity = Input.GetAxis("Horizontal") * speed;

			if (velocity > 0)
				lookRight = true;
		
			if (velocity < 0)
				lookRight = false;
			*/

			if (transform.localScale.x > 0)
				lookRight = true;
			
			if (transform.localScale.x < 0)
				lookRight = false;

			if ((Input.GetButtonDown("Jump")))
			{
				inputJump = true;	
			}
			else
			{
				inputJump = false;	
			}

			if (Input.GetButtonDown("Fire1") && !isSlaying && Input.touchCount == 0)
			{
				isSlaying = true;
                animator.SetBool("isSlaying", true);
				//AudioSource.PlayClipAtPoint(attackSound,transform.position,0.4F);
				StartCoroutine(ResetIsSlaying());
			}


            if (joystickJump.isPressed && !inputJumpPressed)
            {
                _up = true;
                inputJumpPressed = true;
            }

            if (!joystickJump.isPressed)
                inputJumpPressed = false;

            if (joystickAttack.isPressed && !inputAttackPressed && !isSlaying)
            {
                isSlaying = true;
                inputAttackPressed = true;
                animator.SetBool("isSlaying", true);
                //AudioSource.PlayClipAtPoint(attackSound, transform.position, 0.4F);
                StartCoroutine(ResetIsSlaying());
            }

            if (!joystickAttack.isPressed)
                inputAttackPressed = false;
		}
		else
		{
			//velocity = 0;
			gameObject.renderer.enabled = false;
            normalizedHorizontalSpeed = 0;
		}
	}	

    /*
	void InputTouchCheck()
	{	
		if ((healthController.currentHealth > 0)&&(!sceneSwitch))
		{
            if (joystickLeft.isPressed)
				velocity = speed * (-1);
			if (joystickRight.isPressed)
				velocity = speed;

			if (!joystickLeft.isPressed && !joystickRight.isPressed)
				velocity = 0;

			if (velocity > 0)
				lookRight = true;
			
			if (velocity < 0)
				lookRight = false;

			if (joystickJump.isPressed && !inputJumpPressed)
			{
				inputJump = true;
				inputJumpPressed = true;
			}
			else
			{
				inputJump = false;
			}
		}
		else
		{
			velocity = 0;
			gameObject.renderer.enabled = false;
		}
	}
    
	void Move()
	{
		if (characterController.isGrounded && inputJump)
		{
			//moveDirection.y = -1;
			
			if(inputJump)
			{	
				AudioSource.PlayClipAtPoint(jumpSound,transform.position,1);
				moveDirection.y = jumpPower;
			}
		}
		else
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}

			moveDirection.x = velocity;
			characterController.Move(moveDirection * Time.deltaTime);
	}
	*/
	
	void Fight()
	{
		if(isSlaying)
		{
			if(lookRight)
			{
				sendDamageColliderR.attacking = true;
				sendDamageColliderL.attacking = false;
			}
			else
			{
				sendDamageColliderR.attacking = false;
				sendDamageColliderL.attacking = true;
			}
		
		}
		else
		{
			sendDamageColliderR.attacking = false;
			sendDamageColliderL.attacking = false;	
		}
	}
	
    /*
	void SetAnimation()
	{
		if(velocity > 0)
		{
			spriteController.SetAnimation(SpriteController.AnimationType.goRight);	
		}	
		
		if(velocity < 0)
		{
			spriteController.SetAnimation(SpriteController.AnimationType.goLeft);
		}	
	
		if (velocity == 0)
		{
			if (lookRight)
			{
				spriteController.SetAnimation(SpriteController.AnimationType.stayRight);	
			}
			else
			{
				spriteController.SetAnimation(SpriteController.AnimationType.stayLeft);
			}
		}
	
		if (!characterController.isGrounded)
		{
			if (lookRight)
			{
				spriteController.SetAnimation(SpriteController.AnimationType.jumpRight);
			}
			else
			{
				spriteController.SetAnimation(SpriteController.AnimationType.jumpLeft);
			}
		}
	
	if (isSlaying)
		{
			if (lookRight)
			{
				spriteController.SetAnimation(SpriteController.AnimationType.attackRight);
			}
			else
			{
				spriteController.SetAnimation(SpriteController.AnimationType.attackLeft);	
			}
		}
	
	}
    */
	
	IEnumerator ResetIsSlaying()
	{
		yield return new WaitForSeconds(slayingTime);
		isSlaying = false;
        animator.SetBool("isSlaying", false);
	}

	void OnGUI()
	{
		if (GUILayout.Button("+"))
			Application.targetFrameRate += 10;
	
		if (GUILayout.Button("-"))
			Application.targetFrameRate -= 10;

		GUILayout.Label(Application.targetFrameRate.ToString());
	}
}