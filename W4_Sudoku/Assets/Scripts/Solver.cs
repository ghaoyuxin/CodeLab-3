using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Analytics;

//Given a text file representing an unsolved sudoku puzzle,
//identify if the puzzle is
//a) unsolvable,
//b) has a unique solution,
//or c) has multiple correct solutions.

public class Solver : MonoBehaviour
{
    //Load a text file
    //if xx, return unsolvable
    #region
        //check repeating item in a row/column.
        //check repeating item in any 3*3 grid
    #endregion
    //if xx, return solved
    //if xx, return manySolved
    private string[] level;
    private List<string> _row;
    private List<string> _column;
    private List<string> _grid;
    private int _initNumber;
    private void Awake()
    {
        var filePath = Application.dataPath + "/Resources/sudoku_example_1.txt";
        Debug.Assert(File.Exists(filePath));
        level = File.ReadAllLines(filePath);
        //should check if string has 81 items, and no 0. Then properly parse it into 9*9 grid.
      
    }

    private void Start()
    {
        _row = new List<string>();
        _column = new List<string>();
        _grid = new List<string>();
        Debug.Log("Row/Column does not repeat is " + NonRepeatRowColumn().ToString());
        Debug.Log("Grid does not repeat is " + NonRepeatInGrid().ToString());

    }

    private bool NonRepeatRowColumn()
    {
        //doesn't have to convert to numbers since compare string also takes constant time
        for (var y = 0; y < level.Length; y++)
        {
            var row = level[y];
            for (var x = 0; x < row.Length; x++)
            {
                var single = row[x].ToString();
                if (single == ".")//make a new row, check if the condensed row has repeating items
                    continue;
                _row.Add(single); 
                for (var i = 0; i < _row.Count-2; i++)
                {
                    if (_row[i] == _row[i + 1]) return false;
                }
                
                if (level[x][y].ToString() == ".")//make a new column
                    continue;
                _column.Add(level[x][y].ToString());
                
                for (var i = 0; i < _column.Count-2; i++) //, check if has repeating items
                {
                    if (_column[i] == _column[i + 1]) return false;
                }
            }
        }
        return true;
    }

    private bool NonRepeatInGrid()
    {
        for (var m = 0; m < level.Length; m+=3)
        {
            var row = level[m];
            for (var n = 0; n < row.Length; m+=3)
            {
                //3*3 grid
                for (var y = m; y < 3 + m; y ++) 
                {
                    for (var x = n; x < 3 + n; x ++)
                    {
                        var single = row[x].ToString();
                        if (single == ".")
                            continue;
                        _grid.Add(single);
                    }
                }
                for (var i = 0; i < _grid.Count-2; i++)
                {
                    if (_grid[i] == _grid[i + 1]) return false;
                }
            }
        }
        
        return true;
    }
    
    
}
