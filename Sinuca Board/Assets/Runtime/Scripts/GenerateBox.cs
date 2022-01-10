using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBox : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject playerBox;
    [SerializeField] List<ObjectPos> objectPos;
    

    // Start is called before the first frame update
    private void OnEnable()
    {
        for (int i = 0; i < gameManager.numberOfPlayers ; i++)
        {
            Instantiate(playerBox, objectPos[i].transform.position, Quaternion.identity, this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
