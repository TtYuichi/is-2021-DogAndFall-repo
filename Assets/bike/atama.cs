using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atama : MonoBehaviour
{
    Vector3 initPos;
    GameObject underBlock;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position; //���W�擾
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //���̂ɓ����������ɌĂ΂��֐�
    void OnCollisionEnter(Collision col)
    {
        //col�ɓ������������蔻��̏�񂪓���
        //���������������̂̃^�O���uground�v�Ȃ�
        if(col.gameObject.tag == "ground")  //&& transform.position.y == 3
        {
            //��������������
            print("�n�ʂɗ������@(���s)");
            print(underBlock.transform.position); //�^���u���b�N�̈ʒu�c��

        }

        else if (col.gameObject.tag == "dodai" )
        {
            //��������������
            underBlock = col.gameObject;�@//underBlock�̃I�u�W�F�N�g��ς���
            print("�y��ɗ�����");
        }
    }
}
