using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
	public WorldTile[] tiles;

	List<WorldTile> generatedTiles;

	public Transform wall;

	public int numTiles;

	void Start() {
		Generate();
	}

	void Generate() {
		float runningHeight = 0f;

		for( int index = 0; index < numTiles; index++ ) {
			WorldTile randomTile = tiles[Random.Range(0, tiles.Length)];
			WorldTile newTile = Instantiate<WorldTile>( randomTile );

			newTile.transform.position = transform.position - new Vector3( 0f, runningHeight, 0f );
			newTile.transform.parent = wall;

			runningHeight += newTile.height;
		}
		
	}
}
