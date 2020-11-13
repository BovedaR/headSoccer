using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class playerController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public Animator anim;
    private string horizontalAxis;
    private string kick;
    private string jump;
    private Rigidbody2D _rigidbody;
    private AudioSource kickSource;

    private Sprite[] spritesEquipos;
    private Sprite[] spritesCanchas;

    void Start()
    {
        kickSource = this.GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();

        spritesEquipos = Resources.LoadAll<Sprite>("equipos");
        spritesCanchas = Resources.LoadAll<Sprite>("canchas");

        if (this.name == "Player1")
        {
            horizontalAxis = "Horizontal";
            kick = "Fire1";
            jump = "Jump";

            SpriteRenderer spriteR = this.GetComponent<SpriteRenderer>();
            var spriteIndex = Int32.Parse(Convert.ToString(menuController.selectionStack.ToArray()[2]));
            spriteR.sprite = spritesEquipos[spriteIndex];
        }
        else if(this.name == "Player2")
        {
            horizontalAxis = "Horizontal2";
            kick = "Fire2";
            jump = "Jump2";

            SpriteRenderer spriteR = this.GetComponent<SpriteRenderer>();
            var spriteIndex = Int32.Parse(Convert.ToString(menuController.selectionStack.ToArray()[1]));
            spriteR.sprite = spritesEquipos[spriteIndex];
        }
        else
        {
            var spriteIndex = Int32.Parse(Convert.ToString(menuController.selectionStack.ToArray()[0]));
            var spriteR = this.GetComponent<Image> ();
            spriteR.sprite = spritesCanchas[spriteIndex];
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ball")
        {
            kickSource.Play();
        }
    }
}
    