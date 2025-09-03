using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    //List of items
    //Random range of items spawning from chest
    //Spawn Point in chest

    //Check if Chest has been interacted
    //Don't spawn loot if interacted once

    //Use a Coroutine to have item spawn one after another
    //Instantiate the loot


    private Coroutine _spawnItemRoutine;
    private bool _isCollected;
    private bool _isSpawned;
    private int _randomItemToSpawn;

    [SerializeField] [Range(1,19)] private int _minNumber = 1;
    [SerializeField] [Range(2, 20)] private int _maxNumber = 5;

    [SerializeField] private List<GameObject> _lootItems = new List<GameObject>();
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        _randomItemToSpawn = Random.Range(_minNumber,_maxNumber + 1 );
    }

    public void Spawn()
    {
        if(!_isSpawned && !_isCollected)
        {
            //Spawn Loot
            if(_spawnItemRoutine == null)
            {
                _spawnItemRoutine = StartCoroutine(SpawnItemsRoutine());
            }
        }
    }

    private IEnumerator SpawnItemsRoutine()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < _randomItemToSpawn; i++)
        {
            int randomIndex = Random.Range(0, _lootItems.Count);
            GameObject item = Instantiate(_lootItems[randomIndex], _spawnPoint.position, Quaternion.identity);
            item.transform.parent = this.transform;
            yield return new WaitForSeconds(1.5f);
        }

        _isSpawned = true;
        _isCollected = true;
        _spawnItemRoutine = null;
    }

}
