using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

	private AudioSource BGMSource;
	[SerializeField] AudioClip BGM;

	private AudioSource jumpSource;
	[SerializeField] AudioClip jump;

	private AudioSource takeDamageSource;
	[SerializeField] AudioClip takeDamage;

	private AudioSource defeatSource;
	[SerializeField] AudioClip defeat;

	private AudioSource respawnSource;
	[SerializeField] AudioClip respawn;

	private AudioSource LianaAttackSource;
	[SerializeField] AudioClip LianaAttack;

	private AudioSource CactusAttackSource;
	[SerializeField] AudioClip CactusAttack;

	
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	void Start()
	{
		BGMSource = gameObject.AddComponent<AudioSource>();
		BGMSource.clip = BGM;
		BGMSource.loop = true;

		jumpSource = gameObject.AddComponent<AudioSource>();
		jumpSource.clip = jump;
		
		takeDamageSource = gameObject.AddComponent<AudioSource>();
		takeDamageSource.clip = takeDamage;

		defeatSource = gameObject.AddComponent<AudioSource>();
		defeatSource.clip = defeat;

		respawnSource = gameObject.AddComponent<AudioSource>();
		respawnSource.clip = respawn;

		LianaAttackSource = gameObject.AddComponent<AudioSource>();
		LianaAttackSource.clip = LianaAttack;

		CactusAttackSource = gameObject.AddComponent<AudioSource>();
		CactusAttackSource.clip = CactusAttack;
	}

	public void PlayBGM()
	{
		BGMSource.Play();
	}

	public void StopBGM()
	{
		BGMSource.Stop();
	}

	public void PlayJump()
	{
		jumpSource.Play();
	}

	public void PlayTakeDamage()
	{
		takeDamageSource.Play();
	}

	public void PlayDefeat()
	{
		defeatSource.Play();
	}

	public void PlayRespawn()
	{
		respawnSource.Play();
	}

	public void PlayLianaAttack()
	{
		LianaAttackSource.Play();
	}

	public void PlayCactusAttack()
	{
		CactusAttackSource.Play();
	}
	
}
