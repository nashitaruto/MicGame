using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    GameObject player;
    Animator anim;
    Rigidbody rigitBody;
    private float lifeTime = 2.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddExplosionForce(10, player.transform.position, 4);
        anim.speed = 1;
        anim.SetBool("Death", true);
        Destroy(this.gameObject, lifeTime);
    }
}