using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limb : MonoBehaviour
{
    public GameObject player;
    bool inRange = false;

    Color baseColor;
    public Color activeColor = Color.green;

    private bool _isPickedUp;
    bool IsPickedUp
    {
        get
        {
            return _isPickedUp;
        }
        set
        {
            _isPickedUp = value;
            GetComponent<Rigidbody>().useGravity = !value;

            if (value)
            {
                transform.parent = player.transform;

                transform.localPosition = new Vector3(1, 1, 0);
                transform.localRotation = Quaternion.Euler(0, 90, 90);
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                transform.parent = null;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        baseColor = GetComponent<Renderer>().material.color;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player)
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == player)
        {
            inRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (IsPickedUp)
            {
                IsPickedUp = false;
            }
            else if (inRange)
            {
                IsPickedUp = true;
            }
        }

        if (inRange && !IsPickedUp)
        {
            GetComponent<Renderer>().material.color = activeColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = baseColor;
        }
    }
}
