using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class Battle : MonoBehaviour
{
    //[SerializeField] ImageSelection imageLoader;
    [SerializeField] GameObject generateBox;
    [SerializeField] GameManager gameManager;
    [SerializeField] RawImage p1Image;
    [SerializeField] RawImage p2Image;
    [SerializeField] TextMeshProUGUI p1Name;
    [SerializeField] TextMeshProUGUI p2Name;
    [SerializeField] GameObject classification;
    
    public Player player1;
    public Player player2;

    public Text ballInputP1;
    public Text ballInputP2;
    public int ballInputValue1;
    public int ballInputValue2;
    public bool p2IsDifferent;
    public int victoryValue;


    private void OnEnable()
    {
        gameManager.p1WinToggle.isOn = false;
        gameManager.p2WinToggle.isOn = false;
        ballInputP1.text = " ";
        ballInputP2.text = " ";
    }
    private void OnDisable()
    {
        if(!gameManager.finalIsReady)
        {
            int.TryParse(ballInputP1.text, out ballInputValue1);
            int.TryParse(ballInputP2.text, out ballInputValue2);
            victoryValue = 1;
        }
    }
    
    public void StartBatlle()
    {
        while (!p2IsDifferent)
        {
            int firstNumber = Random.Range(0, gameManager.numberOfPlayers);
            int secondNumber = Random.Range(0, gameManager.numberOfPlayers);
            Player p1 = gameManager.players[firstNumber];
            Player p2 = gameManager.players[secondNumber];

            
            if (gameManager.playerCompletedGames.Count == gameManager.numberOfPlayers )
            {
                generateBox.SetActive(false);
                classification.SetActive(true);
                Debug.Log("GameOver");
                break;
            }
            else if (firstNumber != secondNumber && !p1.myGames.Contains(secondNumber) && !p2.myGames.Contains(firstNumber))
            {
                p1.myGames.Add(secondNumber);
                p2.myGames.Add(firstNumber);
                p1.playedGames.text = p1.myGames.Count.ToString();
                p2.playedGames.text = p2.myGames.Count.ToString();
                p1Image.texture = p1.playerImage;
                p2Image.texture = p2.playerImage;
                p1Name.text = p1.savedName.text;
                p2Name.text = p2.savedName.text;
                player1 = p1;
                player2 = p2;
                p2IsDifferent = true;
            }
        }
    }

    
}
