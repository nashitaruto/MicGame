using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicePhysics : MonoBehaviour
{
    public float impulse = 1f;
    Rigidbody rigidBody;
    Rigidbody playerRigidBody;
    GameObject player;
    Animator anim;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rigidBody.freezeRotation = false;
            Vector3 playerVelocity = playerRigidBody.velocity;
            rigidBody.AddForce(playerVelocity * impulse, ForceMode.Impulse);
            //rigidBody.AddForce(Vector3.up * impulse, ForceMode.Impulse);

            anim.speed = 1;
            anim.SetBool("Death", true);

        }
    }
}