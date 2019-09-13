using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
	private float JumpForce = 10;

	public float maxJump;
	public float baseHeight;
	private bool IsJumping;

	public float gravity = 10;
	private float JumpSpeed = 0;

	private float ground;

    private Animator animator;
    private SpriteRenderer renderer;
	private bool IsFlipped;


    // Start is called before the first frame update
    void Start()
    {
		IsFlipped = false;
		IsJumping = false;
		
		ground = transform.position.y;
		baseHeight = ground;


        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
		transform.Translate(dx * speed * Time.deltaTime, 0, 0);

        if (Mathf.Abs(dx) > 0.000001f)
            animator.SetBool("walking", true);
        else
            animator.SetBool("walking", false);


		if (dx < 0 && !IsFlipped)
			IsFlipped= true;
		else if(dx > 0 && IsFlipped)
			IsFlipped = false;
		renderer.flipX = IsFlipped;


		if (Input.GetKeyDown (KeyCode.Space) && !IsJumping) {
			JumpSpeed = JumpForce;
			IsJumping = true;
			//animator.SetBool ("Jumping", true);
		}

		if (IsJumping) {
			transform.position += transform.up * JumpSpeed * Time.deltaTime;
			JumpSpeed -= gravity * Time.deltaTime;
			float height = transform.position.y - baseHeight;

			if (height < 0.0001f) {
				transform.position = new Vector3 (transform.position.x, baseHeight);
				IsJumping = false;
				//animator.SetBool ("Jumping", IsJumping);
			}
		}

    }
}
