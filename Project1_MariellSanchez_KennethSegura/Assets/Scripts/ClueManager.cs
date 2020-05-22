using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{

    public GameObject column0;
    public GameObject column1;
    public GameObject column2;
    public GameObject column3;
    public GameObject column4;
    public GameObject column5;
    public GameObject column6;
    public GameObject column7;
    public GameObject column8;
    public GameObject column9;
    public GameObject column10;
    public GameObject column11;
    public GameObject column12;
    public GameObject column13;
    public GameObject column14;
    public GameObject column15;
    public GameObject column16;
    public GameObject column17;
    public GameObject column18;
    public GameObject row0;
    public GameObject row1;
    public GameObject row2;
    public GameObject row3;
    public GameObject row4;
    public GameObject row5;
    public GameObject row6;
    public GameObject row7;
    public GameObject row8;
    public GameObject row9;
    public GameObject row10;
    public GameObject row11;
    public GameObject row12;
    public GameObject row13;
    public GameObject row14;
    public GameObject row15;
    public GameObject row16;
    public GameObject row17;
    public GameObject row18;
    
    
    // Start is called before the first frame update
    void Start()
    {
        FileManager.Start();
        InitializeRows();
        InitializeColumns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeRows()
    {
        row0.GetComponent<Text>().text = "0";
        row1.GetComponent<Text>().text = "0";
        row2.GetComponent<Text>().text = "";
        row3.GetComponent<Text>().text = "";
        row4.GetComponent<Text>().text = "";
        row5.GetComponent<Text>().text = "";
        row6.GetComponent<Text>().text = "";
        row7.GetComponent<Text>().text = "";
        row8.GetComponent<Text>().text = "";
        row9.GetComponent<Text>().text = "";
        row10.GetComponent<Text>().text = "";
        row11.GetComponent<Text>().text = "";
        row12.GetComponent<Text>().text = "";
        row13.GetComponent<Text>().text = "";
        row14.GetComponent<Text>().text = "";
        row15.GetComponent<Text>().text = "";
        row16.GetComponent<Text>().text = "";
        row17.GetComponent<Text>().text = "";
        row18.GetComponent<Text>().text = "";
    }

    void InitializeColumns()
    {
        column0.GetComponent<Text>().text = "0";
        column1.GetComponent<Text>().text = "0";
        column2.GetComponent<Text>().text = "";
        column3.GetComponent<Text>().text = "";
        column4.GetComponent<Text>().text = "";
        column5.GetComponent<Text>().text = "";
        column6.GetComponent<Text>().text = "";
        column7.GetComponent<Text>().text = "";
        column8.GetComponent<Text>().text = "";
        column9.GetComponent<Text>().text = "";
        column10.GetComponent<Text>().text = "";
        column11.GetComponent<Text>().text = "";
        column12.GetComponent<Text>().text = "";
        column13.GetComponent<Text>().text = "";
        column14.GetComponent<Text>().text = "";
        column15.GetComponent<Text>().text = "";
        column16.GetComponent<Text>().text = "";
        column17.GetComponent<Text>().text = "";
        column18.GetComponent<Text>().text = "";
    }
    
    public void setClues()
    {
        setRows();
        setColumns();
    }

    void setRows()
    {
        int value = FileManager.rowList.Count;
        string listRow = "";
        int i = 0;
        while (i != value) {
            listRow = string.Join(" ", FileManager.rowList[i].ToArray());
            
            if (i == 0)
                row0.GetComponent<Text>().text = listRow;
            else if (i == 1)
                row1.GetComponent<Text>().text = listRow;
            else if (i == 2)
                row2.GetComponent<Text>().text = listRow;
            else if (i == 3)
                row3.GetComponent<Text>().text = listRow;
            else if (i == 4)
                row4.GetComponent<Text>().text = listRow;
            else if (i == 5)
                row5.GetComponent<Text>().text = listRow;
            else if (i == 6)
                row6.GetComponent<Text>().text = listRow;
            else if (i == 7)
                row7.GetComponent<Text>().text = listRow;
            else if (i == 8)
                row8.GetComponent<Text>().text = listRow;
            else if (i == 9)
                row9.GetComponent<Text>().text = listRow;
            else if (i == 10)
                row10.GetComponent<Text>().text = listRow;
            else if (i == 11)
                row11.GetComponent<Text>().text = listRow;
            else if (i == 12)
                row12.GetComponent<Text>().text = listRow;
            else if (i == 13)
                row13.GetComponent<Text>().text = listRow;
            else if (i == 14)
                row14.GetComponent<Text>().text = listRow;
            else if (i == 15)
                row15.GetComponent<Text>().text = listRow;
            else if (i == 16)
                row16.GetComponent<Text>().text = listRow;
            else if (i == 17)
                row17.GetComponent<Text>().text = listRow;
            else if (i == 18)
                row18.GetComponent<Text>().text = listRow;
            
            i++;
        }
    }

    void setColumns()
    {
        int value = FileManager.columnList.Count;
        string listColumn = "";
        int i = 0;
        while (i != value) {
            listColumn = string.Join("", FileManager.columnList[i].ToArray());
            
            if (i == 0)
                column0.GetComponent<Text>().text = listColumn;
            else if (i == 1)
                column1.GetComponent<Text>().text = listColumn;
            else if (i == 2)
                column2.GetComponent<Text>().text = listColumn;
            else if (i == 3)
                column3.GetComponent<Text>().text = listColumn;
            else if (i == 4)
                column4.GetComponent<Text>().text = listColumn;
            else if (i == 5)
                column5.GetComponent<Text>().text = listColumn;
            else if (i == 6)
                column6.GetComponent<Text>().text = listColumn;
            else if (i == 7)
                column7.GetComponent<Text>().text = listColumn;
            else if (i == 8)
                column8.GetComponent<Text>().text = listColumn;
            else if (i == 9)
                column9.GetComponent<Text>().text = listColumn;
            else if (i == 10)
                column10.GetComponent<Text>().text = listColumn;
            else if (i == 11)
                column11.GetComponent<Text>().text = listColumn;
            else if (i == 12)
                column12.GetComponent<Text>().text = listColumn;
            else if (i == 13)
                column13.GetComponent<Text>().text = listColumn;
            else if (i == 14)
                column14.GetComponent<Text>().text = listColumn;
            else if (i == 15)
                column15.GetComponent<Text>().text = listColumn;
            else if (i == 16)
                column16.GetComponent<Text>().text = listColumn;
            else if (i == 17)
                column17.GetComponent<Text>().text = listColumn;
            else if (i == 18)
                column18.GetComponent<Text>().text = listColumn;
            
            i++;
        }
    }

}
