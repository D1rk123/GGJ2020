using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Threading;

public class AudioManager : MonoBehaviour
{
	public enum AudioClips { Geyser, BreakingIce, Jump, Land, InteractSnow, CannonShot, CannonImpact, SeagullAttack, DeathExplosion };

	string backgroundMusicPath = "event:/Music";
	static string backgroundMusicDangerParameter = "Danger";
	public enum MusicDangerLevels { Safe = 0, SlightDanger = 1, Danger = 2 };
	static EventInstance backgroundMusicInstance;

	string ambiencePath = "event:/Ambience";
	static EventInstance ambienceInstance;

	string geyserPath = "event:/SFX/Geyser";
	static EventInstance geyserInstance;

	string breakingIcePath = "event:/SFX/Breaking_Ice";
	static EventInstance breakingIceInstance;

	string jumpPath = "event:/SFX/Character/Jump";
	static EventInstance jumpInstance;

	string landPath = "event:/SFX/Character/Land";
	static EventInstance landInstance;

	string interactSnowPath = "event:/SFX/Character/Interact";
	static EventInstance interactSnowInstance;

	string cannonShotPath = "event:/SFX/Cannon/Cannon";
	static EventInstance cannonShotInstance;

	string cannonImpactPath = "event:/SFX/Cannon/Cannon_Impact";
	static EventInstance cannonImpactInstance;

	string gullScreamPath = "event:/SFX/Seagull_Scream";
	static EventInstance seagullAttackInstance;

	string deathExplosionPath = "event:/SFX/Explosion";
	static EventInstance deathExplosionInstance;

	void Awake ()
	{
		backgroundMusicInstance = RuntimeManager.CreateInstance(backgroundMusicPath);
		ambienceInstance = RuntimeManager.CreateInstance(ambiencePath);
		geyserInstance = RuntimeManager.CreateInstance(geyserPath);
		breakingIceInstance = RuntimeManager.CreateInstance(breakingIcePath);
		jumpInstance = RuntimeManager.CreateInstance(jumpPath);
		landInstance = RuntimeManager.CreateInstance(landPath);
		interactSnowInstance = RuntimeManager.CreateInstance(interactSnowPath);
		cannonShotInstance = RuntimeManager.CreateInstance(cannonShotPath);
		cannonImpactInstance = RuntimeManager.CreateInstance(cannonImpactPath);
		seagullAttackInstance = RuntimeManager.CreateInstance(gullScreamPath);
		deathExplosionInstance = RuntimeManager.CreateInstance(deathExplosionPath);

		backgroundMusicInstance.start();
		ambienceInstance.start();
	}

	public static void SetDanger (MusicDangerLevels level)
	{
		backgroundMusicInstance.setParameterByName(backgroundMusicDangerParameter, (int) level);
	}

	public static void PlayAudioClip (AudioClips whichClip)
	{
		switch (whichClip) {
			case AudioClips.BreakingIce:
				breakingIceInstance.start();
				break;
			case AudioClips.CannonImpact:
				cannonImpactInstance.start();
				break;
			case AudioClips.CannonShot:
				cannonShotInstance.start();
				break;
			case AudioClips.DeathExplosion:
				deathExplosionInstance.start();
				break;
			case AudioClips.Geyser:
				geyserInstance.start();
				break;
			case AudioClips.InteractSnow:
				interactSnowInstance.start();
				break;
			case AudioClips.Jump:
				jumpInstance.start();
				break;
			case AudioClips.Land:
				landInstance.start();
				break;
			case AudioClips.SeagullAttack:
				seagullAttackInstance.start();
				break;
		}
	}
}
