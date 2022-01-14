using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    //[SerializeField] ImageSelection imageLoader;
    [SerializeField] GenerateBox generateBox;
    [SerializeField] GameManager gameManager;
    [SerializeField] RawImage p1Image;
    [SerializeField] RawImage p2Image;
    [SerializeField] TextMeshProUGUI p1Name;
    [SerializeField] TextMeshProUGUI p2Name;
    public List<Player> playerCompletedGames;
    public Text ballInputP1;
    public Text ballInputP2;
    public int ballInputValue1;
    public int ballInputValue2;
    public bool p2IsDifferent;

 

    // Start is called before the first frame update
    void Start()
    {
        p1Image.texture = gameManager.players[0].playerImage;
        p2Image.texture = gameManager.players[1].playerImage;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        int.TryParse(ballInputP1.text, out ballInputValue1);
        int.TryParse(ballInputP2.text, out ballInputValue2);
    }

    public void StartBatlle()
    {
        int maxOfGames = gameManager.numberOfPlayers - 1;
        while (!p2IsDifferent)
        {
            int firstNumber = Random.Range(0, gameManager.numberOfPlayers);
            int secondNumber = Random.Range(0, gameManager.numberOfPlayers);
            Player p1 = gameManager.players[firstNumber];
            Player p2 = gameManager.players[secondNumber];
            Debug.Log("p1 =" + firstNumber);
            Debug.Log("p2 =" + secondNumber);
            if (p1.isCompleted && !playerCompletedGames.Contains(p1))
            {
                playerCompletedGames.Add(p1);
            }

            if (p2.isCompleted && !playerCompletedGames.Contains(p2))
            {
                playerCompletedGames.Add(p2);
            }
            if (firstNumber != secondNumber && !p1.myGames.Contains(secondNumber) && !p2.myGames.Contains(firstNumber))
            {
                p1.myGames.Add(secondNumber);
                p2.myGames.Add(firstNumber);
                p1.playedGames.text = p1.myGames.Count.ToString();
                p2.playedGames.text = p2.myGames.Count.ToString();
                p1Name.text = p1.savedName.text;
                p2Name.text = p2.savedName.text;
                
                Debug.Log(p1.myGames.Count);
                Debug.Log(p2.myGames.Count);
                p2IsDifferent = true;
               
            }
            else if(p1.myGames.Count == maxOfGames && p2.myGames.Count == maxOfGames)
            {
               if(playerCompletedGames.Count == maxOfGames)
               {
                    Debug.Log("GameOver");
                    break;
               }
               else
               {
                    p2IsDifferent = true;
                    continue;
               }
            }
            else
            {
                //p2IsDifferent = true;
                Debug.Log("Sortear o proximo");
                return;
            }
        } 
    }

    private void CountGames()
    {

    }

}
