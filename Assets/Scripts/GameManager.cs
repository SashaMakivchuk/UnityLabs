using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class GameData
{
    public int lives = 3;
    public int collectedCoins = 0;
    public float levelTimer = 120f;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameData data = new GameData();
    public static event Action OnGameOver;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        data.collectedCoins++;
        Debug.Log("Coins: " + data.collectedCoins);
    }

    public void LoseLife()
    {
        data.lives--;
        Debug.Log("Lives left: " + data.lives);
        if (data.lives <= 0)
        {
            Debug.Log("GAME OVER");
            OnGameOver?.Invoke();
        }
    }
}
