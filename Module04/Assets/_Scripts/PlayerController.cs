using System.Collections;
using Packages.Rider.Editor.UnitTesting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
	[SerializeField] float jumpForce = 5f;
	[SerializeField] float damageForce = 5f; // 데미지 시 밀려나는 힘
    [SerializeField] float damageJump = 2f; // 데미지 시 위로 밀려나는 힘
	[SerializeField] int health = 3;

    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true;
	private bool isGrounded = true;
	private bool isStun = false;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		animator.SetTrigger("Respawn");
    }

    void Update()
    {
		if (isStun)
			return;
		float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Move", Mathf.Abs(move));
		if (move != 0)
		{
			rb.velocity = new Vector2(move * speed, rb.velocity.y);
		}

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			AudioManager.instance.PlayJump();
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			animator.SetBool("IsJump", true);
			isGrounded = false;
		}
	}

	void TakeDamage(int direction)
	{
		if (isStun)
			return;
		AudioManager.instance.PlayTakeDamage();
		rb.velocity = new Vector2(0, rb.velocity.y);
		animator.SetBool("IsJump", false);
		animator.SetBool("TakeDamage", true);
		Vector2 damageDirection;
		if (facingRight && direction == 1 || !facingRight && direction == -1)
			Flip();
		damageDirection = new Vector2(direction * damageForce, damageJump);
		rb.velocity = new Vector2(rb.velocity.x + damageDirection.x, rb.velocity.y + damageDirection.y);
		health--;
		if (health <= 0)
		{
			Die();
			AudioManager.instance.StopBGM();
			AudioManager.instance.PlayDefeat();
			GameManager.instance.GameOver();
		}
		StartCoroutine(Stun(1f));
		
	}

	void Die()
	{
		animator.SetTrigger("Die");
		Destroy(gameObject, 1f);
	}

	IEnumerator Stun(float time)
	{
		isStun = true;
		yield return new WaitForSeconds(time);
		animator.SetBool("TakeDamage", false);
		isStun = false;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground")
		{
			animator.SetBool("IsJump", false);
			isGrounded = true;
		}
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			Transform enemy = other.gameObject.transform;
			int d = transform.position.x > enemy.position.x ? 1 : -1;
			TakeDamage(d);
		}
	}
}
