using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
  class Graph
  {
    private List<List<int>> adjList = new List<List<int>>();
    
    public void Add_vertex(List<int> smezhV)
    {
      adjList.Add(smezhV);
    }
    public List<int> Get_adj_vertex(int index)
    {
      List<int> temp = new List<int>();
      foreach (var item in adjList[index])
      {
        temp.Add(item);
      }
      return temp;
    }
    /// <summary>
    /// Составление списка смежности из матрицы весов дуг
    /// </summary>
    /// <param name="matrix"></param>
    public void Init_adj_list(List<List<int>> matrix)
    {
      List<int> adj;
      bool flag = false;
      foreach (List<int> list in matrix) 
      {
        adj = new List<int>();
        flag = false;
        foreach (var item in list)
        {
          if (item != 0)
          {
            flag = true;
            int ind = list.IndexOf(item) + 1;
            adj.Add(ind);
          }
        }
        if (!flag)
        {
          adj.Add(0);
          flag = true;
        }        
        if (flag) this.Add_vertex(adj);
      }
    }
    /// <summary>
    /// Вывод списка смежности
    /// </summary>
    public void Print_adj_list()
    {
      for (int i = 0; i < adjList.Count; i++)
      {
        Console.Write("Вершина: {0} | Смежные вершины: ", i+1);
        foreach (var item in adjList[i])
        {
          Console.Write("{0} ", item);
        }
        Console.WriteLine("");
      }
    }
    /// <summary>
    /// Поиск незамкнутых путей
    /// </summary>
    public void Search_ways(int way_length)
    {
      int cur_length = 0;      
      int start_vertex = 1;
      int cur_vertex;
      List<int> adjL;
      for (cur_vertex = start_vertex; cur_vertex < this.adjList.Count; cur_vertex++)      
      {
        adjL = new List<int>();
        adjL = Get_adj_vertex(start_vertex - 1);
        Console.Write("Смежные вершины для {0} вершины: ", start_vertex);
        foreach (var item in adjL)
        {
          Console.Write("{0} ", item);
        }
        Console.WriteLine();
        if (adjL[0] == 0)
        {
          start_vertex++;
          cur_length = 0;
          cur_vertex = start_vertex;
          continue;
        } else
        {
          for (int i = 0; i < adjL.Count; i++)
          {
            cur_length++;
            cur_vertex = adjL[0];
          }          
        }
      }      
    }
  }
}
