using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBox : MonoBehaviour
{
    [SerializeField] GameObject playerBox;
    [SerializeField] List<ObjectPos> objectPos;
    [SerializeField] int numberOfPlayers;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < numberOfPlayers ; i++)
        {
            Instantiate(playerBox, objectPos[i].transform.position, Quaternion.identity, this.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
