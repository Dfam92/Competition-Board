using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public TextMeshProUGUI victories;
    public TextMeshProUGUI playedGames;
    public TextMeshProUGUI ballInRole;
    public Texture2D playerImage;
    public List<int> myGames;
    public TextMeshProUGUI savedName;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject showName;
    [SerializeField] TextMeshProUGUI playerName;
    public bool isCompleted;

    private void Start()
    {
        victories.text = "-";
        playedGames.text = "-";
        ballInRole.text = "-";
    }
    private void Update()
    {
        if(myGames.Count == gameManager.numberOfPlayers-1)
        {
            isCompleted = true;
        }
        
    }
    public void SetName()
    {
        savedName.text = playerName.text;
        showName.SetActive(true);
        inputField.SetActive(false);
        
    }
}
