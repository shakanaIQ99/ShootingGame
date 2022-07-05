using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 LeftBottom;

    Vector3 RightTop;

    private float Left, Right, Top, Bottom;

    // Start is called before the first frame update
    void Start()
    {
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        foreach(Transform child in gameObject.transform)
        {
            if(child.localPosition.x>=Right)
            {
                Right = child.transform.localPosition.x;
            }
            if (child.localPosition.x <= Left)
            {
               Left = child.transform.localPosition.x;
            }
            if (child.localPosition.x >= Top)
            {
               Top = child.transform.localPosition.z;
            }
            if (child.localPosition.x <= Bottom)
            {
                Bottom = child.transform.localPosition.z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += 0.05f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x -= 0.05f;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                pos.z += 0.05f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                pos.z -= 0.05f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += 0.1f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x -= 0.1f;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                pos.z += 0.1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                pos.z -= 0.1f;
            }
        }
        transform.position = new Vector3(Mathf.Clamp(pos.x,LeftBottom.x+transform.localScale.x-Left,RightTop.x-transform.localScale.x-Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z-Bottom, RightTop.z - transform.localScale.z-Top));
    }

}
