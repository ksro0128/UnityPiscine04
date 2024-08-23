using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager instance;

	[SerializeField] GameObject playerPrefab;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	public void RespawnPlayer()
	{
		if (playerPrefab == null)
		{
			Debug.LogError("Player Prefab is null");
			return;
		}
		Instantiate(playerPrefab, transform.position, Quaternion.identity);
		AudioManager.instance.PlayBGM();
		AudioManager.instance.PlayRespawn();
	}
}
