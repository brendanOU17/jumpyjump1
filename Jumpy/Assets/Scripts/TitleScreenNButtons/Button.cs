using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Button : MonoBehaviour
{
    public SpriteRenderer sprite;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;


    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sprite.sprite = skins[selectedSkin];
    }

   public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin <0)
        {
            selectedSkin = skins.Count - 1;
        }
        sprite.sprite = skins[selectedSkin];
    }

 public void startGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/Assets/selectedSkin.prefab");
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
     public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("main");
    }

   
    
}
