using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CoinWallet : NetworkBehaviour
{
   public NetworkVariable<int> TotalCoins = new();

   private void OnTriggerEnter2D(Collider2D other)
   {
      if(!other.TryGetComponent(out Coin coin)) return;

      int coinValue = coin.Collect();
      
      if(!IsServer) return;

      TotalCoins.Value += coinValue;
   }
}