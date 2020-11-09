using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public Animator anim;
    private string horizontalAxis;
    private string kick;
    private string jump;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (this.name == "Player1")
        {
            horizontalAxis = "Horizontal";
            kick = "Fire1";
            jump = "Jump";
        }
        else
        {
            horizontalAxis = "Horizontal2";
            kick = "Fire2";
            jump = "Jump2";
        }
    }

    void Update()
    {
        var movement = Input.GetAxis(horizontalAxis);
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        Physics2D.IgnoreLayerCollision(8, 9);
        if (Input.GetButtonDown(jump) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown(kick))
        {
            anim.SetBool("butKickPressed", true);
           
        }
        if (Input.GetButtonUp(kick))
        {
            anim.SetBool("butKickPressed", false);
            
        }

    }
}
    