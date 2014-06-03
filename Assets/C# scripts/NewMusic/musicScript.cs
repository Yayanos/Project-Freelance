using UnityEngine;
using System.Collections;

public class musicScript : MonoBehaviour 
	{
		public AudioClip bgm = null;
		private GameObject fadeOut = null;
		private GameObject fadeIn = null;
		
		public float fadeTime = 1.0f;
		
		private void Update()
		{
			if (fadeOut != null && fadeIn != null)
			{
				fadeOut.audio.volume -= (1 / fadeTime) * Time.deltaTime;
				fadeIn.audio.volume += (1 / fadeTime) * Time.deltaTime;
				
				if (fadeIn.audio.volume >= 1)
				{
					fadeIn.audio.volume = 1;
					fadeOut.audio.volume = 0;
					fadeOut.audio.Pause();
					
					fadeIn = null;
					fadeOut = null;
				}
			}
		}
		
		private void OnTriggerEnter(Collider c)
		{
			if (c.tag == "Player")
			{
				GameObject bgmA = GameObject.FindGameObjectWithTag("MusicA");
				GameObject bgmB = GameObject.FindGameObjectWithTag("MusicB");
				
				if (bgmA.audio.isPlaying)
				{
					bgmB.audio.clip = bgm;
					bgmB.audio.volume = 0;
					bgmB.audio.Play();
					
					fadeOut = bgmA;
					fadeIn = bgmB;
				}
				else
				{
					bgmA.audio.clip = bgm;
					bgmA.audio.volume = 0;
					bgmA.audio.Play();
					
					fadeOut = bgmB;
					fadeIn = bgmA;
				}
			}
		}
	}