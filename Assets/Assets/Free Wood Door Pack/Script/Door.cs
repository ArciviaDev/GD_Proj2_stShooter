using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


public class Door : MonoBehaviour {
	public bool open;
	public float smooth = 1.0f;
	float DoorOpenAngle = -90.0f;
    float DoorCloseAngle = 0.0f;
	public AudioSource asource;
	public AudioClip openDoor,closeDoor;
	
	private Quaternion originalRotation;
	private Quaternion openRotation;
	
	// Use this for initialization
	void Start()
	{
		asource = GetComponent<AudioSource>();

		// Remember the rotation set in the Inspector
		originalRotation = transform.localRotation;

		// Calculate the open rotation relative to the original
		openRotation = originalRotation * Quaternion.Euler(0, -90f, 0);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (open)
		{
			transform.localRotation = Quaternion.Slerp(
				transform.localRotation,
				openRotation,
				Time.deltaTime * 5 * smooth
			);
		}
		else
		{
			transform.localRotation = Quaternion.Slerp(
				transform.localRotation,
				originalRotation,
				Time.deltaTime * 5 * smooth
			);
		}
	}

	public void OpenDoor(){
		open =!open;
		asource.clip = open?openDoor:closeDoor;
		asource.Play ();
	}
}
}