Public Enum ChessPieces
    AlfilNegro
    AlfilRojo
    CaballoNegro
    CaballoRojo
    PeonNegro
    PeonRojo
    ReinaNegro
    ReinaRojo
    ReyNegro
    ReyRojo
    TorreNegro
    TorreRojo
End Enum

Public Enum Colores
    Rojo
    Azul
End Enum

Public Enum ColorJugador
    Rojo
    Negro
End Enum

Structure Movimiento
    Public Forward As Integer
    Public ToRight As Integer
End Structure

MustInherit Class Piezas
    Public Sub New(pieceColor As ColorJugador)
        Color = pieceColor
    End Sub

    Property Color As ColorJugador

    Property BoardSquare As Pieces





End Class