using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //�G�̐�����
    public int enemycounter = 0;

    //�G�̔z��
    public GameObject[] enemyprefab = new GameObject[4];

    //�����ꏊ�̔z��
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
                //�ǂ̓G�𐶐����邩�̗���
                int enemy = Random.Range(0, 4);

                //�ǂ̏ꏊ�ɐ������邩�̗���
                int respawn = Random.Range(0, 4);

                Instantiate(enemyprefab[enemy],obeliskObject[respawn].transform.transform.position,Quaternion.identity);

                enemycounter++;
            }

        }
 

    }
}
