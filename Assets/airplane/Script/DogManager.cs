using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogManager : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 45f;

    public GameObject target;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //�@�v���C���[�̕������擾
        var playerDirection = new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.position;
        //�@�G�̌������v���C���[�̕����ɏ����Âς���
        var dir = Vector3.RotateTowards(transform.forward, playerDirection, rotateSpeed * Time.deltaTime, 0f);
        //�@�Z�o���������̊p�x��G�̊p�x�ɐݒ�
        transform.rotation = Quaternion.LookRotation(dir);

        //agent.speed = speed;
        agent.destination = target.transform.position;
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "target")
        {
            Debug.Log("��������");
        }

    }



    /*
   public GameObject target;           // �ǂ�������target
   public float speed = 10.0f;         // dog�̓���Speed

   private static Transform targetTr;  // target
   private static Transform myTr;      // Dog
   private bool Collided = false;      // �G�ꂽ���ǂ���
   private Animator m_Animator;
   private bool isWalking = false;
   private bool isSitting = false;

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
           this.gameObject.SetActive(false);
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
       m_Animator.SetBool("isSitting", isSitting);

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
           isSitting = true;
       }

   }
   */

}
