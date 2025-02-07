using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class MonsterManager : MonoBehaviour
{
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    MonsterPool pool;
    
    private void Awake()
    {
        pool = this.gameObject.GetComponent<MonsterPool>();
    }
    private void Start()
    {
        sw.Start();
        //pool.Init(10);
        MonsterPool.Instance.Init(10);
        sw.Stop();
        Debug.Log("인스턴스 방식으로 소환에 소모한 시간 : <color=red>" + sw.ElapsedMilliseconds.ToString() + "</color> ms");
        
        //MonsterPool.GetMonster();
    }


}
