using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerBox : MonoBehaviour
{
    private string saveName;
    private string nameOfPlayer;

    public TextMeshProUGUI inputText;
    public TextMeshProUGUI loadedName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nameOfPlayer = PlayerPrefs.GetString("name", "none");
        loadedName.text = nameOfPlayer;
        
    }

    public void SetName()
    {
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
    }
}
