using UnityEngine;
using System.Collections.Generic;


public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private static AudioManager instance;
    [Header("Sound Options")]
    public bool soundOn = true;
    public bool musicOn = true;

    public class SoundZ
    {
        public string soundName;
        public AudioClip clip;
    }
    public enum SoundType
    {
        CommonButton,
        Help,
        Etc
    }

    public enum MusicType
    {
        Ingame,
        MainMenu,
    }

    public Dictionary<string, AudioClip> audios;
    public SoundZ[] sfxs;
    public AudioClip[] musics;

    public static AudioManager Get()
    {
        return instance;
    }

    // Use this for initialization
    private void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        soundOn = PlayerProfile.Get().GetSoundOn();
        musicOn = PlayerProfile.Get().GetMusicOn();
        audioSource = GetComponent<AudioSource>();

        foreach (SoundZ ac in sfxs)
        {
            audios.Add(ac.soundName, ac.clip);
        }
    }

    public void PlaySound(string st)
    {
        if (!soundOn)
            return;
        if (audios.ContainsKey(st)) //usando diccionarios 
        {
            AudioSource.PlayClipAtPoint(audios[st], Vector3.zero);
        }

        for (int i = 0; i < sfxs.Length; i++) // sin usar diccionarios
        {
            if (sfxs[i].soundName == st)
            {
                AudioSource.PlayClipAtPoint(sfxs[i].clip, Vector3.zero);
            }

        }
    }

    public void PlayMusic(MusicType mt)
    {
        audioSource.clip = musics[(int)mt];
        if (!musicOn)
            return;

        audioSource.Play();
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;

        if (soundOn)
            PlaySound(SoundType.CommonButton.ToString());

        PlayerProfile.Get().SaveSoundOptions(this);
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;

        if (musicOn)
            audioSource.Play();
        else
            audioSource.Stop();

        PlayerProfile.Get().SaveSoundOptions(this);
    }
}

