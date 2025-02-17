using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene08");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene08");
    }

    public void Controls()
    {
        SceneManager.LoadScene("MenuScene_02");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
