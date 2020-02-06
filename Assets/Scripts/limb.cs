using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limb : MonoBehaviour
{
    public GameObject player;
    public bool inRange = false;

    Color baseColor;
    private Color activeColor = Color.red;
    public Vector3 holdOffset;
    public Vector3 holdAngle;
    private bool _isPickedUp;
    public bool IsPickedUp
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

                transform.localPosition = holdOffset;
                transform.localRotation = Quaternion.Euler(holdAngle);
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
        player = GameObject.FindWithTag("Player");
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
        if (Input.GetKeyDown("e") && !GameObject.Find("Score").GetComponent<Score>().paused)
        {
            if (IsPickedUp)
            {
                IsPickedUp = false;
            }
            else if (inRange && player.GetComponent<player>().heldLimb.Equals(gameObject) && !GameObject.Find("Score").GetComponent<Score>().paused)
            {
                IsPickedUp = true;
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }

        if (IsPickedUp)
        {
            transform.localPosition = holdOffset;
            transform.localRotation = Quaternion.Euler(holdAngle);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (inRange && !IsPickedUp && player.GetComponent<player>().heldLimb.Equals(gameObject))
        {
            GetComponent<Renderer>().material.color = activeColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = baseColor;
        }
    }
}
