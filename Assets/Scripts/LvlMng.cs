using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlMng : MonoBehaviour
{
    static public LvlMng instance;
    [SerializeField] PlayerMovement Playerprefab;
    [SerializeField] Transform      PlayerRespawnPosition;
    private List<GameObject> doors;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        doors = new List<GameObject>();
    }
    public void Respawn()
    {

    }

    public void Load(string lvl , Vector2 position)
    {
        SceneManager.LoadScene(lvl);
        Instantiate(Playerprefab, position,PlayerRespawnPosition.rotation);
    }

    // Update is called once per frame
    
}
