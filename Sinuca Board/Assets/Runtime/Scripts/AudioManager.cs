using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip mainTitleClip;



    private void Start()
    {
        audioSource.DOFade(1f, 10);
        PlayClip(mainTitleClip);
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopClip()
    {
        audioSource.Stop();
    }
}
