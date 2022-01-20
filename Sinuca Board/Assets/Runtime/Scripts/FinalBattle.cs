using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalBattle : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI p1Name;
    [SerializeField] TextMeshProUGUI p2Name;
    [SerializeField] RawImage p1Image;
    [SerializeField] RawImage p2Image;

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
}
