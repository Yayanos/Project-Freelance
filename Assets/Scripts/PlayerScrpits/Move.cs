using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	private float moveSpeed;
	public float minMoveSpeed = 100;
	public float maxMoveSpeed = 150;
	public float rotateSpeed = 10;
	
	public Transform muzzle;
	public Rigidbody bullet;
	public float bulletSpeed = 150;
	
	private Transform target;
	
	public PointerScript mainCameraPointer	= null;
	
	public AudioClip laserSound;
	
	public GameObject thrusterParticle;
	public GameObject thrusterSound;
	private GameObject thrusterSoundClone;
	
	public GameObject boostParticle;
	public GameObject boostSound;
	private GameObject boostSoundClone;
	
	private bool boosting = false;
	
	// Update is called once per frame
	void Start ()
	{
		mainCameraPointer = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PointerScript>();
		ThrusterOff();
		BoostOff();
	}
	
	void Update () 
	{
		Bullet();
		LookAtCursor();
			
	}
	
	void FixedUpdate()
	{
		Movement();
	}


	private void Movement()
	{
		if (Input.GetAxis("Vertical") > .02f)
		{
			rigidbody.AddForce(transform.forward   * moveSpeed);
			
			if (!boosting)
			{
				ThrusterOn();
				BoostOff();
			}
			else
			{
				ThrusterOff();
				BoostOn();
			}
		}
		else
		{
			ThrusterOff();
			BoostOff();
		}
		if (boosting)
		{
			moveSpeed = maxMoveSpeed;	
		}
		else
		{
			moveSpeed = minMoveSpeed;	
		}
		
		if (Input.GetKey(KeyCode.Q))
		{
			boosting = true;	
		}
		else
		{
			boosting = false;	
		}
		
	}
	
	private void Bullet()
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			Rigidbody clone;
			clone = Instantiate(bullet, muzzle.position, muzzle.rotation) as Rigidbody;
			clone.velocity = transform.forward * moveSpeed;
			
			clone.gameObject.name = transform.name;
			
			AudioSource.PlayClipAtPoint(laserSound, transform.position);
		}
	}
	
	private void LookAtCursor()
	{
		Vector3 saveRot	= transform.eulerAngles;
		transform.LookAt(mainCameraPointer.GetMouseTarget(), Vector3.forward);
		transform.eulerAngles = new Vector3(saveRot.x, transform.eulerAngles.y, saveRot.z);
		
	}
	
	private void ThrusterOn()
	{
		thrusterParticle.particleEmitter.emit = true;
		
		if (thrusterSoundClone == null)
		{
			thrusterSoundClone = Instantiate(thrusterSound, transform.position, transform.rotation) as GameObject;	
		}
		else
		{
			thrusterSoundClone.transform.parent = transform;
			thrusterSoundClone.transform.position = transform.position;
		}
	}
	
	private void ThrusterOff()
	{
		thrusterParticle.particleEmitter.emit = false;
		
		Destroy(thrusterSoundClone);
	}
	
	private void BoostOn()
	{
		boostParticle.particleEmitter.emit = true;
		
		if (boostSoundClone == null)
		{
			boostSoundClone = Instantiate(boostSound, transform.position, transform.rotation) as GameObject;	
		}
		else 
		{
			boostSoundClone.transform.parent = transform;
			boostSoundClone.transform.position = transform.position;
		}
	}	
	
	private void BoostOff()
	{
		boostParticle.particleEmitter.emit = false;
		
		Destroy(boostSoundClone);
	}
	
}

