using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images : MonoBehaviour
{
    public Image ImgPlayer;
    public Image ImgCPU;
    public Image FundoPlayer;
    public Image FundoCPU;
    public Sprite[] cardBackSprites;

    private static List<Carta> CardOfComp;
    private static List<Carta> CardOfPlay;

    private Dictionary<string, Sprite> spriteMappings;


    public Sprite A1;
    public Sprite A2;
    public Sprite A3;
    public Sprite A4;
    public Sprite A5;
    public Sprite A6;
    public Sprite A7;
    public Sprite B1;
    public Sprite B2;
    public Sprite B3;
    public Sprite B4;
    public Sprite B5;
    public Sprite B6;
    public Sprite B7;
    public Sprite C1;
    public Sprite C2;
    public Sprite C3;
    public Sprite C4;
    public Sprite C5;
    public Sprite C6;
    public Sprite C7;
    public Sprite D1;
    public Sprite D2;
    public Sprite D3;
    public Sprite D4;
    public Sprite D5;
    public Sprite D6;
    public Sprite D7;
    public Sprite Gray;
    public Sprite Yellow;
    public Sprite Blue;
    public Sprite Green;
    public Sprite Blank;
    public static Images instance { get; private set; }
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
    void Start()
    {
        cardBackSprites = new Sprite[] { Yellow, Blue, Green, Gray };

        spriteMappings = new Dictionary<string, Sprite>()
    {
        { "A1", A1 }, { "A2", A2 }, { "A3", A3 }, { "A4", A4 }, { "A5", A5 }, { "A6", A6 }, { "A7", A7 },
        { "B1", B1 }, { "B2", B2 }, { "B3", B3 }, { "B4", B4 }, { "B5", B5 }, { "B6", B6 }, { "B7", B7 },
        { "C1", C1 }, { "C2", C2 }, { "C3", C3 }, { "C4", C4 }, { "C5", C5 }, { "C6", C6 }, { "C7", C7 },
        { "D1", D1 }, { "D2", D2 }, { "D3", D3 }, { "D4", D4 }, { "D5", D5 }, { "D6", D6 }, { "D7", D7 }
    };

        CardOfComp = GerenciaCartas.instance.GetCartaDoComputador();
        CardOfPlay = GerenciaCartas.instance.GetCartaDoJogador();
        SetGeneric();
    }

   
        
   

    void Update()
    {
           SetImage();
    }

    private void SetImage()
    {
        if (CardOfPlay.Count > 0)
        {
            Carta Player = CardOfPlay[0];
            
            string num = Player.Num;
            

            FundoPlayer.sprite = cardBackSprites[GetCardBackIndex(num[0])];
           

            if (spriteMappings.ContainsKey(num))
            {
                ImgPlayer.sprite = spriteMappings[num];
            }

            
        }
    }
    public void SetImgCPU()
    {
        Carta CPU = CardOfComp[0];
        string nume = CPU.Num;
        FundoCPU.sprite = cardBackSprites[GetCardBackIndex(nume[0])];
        if (spriteMappings.ContainsKey(nume))
        {
            ImgCPU.sprite = spriteMappings[nume];
        }
    }

    private int GetCardBackIndex(char cardNum)
    {

        switch (cardNum)
        {
            case 'A':
                return 0; //amarelo
            case 'B':
                return 1; //azul
            case 'C':
                return 2; //verde
            default:
                return 3; //cinza
        }
    }
    public void SetGeneric()
    {
        ImgCPU.sprite = Blank;
        FundoCPU.sprite = Gray;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
