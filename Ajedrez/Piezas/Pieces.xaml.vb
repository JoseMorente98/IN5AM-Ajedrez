Imports System.IO.Directory

Public Class Pieces
    Private _imagen As New Image
    Private _imagenBrush As New ImageBrush
    Private _pieceColor As ChessPieces

    Public Property Fill As ChessPieces
        Get
            Return Me._pieceColor
        End Get
        Set(value As ChessPieces)
            Me._pieceColor = value
            UpdateColor(value)
        End Set
    End Property

    ''' <summary>
    ''' Actualizador de colores por cada pieza del juego
    ''' </summary>
    ''' <param name="_pieceColor"></param>
    Private Sub UpdateColor(ByVal _pieceColor As ChessPieces)
        Select Case _pieceColor
            Case ChessPieces.AlfilRojo
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Alfil-Textura-Rojo.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush
            Case ChessPieces.AlfilNegro
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Alfil-Textura-Negro.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush

            Case ChessPieces.CaballoRojo
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Caballo-Textura-Rojo.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush
            Case ChessPieces.CaballoNegro
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Caballo-Textura-Negro.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush

            Case ChessPieces.PeonRojo
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Peon-Textura-Rojo.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush
            Case ChessPieces.PeonNegro
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Peon-Textura-Negro.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush

            Case ChessPieces.ReinaRojo
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Reina-Textura-Rojo.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush
            Case ChessPieces.ReinaNegro
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Reina-Textura-Negro.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush

            Case ChessPieces.ReyRojo
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Rey-Textura-Rojo.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush
            Case ChessPieces.ReyNegro
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Rey-Textura-Negro.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush

            Case ChessPieces.TorreRojo
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Torre-Textura-Rojo.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush
            Case ChessPieces.TorreNegro
                _imagen.Source = New BitmapImage(New Uri(GetCurrentDirectory().ToString() & "\Recursos\Torre-Textura-Negro.png"))
                _imagenBrush.ImageSource = _imagen.Source
                Contenido.Background = _imagenBrush
        End Select
    End Sub
End Class
