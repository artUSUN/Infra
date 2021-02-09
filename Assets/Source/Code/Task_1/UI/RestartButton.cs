using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Code.Task_1.UI
{
    public class RestartButton : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
