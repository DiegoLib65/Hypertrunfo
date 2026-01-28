using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    // Start is called before the first frame update

 
    public void ParaMusica()
    {
        Singleton.instance.StopMusic();
    }
    public void TocaMusica()
    {
        Singleton.instance.PlayMusic();
    }
}
