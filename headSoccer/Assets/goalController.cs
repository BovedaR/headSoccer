using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalController : MonoBehaviour
{
    public static int player1Goals = 0;
    public static int player2Goals = 0;

    GameObject Ball;
    GameObject Player1;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.Find("Ball");
        Player1 = GameObject.Find("Player1");
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
                Debug.Log(player1Goals);
            }
            else
            {
                player2Goals++;
                Debug.Log(player2Goals);
            }

            //TODO: Player2
            Player1.transform.position = new Vector3(-6, -4, 0);

            //TODO: Congelar pelota X tiempo
            Ball.transform.position = new Vector3(0, 3, 0);
            Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }

}
