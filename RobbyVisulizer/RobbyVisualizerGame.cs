using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RobbyTheRobot;

namespace RobbyVisulizer
{
    public class RobbyVisulizerGame : Game
    {
        private Random rnd;
        private int x;
        private int y;
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private SpriteFont _scoreFont;
        private double _scoreNum = 0;
        private SpriteFont _moveFont;
        private int _moveNum = 0;
        private SpriteFont _genFont;
        private int _genNum = 0;

        private IRobbyTheRobot _robby;

        private Grid grid;
        private Grid robby;
        private string _gen;
        private string _robyaction;
        private  int[] _robyActionNum;
        private ContentsOfGrid[,] _gridContent;
        private string[] filePaths = Directory.GetFiles("../Generations/", "*.txt");
        private int fileCount = 0;

        public RobbyVisulizerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _robby = Robby.CreateRobby(1000, 200, 100);
            rnd = new Random();
            

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.ApplyChanges();
            _gridContent = _robby.GenerateRandomTestGrid();
            makeGrid(_gridContent);
            
            robby = new RobbyGrid(this, this.x, this.y);
            Components.Add(robby);
            Splitter(filePaths[fileCount]);
            _robyActionNum = new int[_robyaction.Length];
            for(int i = 0; i < _robyaction.Length; i++){
                _robyActionNum[i] = int.Parse(_robyaction[i].ToString());
            }
            x = rnd.Next(0, 10);
            y = rnd.Next(0, 10);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _scoreFont = Content.Load<SpriteFont>("Score");
            _moveFont = Content.Load<SpriteFont>("Move");
            _genFont = Content.Load<SpriteFont>("Generation");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //TO DO: THE LOGIC PART
            _scoreNum += Robby.ScoreForAllele(_robyActionNum, _gridContent, rnd, ref this.x, ref this.y);
            robby.X = this.x;
            robby.Y = this.y;
            _moveNum++;
            _genNum = int.Parse(_gen);
            if (_moveNum == 200 && fileCount != filePaths.Length)
            {
                _moveNum = 0;
                _scoreNum = 0;
                fileCount++;
                _gridContent = _robby.GenerateRandomTestGrid();
                Splitter(filePaths[fileCount]);
                _robyActionNum = new int[_robyaction.Length];
                for(int i = 0; i < _robyaction.Length; i++){
                    _robyActionNum[i] = int.Parse(_robyaction[i].ToString());
                }
                _genNum = int.Parse(_gen);
                _scoreNum += Robby.ScoreForAllele(_robyActionNum, _gridContent, rnd, ref this.x, ref this.y);
            }
            else if (fileCount == filePaths.Length)
            {
                Exit();
            }
            base.Update(gameTime);
            
            // Components.Add(robby);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_genFont, "Generation: " + _gen, new Vector2(0,520), Color.Black);
            _spriteBatch.DrawString(_moveFont, "Move: " + _moveNum + "/200", new Vector2(0,560), Color.Black);
            _spriteBatch.DrawString(_scoreFont, "Points: " + _scoreNum + "/500", new Vector2(0,600), Color.Black);
            makeGrid(_gridContent);
            robby = new RobbyGrid(this, this.x, this.y);
            Components.Add(robby);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void Splitter(string path)
        {
            string rootFile = FileReader(path);
            string[] tmpFile = rootFile.Split(";");
            _gen = tmpFile[3];
            _robyaction = tmpFile[4];
        }

        private static string FileReader(string path)
        {   
            string chromosomes = "";
            try
            {
                using(var sr = new StreamReader(path))
                {
                    chromosomes = sr.ReadLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        
            return chromosomes;
        }

        private void makeGrid(ContentsOfGrid[,] _gridContent)
        {
            for (int i = 0; i < _gridContent.GetLength(0); i++)
            {
                for (int j = 0; j < _gridContent.GetLength(1); j++)
                {
                    
                    if (_gridContent[i, j] is ContentsOfGrid.Can)
                    {
                        Grid grid = new CanGrid(this, i, j);
                        Components.Add(grid);
                    }
                    else if (_gridContent[i, j] is ContentsOfGrid.Empty)
                    {
                        Grid grid = new EmptyGrid(this, i, j);
                        Components.Add(grid);
                    }
                }
            }

        }
    }
}