using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowmovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rnd = new System.Random();
        Vector3 m1 = new Vector3(2f, 0, 0);
        Vector3 m2 = new Vector3(0, 0, 2f);
        Vector3 m3 = new Vector3(-2f, 0, 0);
        Vector3 m4 = new Vector3(0, 0, -2f);
        Vector3[] mvmnts = { m1,m2,m3,m4 };
        transform.position += mvmnts[rnd.Next(3)] * Time.deltaTime * 10f;
    }
}
