using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;   //used to gen position
    public float columnMax = 3.5f;  //used to gen position


    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXposition = 10f;
    private int currentColumn = 0;

	// Use this for initialization
	void Start () {
        columns = new GameObject[columnPoolSize];
        for (int i= 0; i< columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) //generates columns
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXposition, spawnYPosition);

            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }



	}
}
