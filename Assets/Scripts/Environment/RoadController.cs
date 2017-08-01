using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medidas
{
	public float x;
	public float y;
	public float z;

	public  Medidas() {
		x = 0;
		y = 0;
		z = 0;
	}
}

public class RoadController : MonoBehaviour {
	public GameObject[] RoadChunks;
	public GameObject CheckPointEndChunk;
	public bool PruebaDelNext = false;
	private int index;
	private int indexOfNext;
	private Medidas[] medidas;
	private List<int> ListOfIndex;
	void Start () {
		index = 0;
		medidas = new Medidas[RoadChunks.Length];
		ListOfIndex = new List<int> ();
		foreach (GameObject chunk in RoadChunks) {
			BoxCollider col = chunk.GetComponent<BoxCollider> ();
			Medidas med = new Medidas ();
			med.x = col.size.x;
			med.y = col.size.y;
			med.z = col.size.z;
			medidas [index] = med;
			ListOfIndex.Add (index);
			index++;
		}
		index = 0;
		indexOfNext = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (PruebaDelNext) {
			AdvanceTheLast ();
			PruebaDelNext = false;
		}
	}

	public void AdvanceTheLast()
	{
		//Obtengo los index de los Chunks disponibles
		List<int> ListOfIndexAviable = GetListOfIndexAviable(ListOfIndex);
		//elijo uno al azar
		int x = Random.Range (0, ListOfIndexAviable.Count);
		int indexRandon = ListOfIndexAviable [x];

		//Tomo las medidas para la nueva posicion
		float z = medidas [indexOfNext].z + medidas [index].z;

		//creo la posicion y se la asigno
		Vector3 newpos = new Vector3(RoadChunks [index].transform.position.x, RoadChunks [index].transform.position.y, RoadChunks [index].transform.position.z + z);
		RoadChunks [indexRandon].transform.position = newpos;

		newpos = new Vector3 (RoadChunks [indexOfNext].transform.position.x, RoadChunks [indexOfNext].transform.position.y, RoadChunks [indexOfNext].transform.position.z + 5);
		CheckPointEndChunk.transform.position = newpos;
		//Actualizo el index y el next index
		index = indexOfNext;
		indexOfNext = indexRandon;
	}

	List<int> GetListOfIndexAviable(List<int> ListIndex)
	{
		List<int> newList = new List<int> ();
		foreach (int _index in ListIndex) {
			if (_index != index && _index != indexOfNext)
				newList.Add (_index);
		}
		return newList;
	}
}
