using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float spped;

    private Animator animator;
    private SpriteRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        transform.Translate(dx * spped * Time.deltaTime, 0, 0);

        if (Mathf.Abs(dx) > 0.000001f)
            animator.SetBool("walking", true);
        else
            animator.SetBool("walking", false);


        if (dx < 0)
            renderer.flipX = true;
        else
            renderer.flipX = false;
    }
}
