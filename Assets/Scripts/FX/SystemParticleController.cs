using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemParticleController : MonoBehaviour {
	public GameObject FxExplosion;
	public int count;
	// Use this for initialization
	private List<ParticleSystem> FxList;
	void Start () {
		FxList = new List<ParticleSystem> ();
		for(int x = 0; x <= count; x++)
		{			
			GameObject Obj = Instantiate (FxExplosion, transform);
			FxList.Add (Obj.GetComponent<ParticleSystem>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public ParticleSystem GetFxExplosion(Vector3 position, Quaternion rotation)
	{
		ParticleSystem FxReturn = null;
		foreach (ParticleSystem fx in FxList) {
			if (!fx.gameObject.activeSelf) {
				FxReturn = fx;
				FxReturn.transform.position = position;
				FxReturn.transform.rotation = rotation;
				break;
			}
		}
		return FxReturn;
	}
}
