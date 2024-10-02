Imports SharpDX
Imports Microsoft.Xna.Framework
Public Class RNG
    Public Shared Function Free(ByVal Lo As Integer, ByVal Hi As Integer) As Integer
        Static Gen As System.Random = New System.Random()
        Return Gen.Next(Lo, Hi + 1)
    End Function
    Public Shared Gen As System.Random = New System.Random(0)
    Public Shared Function Fixed(ByVal Lo As Integer, ByVal Hi As Integer, Optional ByVal Seed As Integer = 0, Optional ByVal Reset As Boolean = False) As Integer
        If Reset Then Gen = New System.Random(Seed)
        Return Gen.Next(Lo, Hi + 1)
    End Function
    Public Shared Function Free64(ByVal Lo As Int64, ByVal Hi As Int64) As Int64
        Static Gen As System.Random = New System.Random()
        Return Gen.NextDouble(0, 1) * Hi + Gen.NextDouble(0, 1) * Lo
    End Function
    Public Shared GenSingle As System.Random = New System.Random(0)
    Public Shared Function Fixed64(ByVal Lo As Int64, ByVal Hi As Int64, ByVal Seed As Integer, Optional ByVal Reset As Boolean = False) As Int64
        If Reset Then GenSingle = New System.Random(Seed)
        Return GenSingle.NextDouble(0, 1) * Hi + GenSingle.NextDouble(0, 1) * Lo
    End Function
    Public Shared Function ColorXNA() As Microsoft.Xna.Framework.Color
        Return New Microsoft.Xna.Framework.Color(RNG.Free(0, 255), RNG.Free(0, 255), RNG.Free(0, 255))
    End Function
    Public Shared Function ColorXNAfixed(seed As Integer) As Microsoft.Xna.Framework.Color
        Return New Microsoft.Xna.Framework.Color(RNG.Fixed(0, 255, seed, True), RNG.Fixed(0, 255, seed), RNG.Fixed(0, 255, seed))
    End Function
End Class