using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GenerateBox generateBox;
    [SerializeField] GameObject numberOfPlayerMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject boxGenerator;
    [SerializeField] GameObject battleMenu;
    [SerializeField] Text inputOfPlayersText;
    public int numberOfPlayers;
    private int gamesPlayed;
    private int victories;
    private int ballInRole;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartGame()
    {
        numberOfPlayerMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void SetPlayers()
    {
        int.TryParse(inputOfPlayersText.text, out numberOfPlayers);
        numberOfPlayerMenu.SetActive(false);  
        
        Debug.Log(numberOfPlayers);
        Debug.Log(inputOfPlayersText.text);
        StartCoroutine(MainTitleSpawn()); 
    }

    IEnumerator MainTitleSpawn()
    {
        yield return new WaitForSeconds(1);
        boxGenerator.SetActive(true);
    }

    public void UpdateScore()
    {
        battleMenu.SetActive(false);
        boxGenerator.SetActive(true);
        IncreasePlayedGames(1);
        IncreaseVictories(1);
        BallInRole(1);
       
    }

    public void PlayNextGame()
    {
        battleMenu.SetActive(true);
    }

    private void IncreasePlayedGames(int value)
    {
        gamesPlayed += value;
        generateBox.boxes[0].playedGames.text = " " + gamesPlayed;
    }

    private void IncreaseVictories(int value)
    {
        victories += value;
        generateBox.boxes[0].victoriePoint.text = " " + victories;
    }

    private void BallInRole(int value)
    {
        ballInRole += value;
        generateBox.boxes[0].ballInRole.text = " " + ballInRole;
    }


    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
