using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldController : MonoBehaviour
{
	public WorldTile[] tiles;
	List<WorldTile> generatedTiles = new List<WorldTile>();
	public Transform wall;
	public int numTiles;
	private int tileIndex = 0;
	float runningHeight = 0f;



	void Start() {
		Generate();
	    InvokeRepeating("Generate", 5.0f, 5.0f);
	}

	void Update(){

	}

	void Generate() {


		for( int index = 0; index < numTiles; index++ ) {
			WorldTile randomTile = tiles[Random.Range(0, tiles.Length)];
			WorldTile newTile = Instantiate<WorldTile>( randomTile );
			generatedTiles.Add(newTile);

			newTile.transform.position = transform.position - new Vector3( 0f, runningHeight, 0f );
			newTile.transform.parent = wall;

			runningHeight += newTile.height;
		}
	}
}
