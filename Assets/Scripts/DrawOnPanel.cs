using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Presentation;

public class DrawOnPanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform drawArea;
    public float lineThickness = 5f;
    public CourtHeader colorManager;

    private Texture2D texture;
    private Vector2 previousPosition;

    void Start()
    {
        InitTexture();

        colorManager = FindObjectOfType<CourtHeader>();
    }

    void InitTexture()
    {
        int width = ( int ) drawArea.rect.width;
        int height = ( int ) drawArea.rect.height;
        texture = new Texture2D( width, height, TextureFormat.RGBA32, false );
        texture.filterMode = FilterMode.Point;

        Color transparentColor = new Color( 0, 0, 0, 0 );
        Color[] pixels = new Color[width * height];
        for( int i = 0; i < pixels.Length; i++ )
        {
            pixels[i] = transparentColor;
        }
        texture.SetPixels( pixels );

        texture.Apply();

        drawArea.GetComponent<Image>().sprite = Sprite.Create( texture, new Rect( 0, 0, width, height ), new Vector2( 0.5f, 0.5f ) );
    }

    List<Vector2> GetPointsOnLine( int x0, int y0, int x1, int y1 )
    {
        List<Vector2> points = new List<Vector2>();

        int dx = Mathf.Abs( x1 - x0 );
        int dy = Mathf.Abs( y1 - y0 );
        int sx = x0 < x1 ? 1 : -1;
        int sy = y0 < y1 ? 1 : -1;
        int err = dx - dy;

        while( true )
        {
            points.Add( new Vector2( x0, y0 ) );
            if( x0 == x1 && y0 == y1 ) break;
            int e2 = err * 2;
            if( e2 > -dy ) { err -= dy; x0 += sx; }
            if( e2 < dx ) { err += dx; y0 += sy; }
        }

        return points;
    }

    void DrawLine( Vector2 start, Vector2 end )
    {   
        int width = texture.width;
        int height = texture.height;
        Vector2 pixelStart = new Vector2( start.x + width / 2, start.y + height / 2 );
        Vector2 pixelEnd = new Vector2( end.x + width / 2, end.y + height / 2 );

        List<Vector2> points = GetPointsOnLine( ( int ) pixelStart.x, ( int ) pixelStart.y, ( int ) pixelEnd.x, ( int ) pixelEnd.y );
        Color drawColor = colorManager.currentColor;
        foreach( var p in points )
        {
            texture.SetPixel( ( int ) p.x, ( int ) p.y, drawColor );
        }

        texture.Apply();
    }

    public void OnDrag( PointerEventData eventData )
    {
        Vector2 localPoint;
        if( RectTransformUtility.ScreenPointToLocalPointInRectangle( drawArea, eventData.position, eventData.pressEventCamera, out localPoint ) )
        {
            DrawLine( previousPosition, localPoint );
            previousPosition = localPoint;
        }
    }

    void DrawAtPoint( Vector2 point )
    {
        DrawLine( point, point );
    }

    public void OnPointerDown( PointerEventData eventData )
    {
        Vector2 localPoint;
        if( RectTransformUtility.ScreenPointToLocalPointInRectangle( drawArea, eventData.position, eventData.pressEventCamera, out localPoint ) )
        {
            previousPosition = localPoint;
            DrawAtPoint( localPoint );
        }
    }
}
