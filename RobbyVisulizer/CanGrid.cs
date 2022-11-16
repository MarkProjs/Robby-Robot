using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RobbyVisulizer
{
   public class CanGrid: DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private int x;
        private int y;
        private Texture2D _canGrid;

        private RobbyVisulizerGame _game;

        public CanGrid(RobbyVisulizerGame game, int topLeft, int topRight): base(game)
        {
            x = topLeft;
            y = topRight;
            _game = game;
        }

        public override void Initialize() {
            // TODO: Add your initialization logic here
            base.Initialize();
        }
        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _canGrid = _game.Content.Load<Texture2D>("canGrid");
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_canGrid, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }   
    }
}