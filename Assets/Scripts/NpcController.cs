using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class NpcController : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Transform target;
    Rigidbody rigidBody;
    GameObject player;
    private float lifeTime = 2.0f;
    private float defaultMoveSpeed;
    public float MoveSpeed;
    GameObject playercontroller;
    private GameObject gameoverText;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameoverText = GameObject.Find("GameOverText");

        defaultMoveSpeed = agent.speed;
        MoveSpeed = defaultMoveSpeed;
    }

    void Update()
    {
        if (player != null)
        {
            agent.speed = MoveSpeed;
            Move();
        }
        else
        {
            Stop();
        }
    }
    void Move()
    {
        anim.SetFloat("MoveSpeed", agent.speed, 0.1f, Time.deltaTime);
        agent.SetDestination(player.transform.position);
        rigidBody.velocity = agent.desiredVelocity;
    }
    void Stop()
    {
        agent.speed = 0;

        anim.SetFloat("MoveSpeed", agent.speed, 0.1f, Time.deltaTime);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //ゲームオーバー処理
            var gameover = player.GetComponent<PlayerController>();
            player.GetComponent<PlayerController>().enabled = false;
            anim.speed = 0;
            gameoverText.GetComponent<Text>().text = "GAME OVER";
        }
    }
    void OnTriggerEnter(Collider col)
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddExplosionForce(500, player.transform.position, 4);
        anim.speed = 1;
        anim.SetBool("Death", true);
        Destroy(this.gameObject, lifeTime);
    }
}