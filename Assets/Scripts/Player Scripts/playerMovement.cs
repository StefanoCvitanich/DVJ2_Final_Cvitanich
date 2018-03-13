using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMovement : MonoBehaviour {

	public bool insideTower;

    public Joystick joystick;
    private Vector3 processedJoystickDirection;

    CharacterController charCont;

    void Start()
    {
        charCont = gameObject.GetComponent<CharacterController>();

		insideTower = false;
    }

    void Update () {
        
		if (!insideTower) {
			
			if (Application.platform == RuntimePlatform.Android) {
				var x1 = CrossPlatformInputManager.GetAxis ("Horizontal") * Time.deltaTime * 3.0f;
				var z1 = CrossPlatformInputManager.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

				transform.forward = Vector3.Lerp (transform.forward, processJostickDirection (), Time.deltaTime * 8);
				transform.Translate (Vector3.right * x1, Space.World);
				transform.Translate (Vector3.forward * z1, Space.World);
			}

			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

			transform.Rotate (0, x, 0);
			transform.Translate (0, 0, z);
		}
        /*
        if(!charCont.isGrounded)

        charCont.Move(new Vector3(0, x, z) * Time.deltaTime);
        */
    }

    private Vector3 processJostickDirection() {

        processedJoystickDirection = new Vector3 (joystick.GetComponent<Joystick>().getJoystickDirection().x, 0, joystick.GetComponent<Joystick>().getJoystickDirection().y);

        return processedJoystickDirection;
    }
}
