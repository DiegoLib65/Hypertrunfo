using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    private static List<Carta> CardOfComputer;
    private static List<Carta> CardOfPlayer;
    private CPUIA cpu = new CPUIA();
    public Button btforca;
    public Button btvelocidade;
    public Button btintel;
    public Button btresist;
    public Button btmagic;
    public Text nomeP;
    public Text forcaP;
    public Text velocidadeP;
    public Text intelP;
    public Text resistP;
    public Text magicP;
    public Text nomeCP;
    public Text forcaCP;
    public Text velocidadeCP;
    public Text intelCP;
    public Text resistCP;
    public Text magicCP;
    public Text resto1;
    public Text resto2;
    private Color cor;
    private Color core;
    private int cpu_turn;
    private static int jogo = 0;



    void Start()
    {
        if (jogo == 0)
        {
            GerenciaCartas.instance.GameStart();
            cpu.MatrizProporcao();
            jogo = 1;
        }
        CardOfComputer = GerenciaCartas.instance.GetCartaDoComputador();
        CardOfPlayer = GerenciaCartas.instance.GetCartaDoJogador();

        if (CardOfPlayer != null)
        {
            ShowValue();
        }
        cor = Color.blue;
        core = Color.red;

    }

    public void CompararCartas(int categoria)
    {


      
        // Obtenha a carta do jogador e do computador para a categoria selecionada
        if (CardOfComputer.Count > 0 && CardOfPlayer.Count > 0)
        {
            Carta cartaJogador = CardOfPlayer[0];
            Carta cartaComputador = CardOfComputer[0];
            
            // Compare as cartas com base na categoria selecionada
            int valorJogador = 0;
            int valorComputador = 0;

            switch (categoria)
            {
                // Lógica para o turno do jogador (escolha de categoria, comparação, etc.)
                case 1:
                    valorJogador = cartaJogador.Forca;
                    valorComputador = cartaComputador.Forca;
                    
                    break;
                case 2:
                    valorJogador = cartaJogador.Velocidade;
                    valorComputador = cartaComputador.Velocidade;
                    
                    break;
                case 3:
                    valorJogador = cartaJogador.Inteligencia;
                    valorComputador = cartaComputador.Inteligencia;
                   
                    break;
                case 4:
                    valorJogador = cartaJogador.Resistencia;
                    valorComputador = cartaComputador.Resistencia;
                
                    break;
                case 5:
                    valorJogador = cartaJogador.Magia;
                    valorComputador = cartaComputador.Magia;
              
                    break;
            }
            
            if (cartaComputador.Num == "A1" || cartaJogador.Num == "A1")
            {
                Trunfo(cartaComputador, cartaJogador);
            }
            else
            {

                if (valorJogador > valorComputador)
                {

                    // Jogador vence a rodada, ganha as cartas e atualiza os contadores
                    GerenciaCartas.instance.PlayerWin(cartaComputador, cartaJogador);
                    ShowValue();
                    Clear();
                    AtivaBotao(true);
                    cpu_turn = 0;
                    Images.instance.SetGeneric();
                    ChangeRed();

                }
                else if (valorJogador < valorComputador)
                {
                    // Computador vence a rodada, ganha as cartas e atualiza os contadores
                    ChangeRed();
                    GerenciaCartas.instance.CPUWin(cartaComputador, cartaJogador);
                    ShowValue();
                    cpu.SomaProporcao(cpu.VerificarLinha(CardOfComputer[0]), GerenciaCartas.instance.GetCarta());
                    cpu.CategIA(CardOfComputer[0]);
                    StartCoroutine(IAPlay());
                    AtivaBotao(false);
                    cpu_turn = 1;


                }
                else
                {
                    //Empate, lógica de empate (aqui você decide o que fazer em caso de empate)
                    GerenciaCartas.instance.Empate();
                    ChangeRed();
                    print("Empatou");
                    if(cpu_turn == 1)
                    {
                        StartCoroutine(IAPlay());
                    }
                    else
                    {
                        AtivaBotao(true);
                    }
                }
                // Verifique o fim do jogo
                ShowValue();
                
                if(CardOfComputer.Count == 0 || CardOfPlayer.Count == 0) {
                    jogo = 0;
                }
                GerenciaCartas.instance.FinalizarGame();
            }
        }
    }



    public void Força()
    {
        AtivaBotao(false);
        ChangeColor(1);
        Images.instance.SetImgCPU();
        StartCoroutine(ShowIA(1));
    }

    public void Velocidade()
    {
        AtivaBotao(false);
        ChangeColor(2);
        Images.instance.SetImgCPU();
        StartCoroutine(ShowIA(2));
    }

    public void Inteligencia()
    {
        AtivaBotao(false);
        ChangeColor(3);
        Images.instance.SetImgCPU();
        StartCoroutine(ShowIA(3));
    }

    public void Resistencia()
    {
        AtivaBotao(false);
        ChangeColor(4);
        Images.instance.SetImgCPU();
        StartCoroutine(ShowIA(4));
    }

    public void Magia()
    {
        AtivaBotao(false);
        ChangeColor(5);
        Images.instance.SetImgCPU();
        StartCoroutine(ShowIA(5));
    }
    
    private void ShowValue()
    {
        if (CardOfComputer.Count > 0 && CardOfPlayer.Count > 0)
        {

            Carta cartaComputador = CardOfComputer[0];
            Carta cartaJogador = CardOfPlayer[0];
            nomeP.text = cartaJogador.Num + " " + cartaJogador.Nome;
            forcaP.text = cartaJogador.Forca.ToString();
            velocidadeP.text = cartaJogador.Velocidade.ToString();
            intelP.text = cartaJogador.Inteligencia.ToString();
            resistP.text = cartaJogador.Resistencia.ToString();
            magicP.text = cartaJogador.Magia.ToString();
            resto1.text = "Cartas Restantes Player: " + CardOfPlayer.Count.ToString();
            resto2.text = "Cartas Restantes CPU: " + CardOfComputer.Count.ToString();
        }
    }
    private IEnumerator IAPlay()
    {
        
        ShowCPU();
        ChangeColor(cpu.Category);
        Images.instance.SetImgCPU();
        yield return new WaitForSeconds(2);
        
        CompararCartas(cpu.Category);

    }

    private void Trunfo(Carta cartaComputador, Carta cartaJogador)
    {
        if (cartaComputador.Num == "A1")
        {
            
            if (cartaJogador.Num == "A2" || cartaJogador.Num == "A3" || cartaJogador.Num == "A4" || cartaJogador.Num == "A5" || cartaJogador.Num == "A6" || cartaJogador.Num == "A7")
            {
                GerenciaCartas.instance.PlayerWin(cartaComputador, cartaJogador);
                ShowValue();
                Clear();
                ChangeRed();
                AtivaBotao(true);
                Images.instance.SetGeneric();
                GerenciaCartas.instance.FinalizarGame();
            }
            else
            {

                GerenciaCartas.instance.CPUWin(cartaComputador, cartaJogador);
                ShowValue();
                ChangeRed();
                StartCoroutine(IAPlay());
                AtivaBotao(false);
                GerenciaCartas.instance.FinalizarGame();
            }

        }
        if (cartaJogador.Num == "A1")
        {
          
            if (cartaComputador.Num == "A2" || cartaComputador.Num == "A3" || cartaComputador.Num == "A4" || cartaComputador.Num == "A5" || cartaComputador.Num == "A6" || cartaComputador.Num == "A7")
            {
                GerenciaCartas.instance.CPUWin(cartaComputador, cartaJogador);
                ShowValue();
                ChangeRed();
                StartCoroutine(IAPlay());
                AtivaBotao(false); 
                GerenciaCartas.instance.FinalizarGame();
            }
            else
            {

                GerenciaCartas.instance.PlayerWin(cartaComputador, cartaJogador);
                ShowValue();
                Clear();
                ChangeRed();
                AtivaBotao(true);
                Images.instance.SetGeneric();
                GerenciaCartas.instance.FinalizarGame();
            }
        }
    }
   
    private void AtivaBotao(bool troca)
    {
        btforca.interactable = troca;
        btvelocidade.interactable = troca;
        btintel.interactable = troca;
        btresist.interactable = troca;
        btmagic.interactable = troca;
    }

    private void ShowCPU()
    {
        if (CardOfComputer.Count > 0)
        {
            Carta cartaComputador = CardOfComputer[0];
            nomeCP.text = cartaComputador.Num + " " + cartaComputador.Nome;
            forcaCP.text = "Força: " + cartaComputador.Forca.ToString();
            velocidadeCP.text = "Velocidade: " + cartaComputador.Velocidade.ToString();
            intelCP.text = "Inteligência: " + cartaComputador.Inteligencia.ToString();
            resistCP.text = "Resistência: " + cartaComputador.Resistencia.ToString();
            magicCP.text = "Magia: " + cartaComputador.Magia.ToString();
        }
    }
    private IEnumerator ShowIA(int categ)
    {
        ShowCPU();
        yield return new WaitForSeconds(2);
        CompararCartas(categ);


    }
    
    private void ChangeColor(int categ)
    {
        switch (categ)
        {
            case 1:
                forcaP.color = cor;
                forcaCP.color = cor;
                break; 
            case 2:
                velocidadeP.color = cor;
                velocidadeCP.color = cor;
                break;
            case 3:
                intelP.color = cor;
                intelCP.color = cor;
                break;
            case 4:
                resistP.color = cor;
                resistCP.color = cor;
                break;
            case 5:
                magicP.color = cor;
                magicCP.color = cor;
                break;
        }
    }
    private void ChangeRed()
    {
      
                forcaP.color = core;
                forcaCP.color = core;
                velocidadeP.color = core;
                velocidadeCP.color = core;
                intelP.color = core;
                intelCP.color = core;
                resistP.color = core;
                resistCP.color = core;
                magicP.color = core;
                magicCP.color = core;
        
    }
    private void Clear()
    {
        nomeCP.text = "Nome: ?";
        forcaCP.text = "Força: ?";
        velocidadeCP.text = "Velocidade: ?";
        intelCP.text = "Inteligência: ?";
        resistCP.text = "Resistência: ?";
        magicCP.text = "Magia: ?";
    }
}
