/*
    directionToTarget * (�����̔��a+�^�[�Q�b�g�̔��a)�ŁA�����ƃ^�[�Q�b�g�̔��a�̒������̌����x�N�g�������߂���B
    �܂�A���X�̃^�[�Q�b�g���W����A���̒����̃x�N�g���������΁A�^�[�Q�b�g�ɏd�Ȃ�Ȃ��B�܂��A�}�[�W���Ƃ���attackDistanceThreshold��p�ӂ��Ă���B
    �����offset�ł�padding�ł�margin�ł��ǂ�ȕϐ��ł��悭�āA�Ƃ肠�����A�G�̍U���͈͂Ƃ��Ă���B
 */

using UnityEngine;

public class DogManager : MonoBehaviour
{
    public GameObject target;            // �ǂ�������target
    public float speed = 1.0f;           // dog�̓���Speed

    private static Transform targetTr;   // target
    private static Transform myTr;       // Dog
    private static Animator m_Animator;
    private bool Collided  = false;      // �G�ꂽ���ǂ���
    private bool isWalking = false;
    private bool isSitting = false;

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
        if (!Collided) { // target�ɐG��Ă��Ȃ�

            isWalking = true; // ����
            Chase(Collided); // ����

        }
        else
        {
            Chase(Collided); // ����
            isWalking = false;

            //if () // �{�[�����E������
            //{
                // �J�����̏ꏊ�ɕԂ��Ă��� target��Camera�ɂ���΂���
                // isWalking��true�ɂ���
                // Chase(Collided)��Collider��false�ɂ���
                // �J�����̈ʒu�ɗ�����Collider��false�AisWalking��false�AisSitting��True
            //}

        }
    }

    /// <summary>
    /// �G�ꂽ�Ƃ�
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay(Collider col)
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
    void OnTriggerExit(Collider col)
    {
        //Collided = false;
        Debug.Log("�����������");
    }

    /// <summary>
    /// �ǐ�
    /// </summary>
    private void Chase(bool move)
    {
        //�A�j���[�V�������Z�b�g
        m_Animator.SetBool("isWalking", isWalking);
        m_Animator.SetBool("isSitting", isSitting);

        if (!move)
        {
            myTr.LookAt(target.transform);
            Vector3 relativePos = targetTr.position - myTr.position; // Target�̏ꏊ��c��
            myTr.position += relativePos.normalized * speed; // �ړ�
        }
        else
        {
            isSitting = true;
        }

        //if(Collided) // �G��Ă���
        //{
        //    Debug.Log("�G�ꂽ");
        //    isSitting = true;
            
        //}

    }
    /*
    public Transform target;

    float myCollisionRadius;
    float targetCollisionRadius;

    [Range(1.0f, 10.0f)]
    public float attackDistanceThreshold = 1.0f;

    private NavMeshAgent agent;
    private float nextAttackTime;
    private bool touch = false;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        myCollisionRadius = GetComponent<CapsuleCollider>().radius;
        targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;

        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        // Time.time�̓Q�[���J�n����̕b�B
        if (Time.time > nextAttackTime)
        {

            //// �������r����Ƃ��́A������(Mathf.Sqrt)�̃R�X�g�������̂ŁA�����̓��ʂ����v�Z���邱�ƂŁA�p�t�H�[�}���X��������B
            //// ���݂̃^�[�Q�b�g�Ǝ��g�̋����̓��B
            //float sqrMag = (target.position - transform.position).sqrMagnitude;
            //// �U���J�n��臒l�̓��
            //float sqrAttackRange = Mathf.Pow(myCollisionRadius + targetCollisionRadius + attackDistanceThreshold, 2);
            //if (sqrMag < sqrAttackRange)
            //{
            //    nextAttackTime = Time.time + timeBetweenAttacks;
            //    Debug.Log("Attack");
            //}
        }
    }

    IEnumerator UpdatePath()
    {
        while (this.target.position == target.position)//(target != null)
        {
            // �^�[�Q�b�g�̒��S�ɂ܂ňړ�����
            //Vector3 targetPosition = new Vector3(target.position.x, 0f, target.position.z);
            //agent.SetDestination(targetPosition);

            // ���������߂�
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Vector3 targetPosition = target.position - directionToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2);
            //Debug.Log(targetPosition);
            agent.SetDestination(targetPosition);

            if (touch)
            {
                Debug.Log("�G����");
            }

            // �P�b�E�F�C�g
            yield return new WaitForSeconds(.1f);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "target")
        {
            touch = true;
        }

    }

    private void OnCollisionExit(Collision col)
    {
        touch = false;
    }
    */

    //public GameObject target;
    //private NavMeshAgent agent;

    //// Use this for initialization
    //void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //agent.speed = speed;
    //    agent.destination = target.transform.position;

    //}



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
