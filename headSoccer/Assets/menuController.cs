using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class menuController : MonoBehaviour
{
    public static string player1Cancha;
    public static string player2Cancha;
    public static string cancha;

    // Start is called before the first frame update
    void Start()
    {
        string path = Directory.GetCurrentDirectory();
        var equipos = Directory
                .EnumerateFiles(path + "/Assets/equipos", "*.png", SearchOption.AllDirectories)
                .Select(Path.GetFileNameWithoutExtension);

        //jugador 1
        player1Cancha = equipos.First();
        var dropdownPlayer1 = GameObject.Find("ddPlayer1").GetComponent<Dropdown>();
        dropdownPlayer1.options.Clear();
        foreach (string option in equipos)
        {
            dropdownPlayer1.options.Add(new Dropdown.OptionData(option));
        }

        dropdownPlayer1.onValueChanged.AddListener(delegate
        {
            onDropdownChange(dropdownPlayer1);
        });


        //jugador 2
        player2Cancha = equipos.First();
        var dropdownPlayer2 = GameObject.Find("ddPlayer2").GetComponent<Dropdown>();
        dropdownPlayer2.options.Clear();
        foreach (string option in equipos)
        {
            dropdownPlayer2.options.Add(new Dropdown.OptionData(option));
        }

        dropdownPlayer2.onValueChanged.AddListener(delegate
        {
            onDropdownChange(dropdownPlayer2);
        });


        var canchas = Directory
                .EnumerateFiles(path + "/Assets/canchas", "*.png", SearchOption.AllDirectories)
                .Select(Path.GetFileNameWithoutExtension);
        cancha = equipos.First();
        var dropdownCancha = GameObject.Find("ddCancha").GetComponent<Dropdown>();
        dropdownCancha.options.Clear();
        foreach (string option in canchas)
        {
            dropdownCancha.options.Add(new Dropdown.OptionData(option));
        }

        dropdownCancha.onValueChanged.AddListener(delegate
        {
            onDropdownChange(dropdownCancha);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDropdownChange(Dropdown dropdown)
    {
        if (dropdown.name == "ddPlayer1")
        {
            player1Cancha = dropdown.captionText.text;
        }
        else if (dropdown.name == "ddPlayer2")
        {
            player2Cancha = dropdown.captionText.text;
        }
        else
        {
            cancha = dropdown.captionText.text;
            Debug.Log(cancha);
        }
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene("Juego");
    }
}
