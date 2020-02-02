using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patient : MonoBehaviour
{

    public Vector3 getupOffset;
    public Vector3 getupRotation;
    public Vector3 godownOffset = new Vector3(0, -2, 3.2f);
    public Vector3 godownRotation;
    bool going = true;
    public float mult = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("IsRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (going)
        {
            transform.Translate(0, 0, mult);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void Go()
    {
        transform.Rotate(getupRotation);
        transform.Translate(getupOffset);
        GetComponent<Animator>().SetBool("IsRunning", true);
        going = true;
        mult *= 2;
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Bed")
        {
            if (c.gameObject.GetComponent<bed>().occupant == null)
            {
                transform.position = c.gameObject.transform.position + godownOffset;
                transform.rotation = Quaternion.Euler(godownRotation);
                GetComponent<Animator>().SetBool("IsRunning", false);
                going = false;
                c.gameObject.GetComponent<bed>().occupant = this.gameObject;
            }
            else
            {
                transform.Rotate(0, 180, 0);
            }
        }
    }
}
