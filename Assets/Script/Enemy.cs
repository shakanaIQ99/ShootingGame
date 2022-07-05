using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particle;
    private int enemyHp;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHp<=0)
        {
            
            Destroy(this.gameObject);
            GenerateEffect();
            //Instantiate(particle, Vector3.zero, Quaternion.identity);
            //particle.transform.position = gameObject.transform.position;
        }
    }

    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(particle) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }
    public void Damage()
    {
        enemyHp = enemyHp - 1;
    }
}
