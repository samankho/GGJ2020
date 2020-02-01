using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
	public GameObject shootCube;
    public List<GameObject> shootCubes = new List<GameObject>();
    private long _lastSecond = 1;

    void Start() {
        InvokeRepeating("EverySecond", 0f, 0.25f);
    }

    bool IsNearPlayer(float x, float y) => (Math.Pow((x - 500)*(x - 500) + (y - 1)*(y - 1), 0.5) < 1.0);

    void EverySecond() {
        float x, y;
        do {
            x = UnityEngine.Random.Range(-7, 7);
            y = UnityEngine.Random.Range(0.5f, 5);
        } while (IsNearPlayer(x, y));
        
        var z = 0;
        var gameObj = Instantiate(shootCube, new Vector3(x + 500, y, 650), Quaternion.identity);
        shootCubes.Add(gameObj);
    }

    // Update is called once per frame
    void Update() {
        const float destroyWall = 450f;
        var toBeDestroyed = shootCubes.Where(obj => obj.transform.position.z < destroyWall)
                                      .ToList();

        toBeDestroyed.ForEach(Destroy);
        shootCubes = shootCubes.Where(obj => obj.transform.position.z >= destroyWall).ToList();
    }
	

}
