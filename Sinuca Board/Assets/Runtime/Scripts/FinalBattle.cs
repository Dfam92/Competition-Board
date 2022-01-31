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
    [SerializeField] Toggle p1FinalWinToggle;
    [SerializeField] Toggle p2FinalWinToggle;
    [SerializeField] GameObject p1Panel;
    [SerializeField] GameObject p2Panel;
    [SerializeField] GameObject finalObjects;
    [SerializeField] Image LaurelChampion;
    
    
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
    

    public void ChampionDecision()
    {
        if (p1FinalWinToggle.isOn == true)
        {
            p2.SetActive(false);
            p1Panel.SetActive(false);
            HideObjects();
            p1.transform.DOLocalMoveX(67, 2);
            ShowLaurel();

        }
        
        if(p2FinalWinToggle.isOn == true)
        {
            p1.SetActive(false);
            p2Panel.SetActive(false);
            HideObjects();
            p2.transform.DOLocalMoveX(-35f, 2);
            ShowLaurel();

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
    }
    
}
