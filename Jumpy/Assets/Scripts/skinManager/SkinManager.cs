using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinManager : MonoBehaviour
{
    public GameObject [] selectedskin;
    public Transform spawnPoint;
    
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = selectedskin[selectedCharacter];
        GameObject clone = Instantiate(prefab,spawnPoint.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
