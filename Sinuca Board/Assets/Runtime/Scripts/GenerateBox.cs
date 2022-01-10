using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBox : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerBox playerBox;
    [SerializeField] List<ObjectPos> objectPos;
    public List<PlayerBox> boxes;
    

    // Start is called before the first frame update
    private void OnEnable()
    {
        for (int i = 0; i < gameManager.numberOfPlayers ; i++)
        {
            boxes.Add(playerBox);
            Instantiate(boxes[i], objectPos[i].transform.position, Quaternion.identity, this.transform);
        }
        
    }
    private void Start()
    {
       
    }


}
