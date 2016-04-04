using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private int nextNumber = 1;
	private Time startTime;

	public Text txtScrore;
	public Text txtNextNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		txtScrore.text = "Time: " + Time.time.ToString();
		txtNextNumber.text = "Next: " + nextNumber.ToString();

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

			if(hit.collider != null)
			{
				if (int.Parse (hit.collider.name) == nextNumber) 
				{
					nextNumber++;
				}
			}
		}
	}
}
