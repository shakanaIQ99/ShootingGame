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
        //�G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(particle) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
        effect.transform.position = gameObject.transform.position;
    }
    public void Damage()
    {
        playerHP = playerHP - 1;
    }
}
