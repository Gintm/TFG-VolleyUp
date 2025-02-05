using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TeamClassification : MonoBehaviour
{
    public GameObject rowPrefab;  // Asigna el prefab de la fila desde Unity
    public Transform tableParent; // Asigna el panel donde se colocarán las filas
    public string filePath = "data.txt"; // Ruta del archivo (ubicado en StreamingAssets)

    void Start()
    {
        LoadTable();
    }

    void LoadTable()
    {
        // Limpiar la tabla antes de cargar nuevos datos
        foreach( Transform child in tableParent )
        {
            Destroy( child.gameObject );
        }

        // Leer el archivo de texto
        string fullPath = Path.Combine( Application.streamingAssetsPath, filePath );
        if( !File.Exists( fullPath ) )
        {
            Debug.LogError( "Archivo no encontrado: " + fullPath );
            return;
        }

        string[] lines = File.ReadAllLines( fullPath );
        foreach( string line in lines )
        {
            string[] columns = line.Split( ',' );

            // Crear una nueva fila
            GameObject newRow = Instantiate( rowPrefab, tableParent );

            // Asignar cada valor a una celda de la fila
            Text[] textFields = newRow.GetComponentsInChildren<Text>();
            for( int i = 0; i < textFields.Length && i < columns.Length; i++ )
            {
                textFields[i].text = columns[i].Trim();
            }
        }
    }
}
