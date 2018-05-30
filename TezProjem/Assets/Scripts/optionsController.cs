using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class optionsController : MonoBehaviour {

    public AudioMixer audioMixer;

	public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Sahnem");
    }
}
