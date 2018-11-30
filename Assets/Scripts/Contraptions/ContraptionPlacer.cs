using UnityEngine;

namespace Lean.Touch
{
	// This component will spawn Prefab under a finger when dragged from this RectTransform
	[RequireComponent(typeof(RectTransform))]
	public class ContraptionPlacer : MonoBehaviour
	{
		public GameObject constructed;

		[Tooltip("The camera used to calculate the spawn point (None = MainCamera)")]
		public Camera Camera;

		[Tooltip("The conversion method used to find a world point from a screen point")]
		public LeanScreenDepth ScreenDepth;

		protected virtual void OnEnable()
		{
			// Hook into the events we need
			LeanTouch.OnFingerDown += OnFingerDown;
		}

		protected virtual void OnDisable()
		{
			// Unhook events
			LeanTouch.OnFingerDown -= OnFingerDown;
		}

		public void OnFingerDown(LeanFinger finger)
		{
			// Does the prefab exist?
			if (constructed != null)
			{
				// Get the RaycastResults under this finger's current position
				var results = LeanTouch.RaycastGui(finger.ScreenPosition);

				if (results.Count > 0)
				{
					// Is this finger over this UI element?
					if (results[0].gameObject == gameObject)
					{
						// Spawn prefab
						// var instance = Instantiate(constructed);
						
						// Position
						var pos = ScreenDepth.Convert(finger.ScreenPosition, Camera, gameObject);
						
						pos.z = 0;
						
						constructed.transform.position = pos;

						// Select
						// instance.Select(finger);
					}
				}
			}
		}
	}
}
