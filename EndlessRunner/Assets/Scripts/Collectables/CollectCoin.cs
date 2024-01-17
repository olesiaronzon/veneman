using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFx;

    void OnTriggerEnter(Collider other){
      coinFx.Play();
      CollectablesControl.coinCount+=1;
      this.gameObject.SetActive(false);
    }
}
