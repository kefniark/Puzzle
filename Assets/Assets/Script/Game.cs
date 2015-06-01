using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public GameObject table = null;
	public Bubble bubble_prefab = null;

	private Board board;

	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
