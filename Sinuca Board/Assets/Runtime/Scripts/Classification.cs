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
    [SerializeField] GameObject setClassifiedsButton;
    [SerializeField] GameObject InputField;
    
    public List<Player> classifiedPlayers;
    public Dictionary<Player, int> leaderBoard = new Dictionary<Player,int>();

    private int numberOfClassified;
    // Start is called before the first frame update
    void Start()
    {
        if(gameManager.playerCompletedGames.Count == gameManager.numberOfPlayers)
        {
            for (int i = 0; i < gameManager.numberOfPlayers; i++)
            {
                leaderBoard.Add(gameManager.players[i], gameManager.players[i].wins);
                
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
        foreach (KeyValuePair<Player, int> item in leaderBoard.OrderByDescending(winValue => winValue.Value))
        {
            classifiedPlayers.Add(item.Key);
        }
        classificationButton.SetActive(false);
        setClassifiedsButton.SetActive(true);
        InputField.SetActive(true);
    }
    public void SetPlayers()
    {
        int.TryParse(inputTextClassified.text, out numberOfClassified);
        classifiedPlayers.RemoveRange(numberOfClassified, classifiedPlayers.Count - numberOfClassified);

        for (int i = 0; i < numberOfClassified; i++)
        {
            classifiedPlayers[i].gameObjectPosition.SetActive(true);
        }
        gameManager.boxGenerator.SetActive(true);
        gameManager.battleMenu.SetActive(false);
        gameManager.classificationMenu.SetActive(false);
        
    }
}
