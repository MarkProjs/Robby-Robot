using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RobbyTheRobot;

namespace RobbyVisulizer
{
    public class RobbyVisulizerGame : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private IRobbyTheRobot _robby;
        private Grid grid;

        private static readonly string filePath = "";
        private string _score;
        private string _generation;
        private string _totalMoves;
        private string[] _robyaction;
        protected GraphicsDeviceManager graphics;


        public RobbyVisulizerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _robby = Robby.CreateRobby(10, 200, 200);
            ContentsOfGrid[,] grid = _robby.GenerateRandomTestGrid();
            

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] is ContentsOfGrid.Can)
                    {
                        this.grid = new CanGrid(this, i, j);
                        Components.Add(this.grid);
                    }
                    else if (grid[i, j] is ContentsOfGrid.Empty)
                    {
                        this.grid = new EmptyGrid(this, i, j);
                        Components.Add(this.grid);
                    }
                }
            }
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }

        private void Splitter()
        {
            string rootFile = FileReader();
            string[] tmpFile = rootFile.Split(";");
            _score = tmpFile[0];
            _totalMoves = tmpFile[1];
            _generation = tmpFile[2];
            _robyaction = tmpFile[3].Split("-");
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