using UnityEngine;

public class Carta
{
   
	private string nome;
    private string num;
    private int forca;
    private int velocidade;
    private int inteligencia;
    private int resistencia;
    private int magia;

    public string Nome
    {
        get { return nome; }   // get method
        set { nome = value; }
    }
    public string Num
    {
        get { return num; }   // get method
        set { num = value; }
    }
    public int Forca
    {
        get { return forca; }
        set { forca = value; }
    }
    public int Velocidade
    {
        get { return velocidade; }
        set { velocidade = value; }
    }
    public int Inteligencia
    {
        get { return inteligencia; }
        set { inteligencia = value; }
    }
    public int Resistencia
    {
        get { return resistencia; }
        set { resistencia = value; }
    }
    public int Magia
    {
        get { return magia; }
        set { magia = value; }
    }
}
