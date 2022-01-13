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
    public Text ballInputP1;
    public Text ballInputP2;
    public int ballInputValue1;
    public int ballInputValue2;
    public bool p2IsDifferent;

    int[,] possibleGames;

    // Start is called before the first frame update
    void Start()
    {
        
        p1Image.texture = gameManager.players[0].playerImage;
        p2Image.texture = gameManager.players[1].playerImage;
        p1Name.text = gameManager.players[0].savedName.text;
        p2Name.text = gameManager.players[1].savedName.text;

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
       

        while (!p2IsDifferent)
        {
            var firstNumber = Random.Range(0, gameManager.players.Count);
            var secondNumber = Random.Range(0, gameManager.players.Count);
            Player p1 = gameManager.players[firstNumber];
            Player p2 = gameManager.players[secondNumber];
            
            if (firstNumber != secondNumber)
            {
                possibleGames = new int[firstNumber, secondNumber];
                Debug.Log(firstNumber + "= p1");
                Debug.Log(secondNumber+ "= p2");
                Debug.Log(possibleGames);
                print(possibleGames);
                p2IsDifferent = true;
            }
        }

        
    }

}
