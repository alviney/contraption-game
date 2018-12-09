using UnityEngine;
using UnityEngine.UI;

namespace Lean.Touch
{
    // This component will spawn Prefab under a finger when dragged from this RectTransform
    [RequireComponent(typeof(RectTransform))]
    public class Factory_SpawnPart : MonoBehaviour
    {
        public GameObject partPrefab;

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
            if (partPrefab != null)
            {
                // Get the RaycastResults under this finger's current position
                var results = LeanTouch.RaycastGui(finger.ScreenPosition);

                if (results.Count > 0)
                {
                    // Is this finger over this UI element?
                    if (results[0].gameObject == gameObject)
                    {
                        // Spawn prefab
                        var partInstance = Instantiate(partPrefab);

                        // Position
                        partInstance.transform.position = ScreenDepth.Convert(finger.ScreenPosition, Camera, gameObject);

                        Contraption currentContraption = ContraptionsManager.instance.GetCurrentContraption();

                        partInstance.transform.parent = currentContraption.transform;

                        PartsManager.instance.DeselectSelectedParts();

                        // Select
                        partInstance.GetComponent<LeanSelectable>().Select(finger);
                    }
                }
            }
        }
    }
}
