using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    
    private TextMesh textObject;
    private TextMesh text;

    private static long _score = 16;
    private static long _maxscore = 16;
    private static bool Gameover = false;

    private float speed = 32;    // Start is called before the first frame update
    private float _startZ;
    private const float _playerZ = 500f;

    private ISet<GameObject> _alreadyCollided = new HashSet<GameObject>();

    public static long Score {
        get => _score; 
        set {
            _maxscore = Math.Max(value, _maxscore);
            _score = value;
            Gameover |= value < 0;
        }
    }

    void UpdateScoreText() {
        if(Gameover)
            textObject.text = "GAMEOVER";
        else
            textObject.text = "Score: " + Score  +"\n MaxScore:" + _maxscore;
    }

    void Start()
    {
        textObject = GameObject.Find("ScoreText").GetComponent<TextMesh>();
        UpdateScoreText();
        _startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, 0, -1 * Time.deltaTime * speed - ((SpawnScript.Difficulty * SpawnScript.Difficulty) / 4096f));
        var hue = ((Math.Max(0, 10 * (transform.position.z - _playerZ) / (_startZ - _playerZ)) * 100000) % 100000) / 100000;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(hue, 1f, 1f);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (_alreadyCollided.Contains(gameObject)) return;

        _alreadyCollided.Add(gameObject);
        
        gameObject.transform.position = new Vector3(0   , 0, -350);
        UpdateScoreText();

        Score += 10 * (SpawnScript.Difficulty / 5);
    }

}
