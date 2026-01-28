using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{

    public AudioSource background;
    public AudioClip battle;
    public AudioClip intro;
    public static Singleton instance { get; private set; }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    
   public void StopMusic()
    {
        background.Stop(); 
    }
    public void PlayMusic()
    {
        background.Play();
    }

    public void Intro()
    {

        background.clip = intro;
    }
    public void Battle()
    {
        background.clip =battle;
    }

}
