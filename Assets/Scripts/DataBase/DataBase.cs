using System.Collections.Generic;
using System;

public class DataBase
{
    [Serializable]
    public class ComicData
    {
        public string name;
        public string imagePath; // ruta en Resources o Addressables
    }

    [Serializable]
    public class EditorialData
    {
        public string editorial;
        public string iconPath;
        public List<ComicData> comics = new List<ComicData>();
    }

    [Serializable]
    public class ComicDatabase
    {
        public List<EditorialData> editorials = new List<EditorialData>();
    }

}
