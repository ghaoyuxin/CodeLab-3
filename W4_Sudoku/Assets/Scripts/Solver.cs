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
    //if xx, return solved
    //if xx, return manySolved
    private void Awake()
    {
        var filePath = Application.dataPath + "/Resources/sudoku_example_1.txt";
        Debug.Assert(File.Exists(filePath));
        
        string[] level1 = File.ReadAllLines(filePath);


        for (var y = 0; y < level1.Length; y++)
        {
            var row = level1[y];
            for (var x = 0; x < row.Length; x++)
            {
                var single = row[x];
                // if(single.ToString() == ".") print(null);
                // var newlevel1 = Convert.ToInt32(single.ToString());
                // print(newlevel1);
            }
        }
        

    }
    
    

}
