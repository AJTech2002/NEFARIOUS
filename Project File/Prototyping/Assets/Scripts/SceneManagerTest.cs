using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerTest : MonoBehaviour {

    private void Awake()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }


}
