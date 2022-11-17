using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RobbyVisulizer
{
    public class WallGrid : Grid
    {
        public WallGrid(RobbyVisulizerGame _game, int topLeft, int topRight) : base(_game, topLeft, topRight)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gridTexture = _game.Content.Load<Texture2D>("emptyGrid");
        }

    }
}