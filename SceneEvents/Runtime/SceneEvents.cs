using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PMG.Utilities.SceneEvents
{
    public static class SceneEvents
    {
        /// <summary>
        /// Outgoing name, incoming scene (string instead of scene for the 'from' because unity returns a dead scene handle to us)
        /// </summary>
        public static event Action<string, Scene> ActiveSceneChanged; 

        public static string CurrentSceneName { get; private set; }
        public static string PreviousSceneName { get; private set; }


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            CurrentSceneName = null;
            PreviousSceneName = null;
            ActiveSceneChanged = null;                  // clear stale listeners
            SceneManager.activeSceneChanged -= Relay;
            SceneManager.activeSceneChanged += Relay;
        }

        static void Relay(Scene _, Scene to)   // Unity's 'from' is already unloaded — ignore it
        {
            PreviousSceneName = CurrentSceneName;
            CurrentSceneName = to.name;

            ActiveSceneChanged?.Invoke(PreviousSceneName, to);
        }
    }
}