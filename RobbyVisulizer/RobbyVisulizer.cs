using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RobbyVisulizer
{
    public class RobbyVisulizer : DrawableGameComponent
    {
        private Texture2D _canTexture, _emtptyTexture, _robyTexture;
        private SpriteBatch _spriteBatch;
        private EmptyGrid _emptyGrid;
        private CanGrid _canGrid;
        private RobbyGrid _robbyGrid;
        private Game _game;
        private string score;
        private string generation;
        private string moves;
        private string canlocation;
        private string[] Grid;
        private string[] robyaction;
        private readonly int _size = 20;
        private int gridsize = 10;
        private static readonly string filePath = "";


        public RobbyVisulizer(Game game) : base(game)
        {
            _game = game;
            FileReader();
            Splitter();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _canTexture = _game.Content.Load<Texture2D>("canGrid");
            _emtptyTexture = _game.Content.Load<Texture2D>("emptyGrid");
            _robyTexture = _game.Content.Load<Texture2D>("roby");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < robyaction.Length; i++)
            {
                switch (robyaction[i])
                {
                    case "0":
                        
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                    break;
                    case "4":
                        break;
                    case "5":
                        break;
                }
            }            
            
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_robyTexture, new Vector2(0,0),Color.Aqua);
            GenerateGrid();
            _spriteBatch.End();
           
        }

        private void GenerateGrid()
        {
            Grid = canlocation.Split("-");
            for (int i = 0; i < Grid.Length; i++)
            {
                for (int j = 0; j < Grid[0].Length; j++)
                {
                    if (Grid[i] == "e")
                    {
                        _emptyGrid = new EmptyGrid(i * _size, j * _size);
                        _spriteBatch.Draw(_emtptyTexture, new Vector2(i * _size, _size * j), Color.Blue);
                    }
                    else
                    {
                        _canGrid = new CanGrid(i * _size, j * _size);
                        _spriteBatch.Draw(_canTexture, new Vector2(i * _size, _size * j), Color.Aquamarine);
                    }
                }
            }
        }

        private void Splitter()
        {
            string rootFile = FileReader();
            string[] tmpFile = rootFile.Split(";");
            score = tmpFile[0];
            moves = tmpFile[1];
            generation = tmpFile[2];
            robyaction = tmpFile[3].Split("-");
            canlocation = tmpFile[4];
        }

        private static string FileReader()
        {
            string chromosomes = String.Empty;
            if (File.Exists(filePath))
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    int lineCounter = 0;

                    while ((chromosomes = file.ReadLine()) != null)
                    {
                        lineCounter++;
                    }

                    file.Close();
                    Console.WriteLine($"File has {lineCounter} lines."); // This is for testing purposes 
                }
            }

            return chromosomes;
        }
    }
}