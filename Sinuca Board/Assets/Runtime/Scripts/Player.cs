using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleFileBrowser;



public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject showName;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] private int playerID;
    public GameObject gameObjectPosition;
    public TextMeshProUGUI victories;
    public TextMeshProUGUI playedGames;
    public TextMeshProUGUI ballInRole;
    public Texture2D playerImage;
    public string playerImagePath;
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
    public void SetImage()
    {
        //TODO Create a button to set Images ForEachPlayer.
            if (FileBrowser.Success)
            {
                this.playerImagePath = FileBrowser.Result[0];
                WWW localFile = new WWW(this.playerImagePath);
                this.playerImage = localFile.texture;
                
            }
            else
            {
                this.playerImage = null;
                
            }
    }
}
