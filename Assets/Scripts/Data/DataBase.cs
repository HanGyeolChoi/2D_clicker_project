using System.Collections.Generic;

public class DataBase<T> where T : DataModel
{
    public Dictionary<int, T> db = new Dictionary<int, T>();

    public DataBase(List<T> tempList)
    {
        GenerateDbFromList(tempList);
    }

    void GenerateDbFromList(List<T> tempList)
    {
        foreach (var item in tempList)
        {
            db.Add(item.id, item);
        }
    }

    public T Get(int id)
    {
        if (db.ContainsKey(id)) return db[id];

        return null;
    }

    public bool isExist(int id)
    {
        if (db.ContainsKey(id)) return true;
        return false;
    }
}