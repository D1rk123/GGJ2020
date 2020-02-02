using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Threading;

public class AudioManager : MonoBehaviour
{
	public StudioEventEmitter music;
	string backgroundMusicPath = "event:/Music";
	string backgroundMusicDangerParameter = "Danger";
	public enum MusicDangerLevels { Safe = 0, SlightDanger = 1, Danger = 2 };
	EventInstance backgroundMusicInstance;

	string ambiencePath = "event:/Ambience";
	EventInstance ambienceInstance;

	string geyserPath = "event:/SFX/Geyser";
	EventInstance geyserInstance;

	string breakingIcePath = "event:/SFX/Breaking_Ice";
	EventInstance breakingIceInstance;

	//string jumpPath = "event:/SFX/Character/Jump";
	//EventInstance jumpInstance;

	//string landPath = "event:/SFX/Character/Land";
	//EventInstance landInstance;

	void Awake ()
	{
		backgroundMusicInstance = RuntimeManager.CreateInstance(backgroundMusicPath);
		ambienceInstance = RuntimeManager.CreateInstance(ambiencePath);
		geyserInstance = RuntimeManager.CreateInstance(geyserPath);
		breakingIceInstance = RuntimeManager.CreateInstance(breakingIcePath);
		//jumpInstance = RuntimeManager.CreateInstance(jumpPath);
		//landInstance = RuntimeManager.CreateInstance(landPath);

		StartCoroutine(Test());
	}

	IEnumerator Test ()
	{
		//yield return new WaitForSeconds(2);
		//music.Play();
		//backgroundMusicInstance.start();
		Debug.Log("starting");
		yield return null;
	}

	public static void SetDanger (MusicDangerLevels level)
	{
		//backgroundMusicInstance.setParameterByName(backgroundMusicDangerParameter, (int) level);
	}


}
