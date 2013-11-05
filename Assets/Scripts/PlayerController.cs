using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float slayingTime = 0.2F;
	public float gravity = 5;
	public float speed = 8;
	public float jumpPower = 10;
	public SendDamageCollider sendDamageColliderR;	
	public SendDamageCollider sendDamageColliderL;
	
	public AudioClip jumpSound;
	public AudioClip attackSound;
	
	[HideInInspector]
	public bool sceneSwitch = false;
	
	bool isSlaying = false;
	bool lookRight = true;
	bool inputJump = false;
	float velocity = 0;
	Vector3 moveDirection = Vector3.zero;
	CharacterController characterController;
	SpriteController spriteController;
	HealthController healthController;
	
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		spriteController = GetComponent<SpriteController>();
		healthController = GetComponent<HealthController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale > 0)
		InputCheck();
		Move();
		SetAnimation();
		Fight();
		
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        }
	}
	
	
	
	void InputCheck()
	{	
		if ((healthController.currentHealth > 0)&&(!sceneSwitch))
		{
			velocity = Input.GetAxis("Horizontal") * speed;
			
			if (velocity > 0)
				lookRight = true;
		
			if (velocity < 0)
				lookRight = false;
		
			if (Input.GetButtonDown("Jump"))
			{
				inputJump = true;	
			}
			else
			{
				inputJump = false;	
			}
		
			if (Input.GetButtonDown("Fire1")&&!isSlaying)
			{
				isSlaying = true;
				AudioSource.PlayClipAtPoint(attackSound,transform.position,0.4F);
				StartCoroutine(ResetIsSlaying());
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
		if (characterController.isGrounded)
		{
			moveDirection.y = -1;
			
			if(inputJump)
			{	
				AudioSource.PlayClipAtPoint(jumpSound,transform.position,1);
				moveDirection.y = jumpPower;
			}
		}
		else
		{
			moveDirection.y -= gravity;
		}
		
		moveDirection.x = velocity;
		characterController.Move(moveDirection * Time.deltaTime);
	}
	
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
	
	IEnumerator ResetIsSlaying()
	{
		yield return new WaitForSeconds(slayingTime);
		isSlaying = false;
	}
}