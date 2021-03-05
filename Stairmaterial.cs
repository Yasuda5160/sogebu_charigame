using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairmaterial : MonoBehaviour
{
    public Material Stair;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material = Stair;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
