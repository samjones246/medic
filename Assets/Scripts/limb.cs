using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limb : MonoBehaviour
{
    bool up = false;
    public GameObject player;
    public Vector3 offset;
    public float minGrab = 3.0f;
    bool inRange = false;
    public Vector3 forward;
    Color baseColor;
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
        forward = player.transform.forward;

        if(Input.GetKeyDown("e")){
            if(!up){
                if(inRange){
                    up = true;
                    transform.parent = player.transform;
                    GetComponent<Renderer>().material.color = baseColor;
                }
            }else{
                up = false;
                transform.position = transform.position - new Vector3(0, 1, 0);
                transform.parent = null;
            }
        }
        if(up){
            transform.localPosition = new Vector3(1, 1, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
        }

        if (inRange && !up)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = baseColor;
        }
    }
}
