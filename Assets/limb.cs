using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limb : MonoBehaviour
{
    bool up = false;
    public GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(10, 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(up){
            transform.position = player.transform.position;// + offset;
        }
    }
    
    void OnMouseDown(){
        if(!up){
            up = true;
        }else{
            up = false;
        }
    }
}
