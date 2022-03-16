using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class SexConfig : ScriptableObject
{
    [SerializeField] private string[] sex;

    public GameObject GetSex(string sexName)
    {
        var assetName = sex.FirstOrDefault(e => e == sexName);

        return string.IsNullOrEmpty(assetName) ? null : LoadObject(sexName);
    }
    private static GameObject LoadObject(string sexName)
    {
        var asset = Resources.Load<GameObject>($"Sex/{sexName}");
        
        Resources.UnloadUnusedAssets();
        return asset;
    }

#if UNITY_EDITOR
    private void Reset()
    {
        var objects = Resources.LoadAll<GameObject>("Sex");
        sex = new string[objects.Length];

        for (var i = 0; i < sex.Length; i++)
        {
            sex[i] = objects[i].name;
        }
    }
#endif
}
