using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseAnim : MonoBehaviour
{
    public Collider2D pulsecol;

    // Start is called before the first frame update
    void Start()
    {

        pulsecol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PulseStart()
    {
        pulsecol.enabled = true;
    }

    void PulseEnd()
    {
        pulsecol.enabled = false;
    }

}
