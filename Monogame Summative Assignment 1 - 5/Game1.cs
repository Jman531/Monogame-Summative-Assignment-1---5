using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Summative_Assignment_1___5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        bool justUpdatedScreen = false;

        MouseState mouseState;

        Rectangle window;

        SpriteFont instructionFont;

        enum Screen
        {
            title,
            animation,
            end
        }

        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            instructionFont = Content.Load<SpriteFont>("instruction");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();

            if (screen == Screen.title)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.animation;
                    justUpdatedScreen = true;
                }
            }
            else if (screen == Screen.animation)
            {
                if (mouseState.LeftButton != ButtonState.Pressed)
                    justUpdatedScreen = false;

                if (mouseState.LeftButton == ButtonState.Pressed && !justUpdatedScreen)
                {
                    screen = Screen.end;
                    justUpdatedScreen = true;
                }
            }
            else if (screen == Screen.end)
            {
                if (mouseState.LeftButton != ButtonState.Pressed)
                    justUpdatedScreen = false;

                if (mouseState.LeftButton == ButtonState.Pressed && !justUpdatedScreen)
                    this.Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.title)
            {
                _spriteBatch.DrawString(instructionFont, "Click to start the animation!", new Vector2(0, 0), Color.Black);
            }
            else if (screen == Screen.animation)
            {
                _spriteBatch.DrawString(instructionFont, "Click to end the animation!", new Vector2(0, 0), Color.Black);
            }
            else if (screen == Screen.end)
            {
                _spriteBatch.DrawString(instructionFont, "Click to close the program!", new Vector2(0, 0), Color.Black);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
