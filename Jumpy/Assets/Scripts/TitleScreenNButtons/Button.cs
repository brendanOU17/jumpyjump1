using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Button : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;



    public void NextOption()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void BackOption()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;

        }
        characters[selectedCharacter].SetActive(true);
    }

    public void startGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
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
