using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI victories;
    public TextMeshProUGUI playedGames;
    public TextMeshProUGUI ballInRole;
    public Texture2D playerImage;
    [SerializeField] TextMeshProUGUI playerName;
    public TextMeshProUGUI savedName;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject showName;

    private void Start()
    {
        victories.text = "-";
        playedGames.text = "-";
        ballInRole.text = "-";
    }

    public void SetName()
    {
        savedName.text = playerName.text;
        showName.SetActive(true);
        inputField.SetActive(false);
        
    }
}
