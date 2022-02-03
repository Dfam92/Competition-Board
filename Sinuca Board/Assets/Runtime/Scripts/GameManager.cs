using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text inputOfPlayersText;
    [SerializeField] Battle battle;
    [SerializeField] GameObject numberOfPlayerMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject incorrectValueSetPlayers;
    [SerializeField] GameObject incorrectValueSetWins;
    [SerializeField] GameObject p1Animation;
    [SerializeField] GameObject p2Animation;
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;
    [SerializeField] GameObject p1Panel;
    [SerializeField] GameObject p2Panel;
    [SerializeField] GameObject p1Name;
    [SerializeField] GameObject p2Name;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject creatingBoard;
    [SerializeField] Sprite standardSprite;

    public GameObject incorrectValueSetClassifiedPlayers;
    public GameObject boxGenerator;
    public GameObject battleMenu;
    public GameObject battleFinalMenu;
    public GameObject classificationMenu;
    public List<Player> players;
    public List<Player> playerCompletedGames;
    public Toggle p1WinToggle;
    public Toggle p2WinToggle;

    public int numberOfPlayers;
    public bool finalIsReady;

    private void Update()
    {
        if(p1WinToggle.isOn == true)
        {
            p2WinToggle.isOn = false;
            continueButton.SetActive(true);
        }
        else if (p2WinToggle.isOn == true)
        {
            p1WinToggle.isOn = false;
            continueButton.SetActive(true);

        }
    }

    public void StartGame()
    {
        mainMenu.transform.DOLocalMoveY(-1093, 1);
        numberOfPlayerMenu.transform.DOLocalMoveY(-8f, 1);
        StartCoroutine(DesactiveMenu(mainMenu,3));
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
            StartCoroutine(ActiveMenu(creatingBoard, 0));
            FadeScript.timeOfFade = 1.5f;
            FadeScript.m_Fading = false;
            StartCoroutine(ReArmFade());
            StartCoroutine(ActiveMenu(boxGenerator,5));
            StartCoroutine(ActiveButton(playButton, 10));
            StartCoroutine(DesactiveMenu(creatingBoard, 5));
        }
       
    }

    public void UpdateScore()
    {
        if(p1WinToggle.isOn == true || p2WinToggle.isOn == true)
        {
            battleMenu.SetActive(false);
            boxGenerator.SetActive(true);
            battle.player1.BallInRole(battle.ballInputValue1);
            battle.player2.BallInRole(battle.ballInputValue2);
            IncreaseVictories(battle.player1, battle.player2, battle.victoryValue);
            RearmAnimation();
            incorrectValueSetWins.SetActive(false);
            
        }
        else
        {
            incorrectValueSetWins.SetActive(true);
        }
    }

    public void PlayNextGame()
    {
        if (playerCompletedGames.Count < numberOfPlayers)
        {
            battleMenu.SetActive(true);
            continueButton.SetActive(false);
            boxGenerator.SetActive(false);
            StartAnimation();
            SetPlayerInBattle();
        }
        else
        {
            battleMenu.SetActive(false);
            classificationMenu.SetActive(true);
        }
       
    }

    private void IncreaseVictories(Player p1,Player p2, int value = 0)
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator SelectPlayer1()
    {
        yield return new WaitForSeconds(3);
        p1Name.SetActive(true);
        p1Animation.SetActive(false);
        battle.p1Image.gameObject.SetActive(true);
        battle.StartBatlle();
    }
    private IEnumerator SelectPlayer2()
    {
        yield return new WaitForSeconds(4);
        p2Name.SetActive(true);
        p2Animation.SetActive(false);
        StartCoroutine(ActiveMenu(p1Panel, 0.5f));
        StartCoroutine(ActiveMenu(p2Panel, 0.5f));
        battle.p2Image.gameObject.SetActive(true);
    }
    public void StartAnimation()
    {
        animator1.SetBool("isSorting", true);
        animator2.SetBool("isSorting2", true);
    }
    private void RearmAnimation()
    {
        animator1.SetBool("isSorting", false);
        animator2.SetBool("isSorting2", false);
        p1Panel.SetActive(false);
        p2Panel.SetActive(false);
        continueButton.SetActive(false);
        p1Animation.SetActive(true);
        p2Animation.SetActive(true);
        battle.p1Image.gameObject.SetActive(false);
        battle.p2Image.gameObject.SetActive(false);
        p1Animation.GetComponent<SpriteRenderer>().sprite = standardSprite;
        p2Animation.GetComponent<SpriteRenderer>().sprite = standardSprite;
    }

    private void SetPlayerInBattle()
    {
        battle.p2IsDifferent = false;
        p1Name.SetActive(false);
        p2Name.SetActive(false);
        StartCoroutine(SelectPlayer1());
        StartCoroutine(SelectPlayer2());
    }
    private IEnumerator DesactiveMenu(GameObject menu,float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        menu.SetActive(false);
        FadeScript.timeOfFade = 1f;
        FadeScript.m_Fading = false;
    }

    private IEnumerator ActiveMenu(GameObject menu,float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        menu.SetActive(true);
        
    }
    private IEnumerator ActiveButton(GameObject button, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        button.SetActive(true);
    }

    private IEnumerator ReArmFade()
    {
        yield return new WaitForSeconds(2);
        FadeScript.timeOfFade = 0.5f;
        FadeScript.m_Fading = true;

    }
   
}
