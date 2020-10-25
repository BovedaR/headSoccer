using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalController : MonoBehaviour
{
    public static int player1Goals = 0;
    public static int player2Goals = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {
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
        
        }
    } 
}
