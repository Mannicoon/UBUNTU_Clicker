using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    int musicAtual = 0;
    AudioSource audioSource;
    public AudioClip[] clipNames;
    public Text musicName;
    public Slider musicLength;
    private bool stop = true;
    public Text CurrentTime;
    public Text SongLength;

    [Header("Volume")]
    public Slider Volume;
    public Text volumeText;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartAudio();
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
        Volume.value = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        SetVolumeText(audioSource.volume * 100f);

        

        if (!stop)
        {
            musicLength.value += Time.deltaTime;
            CurrentTime.text = musicLength.value.ToString("0") + "s";
            if (musicLength.value >= audioSource.clip.length)
            {
                musicAtual++;
                if(musicAtual >= clipNames.Length)
                    musicAtual = 0;
                StartAudio();
            }
        }
    }

    public void StartAudio(int changeMusic = 0)
    {
        musicAtual += changeMusic;
        if(musicAtual >= clipNames.Length)
        {
            musicAtual = 0;
        }
        else if(musicAtual < 0)
        {
            musicAtual = clipNames.Length - 1;
        }

        if(audioSource.isPlaying && changeMusic == 0)
        {
            return;
        }

        if (stop)
        {
            stop = false;
        }

        audioSource.clip = clipNames[musicAtual];
        musicName.text = audioSource.clip.name;
        musicLength.maxValue = audioSource.clip.length;
        musicLength.value = 0;
        audioSource.Play();
        SongLength.text = audioSource.clip.length.ToString("0") + "s";
    }

    public void StopAudio()
    {
        if (!stop)
        {
            audioSource.Play();
            stop = true;
        }
        else if(stop)
        {
            audioSource.Stop();
            stop = false;
        }
    }

    private void SetVolumeText(float x)
    {
        volumeText.text = x.ToString("0") + "%";
    }

    public void ChangeVolume()
    {
        audioSource.volume = Volume.value;
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
        Debug.Log("Saved: " + audioSource.volume);
    }
}
