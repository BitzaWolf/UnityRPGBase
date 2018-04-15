using UnityEngine;

namespace BitzawolfRPG
{
    public class TestSuite : MonoBehaviour
    {
        void Start()
        {
            testAttributes();
        }

        private void testAttributes()
        {
            Debug.Log("------------------");
            Debug.Log("Starting Attributes Test");

            Attributes a = new Attributes();
            Attributes b = new Attributes(0, 0, 0, 0, 0, 0, 0, 0);
            if (a != b)
                Debug.LogError("Default attribute does not equal a zeroed attribute.");

            b = new Attributes(1, 2, 3, 4, 5, 6, 7, 8);
            a = new Attributes() + new Attributes(1, 2, 3, 4, 5, 6, 7, 8);
            if (a != b)
                Debug.LogError("Adding Attributes test failed");

            a = new Attributes(1, 2, 3, 4, 5, 6, 7, 8);
            a = a + new Attributes(-5, -5, -5, -5, -5, -5, -5, -5);
            b = new Attributes(-4, -3, -2, -1, 0, 1, 2, 3);
            if (a != b)
                Debug.LogError("Adding negative Attributes test failed");
            
            b = new Attributes(-1, -2, -3, -4, -5, -6, -7, -8);
            a = new Attributes() - new Attributes(1, 2, 3, 4, 5, 6, 7, 8);
            if (a != b)
                Debug.LogError("Subtracting Attributes test failed");

            a = new Attributes(1, 2, 3, 4, 5, 6, 7, 8);
            a = a - new Attributes(-5, -5, -5, -5, -5, -5, -5, -5);
            b = new Attributes(6, 7, 8, 9, 10, 11, 12, 13);
            if (a != b)
                Debug.LogError("Subtracting negative Attributes test failed");

            b = new Attributes(5, 10, 15, 20, 25, 30, 35, 40);
            a = new Attributes(1, 2, 3, 4, 5, 6, 7, 8) * 5;
            if (a != b)
                Debug.LogError("Multiplaying Attributes test failed");

            b = new Attributes(-5, -10, -15, -20, -25, -30, -35, -40);
            a = new Attributes(1, 2, 3, 4, 5, 6, 7, 8) * -5;
            if (a != b)
                Debug.LogError("Adding negative Attributes test failed");

            Debug.Log("Finish Attributes Test");
            Debug.Log("------------------");
        }
    }
}