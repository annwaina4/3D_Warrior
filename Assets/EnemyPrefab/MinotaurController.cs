using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurController : MonoBehaviour
{
    //��ԁi�X�e�[�g�p�^�[���j
    private int stateNumber = 0;

    //�ėp�^�C�}�[
    private float timeCounter = 0f;

    private Animator myanimator;

    private Rigidbody myRigidbody;

    private GameObject player;

    private int HP = 3;

    //------------------------------------------------------------------------------------------------------------------
    //�X�^�[�g
    //------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        this.myanimator = GetComponent<Animator>();

        this.myRigidbody = GetComponent<Rigidbody>();

        this.player = GameObject.Find("Player");
    }

    //------------------------------------------------------------------------------------------------------------------
    //�I���W�i���֐�
    //------------------------------------------------------------------------------------------------------------------

    //���������߂�
    float getLength(Vector3 current, Vector3 target)
    {
        return Mathf.Sqrt(((current.x - target.x) * (current.x - target.x)) + ((current.z - target.z) * (current.z - target.z)));
    }

    //���������߂� ���I�C���[�i-180�`0�`+180)
    float getEulerAngle(Vector3 current, Vector3 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.z) * Mathf.Rad2Deg; //���W�A�����I�C���[
    }

    //���������߂� �����W�A��
    float getRadian(Vector3 current, Vector3 target)
    {
        Vector3 value = target - current;
        return Mathf.Atan2(value.x, value.z);
    }

    //------------------------------------------------------------------------------------------------------------------
    //�A�b�v�f�[�g
    //------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        //�^�C�}�[���Z
        timeCounter += Time.deltaTime;

        //���������߂�
        float direction = getEulerAngle(this.transform.position, player.transform.position);

        //���������߂�
        float length = getLength(this.transform.position, player.transform.position);

        //**************************************************************************************************************
        //���������ԏ���
        //**************************************************************************************************************

        //�ҋ@
        if (stateNumber == 0)
        {
            //�v���[���[�̕���������
            this.transform.rotation = Quaternion.Euler(0f, direction, 0f);

            //1�b�o��
            if (timeCounter > 1.0f)
            {
                //�^�C�}�[���Z�b�g
                timeCounter = 0f;

                // �A�j���[�V�����@�O�i
                this.myanimator.SetFloat("speed", 1.0f);

                //��Ԃ̑J�ځi�O�i�j
                stateNumber = 1;
            }
        }

        //�O�i
        else if (stateNumber == 1)
        {
            //�v���[���[�̕���������
            this.transform.rotation = Quaternion.Euler(0f, direction, 0f);

            //�ړ�
            myRigidbody.velocity = transform.forward * 2.0f;

            //5�b�o��
            if (timeCounter > 5.0f)
            {
                timeCounter = 0f;

                //�A�j���[�V�����@�ҋ@
                this.myanimator.SetFloat("speed", 0);

                //��Ԃ̑J�ځi�ҋ@�j
                stateNumber = 0;
            }
        }

    }

    //------------------------------------------------------------------------------------------------------------------
    //�Փ˔���
    //------------------------------------------------------------------------------------------------------------------
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("OnCollisionEnter:" + other.gameObject.tag);

        //�t�@�C�A�[�{�[��
        if (other.gameObject.tag == "Fireball" && HP > 0)
        {
            this.myanimator.SetTrigger("damage");

            HP--;
        }

        //���e�I
        if (other.gameObject.tag == "Meteor" && HP > 0)
        {
            this.myanimator.SetTrigger("damage");

            HP -= 3;
        }

        //Debug.Log("�c��HP" + this.HP);

        if (HP <= 0)
        {
            this.myanimator.SetBool("death", true);

            //�X�e�[�g�p�^�[�����~
            stateNumber = -1;

            //���R�������~
            myRigidbody.useGravity = false;
            //�Փ˂��Ȃ���
            GetComponent<CapsuleCollider>().enabled = false;

            //�T�b��ɔj��
            Destroy(this.gameObject, 5.0f);
        }
    }
}
