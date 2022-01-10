using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScores : MonoBehaviour
{
    [SerializeField] GenerateBox generateBox;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore()
    {
        generateBox.boxes[0].victoriesValues.text += 1;
    }
}
