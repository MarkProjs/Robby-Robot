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
        private EmptyGrid _emptyCan;

        private static readonly string filePath = "";
        private string _score;
        private string _generation;
        private string _totalMoves;
        private string[] _robyaction;

        public RobbyVisulizerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _robby = Robby.CreateRobby(10, 200, 200);
        }

        protected override void Initialize()
        {   
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
            
            
            // The update logic suppose to be there but I can not access the can's data.
            // ContentsOfGrid[,] grid = _robby.GenerateRandomTestGrid();
            
            _emptyCan = new EmptyGrid(this, 0, 0);
            EmptyGrid rowCan = new EmptyGrid(this, 1, 0);
            EmptyGrid rowCan1 = new EmptyGrid(this, 2, 0);
            EmptyGrid colCan = new EmptyGrid(this, 0,1);
            Components.Add(_emptyCan);
            Components.Add(rowCan);
            Components.Add(rowCan1);
            Components.Add(colCan);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }

        private void Splitter(){
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