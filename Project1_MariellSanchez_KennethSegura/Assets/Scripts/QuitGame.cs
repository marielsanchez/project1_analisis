using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitGameFuntion()
    {
        Application.Quit();
        Debug.Log("Se ha salido del juego");

    }
}
