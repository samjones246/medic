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

    // Update is called once per frame
    void Update()
    {
        forward = player.transform.forward;
        if(Vector3.Distance(player.transform.position, transform.position)<minGrab && !up){
            inRange = true;
            GetComponent<Renderer>().material.color = Color.green;
        }else{
            inRange = false;
            GetComponent<Renderer>().material.color = baseColor;
        }
        if(Input.GetKeyDown("e")){
            if(!up){
                if(inRange){
                    up = true;
                    transform.parent = player.transform;
                }
            }else{
                up = false;
                transform.position = transform.position - new Vector3(0, 1, 0);
                transform.parent = null;
            }
        }
        if(up){
            transform.localPosition = new Vector3(1, 1, 0);
        }
    }
}
