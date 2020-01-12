using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

		InvokeRepeating("SpawnMeteor", 1f, 3f);
	}
	
	public void SpawnMeteor()
	{
		ObjectPooler.sharedInstace.UseList();

	}
}
