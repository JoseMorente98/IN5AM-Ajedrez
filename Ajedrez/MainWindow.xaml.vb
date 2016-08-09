Imports Ajedrez.Pieces

Class MainWindow
    Private _matriz(0 To 7, 0 To 7) As Object
    Private _matrizN(0 To 1, 0 To 7) As Object
    Private _matrizR(0 To 1, 0 To 7) As Object
    Dim _mouseX As Double
    Dim _mouseY As Double
    Dim _newX As Integer
    Dim _newY As Integer
    Dim _objeto As Pieces
    Dim _turno As String
    Dim _alternador As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        NewGame()

    End Sub

    Public Sub NewGame()
        Ganan.Text = ""

        Dim _colorNegro As New SolidColorBrush(Colors.Transparent)
        Dim _colorBlanco As New SolidColorBrush(Colors.Black)

        _colorBlanco.Opacity = 0.9

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

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Dim Msg As MsgBoxResult
        Msg = MsgBox("¿Deseas empezar nuevo juego?", vbYesNo, "Nuevo Juego")
        If Msg = MsgBoxResult.Yes Then
            JugadorRojo.IsChecked = True
            Negros.Children.Clear()
            Rojos.Children.Clear()
            Tablero.Children.Clear()
            NewGame()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim Msg As MsgBoxResult
        Keyboard.IsKeyDown(Key.LeftCtrl + Key.S)
        Msg = MsgBox("¿Desea cerrar la partida?", vbYesNo, "Salir")
        If Msg = MsgBoxResult.Yes Then
            Close()
        Else
            Exit Sub
        End If
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

        Informacion.Text = "Coordenadas del Juego: " & _abcisas & "," & _ordenadas & ""
    End Sub

    Private Sub Tablero_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If IsNothing(_objeto) Then
            _objeto = _matriz(_mouseX, _mouseY)
            _newX = _mouseX
            _newY = _mouseY
        ElseIf Not IsNothing(_objeto) Then
            If JugadorRojo.IsChecked = True Then
                If _objeto.Fill = ChessPieces.AlfilRojo Then
                    MovimientoAlfil()
                ElseIf _objeto.Fill = ChessPieces.CaballoRojo Then
                    MovimientoCaballo()
                ElseIf _objeto.Fill = ChessPieces.PeonRojo Then
                    MovimientoPeon()
                ElseIf _objeto.Fill = ChessPieces.ReinaRojo Then
                    MovimientoReina()
                ElseIf _objeto.Fill = ChessPieces.ReyRojo Then
                    MovimientoRey()
                ElseIf _objeto.Fill = ChessPieces.TorreRojo Then
                    MovimientoTorre()
                Else
                    _objeto = Nothing
                End If
            ElseIf JugadorNegro.IsChecked = True Then
                If _objeto.Fill = ChessPieces.AlfilNegro Then
                    MovimientoAlfil()
                ElseIf _objeto.Fill = ChessPieces.CaballoNegro Then
                    MovimientoCaballo()
                ElseIf _objeto.Fill = ChessPieces.PeonNegro Then
                    MovimientoPeon()
                ElseIf _objeto.Fill = ChessPieces.ReinaNegro Then
                    MovimientoReina()
                ElseIf _objeto.Fill = ChessPieces.ReyNegro Then
                    MovimientoRey()
                ElseIf _objeto.Fill = ChessPieces.TorreNegro Then
                    MovimientoTorre()
                Else
                    _objeto = Nothing
                End If
            End If
        End If
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
                            JugadorRojo.IsChecked = False
                            JugadorNegro.IsChecked = True
                        End If
                    End If
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("Movimiento Ilegal")
                    JugadorRojo.IsChecked = True
                    JugadorNegro.IsChecked = False
                ElseIf _mouseY - 1 = _newY Then
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                End If
            ElseIf _objeto.Fill = ChessPieces.PeonNegro Then
                If _newY = 6 Then
                    If _mouseY + 1 = _newY Or _mouseY + 2 = _newY Then
                        If IsNothing(_matriz(_mouseX, 5)) Then
                            Mover()
                            JugadorNegro.IsChecked = False
                            JugadorRojo.IsChecked = True
                        End If
                    End If
                ElseIf _mouseY + 1 = _newY Then
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("Movimiento Ilegal")
                    JugadorNegro.IsChecked = True
                    JugadorRojo.IsChecked = False
                End If
            End If
        ElseIf (_mouseX = _newX + 1) Or (_mouseX = _newX - 1) Then
            If JugadorRojo.IsChecked = True Then
                If (_mouseY = _newY + 1) Then
                    If Not IsNothing(_matriz(_mouseX, _mouseY)) Then
                        If _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilNegro") Then
                            If IsNothing(_matrizN(1, 4)) Then
                                Dim _alfil As New Pieces
                                _alfil.Fill = ChessPieces.AlfilNegro
                                Grid.SetColumn(_alfil, 1)
                                Grid.SetRow(_alfil, 4)
                                Negros.Children.Add(_alfil)
                                _matrizN(1, 4) = _alfil
                            ElseIf IsNothing(_matrizN(1, 5)) Then
                                Dim _alfil As New Pieces
                                _alfil.Fill = ChessPieces.AlfilNegro
                                Grid.SetColumn(_alfil, 1)
                                Grid.SetRow(_alfil, 5)
                                Negros.Children.Add(_alfil)
                                _matrizN(1, 5) = _alfil
                            End If
                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorRojo.IsChecked = False
                            JugadorNegro.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoNegro") Then
                            If IsNothing(_matrizN(1, 2)) Then
                                Dim _caballo As New Pieces
                                _caballo.Fill = ChessPieces.CaballoNegro
                                Grid.SetColumn(_caballo, 1)
                                Grid.SetRow(_caballo, 2)
                                Negros.Children.Add(_caballo)
                                _matrizN(1, 2) = _caballo
                            ElseIf IsNothing(_matrizN(1, 3)) Then
                                Dim _caballo As New Pieces
                                _caballo.Fill = ChessPieces.CaballoNegro
                                Grid.SetColumn(_caballo, 1)
                                Grid.SetRow(_caballo, 3)
                                Negros.Children.Add(_caballo)
                                _matrizN(1, 3) = _caballo
                            End If
                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorRojo.IsChecked = False
                            JugadorNegro.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonNegro") Then
                            If IsNothing(_matrizN(0, 0)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonNegro
                                Grid.SetColumn(_peon, 0)
                                Grid.SetRow(_peon, 0)
                                Negros.Children.Add(_peon)
                                _matrizN(0, 0) = _peon
                            ElseIf IsNothing(_matrizN(0, 1)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonNegro
                                Grid.SetColumn(_peon, 0)
                                Grid.SetRow(_peon, 1)
                                Negros.Children.Add(_peon)
                                _matrizN(0, 1) = _peon
                            ElseIf IsNothing(_matrizN(0, 2)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonNegro
                                Grid.SetColumn(_peon, 0)
                                Grid.SetRow(_peon, 2)
                                Negros.Children.Add(_peon)
                                _matrizN(0, 2) = _peon
                            ElseIf IsNothing(_matrizN(0, 3)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonNegro
                                Grid.SetColumn(_peon, 0)
                                Grid.SetRow(_peon, 3)
                                Negros.Children.Add(_peon)
                                _matrizN(0, 3) = _peon
                            ElseIf IsNothing(_matrizN(0, 4)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonNegro
                                Grid.SetColumn(_peon, 0)
                                Grid.SetRow(_peon, 4)
                                Negros.Children.Add(_peon)
                                _matrizN(0, 4) = _peon
                            ElseIf IsNothing(_matrizN(0, 5)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonNegro
                                Grid.SetColumn(_peon, 0)
                                Grid.SetRow(_peon, 5)
                                Negros.Children.Add(_peon)
                                _matrizN(0, 5) = _peon
                            ElseIf IsNothing(_matrizN(0, 6)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonNegro
                                Grid.SetColumn(_peon, 0)
                                Grid.SetRow(_peon, 6)
                                Negros.Children.Add(_peon)
                                _matrizN(0, 6) = _peon
                            ElseIf IsNothing(_matrizN(0, 7)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonNegro
                                Grid.SetColumn(_peon, 0)
                                Grid.SetRow(_peon, 7)
                                Negros.Children.Add(_peon)
                                _matrizN(0, 7) = _peon
                            End If
                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorRojo.IsChecked = False
                            JugadorNegro.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaNegro") Then
                            If IsNothing(_matrizN(1, 6)) Then
                                Dim _reina As New Pieces
                                _reina.Fill = ChessPieces.ReinaNegro
                                Grid.SetColumn(_reina, 1)
                                Grid.SetRow(_reina, 6)
                                Negros.Children.Add(_reina)
                                _matrizN(1, 6) = _reina
                            End If

                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorRojo.IsChecked = False
                            JugadorNegro.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyNegro") Then
                            If IsNothing(_matrizN(1, 7)) Then
                                Dim _rey As New Pieces
                                _rey.Fill = ChessPieces.ReyNegro
                                Grid.SetColumn(_rey, 1)
                                Grid.SetRow(_rey, 7)
                                Negros.Children.Add(_rey)
                                _matrizN(1, 7) = _rey
                            End If

                            Ganan.Text = "Ganan Rojos"
                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorRojo.IsChecked = False
                            JugadorNegro.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreNegro") Then
                            If IsNothing(_matrizN(1, 0)) Then
                                Dim _torre As New Pieces
                                _torre.Fill = ChessPieces.TorreNegro
                                Grid.SetColumn(_torre, 1)
                                Grid.SetRow(_torre, 0)
                                Negros.Children.Add(_torre)
                                _matrizN(1, 0) = _torre
                            ElseIf IsNothing(_matrizN(1, 1)) Then
                                Dim _torre As New Pieces
                                _torre.Fill = ChessPieces.TorreNegro
                                Grid.SetColumn(_torre, 1)
                                Grid.SetRow(_torre, 1)
                                Negros.Children.Add(_torre)
                                _matrizN(1, 1) = _torre
                            End If

                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorRojo.IsChecked = False
                            JugadorNegro.IsChecked = True
                        End If
                    End If
                End If
            ElseIf JugadorNegro.IsChecked = True Then
                If (_mouseY = _newY - 1) Then
                    If Not IsNothing(_matriz(_mouseX, _mouseY)) Then
                        If _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilRojo") Then
                            If IsNothing(_matrizR(0, 4)) Then
                                Dim _alfil As New Pieces
                                _alfil.Fill = ChessPieces.AlfilRojo
                                Grid.SetColumn(_alfil, 0)
                                Grid.SetRow(_alfil, 4)
                                Rojos.Children.Add(_alfil)
                                _matrizR(0, 4) = _alfil
                            ElseIf IsNothing(_matrizR(0, 5)) Then
                                Dim _alfil As New Pieces
                                _alfil.Fill = ChessPieces.AlfilRojo
                                Grid.SetColumn(_alfil, 0)
                                Grid.SetRow(_alfil, 5)
                                Rojos.Children.Add(_alfil)
                                _matrizR(0, 5) = _alfil
                            End If
                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorNegro.IsChecked = False
                            JugadorRojo.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoRojo") Then
                            If IsNothing(_matrizR(0, 2)) Then
                                Dim _caballo As New Pieces
                                _caballo.Fill = ChessPieces.CaballoRojo
                                Grid.SetColumn(_caballo, 0)
                                Grid.SetRow(_caballo, 2)
                                Rojos.Children.Add(_caballo)
                                _matrizR(0, 2) = _caballo
                            ElseIf IsNothing(_matrizR(0, 3)) Then
                                Dim _caballo As New Pieces
                                _caballo.Fill = ChessPieces.CaballoRojo
                                Grid.SetColumn(_caballo, 0)
                                Grid.SetRow(_caballo, 3)
                                Rojos.Children.Add(_caballo)
                                _matrizR(0, 3) = _caballo
                            End If
                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorNegro.IsChecked = False
                            JugadorRojo.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonRojo") Then
                            If IsNothing(_matrizR(1, 0)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonRojo
                                Grid.SetColumn(_peon, 1)
                                Grid.SetRow(_peon, 0)
                                Rojos.Children.Add(_peon)
                                _matrizR(1, 0) = _peon
                            ElseIf IsNothing(_matrizR(1, 1)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonRojo
                                Grid.SetColumn(_peon, 1)
                                Grid.SetRow(_peon, 1)
                                Rojos.Children.Add(_peon)
                                _matrizR(1, 1) = _peon
                            ElseIf IsNothing(_matrizR(1, 2)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonRojo
                                Grid.SetColumn(_peon, 1)
                                Grid.SetRow(_peon, 2)
                                Rojos.Children.Add(_peon)
                                _matrizR(1, 2) = _peon
                            ElseIf IsNothing(_matrizR(1, 3)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonRojo
                                Grid.SetColumn(_peon, 1)
                                Grid.SetRow(_peon, 3)
                                Rojos.Children.Add(_peon)
                                _matrizR(1, 3) = _peon
                            ElseIf IsNothing(_matrizR(1, 4)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonRojo
                                Grid.SetColumn(_peon, 1)
                                Grid.SetRow(_peon, 4)
                                Rojos.Children.Add(_peon)
                                _matrizR(1, 4) = _peon
                            ElseIf IsNothing(_matrizR(1, 5)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonRojo
                                Grid.SetColumn(_peon, 1)
                                Grid.SetRow(_peon, 5)
                                Rojos.Children.Add(_peon)
                                _matrizR(1, 5) = _peon
                            ElseIf IsNothing(_matrizR(1, 6)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonRojo
                                Grid.SetColumn(_peon, 1)
                                Grid.SetRow(_peon, 6)
                                Rojos.Children.Add(_peon)
                                _matrizR(1, 6) = _peon
                            ElseIf IsNothing(_matrizR(1, 7)) Then
                                Dim _peon As New Pieces
                                _peon.Fill = ChessPieces.PeonRojo
                                Grid.SetColumn(_peon, 1)
                                Grid.SetRow(_peon, 7)
                                Rojos.Children.Add(_peon)
                                _matrizR(1, 7) = _peon
                            End If
                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorNegro.IsChecked = False
                            JugadorRojo.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaRojo") Then
                            If IsNothing(_matrizR(0, 6)) Then
                                Dim _reina As New Pieces
                                _reina.Fill = ChessPieces.ReinaRojo
                                Grid.SetColumn(_reina, 0)
                                Grid.SetRow(_reina, 6)
                                Rojos.Children.Add(_reina)
                                _matrizR(0, 6) = _reina
                            End If

                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorNegro.IsChecked = False
                            JugadorRojo.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyRojo") Then
                            If IsNothing(_matrizR(0, 7)) Then
                                Dim _rey As New Pieces
                                _rey.Fill = ChessPieces.ReyRojo
                                Grid.SetColumn(_rey, 0)
                                Grid.SetRow(_rey, 7)
                                Rojos.Children.Add(_rey)
                                _matrizR(0, 7) = _rey
                            End If

                            Ganan.Text = "Ganan Rojos"
                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorNegro.IsChecked = False
                            JugadorRojo.IsChecked = True
                        ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreRojo") Then
                            If IsNothing(_matrizR(0, 0)) Then
                                Dim _torre As New Pieces
                                _torre.Fill = ChessPieces.TorreRojo
                                Grid.SetColumn(_torre, 0)
                                Grid.SetRow(_torre, 0)
                                Rojos.Children.Add(_torre)
                                _matrizR(0, 0) = _torre
                            ElseIf IsNothing(_matrizR(0, 1)) Then
                                Dim _torre As New Pieces
                                _torre.Fill = ChessPieces.TorreRojo
                                Grid.SetColumn(_torre, 0)
                                Grid.SetRow(_torre, 1)
                                Rojos.Children.Add(_torre)
                                _matrizR(0, 1) = _torre
                            End If

                            Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                            _matriz(_mouseX, _mouseY) = Nothing
                            Mover()
                            JugadorNegro.IsChecked = False
                            JugadorRojo.IsChecked = True
                        End If
                    End If
                End If
            End If
        Else
            _objeto = Nothing
        End If
    End Sub


    Private Sub MovimientoTorre()
        If _newX = _mouseX Or _newY = _mouseY Then
            If _objeto.Fill = ChessPieces.TorreRojo Then
                If IsNothing(_matriz(_mouseX, _mouseY)) Then
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilNegro") Then
                    If IsNothing(_matrizN(1, 4)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilNegro
                        Grid.SetColumn(_alfil, 1)
                        Grid.SetRow(_alfil, 4)
                        Negros.Children.Add(_alfil)
                        _matrizN(1, 4) = _alfil
                    ElseIf IsNothing(_matrizN(1, 5)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilNegro
                        Grid.SetColumn(_alfil, 1)
                        Grid.SetRow(_alfil, 5)
                        Negros.Children.Add(_alfil)
                        _matrizN(1, 5) = _alfil
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoNegro") Then
                    If IsNothing(_matrizN(1, 2)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoNegro
                        Grid.SetColumn(_caballo, 1)
                        Grid.SetRow(_caballo, 2)
                        Negros.Children.Add(_caballo)
                        _matrizN(1, 2) = _caballo
                    ElseIf IsNothing(_matrizN(1, 3)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoNegro
                        Grid.SetColumn(_caballo, 1)
                        Grid.SetRow(_caballo, 3)
                        Negros.Children.Add(_caballo)
                        _matrizN(1, 3) = _caballo
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonNegro") Then
                    If IsNothing(_matrizN(0, 0)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 0)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 0) = _peon
                    ElseIf IsNothing(_matrizN(0, 1)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 1)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 1) = _peon
                    ElseIf IsNothing(_matrizN(0, 2)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 2)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 2) = _peon
                    ElseIf IsNothing(_matrizN(0, 3)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 3)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 3) = _peon
                    ElseIf IsNothing(_matrizN(0, 4)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 4)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 4) = _peon
                    ElseIf IsNothing(_matrizN(0, 5)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 5)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 5) = _peon
                    ElseIf IsNothing(_matrizN(0, 6)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 6)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 6) = _peon
                    ElseIf IsNothing(_matrizN(0, 7)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 7)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 7) = _peon
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaNegro") Then
                    If IsNothing(_matrizN(1, 6)) Then
                        Dim _reina As New Pieces
                        _reina.Fill = ChessPieces.ReinaNegro
                        Grid.SetColumn(_reina, 1)
                        Grid.SetRow(_reina, 6)
                        Negros.Children.Add(_reina)
                        _matrizN(1, 6) = _reina
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyNegro") Then
                    If IsNothing(_matrizN(1, 7)) Then
                        Dim _rey As New Pieces
                        _rey.Fill = ChessPieces.ReyNegro
                        Grid.SetColumn(_rey, 1)
                        Grid.SetRow(_rey, 7)
                        Negros.Children.Add(_rey)
                        _matrizN(1, 7) = _rey
                    End If

                    Ganan.Text = "Ganan Rojos"
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreNegro") Then
                    If IsNothing(_matrizN(1, 0)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreNegro
                        Grid.SetColumn(_torre, 1)
                        Grid.SetRow(_torre, 0)
                        Negros.Children.Add(_torre)
                        _matrizN(1, 0) = _torre
                    ElseIf IsNothing(_matrizN(1, 1)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreNegro
                        Grid.SetColumn(_torre, 1)
                        Grid.SetRow(_torre, 1)
                        Negros.Children.Add(_torre)
                        _matrizN(1, 1) = _torre
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("Movimiento Ilegal")
                    JugadorRojo.IsChecked = True
                    JugadorNegro.IsChecked = False
                End If
            ElseIf _objeto.Fill = ChessPieces.TorreNegro Then
                If IsNothing(_matriz(_mouseX, _mouseY)) Then
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilRojo") Then
                    If IsNothing(_matrizR(0, 4)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilRojo
                        Grid.SetColumn(_alfil, 0)
                        Grid.SetRow(_alfil, 4)
                        Rojos.Children.Add(_alfil)
                        _matrizR(0, 4) = _alfil
                    ElseIf IsNothing(_matrizR(0, 5)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilRojo
                        Grid.SetColumn(_alfil, 0)
                        Grid.SetRow(_alfil, 5)
                        Rojos.Children.Add(_alfil)
                        _matrizR(0, 5) = _alfil
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoRojo") Then
                    If IsNothing(_matrizR(0, 2)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoRojo
                        Grid.SetColumn(_caballo, 0)
                        Grid.SetRow(_caballo, 2)
                        Rojos.Children.Add(_caballo)
                        _matrizR(0, 2) = _caballo
                    ElseIf IsNothing(_matrizR(0, 3)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoRojo
                        Grid.SetColumn(_caballo, 0)
                        Grid.SetRow(_caballo, 3)
                        Rojos.Children.Add(_caballo)
                        _matrizR(0, 3) = _caballo
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonRojo") Then
                    If IsNothing(_matrizR(1, 0)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 0)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 0) = _peon
                    ElseIf IsNothing(_matrizR(1, 1)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 1)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 1) = _peon
                    ElseIf IsNothing(_matrizR(1, 2)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 2)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 2) = _peon
                    ElseIf IsNothing(_matrizR(1, 3)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 3)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 3) = _peon
                    ElseIf IsNothing(_matrizR(1, 4)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 4)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 4) = _peon
                    ElseIf IsNothing(_matrizR(1, 5)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 5)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 5) = _peon
                    ElseIf IsNothing(_matrizR(1, 6)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 6)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 6) = _peon
                    ElseIf IsNothing(_matrizR(1, 7)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 7)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 7) = _peon
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaRojo") Then
                    If IsNothing(_matrizR(0, 6)) Then
                        Dim _reina As New Pieces
                        _reina.Fill = ChessPieces.ReinaRojo
                        Grid.SetColumn(_reina, 0)
                        Grid.SetRow(_reina, 6)
                        Rojos.Children.Add(_reina)
                        _matrizR(0, 6) = _reina
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyRojo") Then
                    If IsNothing(_matrizR(0, 7)) Then
                        Dim _rey As New Pieces
                        _rey.Fill = ChessPieces.ReyRojo
                        Grid.SetColumn(_rey, 0)
                        Grid.SetRow(_rey, 7)
                        Rojos.Children.Add(_rey)
                        _matrizR(0, 7) = _rey
                    End If

                    Ganan.Text = "Ganan Rojos"
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreRojo") Then
                    If IsNothing(_matrizR(0, 0)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreRojo
                        Grid.SetColumn(_torre, 0)
                        Grid.SetRow(_torre, 0)
                        Rojos.Children.Add(_torre)
                        _matrizR(0, 0) = _torre
                    ElseIf IsNothing(_matrizR(0, 1)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreRojo
                        Grid.SetColumn(_torre, 0)
                        Grid.SetRow(_torre, 1)
                        Rojos.Children.Add(_torre)
                        _matrizR(0, 1) = _torre
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True

                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("Movimiento Ilegal")
                    JugadorNegro.IsChecked = True
                    JugadorRojo.IsChecked = False
                End If
            End If
        Else
            _objeto = Nothing
        End If
    End Sub

    Private Sub MovimientoAlfil()
        Dim mov1 As Integer = Math.Abs(_newY - _mouseY)
        Dim mov2 As Integer = Math.Abs(_newX - _mouseX)
        If _objeto.Fill = ChessPieces.AlfilRojo Then
            If mov1 = mov2 Then
                If IsNothing(_matriz(_mouseX, _mouseY)) Then
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilNegro") Then
                    If IsNothing(_matrizN(1, 4)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilNegro
                        Grid.SetColumn(_alfil, 1)
                        Grid.SetRow(_alfil, 4)
                        Negros.Children.Add(_alfil)
                        _matrizN(1, 4) = _alfil
                    ElseIf IsNothing(_matrizN(1, 5)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilNegro
                        Grid.SetColumn(_alfil, 1)
                        Grid.SetRow(_alfil, 5)
                        Negros.Children.Add(_alfil)
                        _matrizN(1, 5) = _alfil
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoNegro") Then
                    If IsNothing(_matrizN(1, 2)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoNegro
                        Grid.SetColumn(_caballo, 1)
                        Grid.SetRow(_caballo, 2)
                        Negros.Children.Add(_caballo)
                        _matrizN(1, 2) = _caballo
                    ElseIf IsNothing(_matrizN(1, 3)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoNegro
                        Grid.SetColumn(_caballo, 1)
                        Grid.SetRow(_caballo, 3)
                        Negros.Children.Add(_caballo)
                        _matrizN(1, 3) = _caballo
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonNegro") Then
                    If IsNothing(_matrizN(0, 0)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 0)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 0) = _peon
                    ElseIf IsNothing(_matrizN(0, 1)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 1)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 1) = _peon
                    ElseIf IsNothing(_matrizN(0, 2)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 2)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 2) = _peon
                    ElseIf IsNothing(_matrizN(0, 3)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 3)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 3) = _peon
                    ElseIf IsNothing(_matrizN(0, 4)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 4)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 4) = _peon
                    ElseIf IsNothing(_matrizN(0, 5)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 5)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 5) = _peon
                    ElseIf IsNothing(_matrizN(0, 6)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 6)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 6) = _peon
                    ElseIf IsNothing(_matrizN(0, 7)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 7)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 7) = _peon
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaNegro") Then
                    If IsNothing(_matrizN(1, 6)) Then
                        Dim _reina As New Pieces
                        _reina.Fill = ChessPieces.ReinaNegro
                        Grid.SetColumn(_reina, 1)
                        Grid.SetRow(_reina, 6)
                        Negros.Children.Add(_reina)
                        _matrizN(1, 6) = _reina
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyNegro") Then
                    If IsNothing(_matrizN(1, 7)) Then
                        Dim _rey As New Pieces
                        _rey.Fill = ChessPieces.ReyNegro
                        Grid.SetColumn(_rey, 1)
                        Grid.SetRow(_rey, 7)
                        Negros.Children.Add(_rey)
                        _matrizN(1, 7) = _rey
                    End If

                    Ganan.Text = "Ganan Rojos"
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreNegro") Then
                    If IsNothing(_matrizN(1, 0)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreNegro
                        Grid.SetColumn(_torre, 1)
                        Grid.SetRow(_torre, 0)
                        Negros.Children.Add(_torre)
                        _matrizN(1, 0) = _torre
                    ElseIf IsNothing(_matrizN(1, 1)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreNegro
                        Grid.SetColumn(_torre, 1)
                        Grid.SetRow(_torre, 1)
                        Negros.Children.Add(_torre)
                        _matrizN(1, 1) = _torre
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("Movimiento Ilegal")
                    JugadorRojo.IsChecked = True
                    JugadorNegro.IsChecked = False
                End If
            End If
        ElseIf _objeto.Fill = ChessPieces.AlfilNegro Then

            If mov1 = mov2 Then
                If IsNothing(_matriz(_mouseX, _mouseY)) Then
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilRojo") Then
                    If IsNothing(_matrizR(0, 4)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilRojo
                        Grid.SetColumn(_alfil, 0)
                        Grid.SetRow(_alfil, 4)
                        Rojos.Children.Add(_alfil)
                        _matrizR(0, 4) = _alfil
                    ElseIf IsNothing(_matrizR(0, 5)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilRojo
                        Grid.SetColumn(_alfil, 0)
                        Grid.SetRow(_alfil, 5)
                        Rojos.Children.Add(_alfil)
                        _matrizR(0, 5) = _alfil
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoRojo") Then
                    If IsNothing(_matrizR(0, 2)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoRojo
                        Grid.SetColumn(_caballo, 0)
                        Grid.SetRow(_caballo, 2)
                        Rojos.Children.Add(_caballo)
                        _matrizR(0, 2) = _caballo
                    ElseIf IsNothing(_matrizR(0, 3)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoRojo
                        Grid.SetColumn(_caballo, 0)
                        Grid.SetRow(_caballo, 3)
                        Rojos.Children.Add(_caballo)
                        _matrizR(0, 3) = _caballo
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonRojo") Then
                    If IsNothing(_matrizR(1, 0)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 0)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 0) = _peon
                    ElseIf IsNothing(_matrizR(1, 1)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 1)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 1) = _peon
                    ElseIf IsNothing(_matrizR(1, 2)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 2)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 2) = _peon
                    ElseIf IsNothing(_matrizR(1, 3)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 3)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 3) = _peon
                    ElseIf IsNothing(_matrizR(1, 4)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 4)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 4) = _peon
                    ElseIf IsNothing(_matrizR(1, 5)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 5)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 5) = _peon
                    ElseIf IsNothing(_matrizR(1, 6)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 6)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 6) = _peon
                    ElseIf IsNothing(_matrizR(1, 7)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 7)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 7) = _peon
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaRojo") Then
                    If IsNothing(_matrizR(0, 6)) Then
                        Dim _reina As New Pieces
                        _reina.Fill = ChessPieces.ReinaRojo
                        Grid.SetColumn(_reina, 0)
                        Grid.SetRow(_reina, 6)
                        Rojos.Children.Add(_reina)
                        _matrizR(0, 6) = _reina
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyRojo") Then
                    If IsNothing(_matrizR(0, 7)) Then
                        Dim _rey As New Pieces
                        _rey.Fill = ChessPieces.ReyRojo
                        Grid.SetColumn(_rey, 0)
                        Grid.SetRow(_rey, 7)
                        Rojos.Children.Add(_rey)
                        _matrizR(0, 7) = _rey
                    End If

                    Ganan.Text = "Ganan Rojos"
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreRojo") Then
                    If IsNothing(_matrizR(0, 0)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreRojo
                        Grid.SetColumn(_torre, 0)
                        Grid.SetRow(_torre, 0)
                        Rojos.Children.Add(_torre)
                        _matrizR(0, 0) = _torre
                    ElseIf IsNothing(_matrizR(0, 1)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreRojo
                        Grid.SetColumn(_torre, 0)
                        Grid.SetRow(_torre, 1)
                        Rojos.Children.Add(_torre)
                        _matrizR(0, 1) = _torre
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("Movimiento Ilegal")
                    JugadorNegro.IsChecked = True
                    JugadorRojo.IsChecked = False
                End If
            End If
        Else
            _objeto = Nothing
        End If
    End Sub

    Public Sub MovimientoRey()
        If _objeto.Fill = ChessPieces.ReyRojo Then
            If (_mouseX = _newX + 1) Or (_mouseX = _newX - 1) Or (_mouseX = _newX) Then
                If (_mouseY = _newY + 1) Or (_mouseY = _newY - 1) Or (_mouseY = _newY) Then
                    If IsNothing(_matriz(_mouseX, _mouseY)) Then
                        Mover()
                        JugadorNegro.IsChecked = True
                        JugadorRojo.IsChecked = False
                    ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilNegro") Then
                        If IsNothing(_matrizN(1, 4)) Then
                            Dim _alfil As New Pieces
                            _alfil.Fill = ChessPieces.AlfilNegro
                            Grid.SetColumn(_alfil, 1)
                            Grid.SetRow(_alfil, 4)
                            Negros.Children.Add(_alfil)
                            _matrizN(1, 4) = _alfil
                        ElseIf IsNothing(_matrizN(1, 5)) Then
                            Dim _alfil As New Pieces
                            _alfil.Fill = ChessPieces.AlfilNegro
                            Grid.SetColumn(_alfil, 1)
                            Grid.SetRow(_alfil, 5)
                            Negros.Children.Add(_alfil)
                            _matrizN(1, 5) = _alfil
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoNegro") Then
                        If IsNothing(_matrizN(1, 2)) Then
                            Dim _caballo As New Pieces
                            _caballo.Fill = ChessPieces.CaballoNegro
                            Grid.SetColumn(_caballo, 1)
                            Grid.SetRow(_caballo, 2)
                            Negros.Children.Add(_caballo)
                            _matrizN(1, 2) = _caballo
                        ElseIf IsNothing(_matrizN(1, 3)) Then
                            Dim _caballo As New Pieces
                            _caballo.Fill = ChessPieces.CaballoNegro
                            Grid.SetColumn(_caballo, 1)
                            Grid.SetRow(_caballo, 3)
                            Negros.Children.Add(_caballo)
                            _matrizN(1, 3) = _caballo
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonNegro") Then
                        If IsNothing(_matrizN(0, 0)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 0)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 0) = _peon
                        ElseIf IsNothing(_matrizN(0, 1)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 1)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 1) = _peon
                        ElseIf IsNothing(_matrizN(0, 2)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 2)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 2) = _peon
                        ElseIf IsNothing(_matrizN(0, 3)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 3)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 3) = _peon
                        ElseIf IsNothing(_matrizN(0, 4)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 4)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 4) = _peon
                        ElseIf IsNothing(_matrizN(0, 5)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 5)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 5) = _peon
                        ElseIf IsNothing(_matrizN(0, 6)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 6)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 6) = _peon
                        ElseIf IsNothing(_matrizN(0, 7)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 7)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 7) = _peon
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaNegro") Then
                        If IsNothing(_matrizN(1, 6)) Then
                            Dim _reina As New Pieces
                            _reina.Fill = ChessPieces.ReinaNegro
                            Grid.SetColumn(_reina, 1)
                            Grid.SetRow(_reina, 6)
                            Negros.Children.Add(_reina)
                            _matrizN(1, 6) = _reina
                        End If

                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyNegro") Then
                        If IsNothing(_matrizN(1, 7)) Then
                            Dim _rey As New Pieces
                            _rey.Fill = ChessPieces.ReyNegro
                            Grid.SetColumn(_rey, 1)
                            Grid.SetRow(_rey, 7)
                            Negros.Children.Add(_rey)
                            _matrizN(1, 7) = _rey
                        End If

                        Ganan.Text = "Ganan Rojos"
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreNegro") Then
                        If IsNothing(_matrizN(1, 0)) Then
                            Dim _torre As New Pieces
                            _torre.Fill = ChessPieces.TorreNegro
                            Grid.SetColumn(_torre, 1)
                            Grid.SetRow(_torre, 0)
                            Negros.Children.Add(_torre)
                            _matrizN(1, 0) = _torre
                        ElseIf IsNothing(_matrizN(1, 1)) Then
                            Dim _torre As New Pieces
                            _torre.Fill = ChessPieces.TorreNegro
                            Grid.SetColumn(_torre, 1)
                            Grid.SetRow(_torre, 1)
                            Negros.Children.Add(_torre)
                            _matrizN(1, 1) = _torre
                        End If

                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                        _objeto = Nothing
                        MsgBox("Movimiento Ilegal")
                        JugadorRojo.IsChecked = True
                        JugadorNegro.IsChecked = False
                    End If
                End If
            End If
        ElseIf _objeto.Fill = ChessPieces.ReyNegro Then
            If (_mouseX = _newX + 1) Or (_mouseX = _newX - 1) Or (_mouseX = _newX) Then
                If (_mouseY = _newY + 1) Or (_mouseY = _newY - 1) Or (_mouseY = _newY) Then
                    If IsNothing(_matriz(_mouseX, _mouseY)) Then
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilRojo") Then
                        If IsNothing(_matrizR(0, 4)) Then
                            Dim _alfil As New Pieces
                            _alfil.Fill = ChessPieces.AlfilRojo
                            Grid.SetColumn(_alfil, 0)
                            Grid.SetRow(_alfil, 4)
                            Rojos.Children.Add(_alfil)
                            _matrizR(0, 4) = _alfil
                        ElseIf IsNothing(_matrizR(0, 5)) Then
                            Dim _alfil As New Pieces
                            _alfil.Fill = ChessPieces.AlfilRojo
                            Grid.SetColumn(_alfil, 0)
                            Grid.SetRow(_alfil, 5)
                            Rojos.Children.Add(_alfil)
                            _matrizR(0, 5) = _alfil
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoRojo") Then
                        If IsNothing(_matrizR(0, 2)) Then
                            Dim _caballo As New Pieces
                            _caballo.Fill = ChessPieces.CaballoRojo
                            Grid.SetColumn(_caballo, 0)
                            Grid.SetRow(_caballo, 2)
                            Rojos.Children.Add(_caballo)
                            _matrizR(0, 2) = _caballo
                        ElseIf IsNothing(_matrizR(0, 3)) Then
                            Dim _caballo As New Pieces
                            _caballo.Fill = ChessPieces.CaballoRojo
                            Grid.SetColumn(_caballo, 0)
                            Grid.SetRow(_caballo, 3)
                            Rojos.Children.Add(_caballo)
                            _matrizR(0, 3) = _caballo
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonRojo") Then
                        If IsNothing(_matrizR(1, 0)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 0)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 0) = _peon
                        ElseIf IsNothing(_matrizR(1, 1)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 1)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 1) = _peon
                        ElseIf IsNothing(_matrizR(1, 2)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 2)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 2) = _peon
                        ElseIf IsNothing(_matrizR(1, 3)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 3)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 3) = _peon
                        ElseIf IsNothing(_matrizR(1, 4)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 4)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 4) = _peon
                        ElseIf IsNothing(_matrizR(1, 5)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 5)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 5) = _peon
                        ElseIf IsNothing(_matrizR(1, 6)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 6)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 6) = _peon
                        ElseIf IsNothing(_matrizR(1, 7)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 7)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 7) = _peon
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaRojo") Then
                        If IsNothing(_matrizR(0, 6)) Then
                            Dim _reina As New Pieces
                            _reina.Fill = ChessPieces.ReinaRojo
                            Grid.SetColumn(_reina, 0)
                            Grid.SetRow(_reina, 6)
                            Rojos.Children.Add(_reina)
                            _matrizR(0, 6) = _reina
                        End If

                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyRojo") Then
                        If IsNothing(_matrizR(0, 7)) Then
                            Dim _rey As New Pieces
                            _rey.Fill = ChessPieces.ReyRojo
                            Grid.SetColumn(_rey, 0)
                            Grid.SetRow(_rey, 7)
                            Rojos.Children.Add(_rey)
                            _matrizR(0, 7) = _rey
                        End If

                        Ganan.Text = "Ganan Rojos"
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreRojo") Then
                        If IsNothing(_matrizR(0, 0)) Then
                            Dim _torre As New Pieces
                            _torre.Fill = ChessPieces.TorreRojo
                            Grid.SetColumn(_torre, 0)
                            Grid.SetRow(_torre, 0)
                            Rojos.Children.Add(_torre)
                            _matrizR(0, 0) = _torre
                        ElseIf IsNothing(_matrizR(0, 1)) Then
                            Dim _torre As New Pieces
                            _torre.Fill = ChessPieces.TorreRojo
                            Grid.SetColumn(_torre, 0)
                            Grid.SetRow(_torre, 1)
                            Rojos.Children.Add(_torre)
                            _matrizR(0, 1) = _torre
                        End If

                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                        _objeto = Nothing
                        MsgBox("Movimiento Ilegal")
                        JugadorNegro.IsChecked = True
                        JugadorRojo.IsChecked = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub MovimientoCaballo()
        If _objeto.Fill = ChessPieces.CaballoRojo Then
            If (_mouseX = _newX + 1) Or (_mouseX = _newX - 1) Or (_mouseX = _newX + 2) Or (_mouseX = _newX - 2) Then
                If (_mouseY = _newY + 2) Or (_mouseY = _newY - 2) Or (_mouseY = _newY + 1) Or (_mouseY = _newY - 1) Then
                    If IsNothing(_matriz(_mouseX, _mouseY)) Then
                        Mover()
                        JugadorNegro.IsChecked = True
                        JugadorRojo.IsChecked = False
                    ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilNegro") Then
                        If IsNothing(_matrizN(1, 4)) Then
                            Dim _alfil As New Pieces
                            _alfil.Fill = ChessPieces.AlfilNegro
                            Grid.SetColumn(_alfil, 1)
                            Grid.SetRow(_alfil, 4)
                            Negros.Children.Add(_alfil)
                            _matrizN(1, 4) = _alfil
                        ElseIf IsNothing(_matrizN(1, 5)) Then
                            Dim _alfil As New Pieces
                            _alfil.Fill = ChessPieces.AlfilNegro
                            Grid.SetColumn(_alfil, 1)
                            Grid.SetRow(_alfil, 5)
                            Negros.Children.Add(_alfil)
                            _matrizN(1, 5) = _alfil
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoNegro") Then
                        If IsNothing(_matrizN(1, 2)) Then
                            Dim _caballo As New Pieces
                            _caballo.Fill = ChessPieces.CaballoNegro
                            Grid.SetColumn(_caballo, 1)
                            Grid.SetRow(_caballo, 2)
                            Negros.Children.Add(_caballo)
                            _matrizN(1, 2) = _caballo
                        ElseIf IsNothing(_matrizN(1, 3)) Then
                            Dim _caballo As New Pieces
                            _caballo.Fill = ChessPieces.CaballoNegro
                            Grid.SetColumn(_caballo, 1)
                            Grid.SetRow(_caballo, 3)
                            Negros.Children.Add(_caballo)
                            _matrizN(1, 3) = _caballo
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonNegro") Then
                        If IsNothing(_matrizN(0, 0)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 0)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 0) = _peon
                        ElseIf IsNothing(_matrizN(0, 1)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 1)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 1) = _peon
                        ElseIf IsNothing(_matrizN(0, 2)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 2)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 2) = _peon
                        ElseIf IsNothing(_matrizN(0, 3)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 3)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 3) = _peon
                        ElseIf IsNothing(_matrizN(0, 4)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 4)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 4) = _peon
                        ElseIf IsNothing(_matrizN(0, 5)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 5)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 5) = _peon
                        ElseIf IsNothing(_matrizN(0, 6)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 6)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 6) = _peon
                        ElseIf IsNothing(_matrizN(0, 7)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonNegro
                            Grid.SetColumn(_peon, 0)
                            Grid.SetRow(_peon, 7)
                            Negros.Children.Add(_peon)
                            _matrizN(0, 7) = _peon
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaNegro") Then
                        If IsNothing(_matrizN(1, 6)) Then
                            Dim _reina As New Pieces
                            _reina.Fill = ChessPieces.ReinaNegro
                            Grid.SetColumn(_reina, 1)
                            Grid.SetRow(_reina, 6)
                            Negros.Children.Add(_reina)
                            _matrizN(1, 6) = _reina
                        End If

                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyNegro") Then
                        If IsNothing(_matrizN(1, 7)) Then
                            Dim _rey As New Pieces
                            _rey.Fill = ChessPieces.ReyNegro
                            Grid.SetColumn(_rey, 1)
                            Grid.SetRow(_rey, 7)
                            Negros.Children.Add(_rey)
                            _matrizN(1, 7) = _rey
                        End If

                        Ganan.Text = "Ganan Rojos"
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreNegro") Then
                        If IsNothing(_matrizN(1, 0)) Then
                            Dim _torre As New Pieces
                            _torre.Fill = ChessPieces.TorreNegro
                            Grid.SetColumn(_torre, 1)
                            Grid.SetRow(_torre, 0)
                            Negros.Children.Add(_torre)
                            _matrizN(1, 0) = _torre
                        ElseIf IsNothing(_matrizN(1, 1)) Then
                            Dim _torre As New Pieces
                            _torre.Fill = ChessPieces.TorreNegro
                            Grid.SetColumn(_torre, 1)
                            Grid.SetRow(_torre, 1)
                            Negros.Children.Add(_torre)
                            _matrizN(1, 1) = _torre
                        End If

                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorRojo.IsChecked = False
                        JugadorNegro.IsChecked = True
                    ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                        _objeto = Nothing
                        MsgBox("Movimiento Ilegal")
                        JugadorRojo.IsChecked = True
                        JugadorNegro.IsChecked = False
                    End If
                End If
            End If
        ElseIf _objeto.Fill = ChessPieces.CaballoNegro Then
            If (_mouseX = _newX + 1) Or (_mouseX = _newX - 1) Or (_mouseX = _newX + 2) Or (_mouseX = _newX - 2) Then
                If (_mouseY = _newY + 2) Or (_mouseY = _newY - 2) Or (_mouseY = _newY + 1) Or (_mouseY = _newY - 1) Then
                    If IsNothing(_matriz(_mouseX, _mouseY)) Then
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilRojo") Then
                        If IsNothing(_matrizR(0, 4)) Then
                            Dim _alfil As New Pieces
                            _alfil.Fill = ChessPieces.AlfilRojo
                            Grid.SetColumn(_alfil, 0)
                            Grid.SetRow(_alfil, 4)
                            Rojos.Children.Add(_alfil)
                            _matrizR(0, 4) = _alfil
                        ElseIf IsNothing(_matrizR(0, 5)) Then
                            Dim _alfil As New Pieces
                            _alfil.Fill = ChessPieces.AlfilRojo
                            Grid.SetColumn(_alfil, 0)
                            Grid.SetRow(_alfil, 5)
                            Rojos.Children.Add(_alfil)
                            _matrizR(0, 5) = _alfil
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoRojo") Then
                        If IsNothing(_matrizR(0, 2)) Then
                            Dim _caballo As New Pieces
                            _caballo.Fill = ChessPieces.CaballoRojo
                            Grid.SetColumn(_caballo, 0)
                            Grid.SetRow(_caballo, 2)
                            Rojos.Children.Add(_caballo)
                            _matrizR(0, 2) = _caballo
                        ElseIf IsNothing(_matrizR(0, 3)) Then
                            Dim _caballo As New Pieces
                            _caballo.Fill = ChessPieces.CaballoRojo
                            Grid.SetColumn(_caballo, 0)
                            Grid.SetRow(_caballo, 3)
                            Rojos.Children.Add(_caballo)
                            _matrizR(0, 3) = _caballo
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonRojo") Then
                        If IsNothing(_matrizR(1, 0)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 0)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 0) = _peon
                        ElseIf IsNothing(_matrizR(1, 1)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 1)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 1) = _peon
                        ElseIf IsNothing(_matrizR(1, 2)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 2)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 2) = _peon
                        ElseIf IsNothing(_matrizR(1, 3)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 3)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 3) = _peon
                        ElseIf IsNothing(_matrizR(1, 4)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 4)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 4) = _peon
                        ElseIf IsNothing(_matrizR(1, 5)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 5)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 5) = _peon
                        ElseIf IsNothing(_matrizR(1, 6)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 6)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 6) = _peon
                        ElseIf IsNothing(_matrizR(1, 7)) Then
                            Dim _peon As New Pieces
                            _peon.Fill = ChessPieces.PeonRojo
                            Grid.SetColumn(_peon, 1)
                            Grid.SetRow(_peon, 7)
                            Rojos.Children.Add(_peon)
                            _matrizR(1, 7) = _peon
                        End If
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaRojo") Then
                        If IsNothing(_matrizR(0, 6)) Then
                            Dim _reina As New Pieces
                            _reina.Fill = ChessPieces.ReinaRojo
                            Grid.SetColumn(_reina, 0)
                            Grid.SetRow(_reina, 6)
                            Rojos.Children.Add(_reina)
                            _matrizR(0, 6) = _reina
                        End If

                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyRojo") Then
                        If IsNothing(_matrizR(0, 7)) Then
                            Dim _rey As New Pieces
                            _rey.Fill = ChessPieces.ReyRojo
                            Grid.SetColumn(_rey, 0)
                            Grid.SetRow(_rey, 7)
                            Rojos.Children.Add(_rey)
                            _matrizR(0, 7) = _rey
                        End If

                        Ganan.Text = "Ganan Rojos"
                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreRojo") Then
                        If IsNothing(_matrizR(0, 0)) Then
                            Dim _torre As New Pieces
                            _torre.Fill = ChessPieces.TorreRojo
                            Grid.SetColumn(_torre, 0)
                            Grid.SetRow(_torre, 0)
                            Rojos.Children.Add(_torre)
                            _matrizR(0, 0) = _torre
                        ElseIf IsNothing(_matrizR(0, 1)) Then
                            Dim _torre As New Pieces
                            _torre.Fill = ChessPieces.TorreRojo
                            Grid.SetColumn(_torre, 0)
                            Grid.SetRow(_torre, 1)
                            Rojos.Children.Add(_torre)
                            _matrizR(0, 1) = _torre
                        End If

                        Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                        _matriz(_mouseX, _mouseY) = Nothing
                        Mover()
                        JugadorNegro.IsChecked = False
                        JugadorRojo.IsChecked = True
                    ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                        _objeto = Nothing
                        MsgBox("Movimiento Ilegal")
                        JugadorNegro.IsChecked = True
                        JugadorRojo.IsChecked = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub MovimientoReina()
        Dim mov1 As Integer = Math.Abs(_newY - _mouseY)
        Dim mov2 As Integer = Math.Abs(_newX - _mouseX)
        If _objeto.Fill = ChessPieces.ReinaRojo Then
            If _newX = _mouseX Or _newY = _mouseY Or mov1 = mov2 Then
                If IsNothing(_matriz(_mouseX, _mouseY)) Then
                    Mover()
                    JugadorNegro.IsChecked = True
                    JugadorRojo.IsChecked = False
                ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilNegro") Then
                    If IsNothing(_matrizN(1, 4)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilNegro
                        Grid.SetColumn(_alfil, 1)
                        Grid.SetRow(_alfil, 4)
                        Negros.Children.Add(_alfil)
                        _matrizN(1, 4) = _alfil
                    ElseIf IsNothing(_matrizN(1, 5)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilNegro
                        Grid.SetColumn(_alfil, 1)
                        Grid.SetRow(_alfil, 5)
                        Negros.Children.Add(_alfil)
                        _matrizN(1, 5) = _alfil
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoNegro") Then
                    If IsNothing(_matrizN(1, 2)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoNegro
                        Grid.SetColumn(_caballo, 1)
                        Grid.SetRow(_caballo, 2)
                        Negros.Children.Add(_caballo)
                        _matrizN(1, 2) = _caballo
                    ElseIf IsNothing(_matrizN(1, 3)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoNegro
                        Grid.SetColumn(_caballo, 1)
                        Grid.SetRow(_caballo, 3)
                        Negros.Children.Add(_caballo)
                        _matrizN(1, 3) = _caballo
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonNegro") Then
                    If IsNothing(_matrizN(0, 0)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 0)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 0) = _peon
                    ElseIf IsNothing(_matrizN(0, 1)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 1)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 1) = _peon
                    ElseIf IsNothing(_matrizN(0, 2)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 2)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 2) = _peon
                    ElseIf IsNothing(_matrizN(0, 3)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 3)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 3) = _peon
                    ElseIf IsNothing(_matrizN(0, 4)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 4)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 4) = _peon
                    ElseIf IsNothing(_matrizN(0, 5)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 5)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 5) = _peon
                    ElseIf IsNothing(_matrizN(0, 6)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 6)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 6) = _peon
                    ElseIf IsNothing(_matrizN(0, 7)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonNegro
                        Grid.SetColumn(_peon, 0)
                        Grid.SetRow(_peon, 7)
                        Negros.Children.Add(_peon)
                        _matrizN(0, 7) = _peon
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaNegro") Then
                    If IsNothing(_matrizN(1, 6)) Then
                        Dim _reina As New Pieces
                        _reina.Fill = ChessPieces.ReinaNegro
                        Grid.SetColumn(_reina, 1)
                        Grid.SetRow(_reina, 6)
                        Negros.Children.Add(_reina)
                        _matrizN(1, 6) = _reina
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyNegro") Then
                    If IsNothing(_matrizN(1, 7)) Then
                        Dim _rey As New Pieces
                        _rey.Fill = ChessPieces.ReyNegro
                        Grid.SetColumn(_rey, 1)
                        Grid.SetRow(_rey, 7)
                        Negros.Children.Add(_rey)
                        _matrizN(1, 7) = _rey
                    End If

                    Ganan.Text = "Ganan Rojos"
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreNegro") Then
                    If IsNothing(_matrizN(1, 0)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreNegro
                        Grid.SetColumn(_torre, 1)
                        Grid.SetRow(_torre, 0)
                        Negros.Children.Add(_torre)
                        _matrizN(1, 0) = _torre
                    ElseIf IsNothing(_matrizN(1, 1)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreNegro
                        Grid.SetColumn(_torre, 1)
                        Grid.SetRow(_torre, 1)
                        Negros.Children.Add(_torre)
                        _matrizN(1, 1) = _torre
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorRojo.IsChecked = False
                    JugadorNegro.IsChecked = True
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("Movimiento Ilegal")
                    JugadorRojo.IsChecked = True
                    JugadorNegro.IsChecked = False
                End If
            End If
        ElseIf _objeto.Fill = ChessPieces.ReinaNegro Then
            If _newX = _mouseX Or _newY = _mouseY Or mov1 = mov2 Then
                If IsNothing(_matriz(_mouseX, _mouseY)) Then
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).fill.ToString.Contains("AlfilRojo") Then
                    If IsNothing(_matrizR(0, 4)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilRojo
                        Grid.SetColumn(_alfil, 0)
                        Grid.SetRow(_alfil, 4)
                        Rojos.Children.Add(_alfil)
                        _matrizR(0, 4) = _alfil
                    ElseIf IsNothing(_matrizR(0, 5)) Then
                        Dim _alfil As New Pieces
                        _alfil.Fill = ChessPieces.AlfilRojo
                        Grid.SetColumn(_alfil, 0)
                        Grid.SetRow(_alfil, 5)
                        Rojos.Children.Add(_alfil)
                        _matrizR(0, 5) = _alfil
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("CaballoRojo") Then
                    If IsNothing(_matrizR(0, 2)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoRojo
                        Grid.SetColumn(_caballo, 0)
                        Grid.SetRow(_caballo, 2)
                        Rojos.Children.Add(_caballo)
                        _matrizR(0, 2) = _caballo
                    ElseIf IsNothing(_matrizR(0, 3)) Then
                        Dim _caballo As New Pieces
                        _caballo.Fill = ChessPieces.CaballoRojo
                        Grid.SetColumn(_caballo, 0)
                        Grid.SetRow(_caballo, 3)
                        Rojos.Children.Add(_caballo)
                        _matrizR(0, 3) = _caballo
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("PeonRojo") Then
                    If IsNothing(_matrizR(1, 0)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 0)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 0) = _peon
                    ElseIf IsNothing(_matrizR(1, 1)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 1)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 1) = _peon
                    ElseIf IsNothing(_matrizR(1, 2)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 2)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 2) = _peon
                    ElseIf IsNothing(_matrizR(1, 3)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 3)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 3) = _peon
                    ElseIf IsNothing(_matrizR(1, 4)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 4)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 4) = _peon
                    ElseIf IsNothing(_matrizR(1, 5)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 5)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 5) = _peon
                    ElseIf IsNothing(_matrizR(1, 6)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 6)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 6) = _peon
                    ElseIf IsNothing(_matrizR(1, 7)) Then
                        Dim _peon As New Pieces
                        _peon.Fill = ChessPieces.PeonRojo
                        Grid.SetColumn(_peon, 1)
                        Grid.SetRow(_peon, 7)
                        Rojos.Children.Add(_peon)
                        _matrizR(1, 7) = _peon
                    End If
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReinaRojo") Then
                    If IsNothing(_matrizR(0, 6)) Then
                        Dim _reina As New Pieces
                        _reina.Fill = ChessPieces.ReinaRojo
                        Grid.SetColumn(_reina, 0)
                        Grid.SetRow(_reina, 6)
                        Rojos.Children.Add(_reina)
                        _matrizR(0, 6) = _reina
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("ReyRojo") Then
                    If IsNothing(_matrizR(0, 7)) Then
                        Dim _rey As New Pieces
                        _rey.Fill = ChessPieces.ReyRojo
                        Grid.SetColumn(_rey, 0)
                        Grid.SetRow(_rey, 7)
                        Rojos.Children.Add(_rey)
                        _matrizR(0, 7) = _rey
                    End If

                    Ganan.Text = "Ganan Rojos"
                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _matriz(_mouseX, _mouseY).Fill.ToString.Contains("TorreRojo") Then
                    If IsNothing(_matrizR(0, 0)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreRojo
                        Grid.SetColumn(_torre, 0)
                        Grid.SetRow(_torre, 0)
                        Rojos.Children.Add(_torre)
                        _matrizR(0, 0) = _torre
                    ElseIf IsNothing(_matrizR(0, 1)) Then
                        Dim _torre As New Pieces
                        _torre.Fill = ChessPieces.TorreRojo
                        Grid.SetColumn(_torre, 0)
                        Grid.SetRow(_torre, 1)
                        Rojos.Children.Add(_torre)
                        _matrizR(0, 1) = _torre
                    End If

                    Tablero.Children.Remove(_matriz(_mouseX, _mouseY))
                    _matriz(_mouseX, _mouseY) = Nothing
                    Mover()
                    JugadorNegro.IsChecked = False
                    JugadorRojo.IsChecked = True
                ElseIf _mouseX <> _newX Or _newY = _mouseY Then ''Error de movimiento
                    _objeto = Nothing
                    MsgBox("Movimiento Ilegal")
                    JugadorNegro.IsChecked = True
                    JugadorRojo.IsChecked = False
                End If
            End If
        End If
    End Sub
End Class
