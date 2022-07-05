using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {

            GameObject[] enemyBulletObjects = GameObject.FindGameObjectsWithTag("EnemyBullet");

            for(int i=0;i<enemyBulletObjects.Length;i++)
            {
                Destroy(enemyBulletObjects[i].gameObject);
            }
            GenerateEffect();
        }

        void GenerateEffect()
        {
            //�G�t�F�N�g�𐶐�����
            GameObject effect = Instantiate(particle) as GameObject;
            //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
            effect.transform.position = gameObject.transform.position;
        }
    }
}
