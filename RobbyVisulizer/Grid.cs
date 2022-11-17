using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RobbyVisulizer
{
    public abstract class Grid : DrawableGameComponent
    {
        public int X { get; }
        public int Y { get; }
        protected Texture2D _gridTexture;
        protected SpriteBatch _spriteBatch;
        protected Color _colorTile = Color.White;
        protected RobbyVisulizerGame _game;
        private int size = 50;

        public Grid(RobbyVisulizerGame game, int topLeft, int topRight) : base(game)
        {
            _game = game;
            X = topLeft;
            Y = topRight;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override abstract void LoadContent();

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_gridTexture, new Rectangle(X * size, Y * size, size, size), _colorTile);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}