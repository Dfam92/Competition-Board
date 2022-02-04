using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SfxManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    [SerializeField] AudioClip startSfxClip;
    [SerializeField] AudioClip crayonSfx;
    [SerializeField] AudioClip spinSound;
    [SerializeField] AudioClip selectPlayerSound;
    [SerializeField] AudioClip readySound;
    [SerializeField] AudioClip clickButtonSound;
    
    [SerializeField]  AudioClip drumClickSound;


    public void PlaySfx(AudioClip clip,float value)
    {
        if(sfxAudioSource != null)
        {
            sfxAudioSource.PlayOneShot(clip, value);
        }
        
    }

    public void StartSound()
    {
        PlaySfx(startSfxClip,0.5f);
    }
    
    public void WritingSound()
    {
        PlaySfx(crayonSfx,1);
    }

    public void SpinSound()
    {
        StartCoroutine(StartSpin());
    }

    public void SelectSound()
    {
        PlaySfx(selectPlayerSound, 1);
    }

    public void ClickSound()
    {
        PlaySfx(clickButtonSound, 1);
    }

    private void StopSpinSound()
    {
        sfxAudioSource.loop = false;
        sfxAudioSource.Stop();
        LetsStart();
    }

    public void DrumClick()
    {
        PlaySfx(drumClickSound, 1);
    }
    public void LetsStart()
    {
        PlaySfx(readySound, 0.8f);
        
    }
    private IEnumerator StartSpin()
    {
        yield return new WaitForSeconds(0.5f);
        sfxAudioSource.loop = true;
        sfxAudioSource.clip = spinSound;
        sfxAudioSource.Play();
        StartCoroutine(StopSpin());
    }
    private IEnumerator StopSpin()
    {
        yield return new WaitForSeconds(3.75f);
        StopSpinSound();
       
    }
}
