using UnityEngine;

namespace BitzawolfRPG
{
    public class Encounter : MonoBehaviour
    {
        public LayerMask groundLayer;
        public float MAX_ENCOUNTER_TIME = 30;
        public float encounterCheckRate = 1;
        public AnimationCurve encounterRate;
        public float battleSearchRadius = 10;
        public GameObject[] enemies;
        
        private float timeToNextEncounterCheck = 0;
        private float timeInEncounterZone = 0;
        private bool isInEncounterZone = false;

        void Start()
        {

        }

        void Update()
        {
            if (!isInEncounterZone)
                return;

            timeInEncounterZone += Time.deltaTime;
            timeToNextEncounterCheck += Time.deltaTime;

            if (timeToNextEncounterCheck > encounterCheckRate)
            {
                timeToNextEncounterCheck -= encounterCheckRate;

                if (rollForEncounter())
                {
                    Vector3 spawnLocation;
                    if (findSpawnLocation(out spawnLocation))
                    {
                        //GameObject enemyPrefab = enemies[Random.Range(0, enemies.Length)];
                        //GameObject enemyGroup = Instantiate(enemyPrefab, spawnLocation, new Quaternion());
                        // RPGManager.enterBattle(enemyGroup);
                    }
                }
            }
        }

        private bool rollForEncounter()
        {
            float currentTimeProportion = timeInEncounterZone / MAX_ENCOUNTER_TIME;
            float encounterChance = encounterRate.Evaluate(currentTimeProportion);
            float rand = Random.Range(0.0f, 1.0f);
            Debug.Log(rand + " < " + encounterChance);

            return (rand < encounterChance);
        }

        private bool findSpawnLocation(out Vector3 targetLocation)
        {
            Debug.Log("Creating a battle!");
            isInEncounterZone = false;

            Vector3 player = new Vector3(); // RPGManager.player.transform.position;
            targetLocation = new Vector3();

            for (int searchIteration = 0; searchIteration < 10; ++searchIteration)
            {
                float angle = Random.Range(0f, Mathf.PI * 2f);

                targetLocation.x = player.x + Mathf.Cos(angle) * battleSearchRadius;
                targetLocation.z = player.z + Mathf.Sin(angle) * battleSearchRadius;
                targetLocation.y = player.y;

                Vector3 direction = targetLocation - player;
                direction = direction.normalized;

                bool lineOfSightBlocked = Physics.Raycast(player, direction, battleSearchRadius);
                bool spawnAreaBlocked = Physics.CheckSphere(targetLocation, 3, ~groundLayer.value);
                if (!lineOfSightBlocked && !spawnAreaBlocked)
                {
                    targetLocation.y += 1;
                    return true;
                }
            }
            
            return false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            Debug.Log("Entered Encounter");
            isInEncounterZone = true;
            timeInEncounterZone = 0;
            timeToNextEncounterCheck = 0;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            Debug.Log("Exiting Encounter zone");
            isInEncounterZone = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 0.4f);
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}