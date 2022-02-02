using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    [SerializeField] AudioSource sFXManager;
    [SerializeField] AudioClip startSfxClip;
    [SerializeField] AudioClip crayonSfx;


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
}
