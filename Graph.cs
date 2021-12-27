using System;
using System.Collections.Generic;

namespace Lab2
{
  class Graph
  {
    private List<List<int>> adjList;
    private List<int> visited;
    private int ways_count, start_vertex;
    public Graph()
    {
      adjList = new List<List<int>>();
      visited = new List<int>();
      ways_count = 0;
    }
    public List<int> Get_adj_vertex(int index)
    {         
      return adjList[index];
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
        if (flag) this.adjList.Add(adj);
      }
    }   
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
    public int Find(int length)
    {
      if (length == 1)
      {
        for (int i = 0; i < adjList.Count; i++)
        {
          if (adjList[i][0] == 0) continue;
          ways_count += adjList[i].Count;
        }
      }
      else
      {        
        for (int i = 0; i < adjList.Count; i++)
        {
          visited.Clear();
          start_vertex = i + 1;
          DFS(start_vertex, length);
        }
      }
      return ways_count;
    }
    private void DFS(int cur_vertex, int n)
    {
      if (n == 0) return;
      visited.Add(cur_vertex);
      List<int> adjL = new List<int>();
      adjL = Get_adj_vertex(cur_vertex - 1);      
      if (adjL[0] != 0)
      {
        if (n == 1)
        {
          ways_count += adjL.Count;
          foreach (int item in adjL)
          {
            if (visited.Contains(item)) ways_count--;
          }
          return;
        }
        foreach (int vertex in adjL)
        {
          if (vertex == start_vertex)
          {
            if (n == 1) ways_count--;
            continue;
          }       
          if (!visited.Contains(vertex)) DFS(vertex, n-1);
          visited.Remove(vertex);
        }        
      }
    }
  }
}
