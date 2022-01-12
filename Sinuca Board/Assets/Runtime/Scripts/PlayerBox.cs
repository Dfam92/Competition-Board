using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI saveName;
    [SerializeField] TextMeshProUGUI nameOfPlayer;
    public TextMeshProUGUI victoriePoint;
    public TextMeshProUGUI playedGames;
    public TextMeshProUGUI ballInRole;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject playerName;
   
    private string loadedName;

    private void Awake()
    {
        loadedName = PlayerPrefs.GetString("PlayerName", nameOfPlayer.text);
        nameOfPlayer.text = loadedName;
    }
    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
    }

    public void SetName()
    {
        nameOfPlayer.text = saveName.text;
        PlayerPrefs.SetString("PlayerName", nameOfPlayer.text);
        inputField.SetActive(false);
        playerName.SetActive(true);

    }

}
