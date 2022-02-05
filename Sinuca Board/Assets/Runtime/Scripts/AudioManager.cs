using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip mainTitleClip;
    [SerializeField] List<AudioClip> battleClips;
    [SerializeField] AudioClip drumSound;
    [SerializeField] AudioClip sadSong;
    [SerializeField] AudioClip finalSongs;
    



    private void Start()
    {
        MainMusic();  
    }

    public void BattleMusics()
    {
        if(audioSource != null)
        {
            audioSource.DOFade(0.8f, 10);
            var index = Random.Range(0, battleClips.Count);
            PlayClip(battleClips[index]);
        }
       
    }

    public void FinalMusics()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(1f, 10);
            var index = Random.Range(0, battleClips.Count);
            PlayClip(finalSongs);
        }

    }


    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void MainMusic()
    {
        if(audioSource != null)
        {
            audioSource.DOFade(0.8f, 5);
            PlayClip(mainTitleClip);
        }
        
    }
    public void SadMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(0.8f, 5);
            PlayClip(sadSong);
        }
    }

    private void ChampionMusic()
    {
        if (audioSource != null)
        {
            audioSource.DOFade(0.8f, 5);
            PlayClip(sadSong);
        }
    }
    public void DrumLoop()
    {
        PlayClip(drumSound);
    }

    public IEnumerator ChangeToMAinMusic(float timeToWaitForNewMusic)
    {
        yield return new WaitForSeconds(timeToWaitForNewMusic);
        MainMusic();
    }

    public IEnumerator ChangeToSadMusic(float timeToWaitForNewMusic)
    {
        yield return new WaitForSeconds(timeToWaitForNewMusic);
        SadMusic();
    }

    public IEnumerator ChangeToFinalMusic(float timeToWaitForNewMusic)
    {
        yield return new WaitForSeconds(timeToWaitForNewMusic);
        FinalMusics();
    }

    public IEnumerator ChangeToChampionMusic(float timeToWaitForNewMusic)
    {
        yield return new WaitForSeconds(timeToWaitForNewMusic);
    }
    public void StopClip()
    {
        audioSource.Stop();
    }
}
