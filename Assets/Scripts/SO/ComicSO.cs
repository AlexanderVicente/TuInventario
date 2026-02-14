using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ComicSO", menuName = "Scriptable Objects/ComicSO")]
public class ComicSO : ScriptableObject
{
    public string editorial;
    public Sprite iconEditorial;
    public ComicItem[] comics;
}

[Serializable]
public class ComicItem
{
    public string name;
    public Sprite image;
}