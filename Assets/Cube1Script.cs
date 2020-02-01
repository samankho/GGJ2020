using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube1Script : MonoBehaviour
{
	public GameObject blueCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(-3 * Time.deltaTime, 0, 0);
        blueCube.transform.Rotate(50 * Time.deltaTime, 0, 0);
    }
}
