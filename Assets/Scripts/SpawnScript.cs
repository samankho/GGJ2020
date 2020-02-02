using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
	public GameObject shootCube;
    public List<GameObject> shootCubes = new List<GameObject>();
	private int _x = 0;
    private long _lastSecond = 1;

    private static long _difficulty = 1;

    public static long Difficulty => _difficulty;

    void Start() {
        InvokeRepeating("EverySecond", 0f, 0.5f);
    }

    bool IsNearPlayer(float x, float y) => (Math.Pow((x - 500)*(x - 500) + (y - 1)*(y - 1), 0.5) < 1.0);

    void EverySecond() {
        float x, y;
        do {
            x = UnityEngine.Random.Range(-5, 5);
            y = UnityEngine.Random.Range(0.5f, 4);
        } while (IsNearPlayer(x, y));
        
        var z = 0;
        var gameObj = Instantiate(shootCube, new Vector3(x + 500, y, 650), Quaternion.identity);
        shootCubes.Add(gameObj);

        _difficulty++;
    }	

    void Update() {
        const float destroyWall = 450f;
        var toBeDestroyed = shootCubes.Where(obj => obj.transform.position.z < destroyWall)
                                      .ToList();
        var malus = toBeDestroyed.Count; 
        toBeDestroyed.ForEach(Destroy);
        shootCubes = shootCubes.Where(obj => obj.transform.position.z >= destroyWall).ToList();

        MoveCube.Score -= malus;
    }
	
}
