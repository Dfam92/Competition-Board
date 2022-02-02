using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    [SerializeField] AudioSource sFXManager;
    [SerializeField] AudioClip startSFXClip;


    public void PlaySfx(AudioClip clip)
    {
        sFXManager.PlayOneShot(clip);
    }

    public void StartSound()
    {
        PlaySfx(startSFXClip);
    }
    
}
