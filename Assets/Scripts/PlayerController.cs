using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private int nextNumber = 1;
	private Time startTime;

	public Text txtScrore;
	public Text txtNextNumber;

    private AudioSource audioSource;
    public AudioClip Success;
    public AudioClip Fail;
    public AudioClip Completed;

    // Use this for initialization
    void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        var seconds = (int) Time.timeSinceLevelLoad;

        txtScrore.text = string.Format("Time: {0} sec", seconds);
		txtNextNumber.text = string.Format("Next: {0}", nextNumber);

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

			if(hit.collider != null)
			{
			    if (int.Parse(hit.collider.name) == nextNumber)
			    {
			        audioSource.PlayOneShot(Success);

			        nextNumber++;
			    }
			    else
			    {
                    audioSource.PlayOneShot(Fail);
                }
			}
		}
	}

}
