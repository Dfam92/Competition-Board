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
    [SerializeField] GameObject continueButton;
    [SerializeField] Sprite standardSprite;
    [SerializeField] AudioManager audioManager;
    [SerializeField] SfxManager sfxManager;

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
        }
        else if (p2WinToggle.isOn == true)
        {
            p1WinToggle.isOn = false;
        }
    }

    public void StartGame()
    {
        mainMenu.transform.DOLocalMoveY(-1093, 1);
        numberOfPlayerMenu.transform.DOLocalMoveY(-8f, 1);
        StartCoroutine(DesactiveMenu(mainMenu));
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
            boxGenerator.SetActive(false);
            battle.p2IsDifferent = false;
            StartAnimation();
            StartCoroutine(SelectPlayers());
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
    private IEnumerator SelectPlayers()
    {
        yield return new WaitForSeconds(3);
        p1Animation.SetActive(false);
        p2Animation.SetActive(false);
        p1Panel.SetActive(true);
        p2Panel.SetActive(true);
        battle.p1Image.gameObject.SetActive(true);
        battle.p2Image.gameObject.SetActive(true);
        continueButton.SetActive(true);
        battle.StartBatlle();
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

    private IEnumerator DesactiveMenu(GameObject menu)
    {
        yield return new WaitForSeconds(3);
        menu.SetActive(false);
    }

    private IEnumerator ActiveMenu(GameObject menu)
    {
        yield return new WaitForSeconds(3);
        menu.SetActive(true);
    }
}
