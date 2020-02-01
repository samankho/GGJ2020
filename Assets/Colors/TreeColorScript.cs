using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColorScript : MonoBehaviour
{
    private MeshRenderer treeColor;
    // Start is called before the first frame update
    void Start()
    {
       treeColor =  gameObject.GetComponent<MeshRenderer>();
        treeColor.material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
