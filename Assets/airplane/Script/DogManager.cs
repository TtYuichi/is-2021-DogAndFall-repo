using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour
{
    public GameObject target;           // 追いかけるtarget
    public float speed = 10.0f;         // dogの動くSpeed

    private static Transform targetTr;  // target
    private static Transform myTr;      // Dog
    private bool Collided = false;      // 触れたかどうか
    private Animator m_Animator;
    private bool isWalking = false;

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
        }
        
    }

}
