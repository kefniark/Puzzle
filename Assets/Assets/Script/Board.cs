using UnityEngine;

public class Board
{

	private const int WIDTH = 8;
	private const int HEIGHT = 10;
	private Bubble[,] board;

	public Board ()
	{
		this.board = new Bubble[WIDTH, HEIGHT];
	}

	public void Add (Bubble bubble, int x, int y)
	{
		Debug.Log (x+":"+y+" => "+bubble.name);
		this.board[x,y] = bubble;
		bubble.x = x;
		bubble.y = y;
		bubble.transform.localPosition = GetPosition(x, y);
	}

	private Vector3 GetPosition(float x, float y)
	{
		Debug.Log ("GetPositionx"+x +":"+y);
		if (y % 2 == 1) {
			return new Vector3(x+0.5f, HEIGHT-y);
		}
		return new Vector3(x, HEIGHT-y);
	}
}