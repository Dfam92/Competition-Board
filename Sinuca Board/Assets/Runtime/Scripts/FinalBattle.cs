using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class FinalBattle : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI p1Name;
    [SerializeField] TextMeshProUGUI p2Name;
    [SerializeField] RawImage p1Image;
    [SerializeField] RawImage p2Image;
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    [SerializeField] Toggle p1FinalWinToggle1;
    [SerializeField] Toggle p2FinalWinToggle1;
    [SerializeField] Toggle p1FinalWinToggle2;
    [SerializeField] Toggle p2FinalWinToggle2;
    [SerializeField] Toggle p1FinalWinToggle3;
    [SerializeField] Toggle p2FinalWinToggle3;
    [SerializeField] GameObject p1Panel;
    [SerializeField] GameObject p2Panel;
    [SerializeField] GameObject finalObjects;
    [SerializeField] Image LaurelChampion;
    [SerializeField] RawImage vsImage;
    [SerializeField] SfxManager sfxManager;
    private int p1Pontuation;
    private int p2Pontuation;
    private bool p1Champion;
    private bool p2Champion;
    private bool playHeartBeat;
    private bool p1fase1;
    private bool p1fase2;
    private bool p1fase3;
    private bool p2fase1;
    private bool p2fase2;
    private bool p2fase3;
    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        Player p1 = gameManager.players[0];
        Player p2 = gameManager.players[1];
        p1Image.texture = p1.playerImage;
        p2Image.texture = p2.playerImage;
        p1Name.text = p1.savedName.text;
        p2Name.text = p2.savedName.text;
               
    }
    void Update()
    {
        StartFinal();
    }
    void OnEnable()
    {
        sfxManager.FinalRound();
        vsImage.transform.DOLocalMoveZ(0, 0.75f);
        p1Panel.transform.DOLocalMoveZ(0, 0.75f);
        p2Panel.transform.DOLocalMoveZ(0, 0.75f);
        StartFinal();
    }

    public void ChampionDecision()
    {
        if (p1Champion == true)
        {
            p2.SetActive(false);
            p1Panel.SetActive(false);
            HideObjects();
            p1.transform.DOLocalMoveX(67, 2);
            ShowLaurel();
            p1Champion = false;
            p1Pontuation = 0;
            StartCoroutine(sfxManager.TempRocket(1));

        }

        if (p2Champion == true)
        {
            p1.SetActive(false);
            p2Panel.SetActive(false);
            HideObjects();
            p2.transform.DOLocalMoveX(-35f, 2);
            ShowLaurel();
            p2Champion = false;
            p2Pontuation = 0;
            StartCoroutine(sfxManager.TempRocket(1));
        }
        
    }

    private void HideObjects()
    {
        finalObjects.SetActive(false);
    }
    
    private void ShowLaurel()
    {
        LaurelChampion.gameObject.SetActive(true);
        FadeScript.m_Fading = true;
        FadeScript.timeOfFade = 1.5f;
    }
    private void StartFinal()
    {
        if(p1Pontuation == 2 && playHeartBeat == false || p2Pontuation == 2 && playHeartBeat == false)
        {
            audioManager.audioSource.DOFade(0, 5);
            sfxManager.HearthBeatSound();
            playHeartBeat = true;
        }


        if (p1FinalWinToggle1.isOn == true && p1fase1 == false)
        {
            p1Pontuation += 1;
            p1FinalWinToggle1.interactable = false;
            p1fase1 = true;
            
        }
        else if(p1FinalWinToggle2.isOn == true && p1fase2 == false)
        {
            p1Pontuation += 1;
            p1FinalWinToggle2.interactable = false;
            p1fase2 = true;
        }
        else if (p1FinalWinToggle3.isOn == true && p1fase3 == false)
        {
            p1Pontuation += 1;
            p1FinalWinToggle3.interactable = false;
            p1fase3 = true;
        }
        else if(p1Pontuation == 3)
        {
            p1Champion = true;
        }


        if (p2FinalWinToggle1.isOn == true && p2fase1 == false)
        {
            p2Pontuation += 1;
            p2FinalWinToggle1.interactable = false;
            p2fase1 = true;
        }
        else if (p2FinalWinToggle2.isOn == true && p2fase2 == false)
        {
            p2Pontuation += 1;
            p2FinalWinToggle2.interactable = false;
            p2fase2 = true;
        }
        else if (p2FinalWinToggle3.isOn == true && p2fase3 == false)
        {
            p2Pontuation += 1;
            p2FinalWinToggle3.interactable = false;
            p2fase3 = true;
        }
        else if(p2Pontuation == 3)
        {
            p2Champion = true;

        }

        ChampionDecision();

    }

   
}
