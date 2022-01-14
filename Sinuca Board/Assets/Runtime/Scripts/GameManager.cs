using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    [SerializeField] GameObject numberOfPlayerMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject boxGenerator;
    [SerializeField] GameObject battleMenu;
    [SerializeField] Text inputOfPlayersText;
    [SerializeField] Battle battle;
    public List<Player> players;
    private Player playerWhoWin;

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
        //IncreasePlayedGames(playerWhoWin, 1);
        //IncreaseVictories(playerWhoWin,1);
        BallInRole(players[0],battle.ballInputValue1);
        Debug.Log(battle.ballInputP1.text);
    }

    public void PlayNextGame()
    {
        battleMenu.SetActive(true);
        boxGenerator.SetActive(false);
        battle.p2IsDifferent = false;
    }

    private void IncreasePlayedGames(Player player, int value)
    {
        gamesPlayed += value;
        player.playedGames.text =" " + gamesPlayed;
    }

    private void IncreaseVictories(Player player,int value)
    {
        victories += value;
        player.victories.text = " " + victories;
    }

    private void BallInRole(Player player,int value)
    {
        ballInRole += value;
        player.ballInRole.text = " " + ballInRole;
       
    }

    

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
