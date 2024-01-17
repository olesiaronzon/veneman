using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
//using System.IO;
//using System;


public class PlayerMove : MonoBehaviour {

    SerialPort sp;

    public float moveSpeed=5;
    public float leftRightSpeed=4;
    public bool canMove=true;
    public bool isJumping=false;
    public bool comingDown=false;
    public GameObject playerObject;


    void Start () {
    sp = new SerialPort("/dev/cu.usbserial-A10LV8AI Serial Port (USB)", 9600);
    //sp.ReadTimeout = 10;
    sp.Open();
    }

    void Update()
    {
      if(sp.IsOpen){
        string data=sp.ReadLine();
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
          if(canMove==true){
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
              if(this.gameObject.transform.position.x > LevelBoundry.leftSide){
                transform.Translate(Vector3.left*Time.deltaTime*leftRightSpeed);
              }
            }
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
              if(this.gameObject.transform.position.x < LevelBoundry.rightSide){
                transform.Translate(Vector3.left*Time.deltaTime*leftRightSpeed* -1);
              }
            }
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)){
              if(isJumping==false){
                isJumping=true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
              }
            }
          }
          if(isJumping==true){
            if(comingDown==false){
              transform.Translate(Vector3.up*Time.deltaTime*3, Space.World);
            }
            if(comingDown==true){
              transform.Translate(Vector3.up*Time.deltaTime*-3, Space.World);
            }
          }
          Debug.Log("Arduino data:" + data);
        }
    }

    public void StopMovement(){
      canMove=false;
      moveSpeed=0;
      leftRightSpeed=0;
    }


    IEnumerator JumpSequence(){
      yield return new WaitForSeconds(0.45f);
      comingDown=true;
      yield return new WaitForSeconds(0.45f);
      isJumping=false;
      comingDown=false;
      playerObject.GetComponent<Animator>().Play("Running");
    }
  }
