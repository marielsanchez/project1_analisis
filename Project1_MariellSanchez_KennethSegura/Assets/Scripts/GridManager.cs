using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    private int rows = 2;
    private int columns = 2;
    private float tileSize = 0.4f;//spaces between the elements
    //ACA
    private GameObject tile;
    public Button buttonback;
    public Text solution;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeSceneGame(){
        SceneManager.LoadScene("MainMenu");
    }
    
    public void GenerateGrid() {
        if (FileManager.Solved)
        {
            rows = FileManager.rowList.Count;
            columns = FileManager.columnList.Count;

            transform.localPosition = new Vector2(-2, 3);
            GameObject referenceTileWhite = (GameObject) Instantiate(Resources.Load("white"));
            GameObject referenceTileBlack = (GameObject) Instantiate(Resources.Load("black"));

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    float posX = col * tileSize;
                    float posY = row * -tileSize;

                    if (FileManager.FinalNonogram[row, col] == 1)
                    {
                        GameObject tileM = (GameObject) Instantiate(referenceTileBlack, transform);
                        tileM.transform.position = new Vector2(posX, posY);
                    }
                    else
                    {
                        GameObject tileM = (GameObject) Instantiate(referenceTileWhite, transform);
                        tileM.transform.position = new Vector2(posX, posY);

                    }
                }
            }

            Destroy(referenceTileWhite);
            Destroy(referenceTileBlack);
            transform.localPosition = new Vector2(-3, 5);
        }
    }
    
    public void GenerateSlowGrid() {
        if (FileManager.Solved)
        {
            rows = FileManager.rowList.Count;
            columns = FileManager.columnList.Count;
            
            transform.localPosition = new Vector2(-2, 3);
            GameObject referenceTileWhite = (GameObject)Instantiate(Resources.Load("white"));
            GameObject referenceTileBlack = (GameObject)Instantiate(Resources.Load("black"));
            
            for (int row = 0; row < rows ; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    float posX = col * tileSize;
                    float posY = row * -tileSize;
                    
                    if ( FileManager.FinalNonogram[row,col] == 1)
                    {
                        GameObject tileM = (GameObject) Instantiate(referenceTileBlack, transform);
                        tileM.transform.position = new Vector2(posX, posY);
                    }
                    else
                    {
                        GameObject tileM = (GameObject) Instantiate(referenceTileWhite, transform);
                        tileM.transform.position = new Vector2(posX, posY);

                    }
                }
                Thread.Sleep(500);
            }  
            Destroy(referenceTileWhite);
            Destroy(referenceTileBlack);
            transform.localPosition = new Vector2(-3, 5);
        }
    }

    public void LastGenerateSlowGrid() {
        rows = FileManager.rowList.Count;
        columns = FileManager.columnList.Count;
        
        transform.localPosition = new Vector2(-2, 3);
        GameObject referenceTileWhite = (GameObject)Instantiate(Resources.Load("white"));
        GameObject referenceTileBlack = (GameObject)Instantiate(Resources.Load("black"));
        
        for (int row = 0; row < rows ; row++)
        {
            StartCoroutine(ExampleCoroutine2(referenceTileBlack, referenceTileWhite, row));
            
        }  
        //Destroy(referenceTileWhite);
        //Destroy(referenceTileBlack);
        transform.localPosition = new Vector2(-3, 5);
    }
    
    IEnumerator ExampleCoroutine2(GameObject referenceTileBlack,GameObject referenceTileWhite, int row)
    {
        yield return new WaitForSeconds(2);
        for (int col = 0; col < columns; col++)
        {
            float posX = col * tileSize;
            float posY = row * -tileSize;
                
            if ( FileManager.FinalNonogram[row,col] == 1)
            {
                GameObject tileM = (GameObject) Instantiate(referenceTileBlack, transform);
                tileM.transform.position = new Vector2(posX, posY);
            }
            else
            {
                GameObject tileM = (GameObject) Instantiate(referenceTileWhite, transform);
                tileM.transform.position = new Vector2(posX, posY);

            }
        }
    }
    
    IEnumerator ExampleCoroutine()
    {
        Debug.Log(Time.time);
        Debug.Log("No estoy llegando aca");
        yield return new WaitForSeconds(2);
        Debug.Log(Time.time);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
