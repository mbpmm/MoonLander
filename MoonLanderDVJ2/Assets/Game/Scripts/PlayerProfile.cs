using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{

    static PlayerProfile instance;

    public static PlayerProfile Get()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }

    public void SaveSoundOptions(AudioManager sm)
    {
        PlayerPrefs.SetInt("SoundOn", sm.soundOn ? 1 : 0);
        PlayerPrefs.SetInt("MusicOn", sm.musicOn ? 1 : 0);
    }

    public bool GetSoundOn()
    {
        if (PlayerPrefs.HasKey("SoundOn"))
            return PlayerPrefs.GetInt("SoundOn") == 1;
        return true;
    }

    public bool GetMusicOn()
    {
        if (PlayerPrefs.HasKey("MusicOn"))
            return PlayerPrefs.GetInt("MusicOn") == 1;
        return true;
    }
}