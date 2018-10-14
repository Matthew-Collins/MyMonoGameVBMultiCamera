Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Input

Public Class Camera
    Public Graphics As GraphicsDeviceManager
    Public World As Matrix = Matrix.CreateTranslation(New Vector3(0, 0, 0))
    Public View As Matrix = Matrix.CreateLookAt(New Vector3(0, 0, 10), New Vector3(0, 0, 0), Vector3.UnitY)
    Public Projection As Matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800 / 480.0F, 0.1F, 100.0F)
    Public Sub New(Graphics As GraphicsDeviceManager)
        Me.Graphics = Graphics
    End Sub
    Public Sub Update(GameTime As GameTime, IsActive As Boolean)
        If IsActive Then
            'If Keyboard.GetState().IsKeyDown(Keys.Left) Then Me.View.
            'If Keyboard.GetState().IsKeyDown(Keys.Right) Then
            'If Keyboard.GetState().IsKeyDown(Keys.Up) Then
            'If Keyboard.GetState().IsKeyDown(Keys.Down) Then
        End If
    End Sub
End Class
