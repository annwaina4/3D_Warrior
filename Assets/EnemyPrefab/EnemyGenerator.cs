using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //敵の生成数
    public int enemycounter = 0;

    //敵の配列
    public GameObject[] enemyprefab = new GameObject[4];

    //生成場所の配列
    public GameObject[] obeliskObject = new GameObject[4];

    float timecounter = 0f;
    float span = 3.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        timecounter += Time.deltaTime;

        if (timecounter > span)
        {
            timecounter = 0f;

            if (enemycounter <= 10)
            {
                //どの敵を生成するかの乱数
                int enemy = Random.Range(0, 4);

                //どの場所に生成するかの乱数
                int respawn = Random.Range(0, 4);

                Instantiate(enemyprefab[enemy],obeliskObject[respawn].transform.transform.position,Quaternion.identity);

                enemycounter++;
            }

        }
 

    }
}
