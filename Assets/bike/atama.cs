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
        initPos = transform.position; //座標取得
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //物体に当たった時に呼ばれる関数
    void OnCollisionEnter(Collision col)
    {
        //colに当たった当たり判定の情報が入る
        //もし当たった物体のタグが「ground」なら
        if(col.gameObject.tag == "ground")  //&& transform.position.y == 3
        {
            //ここを処理する
            print("地面に落ちた　(失敗)");
            print(underBlock.transform.position); //真下ブロックの位置把握

        }

        else if (col.gameObject.tag == "dodai" )
        {
            //ここを処理する
            underBlock = col.gameObject;　//underBlockのオブジェクトを変える
            print("土台に落ちた");
        }
    }
}
