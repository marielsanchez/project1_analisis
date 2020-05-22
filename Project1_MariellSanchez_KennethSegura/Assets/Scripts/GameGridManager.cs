using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGridManager : MonoBehaviour
{
	public Button select;
	public Button check;
	public Button back;
	public Dropdown matrixSize;
	public static string matrizSize = "5x5_";
	public static int[,] GameMatrix;
	public int lives;
	public static int rows;
	public static int columns;
	
	public Image live1;
	public Image live2;
	public Image live3;
	
	public Text status;
	
	// Hints
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
	
	// Row Zero
	public Button button00;
    public Button button01;
    public Button button02;
    public Button button03;
    public Button button04;
    public Button button05;
    public Button button06;
    public Button button07;
    public Button button08;
    public Button button09;
	// Row One
	public Button button10;
    public Button button11;
    public Button button12;
    public Button button13;
    public Button button14;
    public Button button15;
    public Button button16;
    public Button button17;
    public Button button18;
    public Button button19;
	// Row Two
	public Button button20;
    public Button button21;
    public Button button22;
    public Button button23;
    public Button button24;
    public Button button25;
    public Button button26;
    public Button button27;
    public Button button28;
    public Button button29;
	// Row Three
	public Button button30;
    public Button button31;
    public Button button32;
    public Button button33;
    public Button button34;
    public Button button35;
    public Button button36;
    public Button button37;
    public Button button38;
    public Button button39;
	// Row Four
	public Button button40;
    public Button button41;
    public Button button42;
    public Button button43;
    public Button button44;
    public Button button45;
    public Button button46;
    public Button button47;
    public Button button48;
    public Button button49;
	// Row Five
	public Button button50;
    public Button button51;
    public Button button52;
    public Button button53;
    public Button button54;
    public Button button55;
    public Button button56;
    public Button button57;
    public Button button58;
    public Button button59;
	// Row Six
	public Button button60;
    public Button button61;
    public Button button62;
    public Button button63;
    public Button button64;
    public Button button65;
    public Button button66;
    public Button button67;
    public Button button68;
    public Button button69;
	// Row Seven
	public Button button70;
    public Button button71;
    public Button button72;
    public Button button73;
    public Button button74;
    public Button button75;
    public Button button76;
    public Button button77;
    public Button button78;
    public Button button79;
	// Row Eight
	public Button button80;
    public Button button81;
    public Button button82;
    public Button button83;
    public Button button84;
    public Button button85;
    public Button button86;
    public Button button87;
    public Button button88;
    public Button button89;
	// Row Nine
	public Button button90;
    public Button button91;
    public Button button92;
    public Button button93;
    public Button button94;
    public Button button95;
    public Button button96;
    public Button button97;
    public Button button98;
    public Button button99;

    // Start is called before the first frame update
    void Start()
    {
        //llenarMatriz();
		lives = 3;
		disableButtons();
		check.GetComponent<Button>().interactable = false;
		back.GetComponent<Button>().interactable = true;
		
    }

    public void backSceneGame(){
	    SceneManager.LoadScene("MainMenu");
    }
    
    public void matrizSizeHandler(int value){
        if (value == 0){
			//es una 5x5
			matrizSize = "5x5_" + Random.Range(1, 2);
		}
		else if (value == 1){
			//es una 6x6
			matrizSize = "6x6_" + Random.Range(1, 3);
        }
		else if (value == 2){
			//es una 7x7
			matrizSize = "7x7_" + Random.Range(1, 2);
        }
		else if (value == 3){
			//es una 8x8
			matrizSize = "8x8_" + Random.Range(1, 2);
        }
		else {
			//es una 10x10
			matrizSize = "10x10_" + Random.Range(1, 4);
        }
		Debug.Log(matrizSize);
	}
    
	public void selectButton(){
		FileManager.Start(matrizSize);
		rows = FileManager.rowList.Count;
		columns = FileManager.columnList.Count;
		GameMatrix = new int[rows, columns];
		fillMatrix();
		setClues();
		Debug.Log("hi jajaja");
		check.GetComponent<Button>().interactable = true;
		enableButtons();
		select.GetComponent<Button>().interactable = false;
	}

	void enableButtons()
	{
		if (matrizSize == "5x5_1" || matrizSize == "5x5_2"){
			enable_5x5Buttons();
		}
		else if (matrizSize == "6x6_1" || matrizSize == "6x6_2" || matrizSize == "6x6_3"){
			enable_6x6Buttons();
		}
		else if (matrizSize == "7x7_1" || matrizSize == "7x7_2"){
			enable_7x7Buttons();
		}
		else if (matrizSize == "8x8_1"|| matrizSize == "8x8_2"){
			enable_8x8Buttons();
		}
		else {
			//es una 10x10
			enable_10x10Buttons();
		}
	}

	void fillMatrix(){
		//llena la matriz de juego con ceros
		for (int row = 0; row < rows ; row++)
        {
            for (int col = 0; col < columns; col++)
            {
				GameMatrix[row,col] = 0; 
			}
		}
	}

	public string printGameMatrix(){
		string gameMatrix = "";
		for (int row = 0; row < rows ; row++)
        {
            for (int col = 0; col < columns; col++)
            {
				gameMatrix += GameMatrix[row,col]; 
			}
			gameMatrix += "\n";
		}
		return gameMatrix;
	}

	public void printSolutionMatrix(){
		Debug.Log(Utilities.PrintMatrix(FileManager.FinalNonogram));
	}

	public void printBothMatrix(){
		Debug.Log("Game Matrix\n"+printGameMatrix());
		Debug.Log("Solution Matrix\n");
		printSolutionMatrix();
	}
	
	public void checkMatrix(){
		Debug.Log("Game Matrix\n"+printGameMatrix());
		Debug.Log("Solution Matrix\n");
		printSolutionMatrix();
		if (checkAnswer())
		{
			status.text = "YOU HAVE WON!!";
			disableButtons();
			Debug.Log("respuesta correcta");
		}
		else
		{
			lives--;
			if (lives == 2)
			{
				status.text = "Try again";
				live3.enabled = false;
			}
			else if (lives == 1)
			{
				status.text = "Last chance!!";
				live2.enabled = false;
			} else if (lives == 0)
			{
				status.text = "YOU LOST!";
				live1.enabled = false;
				disableButtons();
				check.GetComponent<Button>().interactable = false;
			}
		}

	}

	bool checkAnswer()
	{
		for (int row = 0; row < rows ; row++)
		{
			for (int col = 0; col < columns; col++)
			{
				if (GameMatrix[row, col] != FileManager.FinalNonogram[row, col])
					return false;
			}
		}

		return true;
	}

	public void setClues()
    {
        // cuando el select es seleccionado
        setRows();
        setColumns();
    }

    public void setRows()
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
            i++;
        }
    }

    public void setColumns()
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
            i++;
        }
    }
    
    void disableButtons()
    {
	    //Row Zero
	    button00.GetComponent<Button>().interactable = false;
	    button01.GetComponent<Button>().interactable = false;
	    button02.GetComponent<Button>().interactable = false;
	    button03.GetComponent<Button>().interactable = false;
	    button04.GetComponent<Button>().interactable = false;
	    button05.GetComponent<Button>().interactable = false;
	    button06.GetComponent<Button>().interactable = false;
	    button07.GetComponent<Button>().interactable = false;
	    button08.GetComponent<Button>().interactable = false;
	    button09.GetComponent<Button>().interactable = false;
	    
	    //Row One
	    button10.GetComponent<Button>().interactable = false;
	    button11.GetComponent<Button>().interactable = false;
	    button12.GetComponent<Button>().interactable = false;
	    button13.GetComponent<Button>().interactable = false;
	    button14.GetComponent<Button>().interactable = false;
	    button15.GetComponent<Button>().interactable = false;
	    button16.GetComponent<Button>().interactable = false;
	    button17.GetComponent<Button>().interactable = false;
	    button18.GetComponent<Button>().interactable = false;
	    button19.GetComponent<Button>().interactable = false;
	    
	    //Row Two
	    button20.GetComponent<Button>().interactable = false;
	    button21.GetComponent<Button>().interactable = false;
	    button22.GetComponent<Button>().interactable = false;
	    button23.GetComponent<Button>().interactable = false;
	    button24.GetComponent<Button>().interactable = false;
	    button25.GetComponent<Button>().interactable = false;
	    button26.GetComponent<Button>().interactable = false;
	    button27.GetComponent<Button>().interactable = false;
	    button28.GetComponent<Button>().interactable = false;
	    button29.GetComponent<Button>().interactable = false;
	    
	    //Row Three
	    button30.GetComponent<Button>().interactable = false;
	    button31.GetComponent<Button>().interactable = false;
	    button32.GetComponent<Button>().interactable = false;
	    button33.GetComponent<Button>().interactable = false;
	    button34.GetComponent<Button>().interactable = false;
	    button35.GetComponent<Button>().interactable = false;
	    button36.GetComponent<Button>().interactable = false;
	    button37.GetComponent<Button>().interactable = false;
	    button38.GetComponent<Button>().interactable = false;
	    button39.GetComponent<Button>().interactable = false;
	    
	    //Row Four
	    button40.GetComponent<Button>().interactable = false;
	    button41.GetComponent<Button>().interactable = false;
	    button42.GetComponent<Button>().interactable = false;
	    button43.GetComponent<Button>().interactable = false;
	    button44.GetComponent<Button>().interactable = false;
	    button45.GetComponent<Button>().interactable = false;
	    button46.GetComponent<Button>().interactable = false;
	    button47.GetComponent<Button>().interactable = false;
	    button48.GetComponent<Button>().interactable = false;
	    button49.GetComponent<Button>().interactable = false;
	    
	    //Row Five
	    button50.GetComponent<Button>().interactable = false;
	    button51.GetComponent<Button>().interactable = false;
	    button52.GetComponent<Button>().interactable = false;
	    button53.GetComponent<Button>().interactable = false;
	    button54.GetComponent<Button>().interactable = false;
	    button55.GetComponent<Button>().interactable = false;
	    button56.GetComponent<Button>().interactable = false;
	    button57.GetComponent<Button>().interactable = false;
	    button58.GetComponent<Button>().interactable = false;
	    button59.GetComponent<Button>().interactable = false;
	    
	    //Row Six
	    button60.GetComponent<Button>().interactable = false;
	    button61.GetComponent<Button>().interactable = false;
	    button62.GetComponent<Button>().interactable = false;
	    button63.GetComponent<Button>().interactable = false;
	    button64.GetComponent<Button>().interactable = false;
	    button65.GetComponent<Button>().interactable = false;
	    button66.GetComponent<Button>().interactable = false;
	    button67.GetComponent<Button>().interactable = false;
	    button68.GetComponent<Button>().interactable = false;
	    button69.GetComponent<Button>().interactable = false;
	    
	    //Row Seven
	    button70.GetComponent<Button>().interactable = false;
	    button71.GetComponent<Button>().interactable = false;
	    button72.GetComponent<Button>().interactable = false;
	    button73.GetComponent<Button>().interactable = false;
	    button74.GetComponent<Button>().interactable = false;
	    button75.GetComponent<Button>().interactable = false;
	    button76.GetComponent<Button>().interactable = false;
	    button77.GetComponent<Button>().interactable = false;
	    button78.GetComponent<Button>().interactable = false;
	    button79.GetComponent<Button>().interactable = false;
	    
	    //Row Eight
	    button80.GetComponent<Button>().interactable = false;
	    button81.GetComponent<Button>().interactable = false;
	    button82.GetComponent<Button>().interactable = false;
	    button83.GetComponent<Button>().interactable = false;
	    button84.GetComponent<Button>().interactable = false;
	    button85.GetComponent<Button>().interactable = false;
	    button86.GetComponent<Button>().interactable = false;
	    button87.GetComponent<Button>().interactable = false;
	    button88.GetComponent<Button>().interactable = false;
	    button89.GetComponent<Button>().interactable = false;
	    
	    //Row Nine
	    button90.GetComponent<Button>().interactable = false;
	    button91.GetComponent<Button>().interactable = false;
	    button92.GetComponent<Button>().interactable = false;
	    button93.GetComponent<Button>().interactable = false;
	    button94.GetComponent<Button>().interactable = false;
	    button95.GetComponent<Button>().interactable = false;
	    button96.GetComponent<Button>().interactable = false;
	    button97.GetComponent<Button>().interactable = false;
	    button98.GetComponent<Button>().interactable = false;
	    button99.GetComponent<Button>().interactable = false;
    }

    public void enable_5x5Buttons()
    {
	    //Row Zero
	    button00.GetComponent<Button>().interactable = true;
	    button01.GetComponent<Button>().interactable = true;
	    button02.GetComponent<Button>().interactable = true;
	    button03.GetComponent<Button>().interactable = true;
	    button04.GetComponent<Button>().interactable = true;

	    //Row One
	    button10.GetComponent<Button>().interactable = true;
	    button11.GetComponent<Button>().interactable = true;
	    button12.GetComponent<Button>().interactable = true;
	    button13.GetComponent<Button>().interactable = true;
	    button14.GetComponent<Button>().interactable = true;
	    
	    //Row Two
	    button20.GetComponent<Button>().interactable = true;
	    button21.GetComponent<Button>().interactable = true;
	    button22.GetComponent<Button>().interactable = true;
	    button23.GetComponent<Button>().interactable = true;
	    button24.GetComponent<Button>().interactable = true;
	    
	    //Row Three
	    button30.GetComponent<Button>().interactable = true;
	    button31.GetComponent<Button>().interactable = true;
	    button32.GetComponent<Button>().interactable = true;
	    button33.GetComponent<Button>().interactable = true;
	    button34.GetComponent<Button>().interactable = true;
	    
	    //Row Four
	    button40.GetComponent<Button>().interactable = true;
	    button41.GetComponent<Button>().interactable = true;
	    button42.GetComponent<Button>().interactable = true;
	    button43.GetComponent<Button>().interactable = true;
	    button44.GetComponent<Button>().interactable = true;
	    
    }

    void enable_6x6Buttons()
    {
	    enable_5x5Buttons();
	    
	    button05.GetComponent<Button>().interactable = true;

	    button15.GetComponent<Button>().interactable = true;

	    button25.GetComponent<Button>().interactable = true;
	    
	    button35.GetComponent<Button>().interactable = true;

	    button45.GetComponent<Button>().interactable = true;
	    
	    //Row Five
	    button50.GetComponent<Button>().interactable = true;
	    button51.GetComponent<Button>().interactable = true;
	    button52.GetComponent<Button>().interactable = true;
	    button53.GetComponent<Button>().interactable = true;
	    button54.GetComponent<Button>().interactable = true;
	    button55.GetComponent<Button>().interactable = true;
	    
    }

    void enable_7x7Buttons()
    {
	    enable_6x6Buttons();
	    
	    button06.GetComponent<Button>().interactable = true;
	    button16.GetComponent<Button>().interactable = true;
	    button26.GetComponent<Button>().interactable = true;
	    button36.GetComponent<Button>().interactable = true;
	    button46.GetComponent<Button>().interactable = true;
	    button56.GetComponent<Button>().interactable = true;
	    
	    //Row Six
	    button60.GetComponent<Button>().interactable = true;
	    button61.GetComponent<Button>().interactable = true;
	    button62.GetComponent<Button>().interactable = true;
	    button63.GetComponent<Button>().interactable = true;
	    button64.GetComponent<Button>().interactable = true;
	    button65.GetComponent<Button>().interactable = true;
	    button66.GetComponent<Button>().interactable = true;
    }
    
    void enable_8x8Buttons()
    {
	    enable_7x7Buttons();
	    
	    button07.GetComponent<Button>().interactable = true;
	    button17.GetComponent<Button>().interactable = true;
	    button27.GetComponent<Button>().interactable = true;
	    button37.GetComponent<Button>().interactable = true;
	    button47.GetComponent<Button>().interactable = true;
	    button57.GetComponent<Button>().interactable = true;
	    button67.GetComponent<Button>().interactable = true;
	    
	    //Row Seven
	    button70.GetComponent<Button>().interactable = true;
	    button71.GetComponent<Button>().interactable = true;
	    button72.GetComponent<Button>().interactable = true;
	    button73.GetComponent<Button>().interactable = true;
	    button74.GetComponent<Button>().interactable = true;
	    button75.GetComponent<Button>().interactable = true;
	    button76.GetComponent<Button>().interactable = true;
	    button77.GetComponent<Button>().interactable = true;

    }
    
    void enable_10x10Buttons()
    {
	    enable_8x8Buttons();
	    
	    //Row Eight
	    button08.GetComponent<Button>().interactable = true;
	    button18.GetComponent<Button>().interactable = true;
	    button28.GetComponent<Button>().interactable = true;
	    button38.GetComponent<Button>().interactable = true;
	    button48.GetComponent<Button>().interactable = true;
	    button58.GetComponent<Button>().interactable = true;
	    button68.GetComponent<Button>().interactable = true;
	    button78.GetComponent<Button>().interactable = true;
	    button88.GetComponent<Button>().interactable = true;
	    button98.GetComponent<Button>().interactable = true;
	    
	    //Row Nine
	    button09.GetComponent<Button>().interactable = true;
	    button19.GetComponent<Button>().interactable = true;
	    button29.GetComponent<Button>().interactable = true;
	    button39.GetComponent<Button>().interactable = true;
	    button49.GetComponent<Button>().interactable = true;
	    button59.GetComponent<Button>().interactable = true;
	    button69.GetComponent<Button>().interactable = true;
	    button79.GetComponent<Button>().interactable = true;
	    button89.GetComponent<Button>().interactable = true;
	    button99.GetComponent<Button>().interactable = true;
	    
	    //Row Eight
	    button80.GetComponent<Button>().interactable = true;
	    button81.GetComponent<Button>().interactable = true;
	    button82.GetComponent<Button>().interactable = true;
	    button83.GetComponent<Button>().interactable = true;
	    button84.GetComponent<Button>().interactable = true;
	    button85.GetComponent<Button>().interactable = true;
	    button86.GetComponent<Button>().interactable = true;
	    button87.GetComponent<Button>().interactable = true;
	    button88.GetComponent<Button>().interactable = true;
	    
	    //Row Nine
	    button90.GetComponent<Button>().interactable = true;
	    button91.GetComponent<Button>().interactable = true;
	    button92.GetComponent<Button>().interactable = true;
	    button93.GetComponent<Button>().interactable = true;
	    button94.GetComponent<Button>().interactable = true;
	    button95.GetComponent<Button>().interactable = true;
	    button96.GetComponent<Button>().interactable = true;
	    button97.GetComponent<Button>().interactable = true;
	    button98.GetComponent<Button>().interactable = true;
    }
    
    // Row Zero
	public void button_0_0(){
		if (GameMatrix[0,0] == 0) {
			button00.GetComponent<Image>().color = Color.black;
			GameMatrix[0,0] = 1;
		}
		else if (GameMatrix[0,0] == 1) {
			button00.GetComponent<Image>().color = Color.white;
			GameMatrix[0,0] = 0;
		}
    } 

	public void button_0_1(){
		if (GameMatrix[0,1] == 0) {
			button01.GetComponent<Image>().color = Color.black;
			GameMatrix[0,1] = 1;
		}
		else if (GameMatrix[0,1] == 1) {
			button01.GetComponent<Image>().color = Color.white;
			GameMatrix[0,1] = 0;
		}
    } 

	public void button_0_2(){
		if (GameMatrix[0,2] == 0) {
			button02.GetComponent<Image>().color = Color.black;
			GameMatrix[0,2] = 1;
		}
		else if (GameMatrix[0,2] == 1) {
			button02.GetComponent<Image>().color = Color.white;
			GameMatrix[0,2] = 0;
		}
    } 

	public void button_0_3(){
		if (GameMatrix[0,3] == 0) {
			button03.GetComponent<Image>().color = Color.black;
			GameMatrix[0,3] = 1;
		}
		else if (GameMatrix[0,3] == 1) {
			button03.GetComponent<Image>().color = Color.white;
			GameMatrix[0,3] = 0;
		}
    } 

	public void button_0_4(){
		if (GameMatrix[0,4] == 0) {
			button04.GetComponent<Image>().color = Color.black;
			GameMatrix[0,4] = 1;
		}
		else if (GameMatrix[0,4] == 1) {
			button04.GetComponent<Image>().color = Color.white;
			GameMatrix[0,4] = 0;
		}
    } 
	
	public void button_0_5(){
		if (GameMatrix[0,5] == 0) {
			button05.GetComponent<Image>().color = Color.black;
			GameMatrix[0,5] = 1;
		}
		else if (GameMatrix[0,5] == 1) {
			button05.GetComponent<Image>().color = Color.white;
			GameMatrix[0,5] = 0;
		}
    } 

	public void button_0_6(){
		if (GameMatrix[0,6] == 0) {
			button06.GetComponent<Image>().color = Color.black;
			GameMatrix[0,6] = 1;
		}
		else if (GameMatrix[0,6] == 1) {
			button06.GetComponent<Image>().color = Color.white;
			GameMatrix[0,6] = 0;
		}
    } 

	public void button_0_7(){
		if (GameMatrix[0,7] == 0) {
			button07.GetComponent<Image>().color = Color.black;
			GameMatrix[0,7] = 1;
		}
		else if (GameMatrix[0,7] == 1) {
			button07.GetComponent<Image>().color = Color.white;
			GameMatrix[0,7] = 0;
		}
    } 

	public void button_0_8(){
		if (GameMatrix[0,8] == 0) {
			button08.GetComponent<Image>().color = Color.black;
			GameMatrix[0,8] = 1;
		}
		else if (GameMatrix[0,8] == 1) {
			button08.GetComponent<Image>().color = Color.white;
			GameMatrix[0,8] = 0;
		}
    } 

	public void button_0_9(){
		if (GameMatrix[0,9] == 0) {
			button09.GetComponent<Image>().color = Color.black;
			GameMatrix[0,9] = 1;
		}
		else if (GameMatrix[0,9] == 1) {
			button09.GetComponent<Image>().color = Color.white;
			GameMatrix[0,9] = 0;
		}
    } 

	// Row One
	public void button_1_0(){
		if (GameMatrix[1,0] == 0) {
			button10.GetComponent<Image>().color = Color.black;
			GameMatrix[1,0] = 1;
		}
		else if (GameMatrix[1,0] == 1) {
			button10.GetComponent<Image>().color = Color.white;
			GameMatrix[1,0] = 0;
		}
    } 

	public void button_1_1(){
		if (GameMatrix[1,1] == 0) {
			button11.GetComponent<Image>().color = Color.black;
			GameMatrix[1,1] = 1;
		}
		else if (GameMatrix[1,1] == 1) {
			button11.GetComponent<Image>().color = Color.white;
			GameMatrix[1,1] = 0;
		}
    } 

	public void button_1_2(){
		if (GameMatrix[1,2] == 0) {
			button12.GetComponent<Image>().color = Color.black;
			GameMatrix[1,2] = 1;
		}
		else if (GameMatrix[1,2] == 1) {
			button12.GetComponent<Image>().color = Color.white;
			GameMatrix[1,2] = 0;
		}
    } 

	public void button_1_3(){
		if (GameMatrix[1,3] == 0) {
			button13.GetComponent<Image>().color = Color.black;
			GameMatrix[1,3] = 1;
		}
		else if (GameMatrix[1,3] == 1) {
			button13.GetComponent<Image>().color = Color.white;
			GameMatrix[1,3] = 0;
		}
    } 

	public void button_1_4(){
		if (GameMatrix[1,4] == 0) {
			button14.GetComponent<Image>().color = Color.black;
			GameMatrix[1,4] = 1;
		}
		else if (GameMatrix[1,4] == 1) {
			button14.GetComponent<Image>().color = Color.white;
			GameMatrix[1,4] = 0;
		}
    } 
	
	public void button_1_5(){
		if (GameMatrix[1,5] == 0) {
			button15.GetComponent<Image>().color = Color.black;
			GameMatrix[1,5] = 1;
		}
		else if (GameMatrix[1,5] == 1) {
			button15.GetComponent<Image>().color = Color.white;
			GameMatrix[1,5] = 0;
		}
    } 

	public void button_1_6(){
		if (GameMatrix[1,6] == 0) {
			button16.GetComponent<Image>().color = Color.black;
			GameMatrix[1,6] = 1;
		}
		else if (GameMatrix[1,6] == 1) {
			button16.GetComponent<Image>().color = Color.white;
			GameMatrix[1,6] = 0;
		}
    } 

	public void button_1_7(){
		if (GameMatrix[1,7] == 0) {
			button17.GetComponent<Image>().color = Color.black;
			GameMatrix[1,7] = 1;
		}
		else if (GameMatrix[1,7] == 1) {
			button17.GetComponent<Image>().color = Color.white;
			GameMatrix[1,7] = 0;
		}
    } 

	public void button_1_8(){
		if (GameMatrix[1,8] == 0) {
			button18.GetComponent<Image>().color = Color.black;
			GameMatrix[1,8] = 1;
		}
		else if (GameMatrix[1,8] == 1) {
			button18.GetComponent<Image>().color = Color.white;
			GameMatrix[1,8] = 0;
		}
    } 

	public void button_1_9(){
		if (GameMatrix[1,9] == 0) {
			button19.GetComponent<Image>().color = Color.black;
			GameMatrix[1,9] = 1;
		}
		else if (GameMatrix[1,9] == 1) {
			button19.GetComponent<Image>().color = Color.white;
			GameMatrix[1,9] = 0;
		}
    } 
    
	//Row Two
	public void button_2_0(){
		if (GameMatrix[2,0] == 0) {
			button20.GetComponent<Image>().color = Color.black;
			GameMatrix[2,0] = 1;
		}
		else if (GameMatrix[2,0] == 1) {
			button20.GetComponent<Image>().color = Color.white;
			GameMatrix[2,0] = 0;
		}
    } 

	public void button_2_1(){
		if (GameMatrix[2,1] == 0) {
			button21.GetComponent<Image>().color = Color.black;
			GameMatrix[2,1] = 1;
		}
		else if (GameMatrix[2,1] == 1) {
			button21.GetComponent<Image>().color = Color.white;
			GameMatrix[2,1] = 0;
		}
    } 

	public void button_2_2(){
		if (GameMatrix[2,2] == 0) {
			button22.GetComponent<Image>().color = Color.black;
			GameMatrix[2,2] = 1;
		}
		else if (GameMatrix[2,2] == 1) {
			button22.GetComponent<Image>().color = Color.white;
			GameMatrix[2,2] = 0;
		}
    } 

	public void button_2_3(){
		if (GameMatrix[2,3] == 0) {
			button23.GetComponent<Image>().color = Color.black;
			GameMatrix[2,3] = 1;
		}
		else if (GameMatrix[2,3] == 1) {
			button23.GetComponent<Image>().color = Color.white;
			GameMatrix[2,3] = 0;
		}
    } 

	public void button_2_4(){
		if (GameMatrix[2,4] == 0) {
			button24.GetComponent<Image>().color = Color.black;
			GameMatrix[2,4] = 1;
		}
		else if (GameMatrix[2,4] == 1) {
			button24.GetComponent<Image>().color = Color.white;
			GameMatrix[2,4] = 0;
		}
    } 
	
	public void button_2_5(){
		if (GameMatrix[2,5] == 0) {
			button25.GetComponent<Image>().color = Color.black;
			GameMatrix[2,5] = 1;
		}
		else if (GameMatrix[2,5] == 1) {
			button25.GetComponent<Image>().color = Color.white;
			GameMatrix[2,5] = 0;
		}
    } 

	public void button_2_6(){
		if (GameMatrix[2,6] == 0) {
			button26.GetComponent<Image>().color = Color.black;
			GameMatrix[2,6] = 1;
		}
		else if (GameMatrix[2,6] == 1) {
			button26.GetComponent<Image>().color = Color.white;
			GameMatrix[2,6] = 0;
		}
    } 

	public void button_2_7(){
		if (GameMatrix[2,7] == 0) {
			button27.GetComponent<Image>().color = Color.black;
			GameMatrix[2,7] = 1;
		}
		else if (GameMatrix[2,7] == 1) {
			button27.GetComponent<Image>().color = Color.white;
			GameMatrix[2,7] = 0;
		}
    } 

	public void button_2_8(){
		if (GameMatrix[2,8] == 0) {
			button28.GetComponent<Image>().color = Color.black;
			GameMatrix[2,8] = 1;
		}
		else if (GameMatrix[2,8] == 1) {
			button28.GetComponent<Image>().color = Color.white;
			GameMatrix[2,8] = 0;
		}
    } 

	public void button_2_9(){
		if (GameMatrix[2,9] == 0) {
			button29.GetComponent<Image>().color = Color.black;
			GameMatrix[2,9] = 1;
		}
		else if (GameMatrix[2,9] == 1) {
			button29.GetComponent<Image>().color = Color.white;
			GameMatrix[2,9] = 0;
		}
    } 

	//Row Three
	public void button_3_0(){
		if (GameMatrix[3,0] == 0) {
			button30.GetComponent<Image>().color = Color.black;
			GameMatrix[3,0] = 1;
		}
		else if (GameMatrix[3,0] == 1) {
			button30.GetComponent<Image>().color = Color.white;
			GameMatrix[3,0] = 0;
		}
    } 

	public void button_3_1(){
		if (GameMatrix[3,1] == 0) {
			button31.GetComponent<Image>().color = Color.black;
			GameMatrix[3,1] = 1;
		}
		else if (GameMatrix[3,1] == 1) {
			button31.GetComponent<Image>().color = Color.white;
			GameMatrix[3,1] = 0;
		}
    } 

	public void button_3_2(){
		if (GameMatrix[3,2] == 0) {
			button32.GetComponent<Image>().color = Color.black;
			GameMatrix[3,2] = 1;
		}
		else if (GameMatrix[3,2] == 1) {
			button32.GetComponent<Image>().color = Color.white;
			GameMatrix[3,2] = 0;
		}
    } 

	public void button_3_3(){
		if (GameMatrix[3,3] == 0) {
			button33.GetComponent<Image>().color = Color.black;
			GameMatrix[3,3] = 1;
		}
		else if (GameMatrix[3,3] == 1) {
			button33.GetComponent<Image>().color = Color.white;
			GameMatrix[3,3] = 0;
		}
    } 

	public void button_3_4(){
		if (GameMatrix[3,4] == 0) {
			button34.GetComponent<Image>().color = Color.black;
			GameMatrix[3,4] = 1;
		}
		else if (GameMatrix[3,4] == 1) {
			button34.GetComponent<Image>().color = Color.white;
			GameMatrix[3,4] = 0;
		}
    } 
	
	public void button_3_5(){
		if (GameMatrix[3,5] == 0) {
			button35.GetComponent<Image>().color = Color.black;
			GameMatrix[3,5] = 1;
		}
		else if (GameMatrix[3,5] == 1) {
			button35.GetComponent<Image>().color = Color.white;
			GameMatrix[3,5] = 0;
		}
    } 

	public void button_3_6(){
		if (GameMatrix[3,6] == 0) {
			button36.GetComponent<Image>().color = Color.black;
			GameMatrix[3,6] = 1;
		}
		else if (GameMatrix[3,6] == 1) {
			button36.GetComponent<Image>().color = Color.white;
			GameMatrix[3,6] = 0;
		}
    } 

	public void button_3_7(){
		if (GameMatrix[3,7] == 0) {
			button37.GetComponent<Image>().color = Color.black;
			GameMatrix[3,7] = 1;
		}
		else if (GameMatrix[3,7] == 1) {
			button37.GetComponent<Image>().color = Color.white;
			GameMatrix[3,7] = 0;
		}
    } 

	public void button_3_8(){
		if (GameMatrix[3,8] == 0) {
			button38.GetComponent<Image>().color = Color.black;
			GameMatrix[3,8] = 1;
		}
		else if (GameMatrix[3,8] == 1) {
			button38.GetComponent<Image>().color = Color.white;
			GameMatrix[3,8] = 0;
		}
    } 

	public void button_3_9(){
		if (GameMatrix[3,9] == 0) {
			button39.GetComponent<Image>().color = Color.black;
			GameMatrix[3,9] = 1;
		}
		else if (GameMatrix[3,9] == 1) {
			button39.GetComponent<Image>().color = Color.white;
			GameMatrix[3,9] = 0;
		}
    } 

	//Row Four
	public void button_4_0(){
		if (GameMatrix[4,0] == 0) {
			button40.GetComponent<Image>().color = Color.black;
			GameMatrix[4,0] = 1;
		}
		else if (GameMatrix[4,0] == 1) {
			button40.GetComponent<Image>().color = Color.white;
			GameMatrix[4,0] = 0;
		}
    } 

	public void button_4_1(){
		if (GameMatrix[4,1] == 0) {
			button41.GetComponent<Image>().color = Color.black;
			GameMatrix[4,1] = 1;
		}
		else if (GameMatrix[4,1] == 1) {
			button41.GetComponent<Image>().color = Color.white;
			GameMatrix[4,1] = 0;
		}
    } 

	public void button_4_2(){
		if (GameMatrix[4,2] == 0) {
			button42.GetComponent<Image>().color = Color.black;
			GameMatrix[4,2] = 1;
		}
		else if (GameMatrix[4,2] == 1) {
			button42.GetComponent<Image>().color = Color.white;
			GameMatrix[4,2] = 0;
		}
    } 

	public void button_4_3(){
		if (GameMatrix[4,3] == 0) {
			button43.GetComponent<Image>().color = Color.black;
			GameMatrix[4,3] = 1;
		}
		else if (GameMatrix[4,3] == 1) {
			button43.GetComponent<Image>().color = Color.white;
			GameMatrix[4,3] = 0;
		}
    } 

	public void button_4_4(){
		if (GameMatrix[4,4] == 0) {
			button44.GetComponent<Image>().color = Color.black;
			GameMatrix[4,4] = 1;
		}
		else if (GameMatrix[4,4] == 1) {
			button44.GetComponent<Image>().color = Color.white;
			GameMatrix[4,4] = 0;
		}
    } 
	
	public void button_4_5(){
		if (GameMatrix[4,5] == 0) {
			button45.GetComponent<Image>().color = Color.black;
			GameMatrix[4,5] = 1;
		}
		else if (GameMatrix[4,5] == 1) {
			button45.GetComponent<Image>().color = Color.white;
			GameMatrix[4,5] = 0;
		}
    } 

	public void button_4_6(){
		if (GameMatrix[4,6] == 0) {
			button46.GetComponent<Image>().color = Color.black;
			GameMatrix[4,6] = 1;
		}
		else if (GameMatrix[4,6] == 1) {
			button46.GetComponent<Image>().color = Color.white;
			GameMatrix[4,6] = 0;
		}
    } 

	public void button_4_7(){
		if (GameMatrix[4,7] == 0) {
			button47.GetComponent<Image>().color = Color.black;
			GameMatrix[4,7] = 1;
		}
		else if (GameMatrix[4,7] == 1) {
			button47.GetComponent<Image>().color = Color.white;
			GameMatrix[4,7] = 0;
		}
    } 

	public void button_4_8(){
		if (GameMatrix[4,8] == 0) {
			button48.GetComponent<Image>().color = Color.black;
			GameMatrix[4,8] = 1;
		}
		else if (GameMatrix[4,8] == 1) {
			button48.GetComponent<Image>().color = Color.white;
			GameMatrix[4,8] = 0;
		}
    } 

	public void button_4_9(){
		if (GameMatrix[4,9] == 0) {
			button49.GetComponent<Image>().color = Color.black;
			GameMatrix[4,9] = 1;
		}
		else if (GameMatrix[4,9] == 1) {
			button49.GetComponent<Image>().color = Color.white;
			GameMatrix[4,9] = 0;
		}
    } 
	
	//Row Five
	public void button_5_0(){
		if (GameMatrix[5,0] == 0) {
			button50.GetComponent<Image>().color = Color.black;
			GameMatrix[5,0] = 1;
		}
		else if (GameMatrix[5,0] == 1) {
			button50.GetComponent<Image>().color = Color.white;
			GameMatrix[5,0] = 0;
		}
    } 

	public void button_5_1(){
		if (GameMatrix[5,1] == 0) {
			button51.GetComponent<Image>().color = Color.black;
			GameMatrix[5,1] = 1;
		}
		else if (GameMatrix[5,1] == 1) {
			button51.GetComponent<Image>().color = Color.white;
			GameMatrix[5,1] = 0;
		}
    } 

	public void button_5_2(){
		if (GameMatrix[5,2] == 0) {
			button52.GetComponent<Image>().color = Color.black;
			GameMatrix[5,2] = 1;
		}
		else if (GameMatrix[5,2] == 1) {
			button52.GetComponent<Image>().color = Color.white;
			GameMatrix[5,2] = 0;
		}
    } 

	public void button_5_3(){
		if (GameMatrix[5,3] == 0) {
			button53.GetComponent<Image>().color = Color.black;
			GameMatrix[5,3] = 1;
		}
		else if (GameMatrix[5,3] == 1) {
			button53.GetComponent<Image>().color = Color.white;
			GameMatrix[5,3] = 0;
		}
    } 

	public void button_5_4(){
		if (GameMatrix[5,4] == 0) {
			button54.GetComponent<Image>().color = Color.black;
			GameMatrix[5,4] = 1;
		}
		else if (GameMatrix[5,4] == 1) {
			button54.GetComponent<Image>().color = Color.white;
			GameMatrix[5,4] = 0;
		}
    } 
	
	public void button_5_5(){
		if (GameMatrix[5,5] == 0) {
			button55.GetComponent<Image>().color = Color.black;
			GameMatrix[5,5] = 1;
		}
		else if (GameMatrix[5,5] == 1) {
			button55.GetComponent<Image>().color = Color.white;
			GameMatrix[5,5] = 0;
		}
    } 

	public void button_5_6(){
		if (GameMatrix[5,6] == 0) {
			button56.GetComponent<Image>().color = Color.black;
			GameMatrix[5,6] = 1;
		}
		else if (GameMatrix[5,6] == 1) {
			button56.GetComponent<Image>().color = Color.white;
			GameMatrix[5,6] = 0;
		}
    } 

	public void button_5_7(){
		if (GameMatrix[5,7] == 0) {
			button57.GetComponent<Image>().color = Color.black;
			GameMatrix[5,7] = 1;
		}
		else if (GameMatrix[5,7] == 1) {
			button57.GetComponent<Image>().color = Color.white;
			GameMatrix[5,7] = 0;
		}
    } 

	public void button_5_8(){
		if (GameMatrix[5,8] == 0) {
			button58.GetComponent<Image>().color = Color.black;
			GameMatrix[5,8] = 1;
		}
		else if (GameMatrix[5,8] == 1) {
			button58.GetComponent<Image>().color = Color.white;
			GameMatrix[5,8] = 0;
		}
    } 

	public void button_5_9(){
		if (GameMatrix[5,9] == 0) {
			button59.GetComponent<Image>().color = Color.black;
			GameMatrix[5,9] = 1;
		}
		else if (GameMatrix[5,9] == 1) {
			button59.GetComponent<Image>().color = Color.white;
			GameMatrix[5,9] = 0;
		}
    } 
	
	//Row Six
	public void button_6_0(){
		if (GameMatrix[6,0] == 0) {
			button60.GetComponent<Image>().color = Color.black;
			GameMatrix[6,0] = 1;
		}
		else if (GameMatrix[6,0] == 1) {
			button60.GetComponent<Image>().color = Color.white;
			GameMatrix[6,0] = 0;
		}
    } 

	public void button_6_1(){
		if (GameMatrix[6,1] == 0) {
			button61.GetComponent<Image>().color = Color.black;
			GameMatrix[6,1] = 1;
		}
		else if (GameMatrix[6,1] == 1) {
			button61.GetComponent<Image>().color = Color.white;
			GameMatrix[6,1] = 0;
		}
    } 

	public void button_6_2(){
		if (GameMatrix[6,2] == 0) {
			button62.GetComponent<Image>().color = Color.black;
			GameMatrix[6,2] = 1;
		}
		else if (GameMatrix[6,2] == 1) {
			button62.GetComponent<Image>().color = Color.white;
			GameMatrix[6,2] = 0;
		}
    } 

	public void button_6_3(){
		if (GameMatrix[6,3] == 0) {
			button63.GetComponent<Image>().color = Color.black;
			GameMatrix[6,3] = 1;
		}
		else if (GameMatrix[6,3] == 1) {
			button63.GetComponent<Image>().color = Color.white;
			GameMatrix[6,3] = 0;
		}
    } 

	public void button_6_4(){
		if (GameMatrix[6,4] == 0) {
			button64.GetComponent<Image>().color = Color.black;
			GameMatrix[6,4] = 1;
		}
		else if (GameMatrix[6,4] == 1) {
			button64.GetComponent<Image>().color = Color.white;
			GameMatrix[6,4] = 0;
		}
    } 
	
	public void button_6_5(){
		if (GameMatrix[6,5] == 0) {
			button65.GetComponent<Image>().color = Color.black;
			GameMatrix[6,5] = 1;
		}
		else if (GameMatrix[6,5] == 1) {
			button65.GetComponent<Image>().color = Color.white;
			GameMatrix[6,5] = 0;
		}
    } 

	public void button_6_6(){
		if (GameMatrix[6,6] == 0) {
			button66.GetComponent<Image>().color = Color.black;
			GameMatrix[6,6] = 1;
		}
		else if (GameMatrix[6,6] == 1) {
			button66.GetComponent<Image>().color = Color.white;
			GameMatrix[6,6] = 0;
		}
    } 

	public void button_6_7(){
		if (GameMatrix[6,7] == 0) {
			button67.GetComponent<Image>().color = Color.black;
			GameMatrix[6,7] = 1;
		}
		else if (GameMatrix[6,7] == 1) {
			button67.GetComponent<Image>().color = Color.white;
			GameMatrix[6,7] = 0;
		}
    } 

	public void button_6_8(){
		if (GameMatrix[6,8] == 0) {
			button68.GetComponent<Image>().color = Color.black;
			GameMatrix[6,8] = 1;
		}
		else if (GameMatrix[6,8] == 1) {
			button68.GetComponent<Image>().color = Color.white;
			GameMatrix[6,8] = 0;
		}
    } 

	public void button_6_9(){
		if (GameMatrix[6,9] == 0) {
			button69.GetComponent<Image>().color = Color.black;
			GameMatrix[6,9] = 1;
		}
		else if (GameMatrix[6,9] == 1) {
			button69.GetComponent<Image>().color = Color.white;
			GameMatrix[6,9] = 0;
		}
    } 
	//Row seven
	public void button_7_0(){
		if (GameMatrix[7,0] == 0) {
			button70.GetComponent<Image>().color = Color.black;
			GameMatrix[7,0] = 1;
		}
		else if (GameMatrix[7,0] == 1) {
			button70.GetComponent<Image>().color = Color.white;
			GameMatrix[7,0] = 0;
		}
    } 

	public void button_7_1(){
		if (GameMatrix[7,1] == 0) {
			button71.GetComponent<Image>().color = Color.black;
			GameMatrix[7,1] = 1;
		}
		else if (GameMatrix[7,1] == 1) {
			button71.GetComponent<Image>().color = Color.white;
			GameMatrix[7,1] = 0;
		}
    } 

	public void button_7_2(){
		if (GameMatrix[7,2] == 0) {
			button72.GetComponent<Image>().color = Color.black;
			GameMatrix[7,2] = 1;
		}
		else if (GameMatrix[7,2] == 1) {
			button72.GetComponent<Image>().color = Color.white;
			GameMatrix[7,2] = 0;
		}
    } 

	public void button_7_3(){
		if (GameMatrix[7,3] == 0) {
			button73.GetComponent<Image>().color = Color.black;
			GameMatrix[7,3] = 1;
		}
		else if (GameMatrix[7,3] == 1) {
			button73.GetComponent<Image>().color = Color.white;
			GameMatrix[7,3] = 0;
		}
    } 

	public void button_7_4(){
		if (GameMatrix[7,4] == 0) {
			button74.GetComponent<Image>().color = Color.black;
			GameMatrix[7,4] = 1;
		}
		else if (GameMatrix[7,4] == 1) {
			button74.GetComponent<Image>().color = Color.white;
			GameMatrix[7,4] = 0;
		}
    } 
	
	public void button_7_5(){
		if (GameMatrix[7,5] == 0) {
			button75.GetComponent<Image>().color = Color.black;
			GameMatrix[7,5] = 1;
		}
		else if (GameMatrix[7,5] == 1) {
			button75.GetComponent<Image>().color = Color.white;
			GameMatrix[7,5] = 0;
		}
    } 

	public void button_7_6(){
		if (GameMatrix[7,6] == 0) {
			button76.GetComponent<Image>().color = Color.black;
			GameMatrix[7,6] = 1;
		}
		else if (GameMatrix[7,6] == 1) {
			button76.GetComponent<Image>().color = Color.white;
			GameMatrix[7,6] = 0;
		}
    } 

	public void button_7_7(){
		if (GameMatrix[7,7] == 0) {
			button77.GetComponent<Image>().color = Color.black;
			GameMatrix[7,7] = 1;
		}
		else if (GameMatrix[7,7] == 1) {
			button77.GetComponent<Image>().color = Color.white;
			GameMatrix[7,7] = 0;
		}
    } 

	public void button_7_8(){
		if (GameMatrix[7,8] == 0) {
			button78.GetComponent<Image>().color = Color.black;
			GameMatrix[7,8] = 1;
		}
		else if (GameMatrix[7,8] == 1) {
			button78.GetComponent<Image>().color = Color.white;
			GameMatrix[7,8] = 0;
		}
    } 

	public void button_7_9(){
		if (GameMatrix[7,9] == 0) {
			button79.GetComponent<Image>().color = Color.black;
			GameMatrix[7,9] = 1;
		}
		else if (GameMatrix[7,9] == 1) {
			button79.GetComponent<Image>().color = Color.white;
			GameMatrix[7,9] = 0;
		}
    } 
	
	//Row Eight
	public void button_8_0(){
		if (GameMatrix[8,0] == 0) {
			button80.GetComponent<Image>().color = Color.black;
			GameMatrix[8,0] = 1;
		}
		else if (GameMatrix[8,0] == 1) {
			button80.GetComponent<Image>().color = Color.white;
			GameMatrix[8,0] = 0;
		}
    } 

	public void button_8_1(){
		if (GameMatrix[8,1] == 0) {
			button81.GetComponent<Image>().color = Color.black;
			GameMatrix[8,1] = 1;
		}
		else if (GameMatrix[8,1] == 1) {
			button81.GetComponent<Image>().color = Color.white;
			GameMatrix[8,1] = 0;
		}
    } 

	public void button_8_2(){
		if (GameMatrix[8,2] == 0) {
			button82.GetComponent<Image>().color = Color.black;
			GameMatrix[8,2] = 1;
		}
		else if (GameMatrix[8,2] == 1) {
			button82.GetComponent<Image>().color = Color.white;
			GameMatrix[8,2] = 0;
		}
    } 

	public void button_8_3(){
		if (GameMatrix[8,3] == 0) {
			button83.GetComponent<Image>().color = Color.black;
			GameMatrix[8,3] = 1;
		}
		else if (GameMatrix[8,3] == 1) {
			button83.GetComponent<Image>().color = Color.white;
			GameMatrix[8,3] = 0;
		}
    } 

	public void button_8_4(){
		if (GameMatrix[8,4] == 0) {
			button84.GetComponent<Image>().color = Color.black;
			GameMatrix[8,4] = 1;
		}
		else if (GameMatrix[8,4] == 1) {
			button84.GetComponent<Image>().color = Color.white;
			GameMatrix[8,4] = 0;
		}
    } 
	
	public void button_8_5(){
		if (GameMatrix[8,5] == 0) {
			button85.GetComponent<Image>().color = Color.black;
			GameMatrix[8,5] = 1;
		}
		else if (GameMatrix[8,5] == 1) {
			button85.GetComponent<Image>().color = Color.white;
			GameMatrix[8,5] = 0;
		}
    } 

	public void button_8_6(){
		if (GameMatrix[8,6] == 0) {
			button86.GetComponent<Image>().color = Color.black;
			GameMatrix[8,6] = 1;
		}
		else if (GameMatrix[8,6] == 1) {
			button86.GetComponent<Image>().color = Color.white;
			GameMatrix[8,6] = 0;
		}
    } 

	public void button_8_7(){
		if (GameMatrix[8,7] == 0) {
			button87.GetComponent<Image>().color = Color.black;
			GameMatrix[8,7] = 1;
		}
		else if (GameMatrix[8,7] == 1) {
			button87.GetComponent<Image>().color = Color.white;
			GameMatrix[8,7] = 0;
		}
    } 

	public void button_8_8(){
		if (GameMatrix[8,8] == 0) {
			button88.GetComponent<Image>().color = Color.black;
			GameMatrix[8,8] = 1;
		}
		else if (GameMatrix[8,8] == 1) {
			button88.GetComponent<Image>().color = Color.white;
			GameMatrix[8,8] = 0;
		}
    } 

	public void button_8_9(){
		if (GameMatrix[8,9] == 0) {
			button89.GetComponent<Image>().color = Color.black;
			GameMatrix[8,9] = 1;
		}
		else if (GameMatrix[8,9] == 1) {
			button89.GetComponent<Image>().color = Color.white;
			GameMatrix[8,9] = 0;
		}
    } 
	
	//Row Nine
	public void button_9_0(){
		if (GameMatrix[9,0] == 0) {
			button90.GetComponent<Image>().color = Color.black;
			GameMatrix[9,0] = 1;
		}
		else if (GameMatrix[9,0] == 1) {
			button90.GetComponent<Image>().color = Color.white;
			GameMatrix[9,0] = 0;
		}
    } 

	public void button_9_1(){
		if (GameMatrix[9,1] == 0) {
			button91.GetComponent<Image>().color = Color.black;
			GameMatrix[9,1] = 1;
		}
		else if (GameMatrix[9,1] == 1) {
			button91.GetComponent<Image>().color = Color.white;
			GameMatrix[9,1] = 0;
		}
    } 

	public void button_9_2(){
		if (GameMatrix[9,2] == 0) {
			button92.GetComponent<Image>().color = Color.black;
			GameMatrix[9,2] = 1;
		}
		else if (GameMatrix[9,2] == 1) {
			button92.GetComponent<Image>().color = Color.white;
			GameMatrix[9,2] = 0;
		}
    } 

	public void button_9_3(){
		if (GameMatrix[9,3] == 0) {
			button93.GetComponent<Image>().color = Color.black;
			GameMatrix[9,3] = 1;
		}
		else if (GameMatrix[9,3] == 1) {
			button93.GetComponent<Image>().color = Color.white;
			GameMatrix[9,3] = 0;
		}
    } 

	public void button_9_4(){
		if (GameMatrix[9,4] == 0) {
			button94.GetComponent<Image>().color = Color.black;
			GameMatrix[9,4] = 1;
		}
		else if (GameMatrix[9,4] == 1) {
			button94.GetComponent<Image>().color = Color.white;
			GameMatrix[9,4] = 0;
		}
    } 
	
	public void button_9_5(){
		if (GameMatrix[9,5] == 0) {
			button95.GetComponent<Image>().color = Color.black;
			GameMatrix[9,5] = 1;
		}
		else if (GameMatrix[9,5] == 1) {
			button95.GetComponent<Image>().color = Color.white;
			GameMatrix[9,5] = 0;
		}
    } 

	public void button_9_6(){
		if (GameMatrix[9,6] == 0) {
			button96.GetComponent<Image>().color = Color.black;
			GameMatrix[9,6] = 1;
		}
		else if (GameMatrix[9,6] == 1) {
			button96.GetComponent<Image>().color = Color.white;
			GameMatrix[9,6] = 0;
		}
    } 

	public void button_9_7(){
		if (GameMatrix[9,7] == 0) {
			button97.GetComponent<Image>().color = Color.black;
			GameMatrix[9,7] = 1;
		}
		else if (GameMatrix[9,7] == 1) {
			button97.GetComponent<Image>().color = Color.white;
			GameMatrix[9,7] = 0;
		}
    } 

	public void button_9_8(){
		if (GameMatrix[9,8] == 0) {
			button98.GetComponent<Image>().color = Color.black;
			GameMatrix[9,8] = 1;
		}
		else if (GameMatrix[9,8] == 1) {
			button98.GetComponent<Image>().color = Color.white;
			GameMatrix[9,8] = 0;
		}
    } 

	public void button_9_9(){
		if (GameMatrix[9,9] == 0) {
			button99.GetComponent<Image>().color = Color.black;
			GameMatrix[9,9] = 1;
		}
		else if (GameMatrix[9,9] == 1) {
			button99.GetComponent<Image>().color = Color.white;
			GameMatrix[9,9] = 0;
		}
    } 

	

    // Update is called once per frame
    void Update()
    {
        
    }
}
