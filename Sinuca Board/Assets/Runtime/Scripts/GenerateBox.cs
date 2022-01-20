using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateBox : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public List<GameObject> playerPos;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < gameManager.numberOfPlayers; i++)
        {
            playerPos[i].SetActive(true);
        }
    }
    public void DisableAll()
    {
        for (int i = 0; i < gameManager.numberOfPlayers; i++)
        {
            playerPos[i].SetActive(false);
        }
    }
}
