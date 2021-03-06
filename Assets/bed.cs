﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    public GameObject occupant;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (occupant == null)
        {
            if (collision.gameObject.tag == "Patient")
            {
                occupant = collision.gameObject;
            }
        }
        if (occupant != null)
        {
            List<string> limbs = new List<string>(new string[] { "ArmL", "ArmR", "LegL", "LegR" });
            if (limbs.Contains(collision.gameObject.tag) && collision.gameObject.GetComponent<limb>().IsPickedUp && !occupant.transform.Find(collision.gameObject.tag).gameObject.activeSelf)
            {
                if (collision.gameObject.GetComponent<Renderer>().material.name == occupant.transform.Find("Character").gameObject.GetComponent<Renderer>().material.name)
                {
                    occupant.transform.Find(collision.gameObject.tag).gameObject.SetActive(true);
                    collision.gameObject.SetActive(false);
                }
            }
            int attached = 0;
            foreach (string limb in limbs)
            {
                if (occupant.transform.Find(limb).gameObject.activeSelf)
                {
                    attached++;
                }
            }
            if (attached == 4)
            {
                occupant.GetComponent<patient>().Go();
                occupant = null;
            }
        }
    }
}
