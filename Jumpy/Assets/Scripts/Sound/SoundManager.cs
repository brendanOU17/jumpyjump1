using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, playeDie, trampoline, spring, DyingPlatform, backgroundMusic;
    static AudioSource audioSrc;
    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        playeDie = Resources.Load<AudioClip>("playerDieNew");
        trampoline = Resources.Load<AudioClip>("trampoline");
        spring = Resources.Load<AudioClip>("spring");
        backgroundMusic = Resources.Load<AudioClip>("backgroundMusic");
        DyingPlatform = Resources.Load<AudioClip>("DyingPlatformSound");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Playsound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "playerDieNew":
                audioSrc.PlayOneShot(playeDie);
                break;
            case "trampoline":
                audioSrc.PlayOneShot(trampoline);
                break;
            case "spring":
                audioSrc.PlayOneShot(spring);
                break;
            case "backgroundMusic":
                audioSrc.PlayOneShot(backgroundMusic);
                break;
            case "DyingPlatformSound":
                audioSrc.PlayOneShot(DyingPlatform);
                break;
        }
    }
}