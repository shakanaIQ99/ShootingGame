using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private GameObject player;

    public GameObject Bullet;

    public float time = 1;

    public float delayTime = 1;

    float nowtime = 0;

    void Start()
    {
        nowtime = delayTime;   
    }

    void Update()
    {
        if(player==null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        nowtime -= Time.deltaTime;

        if(nowtime<=0)
        {
            CreateShotObject(-transform.localEulerAngles.y);

            nowtime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        var direction = player.transform.position - transform.position;

        direction.y = 0;

        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        GameObject bulletClone =
            Instantiate(Bullet, transform.position, Quaternion.identity);

        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        bulletObject.SetCharacterObject(gameObject);

        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));

    }

    //private void CreateShotObject(float axis)
    //{
    //    GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);

    //    var bulletObject = bulletClone.GetComponent<EnemyBullet>();

    //    bulletObject.SetCharacterObject(gameObject);

    //    bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    //}

}
