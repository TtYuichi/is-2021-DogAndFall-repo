using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour
{
    public GameObject target;           // �ǂ�������target
    public float speed = 10.0f;         // dog�̓���Speed

    private static Transform targetTr;  // target
    private static Transform myTr;      // Dog
    private bool Collided = false;      // �G�ꂽ���ǂ���
    private Animator m_Animator;
    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        //������
        targetTr = target.transform;
        myTr = this.transform;
        m_Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    /// <summary>
    /// �G�ꂽ�Ƃ�
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "target")
        {
            Collided = true;
            Debug.Log("��������");
        }

    }

    /// <summary>
    /// �G���̂���߂�
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionExit(Collision col)
    {
        Collided = false;
    }

    /// <summary>
    /// �ǐ�
    /// </summary>
    private void Chase()
    {
        //�A�j���[�V�������Z�b�g
        m_Animator.SetBool("isWalking", isWalking);

        if (!Collided) // �G��ĂȂ�
        {
            Debug.Log("�G��ĂȂ�");
            isWalking = true;
            myTr.LookAt(target.transform);
            Vector3 relativePos = targetTr.position - myTr.position; // Target�̏ꏊ��c��
            myTr.position += relativePos.normalized * speed * Time.deltaTime;



        }
        else // �G��Ă���
        {
            Debug.Log("�G�ꂽ");
            isWalking = false;
        }
        
    }

}
