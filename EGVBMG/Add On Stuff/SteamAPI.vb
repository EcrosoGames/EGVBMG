Public Class SteamAPI
    Public Shared appID As UInt32 = 0
    Public Shared Initialized As Boolean = False
    Public Shared Sub SteamStart()
        Try
            Steamworks.SteamClient.Init(appID)
            Initialized = True
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Sub
    Public Shared Sub UpdateStats(Name As String)
        If Initialized Then
            Try
                Select Case Name
                    Case "SCORE"
                        Steamworks.SteamUserStats.SetStat("SCORE", 100)
                    Case "ACH1"
                        For Each ach In Steamworks.SteamUserStats.Achievements
                            If ach.Identifier = "ACH1" Then ach.Trigger()
                        Next
                End Select
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End If
    End Sub
End Class