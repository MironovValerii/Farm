using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private int coin = 0;
    private int blocks = 0;

    public Text TextCoin, TextBlocks;

    private void Awake()
    {
        TextCoin.text = "Coin: " + coin.ToString();
        TextBlocks.text = "Blocks: " + blocks.ToString() + "/40";
    }
    private void Update()
    {
        TextBlocks.text = "Blocks: " + blocks.ToString() + "/40";
        TextCoin.text = "Coin: " + coin.ToString();
    }
    public void SetBlocks(int blocks)
    {
        this.blocks = blocks;
    }

    public void SetCoin(int coin)
    {
        this.coin = this.coin+coin*15;
    }
}
