using UnityEngine.SceneManagement;
using UnityEngine;

public class OpenScene : MonoBehaviour
{
    public void OpenSceneButton(int index)
    {
        SceneManager.LoadScene(index);
    }
}
