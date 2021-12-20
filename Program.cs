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
      Console.WriteLine("Введите длину пути (-1, чтобы вывести все): ");
      int X = Convert.ToInt32(Console.ReadLine());
      Graph graph = new Graph();
      graph.Init_adj_list(weightMatrix);
      graph.Print_adj_list();
      graph.Search_ways(X);
    }
  }
}
