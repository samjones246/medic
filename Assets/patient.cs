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
	bool healed = false;
    public bool missingLegs = false;
    public float mult = 0.5f;
    GameObject targetBed;
    // Start is called before the first frame update
    void Start()
    {
        if (!missingLegs)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsCrawling", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (going)
        {
            if (!healed)
            {
                targetBed = null;
                foreach (GameObject bed in GameObject.FindGameObjectsWithTag("Bed"))
                {
                    if(bed.GetComponent<bed>().occupant == null)
                    {
                        if(targetBed == null || Vector3.Distance(transform.position, bed.transform.position) < Vector3.Distance(transform.position, targetBed.transform.position)){
                            targetBed = bed;
                        }
                    }
                }
                if (targetBed != null)
                {
                    transform.LookAt(targetBed.transform);
                    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
                }
            }
            transform.Translate(0, 0, mult * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if(Vector3.Distance(Vector3.zero, transform.position) > 200)
        {
            Destroy(gameObject);
        }
    }

    public void Go()
    {
        transform.Rotate(getupRotation);
        transform.Translate(getupOffset);
        GetComponent<Animator>().SetBool("IsRunning", true);
        going = true;
		healed = true;
        mult *= 2;
		GameObject.Find("Score").GetComponent<Score>().score++;
    }

    private void OnTriggerEnter(Collider c)
    {
        if(!healed && (c.gameObject.tag == "Bed" && (c.gameObject.Equals(targetBed) || targetBed==null)))
        {
            if (c.gameObject.GetComponent<bed>().occupant == null)
            {
                transform.position = c.gameObject.transform.position + godownOffset;
                transform.rotation = Quaternion.Euler(godownRotation);
                GetComponent<Animator>().SetBool("IsRunning", false);
                GetComponent<Animator>().SetBool("IsCrawling", false);
                going = false;
                c.gameObject.GetComponent<bed>().occupant = this.gameObject;
            }
            else
            {
                transform.Rotate(0, 180, 0);
                healed = true;
                GameObject.Find("Score").GetComponent<Score>().lives--;
            }
        }
    }
}
