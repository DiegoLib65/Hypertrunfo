using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class CPUIA
{

    private static Matriz matriz = new Matriz();
    private string nomeProp;
    private int forcaProp;
    private int velocidadeProp;
    private int inteligenciaProp;
    private int resistenciaProp;
    private int magiaProp;
    private Carta baralho1 = new Carta();
    private List<Carta> cartas = new List<Carta>();
    private int category;

    public void MatrizProporcao()
    {
        cartas = GerenciaCartas.instance.GetCarta();
        for (int i = 0; i < 28; i++)
        {
            baralho1 = cartas[i];

            for (int j = 0; j < 28; j++)
            {

                Carta baralho2 = cartas[j];
                int final = 0;
                final = baralho1.Forca >= baralho2.Forca ? 1 : 0;
                matriz.SetForca(i, j, final);
                final = baralho1.Velocidade >= baralho2.Velocidade ? 1 : 0;
                matriz.SetVelocidade(i, j, final);
                final = baralho1.Inteligencia >= baralho2.Inteligencia ? 1 : 0;
                matriz.SetInteligencia(i, j, final);
                final = baralho1.Resistencia >= baralho2.Resistencia ? 1 : 0;
                matriz.SetResistencia(i, j, final);
                final = baralho1.Magia >= baralho2.Magia ? 1 : 0;
                matriz.SetMagia(i, j, final);
            }

        }

    }

    public int VerificarLinha(Carta cartaIA)
    {
        List<Carta> carta = GerenciaCartas.instance.GetCarta();
        for (int i = 1; i <carta.Count; i++)
        {
            if (cartaIA.Nome == carta[i].Nome)
            {
                return i;
            }

        }
        return 0;
    }

    public void SomaProporcao(int linha, List<Carta> cartas)
    {
        Carta card = cartas[linha];
        nomeProp = card.Nome;
        forcaProp = matriz.SomaLinhaForca(linha);
        velocidadeProp = matriz.SomaLinhaVelocidade(linha);
        inteligenciaProp = matriz.SomaLinhaInteligencia(linha);
        resistenciaProp = matriz.SomaLinhaResistencia(linha);
        magiaProp = matriz.SomaLinhaMagia(linha);
        

    }

    public void CategIA(Carta card)
    {
        
        int categoria = 0;
        if (nomeProp == card.Nome)
        {
            categoria = (forcaProp > velocidadeProp && forcaProp > inteligenciaProp && forcaProp > resistenciaProp && forcaProp > magiaProp) ? 1 :
                       (velocidadeProp > inteligenciaProp && velocidadeProp > resistenciaProp && velocidadeProp > magiaProp) ? 2 :
                       (inteligenciaProp > resistenciaProp && inteligenciaProp > magiaProp) ? 3 :
                       (resistenciaProp > magiaProp) ? 4 : 5;



        }

        category = categoria;
       
        
    }

    
    

     
    
    public int Category
    {
        get { return category; }
        set { category = value; }
    }
    
}
