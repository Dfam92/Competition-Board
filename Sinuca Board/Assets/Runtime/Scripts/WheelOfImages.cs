using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelOfImages : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] float timeToChangeImages;
    [SerializeField] float timeToActiveImages;
    private int imageCount = 0;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(ActiveImages());
    }
    private void Update()
    {
        Debug.Log(imageCount);
        Debug.Log(gameManager.playerImages.Count);
        if (imageCount == gameManager.playerImages.Count)
        {
            imageCount = 0;
        }
    }
  
    public void DisableAllImages()
    {
        for (int i = 0; i < gameManager.animationImages.Count; i++)
        {
            gameManager.animationImages[i].gameObject.SetActive(false);
            gameManager.animationImages2[i].gameObject.SetActive(false);
        }
    }

    IEnumerator ActiveImages()
    {
        yield return new WaitForSeconds(timeToActiveImages);
        gameManager.animationImages[imageCount].gameObject.SetActive(true);
        gameManager.animationImages2[imageCount].gameObject.SetActive(true);
        StartCoroutine(DesactiveImages());
    }
    IEnumerator DesactiveImages()
    {
        yield return new WaitForSeconds(timeToChangeImages);
        gameManager.animationImages[imageCount].gameObject.SetActive(false);
        gameManager.animationImages2[imageCount].gameObject.SetActive(false);
        imageCount++;
        StartCoroutine(ActiveImages());
    }

    //TODO STOP CORROUTINES
}
