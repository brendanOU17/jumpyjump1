using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Button : MonoBehaviour
{
    public CharacterDatabase characterData;
    public SpriteRenderer characterSprite;
    private int selectedOption = 0;


    void Start()
    {
        if (PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            load();
        }
        UpdateCharacter(selectedOption);
    }
    public void NextOption()
    {
       selectedOption++;
        if(selectedOption >= characterData.CharacterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        save();
    }

    public void BackOption()
    {
      selectedOption--;
        if(selectedOption < 0)
        {
            selectedOption = characterData.CharacterCount - 1; 
        }
        UpdateCharacter(selectedOption);
        save();
    }
     private void UpdateCharacter(int selectedOption)
    {
        Character character = characterData.GetCharacter(selectedOption);
        characterSprite.sprite = character.characterSprite;
    }
    private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }


    public void startGame()
    { 
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
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("main");
    }

   
    
}
