using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributes
    private int coin;

    public int Coin
    {
        get { return coin;}
        set { coin = Mathf.Max(value,0); }
    }

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameOverScreen gameOverScreen;


    //Method
    void Update()
    {
        coinText.text = $"coin: {Coin}";
    }

    public void CollectingCoin()
    {
        Coin += 1;
    }
    public void CollectingCoin(int coinCollected)
    {
        Coin += coinCollected;
    }

    public bool HaveAnyCoin()
    {
        return Coin > 0;
    }

    public void GameOver()
    {
        gameOverScreen.StartGameOver();
    }
}
