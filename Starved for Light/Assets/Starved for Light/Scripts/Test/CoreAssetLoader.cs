using UnityEngine;
using UnityEngine.SceneManagement;

namespace S4L.Test {
    public class CoreAssetLoader : MonoBehaviour {

        void Start() {

            CoreAssetLoader[] assetLoaders = FindObjectsOfType<CoreAssetLoader>();
            if (assetLoaders.Length > 1) {
                Destroy(this);
                return;
            }

            DontDestroyOnLoad(this);
            SceneManager.LoadScene("CoreAssets", LoadSceneMode.Additive);
        }
    }
}
