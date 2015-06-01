using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public GameObject character = null;
	public GameObject table = null;
	public Bubble bubble_prefab = null;

	private Board board;
	private ArrayList bullets_moving;

	// Use this for initialization
	void Start () {
		this.bullets_moving = new ArrayList();
		this.board = new Board();
		for (int x=0; x<8; x++) {
			for (int y=0; y<6-x; y++) {
				GameObject clone = (GameObject) bubble_prefab.Instanciate(0, 0);
				clone.transform.SetParent(table.transform, false);
				Bubble bubble = clone.transform.GetComponent<Bubble>();
				this.board.Add(bubble, x, y);
			}
		}
	}

	void FixedUpdate () {
		foreach(Bubble bubble in this.bullets_moving){
			Vector3 v = Quaternion.AngleAxis(bubble.rotation, Vector3.forward) * Vector3.right;
			bubble.transform.Translate(v * bubble.speed);
			Debug.Log( bubble.speed );
			Debug.Log( v * bubble.speed );
		}
	}

	void Update () {

		// Rotation
		Vector3 mouse_pos = Input.mousePosition;
		Vector3 object_pos = Camera.main.WorldToScreenPoint(character.transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		character.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		// Fire
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("Pressed left click.");
			GameObject clone = (GameObject) bubble_prefab.Instanciate(3.5f, -8.5f);
			clone.transform.SetParent(table.transform, false);
			Bubble bubble = clone.transform.GetComponent<Bubble>();
			bubble.rotation = angle;
			this.bullets_moving.Add(bubble);
		}
	}

}
