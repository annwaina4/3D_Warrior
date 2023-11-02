using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiController : MonoBehaviour
{
    private int HP = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("OnCollisionEnter:" + collision.gameObject.tag);
        Debug.Log("�c��HP" + this.HP);
        //�t�@�C�A�[�{�[��
        if (collision.gameObject.tag == "Fireball" && HP > 0)
        {
            GetComponent<Animator>().SetTrigger("damage");

            HP--;
        }

        //���e�I
        if (collision.gameObject.tag == "Meteor" && HP > 0)
        {
            GetComponent<Animator>().SetTrigger("damage");

            HP -= 3;
        }

        if (HP <= 0)
        {
            GetComponent<Animator>().SetTrigger("death");
        }
    }
}
