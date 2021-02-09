using UnityEngine;

namespace Source.Code.Task_1.Systems
{
    public class WorldInitializer : MonoBehaviour
    {
        [Header("Faction Settings")]
        [SerializeField] private FactionSettings redSettings;
        [SerializeField] private FactionSettings blueSettings;
        [Header("Links")]
        [SerializeField] private GameObject trooperPrefab;

        private void Awake()
        {
            var red = InitializeFaction(redSettings);
            var blue = InitializeFaction(blueSettings);
            GameStatesSwitcher.Initialize(blue, red);
        }

        private Faction InitializeFaction(FactionSettings settings)
        {
            var newFaction = settings.SpawnPoint.gameObject.AddComponent<Faction>();
            newFaction.Initialize(settings, trooperPrefab);
            return newFaction;
        }
    }
}
