using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalController : MonoBehaviour
{
    public static int player1Goals = 0;
    public static int player2Goals = 0;

    private GameObject Ball;
    private GameObject Player1;
    private GameObject Player2;
    private GameObject Confetti;
    private AudioSource goalSource;

    // Start is called before the first frame update
    void Start()
    {

        goalSource = this.GetComponent<AudioSource>();

        Ball = GameObject.Find("Ball");
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Confetti = GameObject.Find("Confetti");
        Confetti.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            if (this.name == "goal_1")
            {
                player1Goals++;
            }
            else
            {
                player2Goals++;
            }
            goalSource.Play();
            StartCoroutine("goalAction");
        }
    }

    IEnumerator goalAction()
    {   
        Confetti.GetComponent<ParticleSystem>().Play();
        Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        yield return new WaitForSeconds(2);

        Confetti.GetComponent<ParticleSystem>().Stop();

        Player1.transform.position = new Vector3(-6, -4, 0);
        Player2.transform.position = new Vector3(6, -4, 0);

        Ball.transform.position = new Vector3(0, 3, 0);
        
    }
}
