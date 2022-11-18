using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace RobbyVisulizer
{
    public class RobbyGrid : Grid
    {
        public RobbyGrid(RobbyVisulizerGame _game, int topLeft, int topRight) : base(_game, topLeft, topRight)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gridTexture = _game.Content.Load<Texture2D>("robby");
        }

    }
}