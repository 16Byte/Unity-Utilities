using UnityEngine;
using UnityEngine.SceneManagement;

namespace PMG.Utilities.SceneEvents.Demo
{
    public class SceneChangerSample : MonoBehaviour
    {
        [SerializeField] private string SceneAName = "DemoSceneA";
        [SerializeField] private string SceneBName = "DemoSceneB";

        /// <summary>
        /// Scene change helper, not part of the system used for the button
        /// </summary>
        public void ChangeScene()
        {
            if (SceneManager.GetActiveScene().name == SceneAName)
                SceneManager.LoadScene(SceneBName);
            else
                SceneManager.LoadScene(SceneAName);
        }
    }
}

