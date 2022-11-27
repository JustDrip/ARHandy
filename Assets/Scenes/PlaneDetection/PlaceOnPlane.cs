using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>

    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : PressInputBase
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject { get; private set; }
        public GameObject spawnedObject1 { get; private set; }
        public GameObject spawnedObject2 { get; private set; }
        public GameObject spawnedObject3 { get; private set; }
        public GameObject spawnedObject4 { get; private set; }
        public GameObject spawnedObjectne1 { get; private set; }
        public GameObject spawnedObjectne2 { get; private set; }
        public GameObject spawnedObjectne3 { get; private set; }
        public GameObject spawnedObjectne4 { get; private set; }



        bool m_Pressed;

        protected override void Awake()
        {
            base.Awake();
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        void Update()
        {

            if (Pointer.current == null || m_Pressed == false)
                return;

            var touchPosition = Pointer.current.position.ReadValue();

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;
                Vector3 vec =  new Vector3 (hitPose.position.x,hitPose.position.y,hitPose.position.z);
                

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                    spawnedObject1 = Instantiate(m_PlacedPrefab, new Vector3(hitPose.position.x + 0.25f, hitPose.position.y, hitPose.position.z), hitPose.rotation);
                    spawnedObject2 = Instantiate(m_PlacedPrefab, new Vector3(hitPose.position.x + 0.5f, hitPose.position.y, hitPose.position.z), hitPose.rotation);
                    spawnedObject3 = Instantiate(m_PlacedPrefab, new Vector3(hitPose.position.x + 0.75f, hitPose.position.y, hitPose.position.z), hitPose.rotation);
                    spawnedObject4 = Instantiate(m_PlacedPrefab, new Vector3(hitPose.position.x + 1f, hitPose.position.y, hitPose.position.z), hitPose.rotation);
                    spawnedObjectne1 = Instantiate(m_PlacedPrefab, new Vector3(hitPose.position.x - 0.25f, hitPose.position.y, hitPose.position.z), hitPose.rotation);
                    spawnedObjectne2 = Instantiate(m_PlacedPrefab, new Vector3(hitPose.position.x - 0.5f, hitPose.position.y, hitPose.position.z), hitPose.rotation);
                    spawnedObjectne3 = Instantiate(m_PlacedPrefab, new Vector3(hitPose.position.x - 0.75f, hitPose.position.y, hitPose.position.z), hitPose.rotation);
                    spawnedObjectne4 = Instantiate(m_PlacedPrefab, new Vector3(hitPose.position.x - 1f, hitPose.position.y, hitPose.position.z), hitPose.rotation);

                    

                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                    spawnedObject1.transform.position = new Vector3(hitPose.position.x + 0.25f, hitPose.position.y, hitPose.position.z);
                    spawnedObject2.transform.position = new Vector3(hitPose.position.x + 0.5f, hitPose.position.y, hitPose.position.z);
                    spawnedObject3.transform.position = new Vector3(hitPose.position.x + 0.75f, hitPose.position.y, hitPose.position.z);
                    spawnedObject4.transform.position = new Vector3(hitPose.position.x + 1f, hitPose.position.y, hitPose.position.z);
                    spawnedObjectne1.transform.position = new Vector3(hitPose.position.x - 0.25f, hitPose.position.y, hitPose.position.z);
                    spawnedObjectne2.transform.position = new Vector3(hitPose.position.x - 0.5f, hitPose.position.y, hitPose.position.z);
                    spawnedObjectne3.transform.position = new Vector3(hitPose.position.x - 0.75f, hitPose.position.y, hitPose.position.z);
                    spawnedObjectne4.transform.position = new Vector3(hitPose.position.x - 1f, hitPose.position.y, hitPose.position.z);
                }
            }
        }

        protected override void OnPress(Vector3 position) => m_Pressed = true;

        protected override void OnPressCancel() => m_Pressed = false;

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}
