Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Namespace MyMonoGame
    Public Class Game1
        Inherits Game

        Private Graphics As GraphicsDeviceManager
        Private SpriteBatch As SpriteBatch

        Private Cameras As New List(Of Camera)
        Private ActiveCamera As Camera

        Private Models As New List(Of Drawable)
        Private ActiveModel As Drawable

        Public Sub New()

            Me.Graphics = New GraphicsDeviceManager(Me)
            Me.Graphics.HardwareModeSwitch = False
            Me.Graphics.IsFullScreen = True

            Me.Cameras.Add(New Camera(Me.Graphics, New Vector3(0, 0, 10), New Vector3(0, 0, 0)))
            Me.Cameras.Add(New Camera(Me.Graphics, New Vector3(1, 0, 10), New Vector3(0, 0, 0)))
            Me.Cameras.Add(New Camera(Me.Graphics, New Vector3(2, 0, 10), New Vector3(0, 0, 0)))
            Me.Cameras.Add(New Camera(Me.Graphics, New Vector3(3, 0, 10), New Vector3(0, 0, 0)))
            Me.ActiveCamera = Me.Cameras(0)

            Me.Content.RootDirectory = "Content"

            Me.IsMouseVisible = True

        End Sub

        Protected Overrides Sub LoadContent()
            SpriteBatch = New SpriteBatch(GraphicsDevice)
            Dim Model As Model = Me.Content.Load(Of Model)("robot")
            Me.Models.Add(New Drawable(Model, New Vector3(-4.5, 0, 0), New Vector3(0, MathHelper.ToRadians(-90), 0)))
            Me.Models.Add(New Drawable(Model, New Vector3(-1.5, 0, 0), New Vector3(0, MathHelper.ToRadians(-90), 0)))
            Me.Models.Add(New Drawable(Model, New Vector3(1.5, 0, 0), New Vector3(0, MathHelper.ToRadians(-90), 0)))
            Me.Models.Add(New Drawable(Model, New Vector3(4.5, 0, 0), New Vector3(0, MathHelper.ToRadians(-90), 0)))
            Me.ActiveModel = Me.Models(0)
        End Sub

        Protected Overrides Sub Update(ByVal GameTime As GameTime)

            With GamePad.GetState(PlayerIndex.One)
                If .Buttons.Back = ButtonState.Pressed Then Me.Exit()
            End With

            With Keyboard.GetState
                If .IsKeyDown(Keys.Escape) Then Me.Exit()
                If .IsKeyDown(Keys.F1) AndAlso Me.Models.Count > 0 Then Me.ActiveModel = Me.Models(0)
                If .IsKeyDown(Keys.F2) AndAlso Me.Models.Count > 1 Then Me.ActiveModel = Me.Models(1)
                If .IsKeyDown(Keys.F3) AndAlso Me.Models.Count > 2 Then Me.ActiveModel = Me.Models(2)
                If .IsKeyDown(Keys.F4) AndAlso Me.Models.Count > 3 Then Me.ActiveModel = Me.Models(3)
                If .IsKeyDown(Keys.F5) AndAlso Me.Cameras.Count > 0 Then Me.ActiveCamera = Me.Cameras(0)
                If .IsKeyDown(Keys.F6) AndAlso Me.Cameras.Count > 1 Then Me.ActiveCamera = Me.Cameras(1)
                If .IsKeyDown(Keys.F7) AndAlso Me.Cameras.Count > 2 Then Me.ActiveCamera = Me.Cameras(2)
                If .IsKeyDown(Keys.F8) AndAlso Me.Cameras.Count > 3 Then Me.ActiveCamera = Me.Cameras(3)
            End With

            For Each Camera In Me.Cameras
                Camera.Update(GameTime, Camera Is Me.ActiveCamera)
            Next

            For Each Model In Me.Models
                Model.Update(GameTime, Model Is Me.ActiveModel)
            Next

            MyBase.Update(GameTime)
        End Sub

        Protected Overrides Sub Draw(ByVal GameTime As GameTime)
            GraphicsDevice.Clear(Color.CornflowerBlue)
            For Each Model In Me.Models
                DrawModel(Model, Me.ActiveCamera)
            Next
            MyBase.Draw(GameTime)
        End Sub

        Private Sub DrawModel(ByVal Drawable As Drawable, Camera As Camera)
            For Each Mesh As ModelMesh In Drawable.Model.Meshes
                For Each Effect As BasicEffect In Mesh.Effects
                    Effect.EnableDefaultLighting()
                    Effect.World = Drawable.WorldMatrix
                    Effect.View = Camera.ViewMatrix
                    Effect.Projection = Camera.Projection
                Next
                Mesh.Draw()
            Next
        End Sub

    End Class
End Namespace
