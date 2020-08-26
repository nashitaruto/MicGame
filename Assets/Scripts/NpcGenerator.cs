using UnityEngine;
using System.Collections;

public class NpcGenerator : MonoBehaviour
{

    [SerializeField] GameObject[] enemys;
    [SerializeField] float appearNextTime;
    [SerializeField] int maxNumOfEnemys;
    private int numberOfEnemys;
    private float elapsedTime;

    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }
    void Update()
    {
        if (numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }
        elapsedTime += Time.deltaTime;

        if (elapsedTime > appearNextTime)
        {
            float appearNextTime = Random.Range(1.0f, 8.0f);
            elapsedTime = 0f;
            AppearEnemy();
        }
    }
    void AppearEnemy()
    {
        var randomValue = Random.Range(0, enemys.Length);
        var randomRotationY = Random.value * 360f;

        GameObject.Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, randomRotationY, 0f));

        numberOfEnemys++;
        elapsedTime = 0f;
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGenerator : MonoBehaviour
{
    public GameObject npcPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<30; i++)
        {
            float x = Random.Range(0.0f, 10.0f);
            float y = Random.Range(0.0f, 2.0f);
            float z = Random.Range(0.0f, 10.0f);
            //オブジェクトを生産
            GameObject npc = Instantiate(npcPrefab, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
