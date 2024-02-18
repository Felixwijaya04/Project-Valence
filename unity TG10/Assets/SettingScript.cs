using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingScript : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
    }
}
