using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioManager;
    [SerializeField] AudioClip mainTitleClip;



    private void Start()
    {
        audioManager.DOFade(1, 10);
        PlayClip(mainTitleClip);
    }

    public void PlayClip(AudioClip clip)
    {
        audioManager.clip = clip;
        audioManager.Play();
    }

    public void StopClip()
    {
        audioManager.Stop();
    }
}
