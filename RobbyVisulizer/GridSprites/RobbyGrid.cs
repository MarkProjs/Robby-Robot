using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace RobbyVisulizer
{
    public class RobbyGrid : Grid
    {   private int _left;
        private int _up;
        public RobbyGrid(RobbyVisulizerGame _game, int topLeft, int topRight) : base(_game, topLeft, topRight)
        {
            Left = topLeft;
            Up = topRight;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gridTexture = _game.Content.Load<Texture2D>("robby");
        }

        public int Left
        {
            get
            {
                return this._left;
            }
            set
            {
                this._left = value;
            }
        }

        public int Up
        {
            get
            {
                return this._up;
            }
            set
            {
                this._up = value;
            }
        }

    }
}