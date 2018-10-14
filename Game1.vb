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

            Me.Cameras.Add(New Camera(Me.Graphics))
            Me.Cameras.Add(New Camera(Me.Graphics))
            Me.Cameras.Add(New Camera(Me.Graphics))
            Me.Cameras.Add(New Camera(Me.Graphics))
            Me.ActiveCamera = Me.Cameras(0)

            Me.Content.RootDirectory = "Content"

            Me.IsMouseVisible = True

        End Sub

        Protected Overrides Sub LoadContent()
            SpriteBatch = New SpriteBatch(GraphicsDevice)
            Me.Models.Add(New Drawable(Me.Content.Load(Of Model)("robot"), New Vector3(10, 10, 0)))
            Me.Models.Add(New Drawable(Me.Content.Load(Of Model)("robot"), New Vector3(-10, -10, 0)))
            Me.Models.Add(New Drawable(Me.Content.Load(Of Model)("robot"), New Vector3(20, 20, 0)))
            Me.Models.Add(New Drawable(Me.Content.Load(Of Model)("robot"), New Vector3(-20, -20, 0)))
            Me.ActiveModel = Me.Models(0)
        End Sub

        Protected Overrides Sub Update(ByVal GameTime As GameTime)

            If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed OrElse Keyboard.GetState().IsKeyDown(Keys.Escape) Then Me.Exit()

            If Keyboard.GetState().IsKeyDown(Keys.F5) AndAlso Me.Cameras.Count > 0 Then Me.ActiveCamera = Me.Cameras(0)
            If Keyboard.GetState().IsKeyDown(Keys.F6) AndAlso Me.Cameras.Count > 1 Then Me.ActiveCamera = Me.Cameras(1)
            If Keyboard.GetState().IsKeyDown(Keys.F7) AndAlso Me.Cameras.Count > 2 Then Me.ActiveCamera = Me.Cameras(2)
            If Keyboard.GetState().IsKeyDown(Keys.F8) AndAlso Me.Cameras.Count > 3 Then Me.ActiveCamera = Me.Cameras(3)

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
                DrawModel(Model.Model, Me.ActiveCamera)
            Next
            MyBase.Draw(GameTime)
        End Sub

        Private Sub DrawModel(ByVal Model As Model, Camera As Camera)
            For Each Mesh As ModelMesh In Model.Meshes
                For Each Effect As BasicEffect In Mesh.Effects
                    Effect.World = Camera.World
                    Effect.View = Camera.View
                    Effect.Projection = Camera.Projection
                Next
                Mesh.Draw()
            Next
        End Sub

    End Class
End Namespace
