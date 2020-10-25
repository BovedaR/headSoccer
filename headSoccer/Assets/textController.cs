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
        if (this.name == "player1Text")
        {
            instruction.text = goalController.player1Goals.ToString();
        }
        else
        {
            instruction.text  = goalController.player2Goals.ToString();
        }
    }
}
