using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SfxManager : MonoBehaviour
{
    [SerializeField] AudioSource sFXManager;
    [SerializeField] AudioClip startSfxClip;
    [SerializeField] AudioClip crayonSfx;
    [SerializeField] AudioClip spinSound;
    [SerializeField] AudioClip selectPlayerSound;
    [SerializeField] AudioClip readySound;


    public void PlaySfx(AudioClip clip,float value)
    {
        sFXManager.PlayOneShot(clip,value);
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

    private void StopSpinSound()
    {
        sFXManager.loop = false;
        sFXManager.Stop();
        LetsStart();
    }

    public void LetsStart()
    {
        PlaySfx(readySound, 0.8f);
        
    }
    private IEnumerator StartSpin()
    {
        yield return new WaitForSeconds(0.5f);
        sFXManager.loop = true;
        sFXManager.clip = spinSound;
        sFXManager.Play();
        StartCoroutine(StopSpin());
    }
    private IEnumerator StopSpin()
    {
        yield return new WaitForSeconds(3.75f);
        StopSpinSound();
       
    }
}
