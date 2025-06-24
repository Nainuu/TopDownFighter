using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenMgmt : MonoBehaviour
{
    public void SceneLoader()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
