using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldController : MonoBehaviour
{
	public WorldTile[] tiles;
	List<WorldTile> generatedTiles = new List<WorldTile>();
	public Transform wall;
	public int numTiles;
	private int tileCount;
	private int tileIndex = 0;


	void Start() {
		Generate();
	    //InvokeRepeating("Generate", 5.0f, 10.0f);
	}

	void Update(){

	}

	void Generate() {

	float runningHeight = 0f;

		for( int index = 0; index < numTiles; index++ ) {
			WorldTile randomTile = tiles[Random.Range(0, tiles.Length)];
			WorldTile newTile = Instantiate<WorldTile>( randomTile );
			generatedTiles.Add(newTile);
			tileCount++;

			if(tileCount >= numTiles){
				for(int i = tileCount - numTiles; i < numTiles; i++){
					UnityEngine.Object.Destroy(generatedTiles[i]);
				}
			}


			newTile.transform.position = transform.position - new Vector3( 0f, runningHeight, 0f );
			newTile.transform.parent = wall;

			runningHeight += newTile.height;
		}
	}
}
