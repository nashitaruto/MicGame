using System.Collections;
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
}
