using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private TextMesh textObject;
    private TextMesh text;

    private static int _score = 1;
    private float speed = 32;    // Start is called before the first frame update
    void Start()
    {
            textObject = GameObject.Find("ScoreText").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, 0, -1 * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other) 
    {
        gameObject.transform.position = new Vector3(0, 0, -350);
        Debug.Log("Kaputttttt");
        textObject.text = "Score: " + _score;
        _score++;

    }

}
