using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class Classification : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] Text inputTextClassified;
    [SerializeField] GameObject classificationButton;
    [SerializeField] GameObject listOfPlayers;

    [SerializeField] List<TextMeshProUGUI> leaderBoardText;
    public List<Player> classifiedPlayers;
    public Dictionary<Player, int> leaderBoard = new Dictionary<Player, int>();
    public Dictionary<Player, int> classificationByBalls = new Dictionary<Player, int>();

    private int numberOfClassified;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (gameManager.playerCompletedGames.Count == gameManager.numberOfPlayers)
        {
            Debug.Log("OK");
            for (int i = 0; i < gameManager.numberOfPlayers; i++)
            {
                classificationByBalls.Add(gameManager.players[i], gameManager.players[i].balls);

            }
        }
    }

    public void StartClassification()
    {
        //Ordena o dicionario conforme o Key ou Value(atenção ao final da sentença.);
        foreach (KeyValuePair<Player, int> item in classificationByBalls.OrderByDescending(ballsValue => ballsValue.Value))
        {
            classifiedPlayers.Add(item.Key);
           
        }
        
        leaderBoard.Clear();
        for (int i = 0; i < gameManager.numberOfPlayers; i++)
        {
            leaderBoard.Add(classifiedPlayers[i], classifiedPlayers[i].wins);
        }
        classifiedPlayers.Clear();
        foreach (KeyValuePair<Player, int> item in leaderBoard.OrderByDescending(winValue => winValue.Value))
        {
            classifiedPlayers.Add(item.Key);
           
            
        }
        for (int i = 0; i < gameManager.numberOfPlayers; i++)
        {
            leaderBoardText.Add(classifiedPlayers[i].savedName);
            leaderBoardText[i].text = classifiedPlayers[i].savedName.text;
        }

        classificationButton.SetActive(false);
        listOfPlayers.SetActive(true);
    }
    public void SetPlayers()
    {
        int.TryParse(inputTextClassified.text, out numberOfClassified);
        classifiedPlayers.RemoveRange(numberOfClassified, classifiedPlayers.Count - numberOfClassified);
        leaderBoardText.RemoveRange(0, numberOfClassified);
        for (int i = 0; i < leaderBoardText.Count; i++)
        {
            leaderBoardText[i].color = Color.red;
        }

        for (int i = 0; i < numberOfClassified; i++)
        {

            classifiedPlayers[i].gameObjectPosition.SetActive(true);
        }

        StartCoroutine(StartNewFase());

    }

    IEnumerator StartNewFase()
    {
        yield return new WaitForSeconds(5);
        ResetPlayerInformation();
        numberOfClassified = 0;
        gameManager.numberOfPlayers = classifiedPlayers.Count;
        ResetButtons();
        ResetLists();
       
    }

    private void ResetPlayerInformation()
    {
        gameManager.players.Clear();
        for (int i = 0; i < numberOfClassified; i++)
        {
            classifiedPlayers[i].balls = 0;
            classifiedPlayers[i].wins = 0;
            classifiedPlayers[i].myGames.Clear();
            classifiedPlayers[i].victories.text = "-";
            classifiedPlayers[i].playedGames.text = "-";
            classifiedPlayers[i].ballInRole.text = "-";
            classifiedPlayers[i].isCompleted = false;
            gameManager.players.Add(classifiedPlayers[i]);
        }
    }

    private void ResetLists()
    {
        gameManager.playerCompletedGames.Clear();
        leaderBoard.Clear();
        classificationByBalls.Clear();
        leaderBoardText.Clear();
        classifiedPlayers.Clear();
    }

    private void ResetButtons()
    {
        gameManager.boxGenerator.SetActive(true);
        gameManager.battleMenu.SetActive(false);
        gameManager.classificationMenu.SetActive(false);
        classificationButton.SetActive(true);
        listOfPlayers.SetActive(false);
    }
}
