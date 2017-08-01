using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelObjectController : MonoBehaviour {
	public GameObject Barrel;
	public int count;
	// Use this for initialization
	private List<GameObject> GoList;
	void Awake() {
		GoList = new List<GameObject> ();
		for(int x = 0; x <= count; x++)
		{			
			GameObject Obj = Instantiate (Barrel, transform);
			GoList.Add (Obj);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public GameObject GetBarrel(Vector3 position, Quaternion rotation)
	{
		GameObject _return = null;
		foreach (GameObject go in GoList) {
			if (!go.gameObject.activeSelf) {
				_return = go;
				_return.transform.position = position;
				_return.transform.rotation = rotation;
				break;
			}
		}
		return _return;
	}
}
