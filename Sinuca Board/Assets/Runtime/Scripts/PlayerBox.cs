using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI saveName;
    [SerializeField] TextMeshProUGUI nameOfPlayer;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject playerName;
    public TextMeshProUGUI victoriesValues;
    public TextMeshProUGUI playedGamesValues;
    public TextMeshProUGUI ballsInRoleValues;

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
        victoriesValues.text = " " + 0;
        playedGamesValues.text = " " + 0;
        ballsInRoleValues.text = " " + 0;

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
