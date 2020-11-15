using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{
    Text instruction;
    // Start is called before the first frame update
    void Start()
    {
        instruction = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.name)
        {
            case "player1Text":
                instruction.text = goalController.player1Goals.ToString();
                break;
            case "player2Text":
                instruction.text = goalController.player2Goals.ToString();
                break;
            case "player1TextS":
                instruction.text = goalController.player1Goals.ToString();
                break;
            case "player2TextS":
                instruction.text = goalController.player2Goals.ToString();
                break;
            case "playerWins":
                if (goalController.player1Goals > goalController.player2Goals){
                    instruction.text = $"PLAYER 1 WINS ({goalController.player1Goals.ToString()} - {goalController.player2Goals.ToString()})";
                }
                else
                {
                    instruction.text = $"PLAYER 2 WINS ({goalController.player2Goals.ToString()} - {goalController.player1Goals.ToString()})";
                }
                break;
        }
    }
}
