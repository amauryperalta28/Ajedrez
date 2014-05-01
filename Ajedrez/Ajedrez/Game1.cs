using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Ajedrez.DragAndDropTools;
using DragAndDrop;
using Ajedrez.Models;

namespace Ajedrez
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D inGameScreen;

        Tablero board;
        private DragAndDropController<Item> _dragDropController;

        /**Variables para almacenar posicion actual del puntero*/
        MouseState _currentMouse;
        Vector2 _currentMousePosition;          //La posición actual del mouse

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            SetWindowSize(800, 690);
            
        }
        public void SetWindowSize(int x, int y)
        {
            graphics.PreferredBackBufferWidth = x;
            graphics.PreferredBackBufferHeight = y;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _dragDropController = new DragAndDropController<Item>(this, spriteBatch);
            Components.Add(_dragDropController);
            

            // TODO: use this.Content to load your game content here

            board = new Tablero(Content, spriteBatch, this);
            SetupDraggableItems();

            // Se carga la imagen de fondo de madera del juego
            inGameScreen = Content.Load<Texture2D>(@"Images/fondo");
        }
        protected void SetupDraggableItems()
        {

            _dragDropController.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Casilla c1 = board.Casillas[j, i];
                    // Si hay una ficha en la casilla insertala en el dragAndDropController
                    if (c1.FichaContenida != null)
                    {
                        if (c1.FichaContenida.Color == Colores.Black)
                        {
                            Ficha item = new Reina(spriteBatch, Colores.Black, c1.Posicion, Content);
                            _dragDropController.Add(item);
                        }
                        else
                        {
                            //Ficha item = new Black(spriteBatch, c1.FichaContenida.Texture, c1.Posicion);
                            //_dragDropController.Add(item);

                        }
                    }

                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadSate = GamePad.GetState(PlayerIndex.One);

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            // TODO: Add your update logic here

            //get the current state of the mouse (position, buttons, etc.)
            _currentMouse = Mouse.GetState();

            //remember the mouseposition for use in this Update and subsequent Draw
            _currentMousePosition = new Vector2(_currentMouse.X, _currentMouse.Y);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Dibuja el fondo de madera debajo del tablero
                spriteBatch.Draw(inGameScreen, Vector2.Zero, null, Color.White);
                board.draw(spriteBatch, _currentMousePosition, gameTime);

                // Se dibujan las fichas en el tablero
                foreach (var item in _dragDropController.Items)
                { item.Draw(gameTime); }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
