using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	public GameObject prefab = null;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameObject GetInstance(){
		return new Bubble().prefab;
	}

	public Object Instanciate(float x, float y){
		Debug.Log ("Instanciate New Bubble "+x+","+y);
		Vector3 pos = new Vector3(x, y, 0);
		return Instantiate(this.prefab, pos, Quaternion.identity);
	}
}
