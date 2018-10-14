Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Drawable
    Public Model As Model
    Public Position As Vector3
    Public Sub New(Model As Model, Position As Vector3)
        Me.Model = Model
        Me.Position = Position
    End Sub
    Public Sub Update(GameTime As GameTime, IsActive As Boolean)
        If IsActive Then
            'If Keyboard.GetState().IsKeyDown(Keys.Left) Then Me.Model.
            'If Keyboard.GetState().IsKeyDown(Keys.Right) Then
            'If Keyboard.GetState().IsKeyDown(Keys.Up) Then
            'If Keyboard.GetState().IsKeyDown(Keys.Down) Then
        End If
    End Sub
End Class
