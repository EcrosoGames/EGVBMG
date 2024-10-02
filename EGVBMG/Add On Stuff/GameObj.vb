Public Class GameObj
    Public Shared minfade As Single = 1.1F
    Public Shared Sub DrawLetter(loc As Vector2, text As String, col As Color, effect As Integer, scale As Single)
        Dim TexUse As Texture2D
        Dim TexAdj As Single = 2.0F
        If scale = 1 Then
            TexUse = Textures.TRANSLATE
            TexAdj = 1.0F
        Else
            TexUse = Textures.TRANSLATEx2
        End If

        Dim line As Integer = 0
        Dim lnChar As Integer = 0
        Dim offset As Vector2
        For q As Integer = 0 To text.Length - 1
            Select Case effect
                Case 1 'Wave
                    offset.Y = Math.Sin(lnChar + (Globals.GameTime.TotalGameTime.Milliseconds / 160)) * 10
                Case 2 'RNG colour strobe
                    col = RNG.ColorXNA
                Case 3 'RNG colour
                    col = RNG.ColorXNAfixed(q)
                Case 4 'Blinky
                    col *= Math.Sin((Globals.GameTime.TotalGameTime.Milliseconds / 160)) * 10 + minfade
                Case 5 'Fade Blink and change colour
                    If q = 0 Then col = RNG.ColorXNAfixed(Globals.GameTime.TotalGameTime.Seconds)
                    If q = 0 Then col *= Math.Sin((Globals.GameTime.TotalGameTime.Milliseconds / 160))
                Case 6 'Fade all text
                    If q = 0 Then col *= Math.Sin((Globals.GameTime.TotalGameTime.Milliseconds / 160)) + minfade
                Case 7 'rng color pulse
                    If q = 0 Then col = RNG.ColorXNAfixed(Globals.GameTime.TotalGameTime.Seconds)
                Case 8 'BG thicc
                    If q = 0 Then
                        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X - 2, loc.Y + line * 14 * scale + offset.Y - 2, 11 * scale, 17 * scale), Color.White)
                    ElseIf q = text.Length - 1 Then
                        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X - 1, loc.Y + line * 14 * scale + offset.Y - 2, 12 * scale, 17 * scale), Color.White)
                    End If
                    Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X - 1, loc.Y + line * 14 * scale + offset.Y - 2, 11 * scale, 17 * scale), Color.White)
                Case 9 'BG SLIM
                    Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X - 1, loc.Y + line * 14 * scale + offset.Y - 1, 11 * scale, 15 * scale), Color.White)
                Case 10 'Lil Wave
                    offset.Y = Math.Sin(lnChar + (Globals.GameTime.TotalGameTime.Milliseconds / 160)) * 2
                Case 12 'SFK
                    Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X - 1, loc.Y + line * 14 * scale + offset.Y - 1, 11 * scale, 15 * scale), Color.Black)
                Case 13 'BG thicc
                    If q = 0 Then
                        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X - 2, loc.Y + line * 14 * scale + offset.Y - 2, 11 * scale, 18 * scale), Color.Black)
                    ElseIf q = text.Length - 1 Then
                        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y - 2, 12 * scale, 18 * scale), Color.Black)
                    End If
                    Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y - 2, 11 * scale, 18 * scale), Color.Black)
                Case 14 'Invert 9
                    Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(loc.X + lnChar * 10 * scale + offset.X - 1, loc.Y + line * 14 * scale + offset.Y - 1, 11 * scale, 15 * scale), New Color(50, 50, 50))
            End Select
            Select Case text.Substring(q, 1)
                Case "A"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(73 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "B"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(83 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "C"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(93 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "D"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(103 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "E"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(113 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "F"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(123 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "G"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(133 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "H"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(73 * TexAdj, 15 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "I"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(83 * TexAdj, 15 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "J"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(93 * TexAdj, 15 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "K"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(103 * TexAdj, 15 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "L"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(113 * TexAdj, 15 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "M"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(123 * TexAdj, 15 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "N"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(133 * TexAdj, 15 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "O"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(73 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "P"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(83 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "Q"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(93 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "R"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(103 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "S"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(113 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "T"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(123 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "U"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(133 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "V"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(73 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "W"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(83 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "X"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(93 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "Y"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(103 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "Z"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(113 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case " "
                  '  lnChar += 1
                Case "a"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(1 * TexAdj, 73 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "b"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(11 * TexAdj, 73 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "c"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(21 * TexAdj, 73 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "d"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(31 * TexAdj, 73 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "e"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(41 * TexAdj, 73 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "f"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(51 * TexAdj, 73 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "g"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(61 * TexAdj, 73 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "h"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(1 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "i"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(11 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "j"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(21 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "k"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(31 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "l"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(41 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "m"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(51 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "n"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(61 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "o"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(1 * TexAdj, 101 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "p"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(11 * TexAdj, 101 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "q"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(21 * TexAdj, 101 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "r"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(31 * TexAdj, 101 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "s"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(41 * TexAdj, 101 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "t"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(51 * TexAdj, 101 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "u"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(61 * TexAdj, 101 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "v"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(1 * TexAdj, 115 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "w"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(11 * TexAdj, 115 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "x"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(21 * TexAdj, 115 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "y"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(31 * TexAdj, 115 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "z"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(41 * TexAdj, 115 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "."
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(123 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "!"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(133 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "?"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(73 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "'"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(103 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "$"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(113 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "°"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(123 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "+"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(205 * TexAdj, 15 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "-"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(195 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "_"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(1 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "="
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(205 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "/"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(175 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "\"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(165 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "%"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(155 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "|"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(145 * TexAdj, 1 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "*"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(145 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "&"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(31 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "1"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(175 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "2"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(185 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "3"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(195 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "4"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(205 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "5"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(145 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "6"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(155 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "7"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(165 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "8"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(175 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "9"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(185 * TexAdj, 43 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "0"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(165 * TexAdj, 29 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case ":"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(51 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case ChrW(247)
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(145 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case ChrW(34) 'quotes
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(83 * TexAdj, 57 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case ChrW(13) 'new line
                    lnChar = -2
                    line += 1
                Case ChrW(10) 'Backspace?

                Case "<"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(113 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case ">"
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y, 9 * scale, 13 * scale), New Rectangle(123 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case ","
                    Globals.SpriteBatch.Draw(TexUse, New Rectangle(loc.X + lnChar * 10 * scale + offset.X, loc.Y + line * 14 * scale + offset.Y + scale, 9 * scale, 13 * scale), New Rectangle(133 * TexAdj, 87 * TexAdj, 9 * TexAdj, 13 * TexAdj), col)
                Case "("

                Case ")"

                Case Else
                    Console.WriteLine(AscW(text.Substring(q, 1)))
            End Select
            lnChar += 1
        Next
    End Sub
    Public Shared AchieveCD As Integer = 200
    Public Shared Achieved As Boolean = False
    Public Shared Sub Achievement(title As String, desc As String)
        Dim Y As Integer = 0
        If AchieveCD > 150 Then
            Y = -AchieveCD + 150
        ElseIf AchieveCD < 50 Then
            Y = AchieveCD - 50
        End If

        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, Y, title.Length * 40, 45), Color.Black)
        DrawLetter(New Vector2(0, Y), "Achievement: " & title, Color.White, 0, 2)
        DrawLetter(New Vector2(0, Y + 30), desc, Color.White, 0, 1)


        If AchieveCD > 0 Then
            AchieveCD -= 1
        ElseIf AchieveCD = 0 Then
            AchieveCD = 200
        End If

    End Sub
    Public Shared Sub Textbox(loc As Vector2, text As String, col As Color, effect As Integer, scale As Single, profile As Integer, frame As Integer, options As Integer)
        'Background
        Select Case options
            Case 0
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(0, (63 * frame), 400, 63), Color.White)
            Case 1 'YesNo Y
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(400, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(331, 10), "Yes", col, effect, scale)
                DrawLetter(loc + New Vector2(321, 25), "No", col, effect, scale)
            Case 2 'YesNo N
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(400, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(321, 10), "Yes", col, effect, scale)
                DrawLetter(loc + New Vector2(331, 25), "No", col, effect, scale)
            Case 3 'BuySellCancel B
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(400, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(331, 10), "Buy", col, effect, scale)
                DrawLetter(loc + New Vector2(321, 25), "Sell", col, effect, scale)
                DrawLetter(loc + New Vector2(321, 40), "Quit", col, effect, scale)
            Case 4 'BuySellCancel S
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(400, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(321, 10), "Buy", col, effect, scale)
                DrawLetter(loc + New Vector2(331, 25), "Sell", col, effect, scale)
                DrawLetter(loc + New Vector2(321, 40), "Quit", col, effect, scale)
            Case 5 'BuySellCancel C
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(400, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(321, 10), "Buy", col, effect, scale)
                DrawLetter(loc + New Vector2(321, 25), "Sell", col, effect, scale)
                DrawLetter(loc + New Vector2(331, 40), "Quit", col, effect, scale)
            Case 6 'AtkItmSwiDefStaRun A
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(1200, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(212, 10), "ATTACK", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 25), "ITEM", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 40), "SWITCH", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 10), "DEFEND", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 25), "STATS", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 40), "RUN", col, effect, scale)
            Case 7 'AtkItmSwiDefStaRun I
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(1600, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(212, 10), "Attack", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 25), "Item", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 40), "Switch", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 10), "Defend", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 25), "Stats", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 40), "Run", col, effect, scale)
            Case 8 'AtkItmSwiDefStaRun S
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(2000, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(212, 10), "Attack", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 25), "Item", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 40), "Switch", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 10), "Defend", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 25), "Stats", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 40), "Run", col, effect, scale)
            Case 9 'AtkItmSwiDefStaRun D
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(2400, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(212, 10), "Attack", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 25), "Item", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 40), "Switch", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 10), "Defend", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 25), "Stats", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 40), "Run", col, effect, scale)
            Case 10 'AtkItmSwiDefStaRun S
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(2800, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(212, 10), "Attack", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 25), "Item", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 40), "Switch", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 10), "Defend", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 25), "Stats", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 40), "Run", col, effect, scale)
            Case 11 'AtkItmSwiDefStaRun R
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(3200, (63 * frame), 400, 63), Color.White)
                DrawLetter(loc + New Vector2(212, 10), "Attack", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 25), "Item", col, effect, scale)
                DrawLetter(loc + New Vector2(212, 40), "Switch", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 10), "Defend", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 25), "Stats", col, effect, scale)
                DrawLetter(loc + New Vector2(333, 40), "Run", col, effect, scale)
            Case 12
                Globals.SpriteBatch.Draw(Textures.GUIFRAMES, New Rectangle(loc.X, loc.Y, 400, 63), New Rectangle(800, (63 * frame), 400, 63), Color.White)

            Case 13

            Case 14

            Case 15

            Case 16

            Case 17

            Case 18

            Case 19

            Case 20

        End Select
        'Text
        DrawLetter(loc + New Vector2(48, 10), text, col, effect, scale)
        'Profile

    End Sub
    Public Shared Sub DrawMenu(sel As Integer, Entries As List(Of MenuEntry), Size As Vector2, Pos As Vector2, scale As Integer, alignment As Integer)
        Dim MenuY As Integer = Pos.Y + 20
        For x = 0 To Entries.Count - 1
            Select Case alignment
                Case 0
                    If x = sel Then
                        GameObj.DrawLetter(New Vector2(Pos.X - (25 * scale) - Entries.Item(x).Text.Length * 20, MenuY), Entries.Item(x).Text, Color.Red, 0, scale)
                    ElseIf Entries.Item(x).Enabled = True Then
                        GameObj.DrawLetter(New Vector2(Pos.X - Entries.Item(x).Text.Length * 20, MenuY), Entries.Item(x).Text, Color.White, 0, scale)
                    Else
                        GameObj.DrawLetter(New Vector2(Pos.X - Entries.Item(x).Text.Length * 20, MenuY), Entries.Item(x).Text, Color.Gray, 0, scale)
                    End If
                Case 1
                    If x = sel Then
                        GameObj.DrawLetter(New Vector2(Pos.X - (25 * scale) - Entries.Item(x).Text.Length * 10, MenuY), Entries.Item(x).Text, Color.Red, 0, scale)
                    ElseIf Entries.Item(x).Enabled = True Then
                        GameObj.DrawLetter(New Vector2(Pos.X - Entries.Item(x).Text.Length * 10, MenuY), Entries.Item(x).Text, Color.White, 0, scale)
                    Else
                        GameObj.DrawLetter(New Vector2(Pos.X - Entries.Item(x).Text.Length * 10, MenuY), Entries.Item(x).Text, Color.Gray, 0, scale)
                    End If
            End Select
            MenuY += 28.0F
        Next
    End Sub
    Public Shared Sub ControlHint(btn As Integer)
        Select Case btn
            Case 0 'A
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(290, 374, 18, 26), Color.White)
            Case 1 'B
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(310, 374, 18, 26), Color.White)
            Case 2 'X
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(330, 374, 18, 26), Color.White)
            Case 3 'Y
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(350, 374, 18, 26), Color.White)
            Case 4 'Rs
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(290, 346, 18, 26), Color.White)
            Case 5 'Ls
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(310, 346, 18, 26), Color.White)
            Case 6 'RT
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(330, 346, 18, 26), Color.White)
            Case 7 'LT
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(350, 346, 18, 26), Color.White)
            Case 8 'RB
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(370, 346, 18, 26), Color.White)
            Case 9 'LB
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(390, 346, 18, 26), Color.White)
            Case 10 'Menu
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(390, 374, 18, 26), Color.White)
            Case 11 'Share
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(370, 374, 18, 26), Color.White)
            Case 12 'X
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(290, 402, 18, 26), Color.White)
            Case 13 'O
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(310, 402, 18, 26), Color.White)
            Case 14 '[]
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(330, 402, 18, 26), Color.White)
            Case 15 '/_\
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(350, 402, 18, 26), Color.White)
            Case 16 'Sel
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(410, 346, 18, 26), Color.White)
            Case 17 'Start
                Globals.SpriteBatch.Draw(Textures.TRANSLATEx2, New Rectangle(382, 214, 18, 26), New Rectangle(410, 374, 18, 26), Color.White)
        End Select
    End Sub
End Class