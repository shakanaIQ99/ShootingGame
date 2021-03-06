using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float spead = 5;

    public float time = 20;

    protected Vector3 forward =
        new Vector3(0, 0, 1);

    protected Quaternion forwardAxis = Quaternion.identity;

    protected Rigidbody rb;

    protected GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        if (enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = forwardAxis * forward * spead;

        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(this.gameObject);
        }


    }

    public void SetCharacterObject(GameObject character)
    {
        this.enemy = character;
    }

    public void SetForwardAxis(Quaternion axis)
    {
        this.forwardAxis = axis;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"/* || other.gameObject.tag == "PlayerBody"*/)
        {
            Destroy(this.gameObject);

            other.GetComponent<PlayerHP>().Damage();
           
        }
    }
}
