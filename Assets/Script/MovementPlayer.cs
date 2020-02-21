using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

	private Rigidbody2D player;
	private Animator animator;
	public float Speed;

    public static bool lockControls = false;
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (lockControls)
        {

            player.velocity = Vector2.zero;
            return;
        }

		float valueX = Input.GetAxisRaw("Horizontal");
		float valueY = Input.GetAxisRaw("Vertical");

		Vector2 Movement = new Vector2(valueX, valueY);

		if(Movement != Vector2.zero)
		{
			animator.SetBool("Move", true);
			Movement.Normalize();
		}
		else
		{
			animator.SetBool("Move", false);
        }

		animator.SetFloat("MoveX", Movement.x);
		animator.SetFloat("MoveY", Movement.y);
		player.velocity = Speed * Movement;
    }
}
