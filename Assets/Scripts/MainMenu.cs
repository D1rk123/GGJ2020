using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetExtended;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
		for (int i = 0; i < 3; i++) {
			if (XInputEX.GetAnyInputDown(i) || Input.anyKeyDown) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(1);
			}
		}       
    }
}
