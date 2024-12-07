using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (player.HaveAnyCoin())
                {
                    //Drop Coin
                    //Add I Frame
                    player.Coin = 0;
                }
                else
                {
                    Time.timeScale = 0;
                    player.GameOver();
                }
            }
        }
    }
}
