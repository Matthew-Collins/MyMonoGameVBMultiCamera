Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Input

Public Class Camera

    Public Graphics As GraphicsDeviceManager

    Public Position As Vector3
    Public LookAt As Vector3

    Public Projection As Matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800 / 480.0F, 0.1F, 100.0F)

    Public Sub New(Graphics As GraphicsDeviceManager, Position As Vector3, LookAt As Vector3)
        Me.Graphics = Graphics
        Me.Position = Position
        Me.LookAt = LookAt
    End Sub
    Public Sub Update(GameTime As GameTime, IsActive As Boolean)
        If IsActive Then
            With Keyboard.GetState()
                If .IsKeyDown(Keys.Left) AndAlso .IsKeyDown(Keys.Space) Then Me.Position.X -= 0.1
                If .IsKeyDown(Keys.Right) AndAlso .IsKeyDown(Keys.Space) Then Me.Position.X += 0.1
                If .IsKeyDown(Keys.Up) AndAlso .IsKeyDown(Keys.Space) Then Me.Position.Z -= 0.1
                If .IsKeyDown(Keys.Down) AndAlso .IsKeyDown(Keys.Space) Then Me.Position.Z += 0.1
            End With
        End If
    End Sub
    Public Function ViewMatrix() As Matrix
        Return Matrix.CreateLookAt(Me.Position, Me.LookAt, Vector3.UnitY)
    End Function

End Class
