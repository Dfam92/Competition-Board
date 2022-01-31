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
    [SerializeField] List<TextMeshProUGUI> classificationBoard;

    public List<Player> classifiedPlayers;
    public Dictionary<Player, int> leaderBoard = new Dictionary<Player, int>();
    public Dictionary<Player, int> classificationByBalls = new Dictionary<Player, int>();

    private int numberOfClassified;
    
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < classificationBoard.Count; i++)
        {
            classificationBoard[i].text = " ";
        }
    }
    void OnEnable()
    {
        if (gameManager.playerCompletedGames.Count == gameManager.numberOfPlayers)
        {
            
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
        
        for (int i = 0; i < classifiedPlayers.Count; i++)
        {
            leaderBoardText.Add(classifiedPlayers[i].savedName);
            classificationBoard[i].text = leaderBoardText[i].text;
        }
       
        classificationButton.SetActive(false);
        listOfPlayers.SetActive(true);
    }
    public void SetPlayers()
    {
        int.TryParse(inputTextClassified.text, out numberOfClassified);
        if(numberOfClassified >= classifiedPlayers.Count || numberOfClassified <= 1)
        {
            gameManager.incorrectValueSetClassifiedPlayers.SetActive(true);
        }
        else
        {
            for (int i = numberOfClassified; i < classifiedPlayers.Count; i++)
            {
                classificationBoard[i].color = Color.red;
            }

            classifiedPlayers.RemoveRange(numberOfClassified, classifiedPlayers.Count - numberOfClassified);

            for (int i = 0; i < numberOfClassified; i++)
            {

                classifiedPlayers[i].gameObjectPosition.SetActive(true);
            }

            if (classifiedPlayers.Count > 2)
            {
                StartCoroutine(StartNewPhase());
            }
            else
            {
                gameManager.finalIsReady = true;
                StartCoroutine(StartFinalPhase());
            }
            gameManager.incorrectValueSetClassifiedPlayers.SetActive(false);
        }

       
    }

    IEnumerator StartNewPhase()
    {
        yield return new WaitForSeconds(5);
        ResetPlayerInformation();
        ResetButtons();
        ResetLists();
        numberOfClassified = 0;
        gameManager.numberOfPlayers = gameManager.players.Count;
    }
    IEnumerator StartFinalPhase()
    {
        yield return new WaitForSeconds(5);
        ResetPlayerInformation();
        ResetButtons();
        ResetLists();
        Debug.Log("FinalStarted");
        gameManager.battleFinalMenu.SetActive(true);
        gameManager.boxGenerator.SetActive(false);
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
