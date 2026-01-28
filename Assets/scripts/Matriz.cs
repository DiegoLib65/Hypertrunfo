using UnityEngine;
using System.Linq;
public class Matriz
{
	private static int[,] forca = new int[28,28];
    private static int[,] velocidade = new int[28, 28];
    private static int[,] inteligencia = new int[28, 28];
    private static int[,] resistencia = new int[28, 28];
    private static int[,] magia = new int[28, 28];

    public int GetForca(int i, int j)
    {
        return forca[i, j];
    }
    public void SetForca(int i, int j,int value)
    {
        forca[i, j] = value;
       
    }
    public int GetVelocidade(int i, int j)
    {
        return velocidade[i, j];
    }
    public void SetVelocidade(int i, int j, int value)
    {
        velocidade[i, j] = value;

    }
    public int GetInteligencia(int i, int j)
    {
        return inteligencia[i, j];
    }
    public void SetInteligencia(int i, int j, int value)
    {
        inteligencia[i, j] = value;

    }
    public int GetResistencia(int i, int j)
    {
        return resistencia[i, j];
    }
    public void SetResistencia(int i, int j, int value)
    {
        resistencia[i, j] = value;

    }
    public int GetMagia(int i, int j)
    {
        return magia[i, j];
    }
    public void SetMagia(int i, int j, int value)
    {
        magia[i, j] = value;

    }
    public int SomaLinhaForca(int linhaIndex)
    {
        return Enumerable.Range(0, 28).Select(j => forca[linhaIndex, j]).Sum();
    }

    public int SomaLinhaVelocidade(int linhaIndex)
    {
        return Enumerable.Range(0, 28).Select(j => velocidade[linhaIndex, j]).Sum();
    }

    public int SomaLinhaInteligencia(int linhaIndex)
    {
        return Enumerable.Range(0, 28).Select(j => inteligencia[linhaIndex, j]).Sum();
    }

    public int SomaLinhaResistencia(int linhaIndex)
    {
        return Enumerable.Range(0, 28).Select(j => resistencia[linhaIndex, j]).Sum();
    }

    public int SomaLinhaMagia(int linhaIndex)
    {
        return Enumerable.Range(0, 28).Select(j => magia[linhaIndex, j]).Sum();
    }


}
