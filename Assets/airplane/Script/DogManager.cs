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

        //　プレイヤーの方向を取得
        var playerDirection = new Vector3(transform.position.x, transform.position.y, transform.position.z) - transform.position;
        //　敵の向きをプレイヤーの方向に少しづつ変える
        var dir = Vector3.RotateTowards(transform.forward, playerDirection, rotateSpeed * Time.deltaTime, 0f);
        //　算出した方向の角度を敵の角度に設定
        transform.rotation = Quaternion.LookRotation(dir);

        //agent.speed = speed;
        agent.destination = target.transform.position;
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "target")
        {
            Debug.Log("当たった");
        }

    }



    /*
   public GameObject target;           // 追いかけるtarget
   public float speed = 10.0f;         // dogの動くSpeed

   private static Transform targetTr;  // target
   private static Transform myTr;      // Dog
   private bool Collided = false;      // 触れたかどうか
   private Animator m_Animator;
   private bool isWalking = false;
   private bool isSitting = false;

   // Start is called before the first frame update
   void Start()
   {
       //初期化
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
   /// 触れたとき
   /// </summary>
   /// <param name="col"></param>
   void OnCollisionEnter(Collision col)
   {
       if (col.gameObject.tag == "target")
       {
           Collided = true;
           Debug.Log("当たった");
           this.gameObject.SetActive(false);
       }

   }

   /// <summary>
   /// 触れるのをやめた
   /// </summary>
   /// <param name="col"></param>
   private void OnCollisionExit(Collision col)
   {
       Collided = false;
   }

   /// <summary>
   /// 追跡
   /// </summary>
   private void Chase()
   {
       //アニメーションをセット
       m_Animator.SetBool("isWalking", isWalking);
       m_Animator.SetBool("isSitting", isSitting);

       if (!Collided) // 触れてない
       {
           Debug.Log("触れてない");
           isWalking = true;
           myTr.LookAt(target.transform);
           Vector3 relativePos = targetTr.position - myTr.position; // Targetの場所を把握
           myTr.position += relativePos.normalized * speed * Time.deltaTime;


       }
       else // 触れている
       {
           Debug.Log("触れた");
           isWalking = false;
           isSitting = true;
       }

   }
   */

}
