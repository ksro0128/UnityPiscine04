using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
	[SerializeField] Image fadeImage;
	[SerializeField] float fadeDuration = 1f;
	[SerializeField] TMPro.TextMeshProUGUI restartText;

	bool isGameOver = false;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	void Start()
	{
		PlayerSpawnManager.instance.RespawnPlayer();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R) && isGameOver)
		{
			restartText.gameObject.SetActive(false);
			StartCoroutine(FadeIn());
			PlayerSpawnManager.instance.RespawnPlayer();
			isGameOver = false;
		}
	}

	public void GameOver()
	{
		//ScreenFadeout
		isGameOver = true;
		StartCoroutine(FadeOut());
	}

	IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
		restartText.gameObject.SetActive(true);
    }

	IEnumerator FadeIn()
	{
		float elapsedTime = 0f;
		Color color = fadeImage.color;

		while (elapsedTime < fadeDuration)
		{
			elapsedTime += Time.deltaTime;
			color.a = 1 - Mathf.Clamp01(elapsedTime / fadeDuration);
			fadeImage.color = color;
			yield return null;
		}
		restartText.gameObject.SetActive(false);
		color.a = 0f;
		fadeImage.color = color;
	}
}
