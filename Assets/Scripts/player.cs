using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class player : MonoBehaviour
{
    public GameObject heldLimb;
    public float mult = 0.25f;
    float h = 0;
    float v = 0;
    float targetY = 0f;
    public float turnSpeed = 360f;
    void Awake () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 45;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (!(h == 0) || !(v == 0))
        {
            targetY = Mathf.Rad2Deg * Mathf.Atan2(h, v);
        }
        Vector3 pos = this.transform.position;
        float moveX = h * mult * Time.deltaTime;
        float moveZ = v * mult * Time.deltaTime;
        transform.position = new Vector3(pos.x+moveX, pos.y, pos.z+moveZ);
        float step = turnSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, targetY, 0), step);
        GameObject[] armL = GameObject.FindGameObjectsWithTag("ArmL");
        GameObject[] armR = GameObject.FindGameObjectsWithTag("ArmR");
        GameObject[] legL = GameObject.FindGameObjectsWithTag("LegL");
        GameObject[] legR = GameObject.FindGameObjectsWithTag("LegR");
        GameObject[] limbs = armL.Concat(armR).ToArray<GameObject>();
        limbs = limbs.Concat(legL).ToArray<GameObject>();
        limbs = limbs.Concat(legR).ToArray<GameObject>();
        foreach(GameObject limb in limbs)
        {
            if (!limb.GetComponent<limb>().IsPickedUp && limb.GetComponent<limb>().inRange)
            {
                if (heldLimb == null)
                {
                    heldLimb = limb;
                }
                else if (Vector3.Distance(transform.position, limb.transform.position) < Vector3.Distance(transform.position, heldLimb.transform.position))
                {
                    heldLimb = limb;
                }
            }
        }
    }
}
