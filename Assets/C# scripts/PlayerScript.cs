using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public GameObject Player = null;
    public float playerSpeed = 0.032f;

	enum PlayerState : short {ATK , NUET , DEF};
    private Animator animator = null;
    bool isRight = false;
    bool isJumping = false; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update () 
	{
		if (Input.GetKey(KeyCode.D)) 
		{
            transform.Translate(Vector3.right * playerSpeed);
            if (isRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isRight = false;
            }
            animator.SetFloat("speed", playerSpeed);
		}
		if (Input.GetKey(KeyCode.A)) 
		{
            transform.Translate(Vector3.right * playerSpeed * -1.0f);
            if (!isRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isRight = true;
            }
            animator.SetFloat("speed", -playerSpeed);
		}
        if (Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            while (isJumping == true)
            {
                if (isJumping)
                {
                    rigidbody.AddForce(0.0f, 256.0f, 0.0f);
                }
                else if (!isJumping)
                {
                    rigidbody.AddForce(0.0f , 0.0f , 0.0f);
                }
            }

        }
    }
}


