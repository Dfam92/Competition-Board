using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text inputOfPlayersText;
    [SerializeField] Battle battle;
    [SerializeField] GameObject numberOfPlayerMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject incorrectValueSetPlayers;
    [SerializeField] GameObject incorrectValueSetWins;

    public GameObject incorrectValueSetClassifiedPlayers;
    public GameObject boxGenerator;
    public GameObject battleMenu;
    public GameObject battleFinalMenu;
    public GameObject classificationMenu;
    
    public List<Player> players;
    public List<Player> playerCompletedGames;
    public int numberOfPlayers;
    public Toggle p1WinToggle;
    public Toggle p2WinToggle;


    public bool finalIsReady;

    public void StartGame()
    {
        numberOfPlayerMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void SetPlayers()
    {
       
        int.TryParse(inputOfPlayersText.text, out numberOfPlayers);
        if(numberOfPlayers > 18 || numberOfPlayers < 3)
        {
            incorrectValueSetPlayers.SetActive(true);
        }
        else
        {
            incorrectValueSetPlayers.SetActive(false);
            numberOfPlayerMenu.SetActive(false);
            StartCoroutine(MainTitleSpawn());
        }
       
    }

    IEnumerator MainTitleSpawn()
    {
        yield return new WaitForSeconds(1);
        boxGenerator.SetActive(true);
    }

    public void UpdateScore()
    {
        if(p1WinToggle.isOn == true || p2WinToggle.isOn == true)
        {
            if (playerCompletedGames.Count < numberOfPlayers)
            {
                battleMenu.SetActive(false);
                boxGenerator.SetActive(true);
                // BallInRole(battle.player1, battle.ballInputValue1, battle.player2, battle.ballInputValue2);
                battle.player1.BallInRole(battle.ballInputValue1);
                battle.player2.BallInRole(battle.ballInputValue2);
                IncreaseVictories(battle.player1, battle.player2, battle.victoryValue);
            }
            else
            {
                battleMenu.SetActive(false);
                classificationMenu.SetActive(true);
            }
            incorrectValueSetWins.SetActive(false);
        }
        else
        {
            incorrectValueSetWins.SetActive(true);
        }
    }

    public void PlayNextGame()
    {
        battleMenu.SetActive(true);
        boxGenerator.SetActive(false);
        battle.p2IsDifferent = false;
        
    }

    /*private void BallInRole(Player p1, int value1, Player p2, int value2)
    {
        if(playerCompletedGames.Count < numberOfPlayers)
        {
            p1.balls += value1;
            p1.ballInRole.text = " " + p1.balls;
            p2.balls += value2;
            p2.ballInRole.text = " " + p2.balls;
        }
    }*/

    private void IncreaseVictories(Player p1,Player p2, int value = 0)
    {
        if(playerCompletedGames.Count < numberOfPlayers)
        {
            if (p1WinToggle.isOn == true)
            {
                p1.wins += value;
                p1.victories.text = " " + p1.wins;
            }
            else if(p2WinToggle.isOn == true)
            {
                p2.wins += value;
                p2.victories.text = " " + p2.wins; 
            }
           
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
