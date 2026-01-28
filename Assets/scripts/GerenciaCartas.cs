using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class GerenciaCartas : MonoBehaviour
{
    private static List<Carta> cartas;
    private static List<Carta> cartasDoJogador;
    private static List<Carta> cartasDoComputador;
    private static List<Carta> pilha;
    private tela screen = new tela();
    private string nomeProp;
    private int forcaProp;
    private int velocidadeProp;
    private int inteligenciaProp;
    private int resistenciaProp;
    private int magiaProp;
    public static GerenciaCartas instance { get; private set; }

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

    

    public void GameStart()
    {

        cartas = new List<Carta>(); // Inicialize a lista de cartas
        cartasDoJogador = new List<Carta>();
        cartasDoComputador = new List<Carta>();
        pilha = new List<Carta>();

        // Carregue o arquivo CSV a partir da pasta Resources
        TextAsset csvFile = Resources.Load<TextAsset>("cartas");

        if (csvFile != null)
        {
            // Divida o arquivo em linhas
            string[] linhas = csvFile.text.Split('\n');

            for (int i = 1; i < linhas.Length; i++) // Comece a partir da segunda linha, ignorando o cabeçalho
            {
                string linha = linhas[i].Trim(); // Remova espaços em branco no início e no final da linha

                if (!string.IsNullOrEmpty(linha)) // Verifique se a linha não está vazia
                {
                    string[] dados = linha.Split(';');

                    // Certifique-se de que há dados suficientes na linha antes de tentar criar a carta
                    if (dados.Length >= 7)
                    {
                        // Crie um objeto Carta e atribua os dados
                        Carta carta = new Carta();
                        carta.Nome = dados[0];
                        carta.Num = dados[1];
                        carta.Forca = int.Parse(dados[2]);
                        carta.Velocidade = int.Parse(dados[3]);
                        carta.Inteligencia = int.Parse(dados[4]);
                        carta.Resistencia = int.Parse(dados[5]);
                        carta.Magia = int.Parse(dados[6]);

                        cartas.Add(carta);
                    }
                    else
                    {
                        Debug.LogError("Dados de carta incompletos na linha " + (i + 1) + ". Verifique o arquivo CSV.");
                    }
                }
            }

        }
        else
        {
            Debug.LogError("Arquivo CSV 'cartas' não encontrado na pasta 'Resources'. Certifique-se de que o nome do arquivo esteja correto e o arquivo esteja na pasta correta.");
        }

        // Distribua as cartas aleatoriamente entre o jogador e o computador
        DistribuirCartasAleatoriamente();
        
        
    }

    private void DistribuirCartasAleatoriamente()
    {
        List<Carta> cartasRestantes = new List<Carta>(cartas); // Crie uma cópia das cartas originais

        // Distribua as cartas em turnos até que não haja mais cartas restantes
        while (cartasRestantes.Count > 0)
        {
            // Escolha uma carta aleatória das cartas restantes
            int indiceAleatorio = Random.Range(0, cartasRestantes.Count);
            Carta cartaSelecionada = cartasRestantes[indiceAleatorio];

            // Adicione a carta selecionada ao jogador ou ao computador alternadamente
            if (cartasDoJogador.Count <= cartasDoComputador.Count)
            {
                cartasDoJogador.Add(cartaSelecionada);
            }
            else
            {
                cartasDoComputador.Add(cartaSelecionada);
            }
            // Remova a carta selecionada da lista de cartas restantes
            cartasRestantes.RemoveAt(indiceAleatorio);

        }

    }


    public List<Carta> GetCartaDoComputador()
    {
        return cartasDoComputador;
    }
    public List<Carta> GetCartaDoJogador()
    {
        return cartasDoJogador;
    }
    public List<Carta> GetCarta()
    {
       
        return cartas;
    }
    public void PlayerWin(Carta cartaComputador, Carta cartaJogador)
    {
        cartasDoJogador.Add(cartaComputador);
        cartasDoJogador.Add(cartaJogador);
        cartasDoComputador.RemoveAt(0);
        cartasDoJogador.RemoveAt(0);

        while (pilha.Count > 0)
        {
            cartasDoJogador.Add(pilha[0]);
            pilha.RemoveAt(0);
        }
        
    }

    public void CPUWin(Carta cartaComputador, Carta cartaJogador)
    {
        cartasDoComputador.Add(cartaJogador);
        cartasDoComputador.Add(cartaComputador);
        cartasDoJogador.RemoveAt(0);
        cartasDoComputador.RemoveAt(0);

        while (pilha.Count > 0)
        {
            cartasDoComputador.Add(pilha[0]);
                pilha.RemoveAt(0);
        }
        
    }

    public void Empate()
    {
        pilha.Add(cartasDoJogador[0]);
        pilha.Add(cartasDoComputador[0]);
        cartasDoJogador.RemoveAt(0);
        cartasDoComputador.RemoveAt(0);
    }
    public void FinalizarGame()
    {
        if (cartasDoComputador.Count == 0)
        {
            screen.TrocaWinner();
            Destroy(gameObject);
            Images.instance.Destroy();


        }
        if (cartasDoJogador.Count == 0)
        {
            screen.TrocaLoser();
            Destroy(gameObject);
            Images.instance.Destroy();

        }

    }
}
