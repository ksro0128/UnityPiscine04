using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liana : MonoBehaviour
{
    private CircleCollider2D lianaCollider;
	private Animator animator;
	[SerializeField] float detectRange = 3f;

	private int face = 1;


    void Start()
	{
		lianaCollider = GetComponent<CircleCollider2D>();
		animator = GetComponent<Animator>();
		StartCoroutine(DetectPlayer());
	}

	IEnumerator DetectPlayer()
	{
		while (true)
		{
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                float distanceToPlayer = transform.position.x - player.transform.position.x;

                if (distanceToPlayer <= detectRange * face)
				{
					animator.SetTrigger("Attack");
					AudioManager.instance.PlayLianaAttack();
				}
				yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(0.1f);
        }
	}

	public void EnableCollider()
	{
		lianaCollider.offset = new Vector2(0.42f, 4.38f);
		lianaCollider.enabled = true;
	}

	public void MoveCollider1()
	{
		lianaCollider.offset = new Vector2(0.47f, 5.49f);
	}

	public void MoveCollider2()
	{
		lianaCollider.offset = new Vector2(1.51f, 5.88f);
	}

	public void MoveCollider3()
	{
		lianaCollider.offset = new Vector2(1.51f, 6.19f);
	}

	public void MoveCollider4()
	{
		lianaCollider.offset = new Vector2(-3.99f, 6.19f);
	}

	public void MoveCollider5()
	{
		lianaCollider.offset = new Vector2(-3.05f, 3.26f);
	}

	public void MoveCollider6()
	{
		lianaCollider.offset = new Vector2(-3.05f, 1.28f);
	}

	public void MoveCollider7()
	{
		lianaCollider.offset = new Vector2(-2.68f, 2.24f);
	}

	public void MoveCollider8()
	{
		lianaCollider.offset = new Vector2(-1.65f, 3.01f);
	}

	public void DisableCollider()
	{
		lianaCollider.enabled = false;
	}
}
