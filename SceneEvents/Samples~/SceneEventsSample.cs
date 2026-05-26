using UnityEngine;
using UnityEngine.SceneManagement;

namespace PMG.Utilities.SceneEvents.Demo
{
    public class SceneEventsSample : MonoBehaviour
    {
        public static SceneEventsSample Instance { get; private set; }

        private void OnEnable() => SceneEvents.ActiveSceneChanged += Test;
        private void OnDisable() => SceneEvents.ActiveSceneChanged -= Test;
        private void Awake()
        { 
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Test(string scene1Name, Scene scene2) => Debug.Log($"Scene changed from {scene1Name} to {scene2.name}");
    }
}
