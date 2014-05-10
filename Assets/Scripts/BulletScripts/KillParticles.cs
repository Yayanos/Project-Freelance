using UnityEngine;
using System.Collections;

public class KillParticles : MonoBehaviour
{
	private bool createdParticles	= false;
	
	private void Update()
	{
		if (createdParticles && particleEmitter.particleCount == 0)
			GameObject.Destroy(gameObject);
		
		if (particleEmitter.particleCount > 0)
			createdParticles = true;
	}
}