using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{	
	public int playerId 			= 1;
	public GameObject Player = null;
	public GameObject bullet = null;
	public float bulletSpeed = 8.0f;
    public float playerSpeed = 0.032f;
	public float jumpForce = 256.0f;
	
    private Animator animator = null;
    bool isRight = false;
	bool isJumping = false;
//	bool isClimbing = false;
	//bool again = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update () 
	{	
		if(playerId == 1)
		{
			if (Input.GetKey(KeyCode.D)) 
			{

 	           transform.Translate(Vector3.right * playerSpeed);
    	        if (isRight)
        	    {
            	    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
               	 isRight = false;
            	}
            	animator.SetFloat("Speed", playerSpeed);
			}
			else if (Input.GetKey(KeyCode.A)) 
			{
            	transform.Translate(Vector3.right * playerSpeed * -1.0f);
            	if (!isRight)
            	{
                	transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                	isRight = true;
            	}
            	animator.SetFloat("Speed", -playerSpeed);
			}
			else
				animator.SetFloat("Speed", 0);
       
			if (!isJumping && Input.GetKey(KeyCode.Space))
			{		 	
				//this.transform.Translate(Vector3.up * jumpForce);
				rigidbody.AddForce(0 , jumpForce  , 0);
				animator.SetBool("Jump", true);
				isJumping = true;
			}

			if (Input.GetKey (KeyCode.J)) 
			{
				animator.SetBool ("Attack", true);

			}

			if (Input.GetKeyDown(KeyCode.K)) 
			{
				Debug.Log("Shotmotherfucker!!");
				GameObject shot = GameObject.Instantiate(bullet, transform.position, transform.rotation ) as GameObject;
				shot.rigidbody2D.AddForce(transform.right * transform.localScale.x * bulletSpeed);
				shot.rigidbody2D.angularVelocity = -1500.0f;
				animator.SetBool ("Special", true);
			}

			if (Input.GetKey (KeyCode.S))
			{
				animator.SetBool ("Crouch", true);
			}
			else if((Input.GetKey (KeyCode.S)))
			{
				animator.SetBool ("Crouch", false);
			}

		}

	}	
	
	private void OnCollisionEnter(Collision c)
	{
		Debug.Log("Check if Jump");
		if (c.rigidbody != null &&
		    c.rigidbody.mass <= rigidbody.mass &&
		    c.rigidbody.velocity.y > 0.0f)
		{
			return;
		}
		
		if (c.contacts[0].normal.y > 0.1f)
			isJumping = false;
	}

	private void OnTriggerStay(Collider c)
	{
		Debug.Log("Dead");
		if(c.tag == "DeadBounds")
		{
			Application.LoadLevel(Application.loadedLevel);
			//Destroy(gameObject);
		}
		
	}

}
