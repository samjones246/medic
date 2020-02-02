using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patient : MonoBehaviour
{

    public Vector3 getupOffset;
    public Vector3 getupRotation;
    public bool going = false;
    public float mult = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (going)
        {
            transform.Translate(0, 0, mult);
        }
    }

    public void Go()
    {
        transform.Rotate(getupRotation);
        transform.Translate(getupOffset);
        GetComponent<Animator>().SetBool("IsRunning", true);
        going = true;
        transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bed")
        {
            transform.parent = collision.gameObject.transform;
            transform.localPosition = new Vector3(0, -2, 3.2f);
        }
    }
}
