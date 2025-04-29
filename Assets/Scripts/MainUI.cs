using System;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private bool isPlayer1 = true;
    private bool isPlayer2;
    public void ChangeScene()
    {
        if (isPlayer1)
        {
            SceneManager.LoadScene("1Player");
        }
        if (isPlayer2)
        {
            SceneManager.LoadScene("2Player");
        }
    }

    public void Options()
    {
        if (player1.activeSelf == false)
        {
            player1.SetActive(true);
            player2.SetActive(true);
        }
        else 
        {
            player1.SetActive(false);
            player2.SetActive(false);
        }
    }

    public void Player1()
    {
        isPlayer1 = true;
        isPlayer2 = false;
        player1.SetActive(false);
        player2.SetActive(false);
    }
    public void Player2()
    {
        isPlayer1 = false;
        isPlayer2 = true;
        player1.SetActive(false);
        player2.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
