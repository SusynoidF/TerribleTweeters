using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] string _nextLvlName;
    Monster[] _monsters;
    

    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonstersAllDead())
        NextLevel();
    }

    void NextLevel()
    {
        Debug.Log("Go to level " + _nextLvlName);
        SceneManager.LoadScene(_nextLvlName);
    }

    bool MonstersAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
            return false;
        }
        return true;
    }
}
