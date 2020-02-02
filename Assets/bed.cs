using System.Collections;
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
        if (Input.GetKeyDown("f"))
        {
            occupant.transform.Find("LegL").gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        List<string> limbs = new List<string>(new string[]{ "ArmL", "ArmR", "LegL", "LegR" });
        Debug.Log(collision.gameObject.name);
        if (limbs.Contains(collision.gameObject.name))
        {
            occupant.transform.Find(collision.gameObject.name).gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        
    }
}
