Imports System.Device.Location
Module Location_GPS_mod
    Public Latitude_ As Object
    Public Longitude_ As Object
    Private WithEvents Watcher As New GeoCoordinateWatcher()
    Public Function Lca1()
        Latitude_.Text = ""
        Longitude_.Text = ""

        Watcher.Start()

    End Function
    Private Sub Watcher_PositionChanged(sender As Object, e As GeoPositionChangedEventArgs(Of GeoCoordinate)) Handles Watcher.PositionChanged

        Latitude_.Text = (e.Position.Location.Latitude)
        Longitude_.Text = (e.Position.Location.Longitude)


        Watcher.Stop()
    End Sub
End Module
