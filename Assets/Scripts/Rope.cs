using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
	void LateUpdate()
	{
		Vector3 localRot = transform.rotation.eulerAngles;

		transform.localRotation = Quaternion.Euler(new Vector3(localRot.x, localRot.y, 0));
	}
}