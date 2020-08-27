using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public FloatingJoystick joystick;
    private CharacterController characterController;
    public float MoveSpeed;
    private Animator anim;
    private GameObject stateText;
    GameObject mic;
    GameObject backtomenu;

    void Start()
    {
        mic = GameObject.Find("Mic");
        this.stateText = GameObject.Find("GameResultText");
        characterController = GetComponent<CharacterController>();
        GetComponent<SphereCollider>().enabled = false;

        anim = GetComponent<Animator>();
        anim.SetBool("Run", false);

        backtomenu = GameObject.Find("BacktoMenu");
    }

    void Update()
    {
        //移動
        float E_Rotation = Input.GetAxis("Mouse X");
        float E_Position = Input.GetAxis("Mouse Y");
        float P_Rotation = joystick.Horizontal;
        float P_Position = joystick.Vertical;
        //スマホ
        if (joystick.Vertical > 0)
        {
            characterController.Move(this.gameObject.transform.forward * MoveSpeed * Time.deltaTime);
            anim.SetBool("Run", true);
        }

        if (joystick.Vertical < 0)
        {
            characterController.Move(this.gameObject.transform.forward * -1f * MoveSpeed * Time.deltaTime);
            anim.SetBool("Run", true);
        }

        if (joystick.Horizontal > 0)
        {
            this.transform.Rotate(0, P_Rotation, 0);
        }

        if (joystick.Horizontal < 0)
        {
            this.transform.Rotate(0, P_Rotation * 1.0f, 0);
        }

        if (joystick.Vertical == 0 && joystick.Horizontal == 0)
        {
            anim.SetBool("Run", false);
        }

        //PC
        if (Application.isEditor)
        {
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
        }

            //音の衝突判定のon off
            MicVolume volumeRate = mic.GetComponent<MicVolume>();
        if (volumeRate.m_volumeRate >= 0.1)
        {
            GetComponent<SphereCollider>().enabled = true;
        }
        else
        {
            GetComponent<SphereCollider>().enabled = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            anim.speed = 0;
        }
    }
            //ゴール時の処理
            private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "GoalTag")
        {
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
            anim.SetBool("Run", false);
            backtomenu.GetComponent<BacktoMenu>().isFadeOut = true;
            this.GetComponent<PlayerController>().enabled = false;
        }
    }
}