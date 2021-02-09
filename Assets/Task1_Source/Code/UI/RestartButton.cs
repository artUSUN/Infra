using UnityEngine;
using UnityEngine.SceneManagement;

namespace Task1.Source.Code.UI
{
    public class RestartButton : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
