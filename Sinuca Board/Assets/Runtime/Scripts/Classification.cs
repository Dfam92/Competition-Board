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
    void Start()
    {
        if (gameManager.playerCompletedGames.Count == gameManager.numberOfPlayers)
        {
            for (int i = 0; i < gameManager.numberOfPlayers; i++)
            {
                classificationByBalls.Add(gameManager.players[i], gameManager.players[i].balls);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartClassification()
    {
        //Ordena o dicionario conforme o Key ou Value(atenção ao final da sentença.);
        foreach (KeyValuePair<Player, int> item in classificationByBalls.OrderByDescending(ballsValue => ballsValue.Value))
        {
            classifiedPlayers.Add(item.Key);
            Debug.Log($"{item.Key} + {item.Value}");
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
            Debug.Log($"{item.Key} + {item.Value}");
        }
        for (int i = 0; i < gameManager.numberOfPlayers; i++)
        {
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
        for (int i = 0; i < numberOfClassified; i++)
        {
            classifiedPlayers[i].balls = 0;
            classifiedPlayers[i].wins = 0;
            classifiedPlayers[i].myGames.Clear();
            classifiedPlayers[i].victories.text = "-";
            classifiedPlayers[i].playedGames.text = "-";
            classifiedPlayers[i].ballInRole.text = "-";
            classifiedPlayers[i].isCompleted = false;

        }
        gameManager.playerCompletedGames.Clear();
        gameManager.boxGenerator.SetActive(true);
        gameManager.battleMenu.SetActive(false);
        gameManager.classificationMenu.SetActive(false);
    }
}
