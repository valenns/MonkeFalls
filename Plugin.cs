using System;
using BepInEx;
using UnityEngine;
using Utilla;
using GorillaLocomotion;

namespace MonkeFalls
{
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]

	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		MeshCollider floor;

		Rigidbody monke;

		void Start()
		{
			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnEnable()
		{
			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			floor = GameObject.Find("Level/forest/ForestObjects/pitgeo/pit ground").GetComponent<MeshCollider>();
			monke = Player.Instance.bodyCollider.attachedRigidbody;
		}

		void Update()
		{
			if (monke != null && floor != null)
			{
				if (monke.velocity.y < -7f && floor.bounds.Contains(monke.position))
				{
					Application.Quit();
				}
			}
		}
	}
}
