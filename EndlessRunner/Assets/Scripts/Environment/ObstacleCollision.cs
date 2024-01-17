using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud;
    public GameObject levelControl;

    void OnTriggerEnter(Collider other){
      this.gameObject.GetComponent<BoxCollider>().enabled=false;
      thePlayer.GetComponent<PlayerMove>().StopMovement();
      charModel.GetComponent<Animator>().Play("Stumble Backwards");
      levelControl.GetComponent<LevelDistance>().enabled=false;
      crashThud.Play();
      levelControl.GetComponent<EndRunSequence>().enabled=true;
    }
}
