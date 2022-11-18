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

        private static readonly string filePath = "";
        private string _gen;
        private string[] _robyaction;
        private  int[] _robyActionNum;
        private ContentsOfGrid[,] _gridContent;


        public RobbyVisulizerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _robby = Robby.CreateRobby(1000, 200, 100);
            rnd = new Random();
            x = rnd.Next(0, 10);
            y = rnd.Next(0, 10);

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.ApplyChanges();
            _gridContent = _robby.GenerateRandomTestGrid();
            // this.grid = new RobbyGrid(this, _robyaction[0,0],_robyaction[]);
            for (int i = 0; i < _gridContent.GetLength(0); i++)
            {
                for (int j = 0; j < _gridContent.GetLength(1); j++)
                {
                    
                    if (_gridContent[i, j] is ContentsOfGrid.Can)
                    {
                        this.grid = new CanGrid(this, i, j);
                        Components.Add(this.grid);
                    }
                    else if (_gridContent[i, j] is ContentsOfGrid.Empty)
                    {
                        this.grid = new EmptyGrid(this, i, j);
                        Components.Add(this.grid);
                    }
                }
            }
            Grid robby = new RobbyGrid(this, this.x, this.y);
            Components.Add(robby);
            // Splitter();
            // _robyActionNum = new int[_robyaction.Length];
            // for(int i = 0; i < _robyaction.Length; i++){
            //     _robyActionNum[i] = Int32.Parse(_robyaction[i]);
            // }
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

            // _moveNum++;
            // _scoreNum = Robby.ScoreForAllele(_robyActionNum, _gridContent, rnd, ref x, ref y);
            // _genNum = Int32.Parse(_gen);
            // Splitter();
            // _robyActionNum = new int[_robyaction.Length];
            // for(int i = 0; i < _robyaction.Length; i++){
            //     _robyActionNum[i] = Int32.Parse(_robyaction[i]);
            // }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_genFont, "Generation: " + _genNum, new Vector2(0,510), Color.Black);
            _spriteBatch.DrawString(_moveFont, "Move: " + _moveNum + "/200", new Vector2(0,530), Color.Black);
            _spriteBatch.DrawString(_scoreFont, "Points: " + _scoreNum + "/500", new Vector2(0,550), Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void Splitter(String path)
        {
            string rootFile = FileReader(path);
            string[] tmpFile = rootFile.Split(";");
            _gen = tmpFile[3];
            _robyaction = tmpFile[4].Split("-");
            
        }

        private static string FileReader(String path)
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