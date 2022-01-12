using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] GenerateBox generateBox;
    [SerializeField] GameManager gameManager;
    public Text ballInputP1;
    public Text ballInputP2;
    public int ballInputValue1;
    public int ballInputValue2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        int.TryParse(ballInputP1.text, out ballInputValue1);
        int.TryParse(ballInputP2.text, out ballInputValue2);
    }

    public void StartBatlle()
    {
        var p1 = gameManager.players[Random.Range(0, generateBox.boxes.Count)];
        var p2 = gameManager.players[Random.Range(0, generateBox.boxes.Count)];

        do
        {
            p2 = gameManager.players[Random.Range(0, generateBox.boxes.Count)];
        } while (p2 == p1);
       
       
        Debug.Log(p1 + " = p1");
        Debug.Log(p2 + "= p2");
    }

}
