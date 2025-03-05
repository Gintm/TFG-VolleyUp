using System;
using System.IO;
using System.Net.Http;
using DefaultNamespace;
using Persistence;
using UnityEngine;

public interface RoundRepo 
{
    public void LoadData( TextAsset file );
    public void LoadData( string path );
    public abstract Round OneRound(int session, int level);
}

public class OneQuestionOneAnswerRepo : MonoBehaviour, RoundRepo
{
    TextAsset JSONFile;

    public void LoadData(TextAsset file)
    {
        JSONFile = file;
    }

    public void LoadData( string path ) { }

    public Round OneRound(int session, int level)
    {
        return LoadFromJson.OneRound( JSONFile.text, session, level );
    }
}

public class QaRoundRepo : MonoBehaviour, RoundRepo
{
    string JSONpath;

    public void LoadData( TextAsset file ) { }

    public void LoadData( string path )
    {
        JSONpath = path;
    }

    public Round OneRound( int session, int level )
    {
        var jsonData = File.ReadAllText( JSONpath );
        return LoadFromJson.OneRound( jsonData, session, level );
    }
}