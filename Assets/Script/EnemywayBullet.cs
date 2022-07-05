using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemywayBullet : MonoBehaviour
{
    private GameObject player;

    public GameObject bullet;

    public int bulletwaynum = 3;

    public float bulletwayspace = 30;

    public float time = 1;

    public float delayTime = 1;

    float nowtime = 0;


    // Start is called before the first frame update
    void Start()
    {
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(player==null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        nowtime -= Time.deltaTime;

        if(nowtime<=0)
        {
            float bulletWaySpaceSplit = 0;

            for(int i=0;i<bulletwaynum;i++)
            {
                CreateShotObject(bulletwayspace - bulletWaySpaceSplit + transform.localEulerAngles.y);

                bulletWaySpaceSplit += (bulletwayspace / (bulletwaynum - 1)) * 2;
            }
            nowtime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        var direction = player.transform.position - transform.position;

        direction.y = 0;

        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        bulletObject.SetCharacterObject(gameObject);

        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));

    }


}
