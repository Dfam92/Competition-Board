using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateBox : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] List<GameObject> objectPos;
    

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < gameManager.numberOfPlayers; i++)
        {
            objectPos[i].SetActive(true);
        }
    }


}
