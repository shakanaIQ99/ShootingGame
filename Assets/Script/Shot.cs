using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public GameObject Bullet;

    private float countup = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        countup = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            countup += 0.1f;
            if (countup >= 1.0f)
            {
                Instantiate(Bullet, transform.position, Quaternion.identity);
                countup = 0.0f;
            }
        }
    }
}
