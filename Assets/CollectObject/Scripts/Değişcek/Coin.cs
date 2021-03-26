using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ICollectible
{
    public bool OnCollect(PlayerController playerController)
    {
        return true;
    }
}
