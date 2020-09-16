using UnityEngine;
using System;

public class GameOfLife:MonoBehaviour {
	public int width = 30, height = 30, depth = 30;
	public int minSurvivalNeighbourCount = 4;   //inclusive
	public int maxSurvivalNeighbourCount = 14;  //inclusive
	public int minBirthNeighbourCount = 7;      //inclusive
	public int maxBirthNeighbourCount = 10;     //inclusive
	[Range(0, 1)]
	public float initialDensity;
	public GameObject cell;
	public int generation = 0;

	bool[,,] universe;
	GameObject[,,] cells;

	void Start() {
		universe = new bool[width, height, depth];
		cells = new GameObject[width, height, depth];
		System.Random random = new System.Random();
		for(int z = 0; z < universe.GetLength(2); z++) {
			for(int y = 0; y < universe.GetLength(1); y++) {
				for(int x = 0; x < universe.GetLength(0); x++) {
					if(random.NextDouble() < initialDensity) {
						universe[x, y, z] = true;
					} else {
						universe[x, y, z] = false;
					}
					cells[x, y, z] = (GameObject) Instantiate(cell, new Vector3(x - (float)width/2f, y - (float)height/2f, z - (float)depth/2f), Quaternion.Euler(0, 0, 0));
					cells[x, y, z].transform.SetParent(transform);
				}
			}
		}
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.E) || true) {
			generation += 1;
			bool[,,] newUniverse = new bool[width, height, depth];
			for(int z = 0; z < universe.GetLength(2); z++) {
				for(int y = 0; y < universe.GetLength(1); y++) {
					for(int x = 0; x < universe.GetLength(0); x++) {
						int liveNeighbours = 0;

						for(int z2 = z - 1; z2 < z + 2; z2++) {
							for(int y2 = y - 1; y2 < y + 2; y2++) {
								for(int x2 = x - 1; x2 < x + 2; x2++) {
									if(z2 >= 0 && z2 < universe.GetLength(2) &&
										y2 >= 0 && y2 < universe.GetLength(1) &&
										x2 >= 0 && x2 < universe.GetLength(0) &&
										!(x2 == x && y2 == y && z2 == z)) {
										if(universe[x2, y2, z2]) {
											liveNeighbours++;
										}
									}
								}
							}
						}

						if(universe[x, y, z] == true) {
							//Currently Alive
							if(liveNeighbours >= minSurvivalNeighbourCount && liveNeighbours <= maxSurvivalNeighbourCount) {
								//Survives
								newUniverse[x, y, z] = true;
							} else {
								//Dies
								newUniverse[x, y, z] = false;
							}
						} else {
							//Currently Dead
							if(liveNeighbours >= minBirthNeighbourCount && liveNeighbours <= maxBirthNeighbourCount) {
								//Birth
								newUniverse[x, y, z] = true;
							} else {
								//Remains Dead
								newUniverse[x, y, z] = false;
							}
						}
					}
				}
			}
			universe = newUniverse;

			//Generate Prefabs
			for(int z = 0; z < universe.GetLength(2); z++) {
				for(int y = 0; y < universe.GetLength(1); y++) {
					for(int x = 0; x < universe.GetLength(0); x++) {
						if(universe[x, y, z]) {
							cells[x, y, z].SetActive(true);
						} else {
							cells[x, y, z].SetActive(false);
						}
					}
				}
			}
		}
	}

	private void OnDrawGizmos() {
		Gizmos.DrawWireCube(new Vector3(0, 0, 0), new Vector3(width, height, depth));
	}
}
