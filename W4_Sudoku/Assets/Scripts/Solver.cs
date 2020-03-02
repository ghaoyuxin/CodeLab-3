using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
    private void Awake()
    {
        var filePath = Application.dataPath + "/Resources/sudoku_example_1.txt";
        Debug.Assert(File.Exists(filePath));
        level = File.ReadAllLines(filePath);
        //should check if string has 81 items, and no 0. Then properly parse it into 9*9 grid.
      
    }

    private void Start()
    {
        Debug.Log("Row/column does not repeat is " + NonRepeat().ToString());
        
    }

    private bool NonRepeat()
    {
        //doesn't have to convert to numbers since compare to also takes constant time
        //uint
        for (var y = 0; y < level.Length - 2; y++)
        {
            var row = level[y];
            for (var x = 0; x < row.Length - 2; x++)
            {
                var single = row[x].ToString();
                if (single == ".")
                    continue;
                

            }
            

        }

        return true;
    }
    
    

}
