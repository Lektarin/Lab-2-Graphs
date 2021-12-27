using System;
using System.Collections.Generic;

namespace Lab2
{
  /* Вариант 71
   Дана матрица весов дуг. Определить ВСЕ (т.е. не обязательно самые короткие) незамкнутые пути 
   в орграфе заданной длины х (вводится с клавиатуры).
   Список смежности 
  */
 
  class Program
  {
    static List<List<int>> weightMatrix = new List<List<int>>();
    static List<List<int>> weightMatrix2 = new List<List<int>>();
    static void Main(string[] args)
    {
      // Матрица весов дуг
      weightMatrix.Add(new List<int> { 0, 7, 5, 0, 6 }); // 1
      weightMatrix.Add(new List<int> { 0, 0, 0, 0, 0 }); // 2
      weightMatrix.Add(new List<int> { 0, 0, 0, 4, 0 }); // 3
      weightMatrix.Add(new List<int> { 0, 0, 0, 0, 2 }); // 4
      weightMatrix.Add(new List<int> { 6, 5, 0, 0, 0 }); // 5
      Console.WriteLine("Матрица весов дуг:");
      foreach (var node in weightMatrix)
      {
        foreach (var item in node)
          Console.Write(item + " ");
        Console.WriteLine();
      }      
      Graph graph = new Graph();
      graph.Init_adj_list(weightMatrix);
      graph.Print_adj_list();
      Console.WriteLine("Введите длину пути: ");
      int X = Convert.ToInt32(Console.ReadLine());
      while (X < 1 || X > 10000)
      {
        Console.WriteLine("Ошибка! Введите корректную длину.");
        Console.WriteLine("Введите длину пути: ");
        X = Convert.ToInt32(Console.ReadLine());
      }
      Console.WriteLine($"Количество незамкнутых путей с длиной {X}: {graph.Find(X)}.");
      // Матрица весов дуг
      weightMatrix2.Add(new List<int> { 0, 5, 0, 0, 0 }); // 1
      weightMatrix2.Add(new List<int> { 0, 0, 4, 3, 0 }); // 2
      weightMatrix2.Add(new List<int> { 0, 0, 0, 0, 5 }); // 3
      weightMatrix2.Add(new List<int> { 0, 0, 0, 0, 6 }); // 4
      weightMatrix2.Add(new List<int> { 0, 0, 0, 0, 0 }); // 5
      Console.WriteLine("Матрица весов дуг:");
      foreach (var node in weightMatrix2)
      {
        foreach (var item in node)
          Console.Write(item + " ");
        Console.WriteLine();
      }
      Graph graph2 = new Graph();
      graph2.Init_adj_list(weightMatrix2);
      graph2.Print_adj_list();
      Console.WriteLine("Введите длину пути: ");
      int X2 = Convert.ToInt32(Console.ReadLine());
      while (X2 < 1 || X2 > 10000)
      {
        Console.WriteLine("Ошибка! Введите корректную длину.");
        Console.WriteLine("Введите длину пути: ");
        X2 = Convert.ToInt32(Console.ReadLine());
      }
      Console.WriteLine($"Количество незамкнутых путей с длиной {X2}: {graph2.Find(X2)}.");
    }
  }
}
