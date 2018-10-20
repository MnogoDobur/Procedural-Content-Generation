using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spawner : MonoBehaviour {
	/*TODO
	 * Animals spawn positions
	 * prey and predator
	 * */
	public GameObject[] animals;
	public GameObject[] trees;
	public GameObject[] vegetation;
	public GameObject[] bushes;
	public GameObject[] grass;
	public GameObject[] rocks;

	public LayerMask layerMask =2;

	public GameObject[] animalsSpawned;
	public GameObject[] treesSpawned;
	public GameObject[] vegetationSpawned;
	public GameObject[] bushesSpawned;
	public GameObject[] grassSpawned;
	public GameObject[] rocksSpawned;

	public GameObject[] terrains;

	public GameObject water;
	public GameObject player;
	public GameObject image;
	public GameObject text1;
	public GameObject text2;

	private int numberOfAnimalstoSpawn = 50;
	private int numberOfTreestoSpawn = 80;
	private int numberOfPlantstoSpawn = 77;
	private int numberOfGrasstoSpawn = 200;
	private int numberOfBushestoSpawn = 65;
	private int numberOfRockstoSpawn = 35;
	public static bool test=false;
	private int testInt = 0;
	public LayerMask PositionLayers;
	// Use this for initialization
	void Start () {
		StartCoroutine ("starting");
			//InvokeRepeating("testAnimalsAndTreeDistance", 2.0f, 3.0f);
		InvokeRepeating("getAllAnimals", 5.6f, 9.3f);
		InvokeRepeating("getAllTrees", 15.2f, 8.3f);
		InvokeRepeating("getAllVegetation", 15.4f, 15.3f);
		//InvokeRepeating ("checkBioCount", 6.9f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		if (TerrainGenerator.counter > testInt) {
			spawn ();
			testInt = TerrainGenerator.counter;
		}
		Vector3 playerPos = new Vector3 (player.gameObject.transform.position.x,0.75f,player.gameObject.transform.position.z);
		water.transform.position = playerPos;
	}
	public void spawn(){
		getAvailableTerrains ();
		for (int i = 0; i < terrains.Length; i++) {
			Debug.Log ("spawning on nUmber of terrains : " + terrains.Length);
			if (terrains [i].activeSelf == true) {
				for (int j = 0; j < numberOfAnimalstoSpawn; j++) {
					spawnAtRandomPos (terrains [i],animals,1.1f,7.1f);
				}
				for (int j = 0; j < numberOfPlantstoSpawn; j++) {
					spawnAtRandomPos (terrains [i],vegetation,0.55f,1.1f);
				}

				for (int j = 0; j < numberOfTreestoSpawn; j++) {
					spawnAtRandomPos (terrains [i],trees,0.7f,6.1f);
					Debug.Log ("spawning trees on : " + terrains[i].gameObject.name);
				}
				for(int j = 0; j < numberOfBushestoSpawn; j++){
					spawnAtRandomPos (terrains [i],bushes,1.3f,5.1f);
				}
				for(int j = 0; j < numberOfGrasstoSpawn; j++){
					spawnAtRandomPos (terrains [i],grass,1.3f,7.1f);
				}
				for(int j = 0; j < numberOfRockstoSpawn; j++){
					spawnAtRandomPos (terrains [i],rocks,1.3f,7.1f);
				}
				terrains [i].gameObject.tag = "UsedChunk";
			}
		}
	}
	public void spawnFirst(){
		getAvailableTerrains ();
		for (int i = 0; i<terrains.Length ; i++) {
			terrains [i].gameObject.tag = "UsedChunk";
			for (int j = 0; j < 130; j++) {
				spawnAtRandomPos (terrains [i],trees,0.7f,6.1f);
			}
			for (int j = 0; j < 6; j++) {
				spawnAtRandomPos (terrains [i],vegetation,0.55f,1.1f);
			}
			for(int j = 0; j < 17; j++){
				spawnAtRandomPos (terrains [i],animals,1.1f,7.1f);
			}
			for(int j = 0; j < 17; j++){
				spawnAtRandomPos (terrains [i],bushes,1.3f,5.1f);
			}
			for(int j = 0; j < 1500; j++){
				spawnAtRandomPos (terrains [i],grass,1.3f,3.1f);
			}
			for(int j = 0; j < 14; j++){
				spawnAtRandomPos (terrains [i],rocks,1.3f,7.1f);
			}
		}
	}

	public void spawnAtRandomPos(GameObject terrain,GameObject[] prefabs,float minY,float maxY){
		float TerrainLeft = terrain.transform.position.x;
		float TerrainBottom = terrain.transform.position.z;
		float TerrainRight = TerrainLeft + 242;
		float TerrainTop = TerrainBottom + 242;
		float terrainHeight = 100.5f;
		RaycastHit hit;
		float randomPosX, randomPosY, randomPosZ;
		Vector3 randomPos = Vector3.zero;


		randomPosX = Random.Range (TerrainLeft, TerrainRight);
		randomPosZ = Random.Range (TerrainBottom, TerrainTop);
		if (Physics.Raycast (new Vector3 (randomPosX, 9999f, randomPosZ), Vector3.down, out hit, Mathf.Infinity, layerMask)) {
			terrainHeight = hit.point.y;
			randomPosY = terrainHeight;

			if (randomPosY <= maxY && randomPosY >= minY && hit.transform.gameObject.tag != "Water") {
				
				Vector3 position = new Vector3 (randomPosX, randomPosY, randomPosZ);
				GameObject gameObject = Instantiate (prefabs [Random.Range (prefabs.Length - prefabs.Length, prefabs.Length)], position, Quaternion.identity);
			}/*
			if (prefabs.Length == 10) {
				float test = 0.0f;
				for (int i = 0; i < 5; i++) {
					test += 1.5f;
					if (test >= 9) {
						test += 2.2f;
					}
					Vector3 tempPos = new Vector3 (randomPosX+test, randomPosY, randomPosZ+test);
					GameObject gameObject = Instantiate (prefabs [Random.Range (prefabs.Length-prefabs.Length, prefabs.Length)], tempPos, Quaternion.identity);
				}
			}*/
			if (vegetationSpawned.Length <= 100) {
				if (randomPosY <= 1.1f && randomPosY >= 0.55f && hit.transform.gameObject.tag != "Water") {
					Vector3 tempPos = new Vector3 (randomPosX + 0.8f, randomPosY, randomPosZ + 1.2f);
					GameObject plant = Instantiate (vegetation [Random.Range (vegetation.Length-vegetation.Length, vegetation.Length)], tempPos, Quaternion.identity);
				}
			}
		}
	}

			
	public void getAllAnimals(){
		animalsSpawned = GameObject.FindGameObjectsWithTag ("Animal");
		for (int i = 0; i < animalsSpawned.Length; i++) {
			float dist = Vector3.Distance (animalsSpawned [i].transform.position, player.transform.position);
			if (Vector3.Distance (player.gameObject.transform.position, animalsSpawned [i].gameObject.transform.position) >= 700) {
				Destroy (animalsSpawned [i]);
			}
		}
	}
	public void getAllVegetation(){
		vegetationSpawned = GameObject.FindGameObjectsWithTag ("Vegetation");
		bushesSpawned = GameObject.FindGameObjectsWithTag ("Bush");
		grassSpawned = GameObject.FindGameObjectsWithTag ("Grass");
		rocksSpawned = GameObject.FindGameObjectsWithTag ("Rock");
		for (int i = 0; i < vegetationSpawned.Length; i++) {
			float dist = Vector3.Distance (vegetationSpawned [i].transform.position, player.transform.position);
			if (dist >= 700) {
				Destroy (vegetationSpawned [i]);
			}
		}
		for (int i = 0; i < bushesSpawned.Length; i++) {
			float dist = Vector3.Distance (bushesSpawned [i].transform.position, player.transform.position);
			if (dist >= 700) {
				Destroy (bushesSpawned [i]);;
			}
		}
		for (int i = 0; i < grassSpawned.Length; i++) {
			float dist = Vector3.Distance (grassSpawned [i].transform.position, player.transform.position);
			if (dist >= 700) {
				Destroy (grassSpawned [i]);
			}
		}
		for (int i = 0; i < rocksSpawned.Length; i++) {
			float dist = Vector3.Distance (rocksSpawned [i].transform.position, player.transform.position);
			if (dist >= 700) {
				Destroy (rocksSpawned [i]);
			}
		}
	}

	public void getAllTrees(){
		treesSpawned = GameObject.FindGameObjectsWithTag ("Tree");
		for (int i = 0; i < treesSpawned.Length; i++) {
			float dist = Vector3.Distance (treesSpawned [i].transform.position, player.transform.position);
			if (Vector3.Distance (player.gameObject.transform.position, treesSpawned [i].gameObject.transform.position) >= 700) {
				Destroy (treesSpawned [i]);
			}
		}
	}
	public void getAvailableTerrains(){
		terrains = GameObject .FindGameObjectsWithTag ("Chunk");
		System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>(terrains);
		for (int i = 0; i < terrains.Length; i++) {
			if (terrains [i].activeInHierarchy == false) {
				list.Remove(list[i]);
			}
		}
		terrains = list.ToArray();
	}
		
	IEnumerator starting(){
		yield return new WaitForSeconds (2);
		spawnFirst ();
		text1.SetActive (false);
		text2.SetActive (true);
			water.SetActive (true);
		yield return new WaitForSeconds (6);
		player.SetActive (true);
		image.SetActive (false);
		text2.SetActive (false);
	}
}