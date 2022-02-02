using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject showName;
    [SerializeField] TextMeshProUGUI playerName;

    public GameObject gameObjectPosition;
    public TextMeshProUGUI victories;
    public TextMeshProUGUI playedGames;
    public TextMeshProUGUI ballInRole;
    public Texture2D playerImage;
    public List<int> myGames;
    public TextMeshProUGUI savedName;
    
    public bool isCompleted;
    public int balls;
    public int wins;

    private void Start()
    {
        victories.text = "-";
        playedGames.text = "-";
        ballInRole.text = "-";
        savedName.text = "";
    }

    public void BallInRole(int value)
    {
        this.balls += value;
        this.ballInRole.text = " " + this.balls;
    }
    private void Update()
    {
        if(myGames.Count == gameManager.numberOfPlayers-1 && !isCompleted)
        {
            gameManager.playerCompletedGames.Add(this);
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
