using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using SimpleFileBrowser;

public class GameManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] GameObject numberOfPlayerMenu;
    [SerializeField] GameObject mainMenu;
    public GameObject creatingBoard;
    public GameObject boxGenerator;
    public GameObject battleMenu;
    public GameObject battleFinalMenu;
    public GameObject classificationMenu;
    public WheelOfImages wheelOfImages;
    public WheelOfImages wheelOfImages2;

    [Header("Players UI's")]
    [SerializeField] Text inputOfPlayersText;
    [SerializeField] Battle battle;
    [SerializeField] GameObject incorrectValueSetPlayers;
    [SerializeField] GameObject incorrectValueSetWins;
    [SerializeField] GameObject p1Panel;
    [SerializeField] GameObject p2Panel;
    [SerializeField] GameObject p1Name;
    [SerializeField] GameObject p2Name;
    public GameObject blackBoard;
    public Toggle p1WinToggle;
    public Toggle p2WinToggle;
    public GameObject nameNotAssigned;


    [Header("General Buttons and Texts")]
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject playButton;
    public GameObject incorrectValueSetClassifiedPlayers;


    [Header("Specifics instances")]
    public Sprite standardSprite;
    [SerializeField] SfxManager sfxManager;
    [SerializeField] AudioManager audioManager;
    [SerializeField] RawImage vsImage;
    public GameObject mainEventSystem;

    [Header(" ")]
    public List<Player> players;
    public List<Player> playerCompletedGames;
    public List<Texture2D> playerImages;
    public List<RawImage> animationImages;
    public List<RawImage> animationImages2;
    public int numberOfPlayers;
    public bool finalIsReady;
    public bool browserIsActive;
    private bool imagesWereSetted;
    Vector3 standardVsPos;
    Vector3 standardP1Panel;
    Vector3 standardP2Panel;


    private void Start()
    {
        standardVsPos = vsImage.transform.position;
        standardP1Panel = p1Panel.transform.position;
        standardP2Panel = p2Panel.transform.position;
        
    }
    private void Update()
    {
        CheckVictory();
        // how the fileBrowser has your own EventSystem this was done for makes sure of only 1 is active in the runtime.
        if(!FileBrowser.IsOpen)
        {
            mainEventSystem.SetActive(true);
            if(FileBrowser.Success)
            {
                blackBoard.SetActive(false);
            }
            else
            {
                blackBoard.SetActive(false);
            }
             
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
            StartCoroutine(DesactiveMenu(creatingBoard, 5));
        }
       
    }

    public void OpenBrowser()
    {
        if (!browserIsActive)
        {
            FileBrowser.ShowSaveDialog(null, null, FileBrowser.PickMode.Files, false, " ", " ", "Save As", "Save");
            browserIsActive = true;
            mainEventSystem.SetActive(false);
            
        }

    }

    public void CheckAllPlayerDone()
    {
        if (playerImages.Count == numberOfPlayers)
        {
            playButton.SetActive(true);
        }
    }

    public void PlayNextGame()
    {
        if (playerCompletedGames.Count < numberOfPlayers)
        {
            battleMenu.SetActive(true);
            continueButton.SetActive(false);
            boxGenerator.SetActive(false);
            SetPlayerInBattle();
            sfxManager.SpinSound();
            RestartUIBattlePos();
            audioManager.audioSource.DOFade(0, 5);
            playButton.SetActive(false);
            InputImagesInWhells();
            wheelOfImages.gameObject.SetActive(true);
            wheelOfImages2.gameObject.SetActive(true);

        }
        else
        {
            battleMenu.SetActive(false);
            classificationMenu.SetActive(true);
            audioManager.DrumLoop();
        }

    }

    private void InputImagesInWhells()
    {
        if (!imagesWereSetted)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                animationImages[i].texture = playerImages[i];
                animationImages2[i].texture = playerImages[i];
            }
            imagesWereSetted = true;
        }
    }

    private void SetPlayerInBattle()
    {
        battle.p2IsDifferent = false;
        p1Name.SetActive(false);
        p2Name.SetActive(false);
        StartCoroutine(SelectPlayer1());
        StartCoroutine(SelectPlayer2());
    }

    private IEnumerator SelectPlayer1()
    {
        yield return new WaitForSeconds(3);
        p1Name.SetActive(true);
        battle.p1Image.gameObject.SetActive(true);
        sfxManager.SelectSound();
        battle.StartBatlle();
        //wheelOfImages.DisableWheel1();
        wheelOfImages.gameObject.SetActive(false);
    }
    private IEnumerator SelectPlayer2()
    {
        yield return new WaitForSeconds(4);
        p2Name.SetActive(true);

        StartCoroutine(ActiveMenu(p1Panel, 0.5f));
        StartCoroutine(ActiveMenu(p2Panel, 0.5f));
        sfxManager.SelectSound();
        battle.p2Image.gameObject.SetActive(true);
        vsImage.transform.DOLocalMoveZ(0, 0.75f);
        p1Panel.transform.DOLocalMoveZ(0, 0.75f);
        p2Panel.transform.DOLocalMoveZ(0, 0.75f);
        audioManager.BattleMusics();
        //wheelOfImages2.DisableWheel2();
        wheelOfImages2.gameObject.SetActive(false);
    }
   
    private void CheckVictory()
    {
        if (p1WinToggle.isOn == true)
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
            audioManager.audioSource.DOFade(0, 2);
            StartCoroutine(audioManager.ChangeToMAinMusic(1));
            StartCoroutine(ActiveButton(playButton, 2));
            incorrectValueSetWins.SetActive(false);
            wheelOfImages.DisableAll();
        }
        else
        {
            incorrectValueSetWins.SetActive(true);
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

    private void RearmAnimation()
    {
        p1Panel.SetActive(false);
        p2Panel.SetActive(false);
        continueButton.SetActive(false);
        battle.p1Image.gameObject.SetActive(false);
        battle.p2Image.gameObject.SetActive(false);
    }

    private void RestartUIBattlePos()
    {
        vsImage.transform.position = standardVsPos;
        p1Panel.transform.position = standardP1Panel;
        p2Panel.transform.position = standardP2Panel;
    }

    public void Restart()
    {
        audioManager.enabled = false;
        sfxManager.enabled = false;
        Player.isSetImageButtonActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowSafetyBlackBoard()
    {
        blackBoard.SetActive(true);
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
        yield return new WaitForSeconds(3);
        FadeScript.timeOfFade = 0.5f;
        FadeScript.m_Fading = true;

    }
   
}
