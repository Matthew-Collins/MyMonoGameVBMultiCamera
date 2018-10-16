Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Drawable
    Public Model As Model
    Public Position As Vector3
    Public Rotation As Vector3
    Public Sub New(Model As Model, Position As Vector3, Rotation As Vector3)
        Me.Model = Model
        Me.Position = Position
        Me.Rotation = Rotation
    End Sub
    Public Sub Update(GameTime As GameTime, IsActive As Boolean)
        If IsActive Then
            With Keyboard.GetState
                If .IsKeyDown(Keys.Left) AndAlso Not .IsKeyDown(Keys.Space) Then Me.Position.X -= 0.1
                If .IsKeyDown(Keys.Right) AndAlso Not .IsKeyDown(Keys.Space) Then Me.Position.X += 0.1
                If .IsKeyDown(Keys.Up) AndAlso Not .IsKeyDown(Keys.Space) Then Me.Position.Z -= 0.1
                If .IsKeyDown(Keys.Down) AndAlso Not .IsKeyDown(Keys.Space) Then Me.Position.Z += 0.1
            End With
        End If
    End Sub
    Public Function WorldMatrix() As Matrix
        Return Matrix.CreateFromYawPitchRoll(Me.Rotation.X, Me.Rotation.Y, Me.Rotation.Z) * Matrix.CreateTranslation(Me.Position)
    End Function
End Class
