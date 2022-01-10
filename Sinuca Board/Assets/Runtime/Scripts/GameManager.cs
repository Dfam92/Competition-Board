using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject numberOfPlayerMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject boxGenerator;
    [SerializeField] Text inputOfPlayersText;
    public int numberOfPlayers;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartGame()
    {
        numberOfPlayerMenu.SetActive(true);
        mainMenu.SetActive(false);

    }

    public void SetPlayers()
    {
        int.TryParse(inputOfPlayersText.text, out numberOfPlayers);
        numberOfPlayerMenu.SetActive(false);  
        
        Debug.Log(numberOfPlayers);
        Debug.Log(inputOfPlayersText.text);
        StartCoroutine(MainTitleSpawn());
        
    }

    IEnumerator MainTitleSpawn()
    {
        yield return new WaitForSeconds(1);
        boxGenerator.SetActive(true);

    }
}
