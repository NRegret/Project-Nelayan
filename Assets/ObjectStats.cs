using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    private void OnDestroy() {
        ObjectSpawner spawner = FindObjectOfType<ObjectSpawner>();
        if (spawner != null) {
            spawner.PrefabDestroyed(gameObject);
        }
    }
}
