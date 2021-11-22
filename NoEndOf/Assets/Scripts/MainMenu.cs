using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public Image progress;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void PlayGame()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Game"));
        StartCoroutine(LoadingScreen());
        
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musiVolume", volumeSlider.value);
    }

    IEnumerator LoadingScreen () 
    {
        float totalProgress = 0;
        for(int i=0;i<scenesToLoad.Count;++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                progress.fillAmount = totalProgress / scenesToLoad.Count;

                yield return null;
            }
        }
     
    }
}
