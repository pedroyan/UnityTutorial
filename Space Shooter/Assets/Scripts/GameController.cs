using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject Hazard;
	public Vector3 SpawnValue;

	public int HazardCount;
	public float SpawnWait;
	public float StartWait;
	public float WaveWait;

	private void Start() {
		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves() {

		yield return new WaitForSeconds(StartWait);

		while (true) {
			for (int i = 0; i < HazardCount; i++) {
				var spawnPosition = new Vector3(Random.Range(-SpawnValue.x, SpawnValue.x), SpawnValue.y, SpawnValue.z);
				Instantiate(Hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(SpawnWait);
			}
			yield return new WaitForSeconds(WaveWait);
		}
	}
}
