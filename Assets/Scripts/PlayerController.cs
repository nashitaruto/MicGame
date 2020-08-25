﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;
    private Vector3 Velocity;
    public Transform verRot;
    public Transform horRot;
    public float MoveSpeed;
    private Animator anim;
    private GameObject stateText;
    GameObject mic;

    void Start()
    {
        mic = GameObject.Find("Mic");
        this.stateText = GameObject.Find("GameResultText");
        characterController = GetComponent<CharacterController>();
        GetComponent<SphereCollider>().enabled = false;

        anim = GetComponent<Animator>();
        anim.SetBool("Run", false);
    }

    void Update()
    {
        //移動
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        horRot.transform.Rotate(new Vector3(0, X_Rotation * 2, 0));
        verRot.transform.Rotate(-Y_Rotation * 2, 0, 0);

            if (Input.GetKey(KeyCode.W))
            {
                characterController.Move(this.gameObject.transform.forward * MoveSpeed * Time.deltaTime);
                anim.SetBool("Run", true);
            }

            else if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                characterController.Move(this.gameObject.transform.forward * -1f * MoveSpeed * Time.deltaTime);
                anim.SetBool("Run", true);
            }

            else if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                characterController.Move(this.gameObject.transform.right * -1 * MoveSpeed * Time.deltaTime);
                anim.SetBool("Run", true);
            }

            else if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("Run", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                characterController.Move(this.gameObject.transform.right * MoveSpeed * Time.deltaTime);
                anim.SetBool("Run", true);
            }

            else if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("Run", false);
            }

        characterController.Move(Velocity);
        
        //音の衝突判定のon off
        MicVolume volumeRate = mic.GetComponent<MicVolume>();
        if (volumeRate.m_volumeRate >= 0.8)
        {
            GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            GetComponent<SphereCollider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "GoalTag")
        {
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
            anim.SetBool("Run", false);
            this.GetComponent<PlayerController>().enabled = false;
        }
    }
}