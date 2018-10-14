Namespace MyMonoGame
    Class Program
        <STAThread>
        Public Shared Sub Main()
            Using Game As New Game1()
                Game.Run()
            End Using
        End Sub
    End Class
End Namespace

