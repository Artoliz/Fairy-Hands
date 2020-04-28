using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class BookUIButtonController : MonoBehaviour {

	private AnimatedBookController animatedBookController;

	// Use this for initialization
	void Start () {
		animatedBookController = FindObjectOfType<AnimatedBookController> ();
	}
	
	public void CallTurnNextPage() {
		animatedBookController.TurnToNextPage ();
	}

	public void CallTurnPreviousPage() {
		foreach (var hand in Player.instance.hands)
		{
			if (hand != null)
			{
				animatedBookController.TurnToPreviousPage ();
			}
		}
	}
}
