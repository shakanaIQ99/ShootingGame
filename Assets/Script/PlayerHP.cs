using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject particle;
    private int playerHP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0)
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
        playerHP = playerHP - 1;
    }
}
