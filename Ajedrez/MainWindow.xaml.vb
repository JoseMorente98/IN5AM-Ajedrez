Imports Ajedrez.Pieces

Class MainWindow
    Private _matriz(0 To 7, 0 To 7) As Object
    Private _matrizR(0 To 1, 0 To 7) As Object
    Dim _mouseX As Double
    Dim _mouseY As Double
    Dim _newX As Integer
    Dim _newY As Integer
    Dim _objeto As Pieces
    Dim _turno As String
    Dim _alternador As Boolean

    Public Sub New()
        Dim _colorNegro As New SolidColorBrush(Colors.Transparent)
        Dim _colorBlanco As New SolidColorBrush(Colors.Black)

        _colorBlanco.Opacity = 0.9
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For _y As Integer = 0 To 7
            For _x As Integer = 0 To 7
                If (_x Mod 2) Then
                    Dim cuadroNegro As New Rectangle
                    cuadroNegro.Fill = _colorBlanco
                    If (_y Mod 2) Then
                        Grid.SetRow(cuadroNegro, _y)
                        Grid.SetColumn(cuadroNegro, _x - 1)
                    Else
                        Grid.SetRow(cuadroNegro, _y)
                        Grid.SetColumn(cuadroNegro, _x)
                    End If
                    Tablero.Children.Add(cuadroNegro)
                Else
                    Dim cuadroBlanco As New Rectangle
                    cuadroBlanco.Fill = _colorNegro
                    If (_y Mod 2) Then
                        Grid.SetRow(cuadroBlanco, _y)
                        Grid.SetColumn(cuadroBlanco, _x + 1)
                    Else
                        Grid.SetRow(cuadroBlanco, _y)
                        Grid.SetColumn(cuadroBlanco, _x)
                    End If
                    Tablero.Children.Add(cuadroBlanco)
                End If
            Next
        Next

        For _x As Integer = 0 To 7
            Dim _peonRojo As New Pieces
            _peonRojo.Fill = ChessPieces.PeonRojo
            Grid.SetColumn(_peonRojo, _x)
            Grid.SetRow(_peonRojo, 1)
            Tablero.Children.Add(_peonRojo)
            _matriz(_x, 1) = _peonRojo

            Dim _peonNegro As New Pieces
            _peonNegro.Fill = ChessPieces.PeonNegro
            Grid.SetColumn(_peonNegro, _x)
            Grid.SetRow(_peonNegro, 6)
            Tablero.Children.Add(_peonNegro)
            _matriz(_x, 6) = _peonNegro
        Next

        For _x As Integer = 0 To 7 Step 7
            Dim _torreRojo As New Pieces
            _torreRojo.Fill = ChessPieces.TorreRojo
            Grid.SetColumn(_torreRojo, _x)
            Grid.SetRow(_torreRojo, 0)
            Tablero.Children.Add(_torreRojo)
            _matriz(_x, 0) = _torreRojo

            Dim _torreNegro As New Pieces
            _torreNegro.Fill = ChessPieces.TorreNegro
            Grid.SetColumn(_torreNegro, _x)
            Grid.SetRow(_torreNegro, 7)
            Tablero.Children.Add(_torreNegro)
            _matriz(_x, 7) = _torreNegro
        Next

        For _x As Integer = 1 To 7 Step 5
            Dim _caballoRojo As New Pieces
            _caballoRojo.Fill = ChessPieces.CaballoRojo
            Grid.SetColumn(_caballoRojo, _x)
            Grid.SetRow(_caballoRojo, 0)
            Tablero.Children.Add(_caballoRojo)
            _matriz(_x, 0) = _caballoRojo

            Dim _caballoNegro As New Pieces
            _caballoNegro.Fill = ChessPieces.CaballoNegro
            Grid.SetColumn(_caballoNegro, _x)
            Grid.SetRow(_caballoNegro, 7)
            Tablero.Children.Add(_caballoNegro)
            _matriz(_x, 7) = _caballoNegro
        Next

        For _x As Integer = 2 To 7 Step 3
            Dim _alfilRojo As New Pieces
            _alfilRojo.Fill = ChessPieces.AlfilRojo
            Grid.SetColumn(_alfilRojo, _x)
            Grid.SetRow(_alfilRojo, 0)
            Tablero.Children.Add(_alfilRojo)
            _matriz(_x, 0) = _alfilRojo

            Dim _alfilNegro As New Pieces
            _alfilNegro.Fill = ChessPieces.AlfilNegro
            Grid.SetColumn(_alfilNegro, _x)
            Grid.SetRow(_alfilNegro, 7)
            Tablero.Children.Add(_alfilNegro)
            _matriz(_x, 7) = _alfilNegro
        Next

        For _x As Integer = 4 To 4
            Dim _ReyRojo As New Pieces
            _ReyRojo.Fill = ChessPieces.ReyRojo
            Grid.SetColumn(_ReyRojo, _x)
            Grid.SetRow(_ReyRojo, 0)
            Tablero.Children.Add(_ReyRojo)
            _matriz(_x, 0) = _ReyRojo

            Dim _ReyNegro As New Pieces
            _ReyNegro.Fill = ChessPieces.ReyNegro
            Grid.SetColumn(_ReyNegro, _x)
            Grid.SetRow(_ReyNegro, 7)
            Tablero.Children.Add(_ReyNegro)
            _matriz(_x, 7) = _ReyNegro
        Next

        For _x As Integer = 3 To 3
            Dim _reinaRojo As New Pieces
            _reinaRojo.Fill = ChessPieces.ReinaRojo
            Grid.SetColumn(_reinaRojo, _x)
            Grid.SetRow(_reinaRojo, 0)
            Tablero.Children.Add(_reinaRojo)
            _matriz(_x, 0) = _reinaRojo

            Dim _reinaNegro As New Pieces
            _reinaNegro.Fill = ChessPieces.ReinaNegro
            Grid.SetColumn(_reinaNegro, _x)
            Grid.SetRow(_reinaNegro, 7)
            Tablero.Children.Add(_reinaNegro)
            _matriz(_x, 7) = _reinaNegro
        Next

    End Sub

    Private Sub Tablero_MouseMove(sender As Object, e As MouseEventArgs)
        Dim _abcisas As String = ""
        Dim _ordenadas As String = ""
        _mouseX = e.GetPosition(sender).X \ 68.75
        _mouseY = e.GetPosition(sender).Y \ 68.75
        Select Case _mouseX
            Case 0
                _abcisas = "A"
            Case 1
                _abcisas = "B"
            Case 2
                _abcisas = "C"
            Case 3
                _abcisas = "D"
            Case 4
                _abcisas = "E"
            Case 5
                _abcisas = "F"
            Case 6
                _abcisas = "G"
            Case 7
                _abcisas = "H"
        End Select

        Select Case _mouseY
            Case 0
                _ordenadas = "8"
            Case 1
                _ordenadas = "7"
            Case 2
                _ordenadas = "6"
            Case 3
                _ordenadas = "5"
            Case 4
                _ordenadas = "4"
            Case 5
                _ordenadas = "3"
            Case 6
                _ordenadas = "2"
            Case 7
                _ordenadas = "1"
        End Select

        Informacion.Text = "Posición: " & _abcisas & "," & _ordenadas & "; Pieza: Torre; Gana: Blancas; Turno: Blancas; Tiempo: 14:53:00"
    End Sub

    Private Sub Tablero_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If IsNothing(_objeto) Then
            _objeto = _matriz(_mouseX, _mouseY)
            _newX = _mouseX
            _newY = _mouseY
        ElseIf Not IsNothing(_objeto) Then
            If JugadorRojo.IsChecked = True Then
                If _objeto.Fill = ChessPieces.AlfilRojo Then

                ElseIf _objeto.Fill = ChessPieces.CaballoRojo Then

                ElseIf _objeto.Fill = ChessPieces.PeonRojo Then
                    MovimientoPeon()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _objeto.Fill = ChessPieces.ReinaRojo Then

                ElseIf _objeto.Fill = ChessPieces.ReyRojo Then

                ElseIf _objeto.Fill = ChessPieces.TorreRojo Then

                Else
                    _objeto = Nothing
                End If

            ElseIf JugadorNegro.IsChecked = True Then
                If _objeto.Fill = ChessPieces.AlfilNegro Then

                ElseIf _objeto.Fill = ChessPieces.CaballoNegro Then

                ElseIf _objeto.Fill = ChessPieces.PeonNegro Then
                    MovimientoPeon()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _objeto.Fill = ChessPieces.ReinaNegro Then

                ElseIf _objeto.Fill = ChessPieces.ReyNegro Then

                ElseIf _objeto.Fill = ChessPieces.TorreNegro Then

                Else
                    _objeto = Nothing
                End If

            End If
        End If
    End Sub

    Private Sub EliminarPieza()
        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
    End Sub

    Private Sub Mover()
        Tablero.Children.Remove(_matriz(_newX, _newY))
        _matriz(_newX, _newY) = Nothing
        Grid.SetColumn(_objeto, _mouseX)
        Grid.SetRow(_objeto, _mouseY)
        Tablero.Children.Add(_objeto)
        _matriz(_mouseX, _mouseY) = _objeto
        _objeto = Nothing
    End Sub

    Private Sub MovimientoPeon()
        If _newX = _mouseX Then
            If _objeto.Fill = ChessPieces.PeonRojo Then
                If _newY = 1 Then
                    If _mouseY - 1 = _newY Or _mouseY - 2 = _newY Then
                        If IsNothing(_matriz(_mouseX, 2)) Then
                            Mover()
                        End If
                    End If
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing

                    MsgBox("No puede mover en ese lugar")
                ElseIf _mouseY - 1 = _newY Then
                    Mover()
                End If
            ElseIf _objeto.Fill = ChessPieces.PeonNegro Then
                If _newY = 6 Then
                    If _mouseY + 1 = _newY Or _mouseY + 2 = _newY Then
                        If IsNothing(_matriz(_mouseX, 5)) Then
                            Mover()
                        End If
                    End If
                ElseIf _mouseY + 1 = _newY Then
                    Mover()
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("No puede mover en ese lugar")
                End If
            End If
        Else
            _objeto = Nothing
        End If
    End Sub


End Class
