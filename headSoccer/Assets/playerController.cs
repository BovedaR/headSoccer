using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public Animator anim;

    private Rigidbody2D _rigidbody;

    GameObject Boot;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Boot = GameObject.Find("Boot");
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("butKickPressed", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("butKickPressed", false);
        }

    }
}
    