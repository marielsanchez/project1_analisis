using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public static int[,] FinalNonogram;
    public static bool Solved = false;
        
    //Creation of the list that are going to have the ammount of color cells in the column and row
    public static List<List<int>> rowList = new List<List<int>>();
    public static List<List<int>> columnList = new List<List<int>>();
    
    // Start is called before the first frame update
    public static void Start()
    {
        const string path =
            @"D:\Mariell\Documents\2020\Analisis\Project1\Files\10x10_3.txt";
        //"C:\Users\Kenneth SF\OneDrive - Estudiantes ITCR\TEC\2020\I Semestre\Análisis de Algoritmos\Proyectos\Proyecto_1\10x10_4.txt";
        //Reads the file and converts it into two list, one for the rows and the other for the columns
        ReadFile(path, rowList, columnList);
        var nonogramMatrix = new int[rowList.Count,columnList.Count];
        FinalNonogram = new int[rowList.Count,columnList.Count ];
        GridFiller.StartExe(nonogramMatrix,rowList,columnList);
        Utilities.CleanMatrix(FinalNonogram);
        //if (Utilities.HasSolution(FinalNonogram))
        //{
         //   Solved = true;
       // }

    }


	public static void Start(string pMatrixSize)
    {
        string path =
            @"D:\Mariell\Documents\2020\Analisis\Project1\Files\"+pMatrixSize+".txt";
        //"C:\Users\Kenneth SF\OneDrive - Estudiantes ITCR\TEC\2020\I Semestre\Análisis de Algoritmos\Proyectos\Proyecto_1\10x10_4.txt";
        //Reads the file and converts it into two list, one for the rows and the other for the columns
        ReadFile(path, rowList, columnList);
        var nonogramMatrix = new int[rowList.Count,columnList.Count];
        FinalNonogram = new int[rowList.Count,columnList.Count ];
        GridFiller.StartExe(nonogramMatrix,rowList,columnList);
        Utilities.CleanMatrix(FinalNonogram);

        /***
         CHANGE ALL OF THIS
         * 
        GridFiller.StartExe(nonogramMatrix,rowList,columnList);
        Console.WriteLine();
        Utilities.CleanMatrix(FinalNonogram);
        if (Utilities.HasSolution(FinalNonogram))
            Utilities.Print2DArray(FinalNonogram);
        else
            Console.WriteLine("El Nonograma no posee solución");
         */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void ReadFile(string path,List<List<int>> rowList,List<List<int>> columnList)
    {
        string line;
        var orientation = "FILAS";
            
        // Read the file and display it line by line.  
        System.IO.StreamReader file =   
            new System.IO.StreamReader(@path);  
        while((line = file.ReadLine()) != null)
        {
            if ((line == "FILAS") || (line == "COLUMNAS"))
                orientation = line;
            else 
            {
                var aux = Utilities.ConvertToList(line);
                if(orientation=="FILAS")
                    rowList.Add(aux);
                else
                    columnList.Add(aux);
            }
        }
        file.Close();
    }
    
}
