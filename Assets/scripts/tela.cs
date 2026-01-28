using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tela : MonoBehaviour
{

  
    private static string cenaAnterior;


    public void TrocaBatalha()
    {
        SceneManager.LoadScene("Batalha");
        Singleton.instance.Battle();
        Singleton.instance.PlayMusic();

    }
    public void TrocaInicial()
    {
        SceneManager.LoadScene("Inicial");
        Singleton.instance.Intro();
        Singleton.instance.PlayMusic();
    }

    public void TrocaConfiguracao()
    {
        cenaAnterior = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Config");
        

    }
    public void TrocaConfiguracaoBatttle()
    {
        cenaAnterior = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Config");
        Images.instance.Destroy();

    }


    public void VoltadaConfig()
    {

        SceneManager.LoadScene(cenaAnterior);

    }
    public void TrocaWinner()
    {
        SceneManager.LoadScene("Winner");
        
    }

    public void TrocaLoser()
    {
        SceneManager.LoadScene("Loser");
    }




}

